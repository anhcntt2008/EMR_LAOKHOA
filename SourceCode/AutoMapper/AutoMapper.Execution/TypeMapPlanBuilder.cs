using AutoMapper.Configuration;
using AutoMapper.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper.Execution
{
	public class TypeMapPlanBuilder
	{
		private static readonly Expression<Func<AutoMapperMappingException>> CtorExpression = () => new AutoMapperMappingException(null, null, default(TypePair), null, null);

		private static readonly Expression<Action<ResolutionContext>> IncTypeDepthInfo = (ResolutionContext ctxt) => ctxt.IncrementTypeDepth(default(TypePair));

		private static readonly Expression<Action<ResolutionContext>> ValidateMap = (ResolutionContext ctxt) => ctxt.ValidateMap(null);

		private static readonly Expression<Action<ResolutionContext>> DecTypeDepthInfo = (ResolutionContext ctxt) => ctxt.DecrementTypeDepth(default(TypePair));

		private static readonly Expression<Func<ResolutionContext, int>> GetTypeDepthInfo = (ResolutionContext ctxt) => ctxt.GetTypeDepth(default(TypePair));

		private readonly IConfigurationProvider _configurationProvider;

		private readonly ParameterExpression _destination;

		private readonly ParameterExpression _initialDestination;

		private readonly TypeMap _typeMap;

		public ParameterExpression Source
		{
			get;
		}

		public ParameterExpression Context
		{
			get;
		}

		public TypeMapPlanBuilder(IConfigurationProvider configurationProvider, TypeMap typeMap)
		{
			_configurationProvider = configurationProvider;
			_typeMap = typeMap;
			Source = Expression.Parameter(typeMap.SourceType, "src");
			_initialDestination = Expression.Parameter(typeMap.DestinationTypeToUse, "dest");
			Context = Expression.Parameter(typeof(ResolutionContext), "ctxt");
			_destination = Expression.Variable(_initialDestination.Type, "typeMapDestination");
		}

		public LambdaExpression CreateMapperLambda(Stack<TypeMap> typeMapsPath)
		{
			if (_typeMap.SourceType.IsGenericTypeDefinition() || _typeMap.DestinationTypeToUse.IsGenericTypeDefinition())
			{
				return null;
			}
			LambdaExpression lambdaExpression = TypeConverterMapper() ?? _typeMap.Substitution ?? _typeMap.CustomMapper ?? _typeMap.CustomProjection;
			if (lambdaExpression != null)
			{
				return Expression.Lambda(lambdaExpression.ReplaceParameters(Source, _initialDestination, Context), Source, _initialDestination, Context);
			}
			CheckForCycles(typeMapsPath);
			bool constructorMapping;
			Expression destinationFunc = CreateDestinationFunc(out constructorMapping);
			Expression assignmentFunc = CreateAssignmentFunc(destinationFunc, constructorMapping);
			Expression expression = CreateMapperFunc(assignmentFunc);
			ConditionalExpression conditionalExpression = ExpressionBuilder.CheckContext(_typeMap, Context);
			Expression[] expressions = (conditionalExpression == null) ? new Expression[1]
			{
				expression
			} : new Expression[2]
			{
				conditionalExpression,
				expression
			};
			return Expression.Lambda(Expression.Block(new ParameterExpression[1]
			{
				_destination
			}, expressions), Source, _initialDestination, Context);
		}

		private void CheckForCycles(Stack<TypeMap> typeMapsPath)
		{
			if (_typeMap.PreserveReferences)
			{
				return;
			}
			if (typeMapsPath == null)
			{
				typeMapsPath = new Stack<TypeMap>();
			}
			typeMapsPath.Push(_typeMap);
			foreach (var item in from pm in _typeMap.GetPropertyMaps()
				where pm.CanResolveValue()
				let propertyTypeMap = ResolvePropertyTypeMap(pm)
				where propertyTypeMap != null && !propertyTypeMap.PreserveReferences
				select new
				{
					PropertyTypeMap = propertyTypeMap,
					PropertyMap = pm
				})
			{
				if (typeMapsPath.Count % _configurationProvider.MaxExecutionPlanDepth == 0)
				{
					item.PropertyMap.Inline = false;
				}
				TypeMap propertyTypeMap = item.PropertyTypeMap;
				if (typeMapsPath.Contains(propertyTypeMap) && !propertyTypeMap.SourceType.IsValueType())
				{
					SetPreserveReferences(propertyTypeMap);
					foreach (TypeMap item2 in propertyTypeMap.IncludedDerivedTypes.Select(ResolveTypeMap))
					{
						SetPreserveReferences(item2);
					}
				}
				else
				{
					propertyTypeMap.Seal(_configurationProvider, typeMapsPath);
				}
			}
			typeMapsPath.Pop();
		}

		private void SetPreserveReferences(TypeMap propertyTypeMap)
		{
			propertyTypeMap.PreserveReferences = true;
		}

		private TypeMap ResolvePropertyTypeMap(PropertyMap propertyMap)
		{
			if (propertyMap.SourceType == null)
			{
				return null;
			}
			TypePair types = new TypePair(propertyMap.SourceType, propertyMap.DestinationPropertyType);
			return ResolveTypeMap(types);
		}

		private TypeMap ResolveTypeMap(TypePair types)
		{
			TypeMap typeMap = _configurationProvider.ResolveTypeMap(types);
			IObjectMapperInfo objectMapperInfo;
			if (typeMap == null && (objectMapperInfo = (_configurationProvider.FindMapper(types) as IObjectMapperInfo)) != null)
			{
				typeMap = _configurationProvider.ResolveTypeMap(objectMapperInfo.GetAssociatedTypes(types));
			}
			return typeMap;
		}

		private LambdaExpression TypeConverterMapper()
		{
			if (_typeMap.TypeConverterType == null)
			{
				return null;
			}
			Type type2;
			if (_typeMap.TypeConverterType.IsGenericTypeDefinition())
			{
				Type type = _typeMap.SourceType.IsGenericType() ? _typeMap.SourceType.GetTypeInfo().GenericTypeArguments[0] : _typeMap.DestinationTypeToUse.GetTypeInfo().GenericTypeArguments[0];
				type2 = _typeMap.TypeConverterType.MakeGenericType(type);
			}
			else
			{
				type2 = _typeMap.TypeConverterType;
			}
			Type type3 = typeof(ITypeConverter<, >).MakeGenericType(_typeMap.SourceType, _typeMap.DestinationTypeToUse);
			return Expression.Lambda(Expression.Call(ExpressionFactory.ToType(CreateInstance(type2), type3), type3.GetDeclaredMethod("Convert"), Source, _initialDestination, Context), Source, _initialDestination, Context);
		}

		private Expression CreateDestinationFunc(out bool constructorMapping)
		{
			Expression expression = ExpressionFactory.ToType(CreateNewDestinationFunc(out constructorMapping), _typeMap.DestinationTypeToUse);
			Expression right = _typeMap.DestinationTypeToUse.IsValueType() ? expression : Expression.Coalesce(_initialDestination, expression);
			Expression expression2 = Expression.Assign(_destination, right);
			if (_typeMap.PreserveReferences)
			{
				ParameterExpression parameterExpression = Expression.Variable(typeof(object), "dest");
				MethodInfo declaredMethod = Context.Type.GetDeclaredMethod("CacheDestination");
				MethodCallExpression ifTrue = Expression.Call(Context, declaredMethod, Source, Expression.Constant(_destination.Type), _destination);
				ConditionalExpression conditionalExpression = Expression.IfThen(Expression.NotEqual(Source, Expression.Constant(null)), ifTrue);
				expression2 = Expression.Block(new ParameterExpression[1]
				{
					parameterExpression
				}, Expression.Assign(parameterExpression, expression2), conditionalExpression, parameterExpression);
			}
			return expression2;
		}

		private Expression CreateAssignmentFunc(Expression destinationFunc, bool constructorMapping)
		{
			List<Expression> list = new List<Expression>();
			foreach (PropertyMap item in from pm in _typeMap.GetPropertyMaps()
				where pm.CanResolveValue()
				select pm)
			{
				Expression expression = TryPropertyMap(item);
				if (constructorMapping && _typeMap.ConstructorParameterMatches(item.DestinationProperty.Name))
				{
					expression = _initialDestination.IfNullElse(Expression.Empty(), expression);
				}
				list.Add(expression);
			}
			foreach (PathMap item2 in _typeMap.PathMaps.Where((PathMap pm) => !pm.Ignored))
			{
				list.Add(HandlePath(item2));
			}
			foreach (LambdaExpression beforeMapAction in _typeMap.BeforeMapActions)
			{
				list.Insert(0, beforeMapAction.ReplaceParameters(Source, _destination, Context));
			}
			list.Insert(0, destinationFunc);
			if (_typeMap.MaxDepth > 0)
			{
				list.Insert(0, Expression.Call(Context, ((MethodCallExpression)IncTypeDepthInfo.Body).Method, Expression.Constant(_typeMap.Types)));
			}
			if (_typeMap.IsConventionMap && _typeMap.Profile.ValidateInlineMaps)
			{
				list.Insert(0, Expression.Call(Context, ((MethodCallExpression)ValidateMap.Body).Method, Expression.Constant(_typeMap)));
			}
			list.AddRange(_typeMap.AfterMapActions.Select((LambdaExpression afterMapAction) => afterMapAction.ReplaceParameters(Source, _destination, Context)));
			if (_typeMap.MaxDepth > 0)
			{
				list.Add(Expression.Call(Context, ((MethodCallExpression)DecTypeDepthInfo.Body).Method, Expression.Constant(_typeMap.Types)));
			}
			list.Add(_destination);
			return Expression.Block(list);
		}

		private Expression HandlePath(PathMap pathMap)
		{
			Expression expression = ((MemberExpression)pathMap.DestinationExpression.ConvertReplaceParameters(_destination)).Expression;
			Expression arg = CreateInnerObjects(expression);
			Expression arg2 = CreatePropertyMapFunc(new PropertyMap(pathMap), expression);
			return Expression.Block(arg, arg2);
		}

		private Expression CreateInnerObjects(Expression destination)
		{
			return Expression.Block(destination.GetMembers().Select(NullCheck).Reverse()
				.Concat(new DefaultExpression[1]
				{
					Expression.Empty()
				}));
		}

		private Expression NullCheck(MemberExpression memberExpression)
		{
			Expression setter = ExpressionFactory.GetSetter(memberExpression);
			Expression then = (setter == null) ? ((Expression)Expression.Throw(Expression.Constant(new NullReferenceException($"{memberExpression} cannot be null because it's used by ForPath.")))) : ((Expression)Expression.Assign(setter, DelegateFactory.GenerateConstructorExpression(memberExpression.Type)));
			return memberExpression.IfNullElse(then);
		}

		private Expression CreateMapperFunc(Expression assignmentFunc)
		{
			Expression expression = assignmentFunc;
			if (_typeMap.Condition != null)
			{
				expression = Expression.Condition(_typeMap.Condition.Body, expression, Expression.Default(_typeMap.DestinationTypeToUse));
			}
			if (_typeMap.MaxDepth > 0)
			{
				expression = Expression.Condition(Expression.LessThanOrEqual(Expression.Call(Context, ((MethodCallExpression)GetTypeDepthInfo.Body).Method, Expression.Constant(_typeMap.Types)), Expression.Constant(_typeMap.MaxDepth)), expression, Expression.Default(_typeMap.DestinationTypeToUse));
			}
			if (_typeMap.Profile.AllowNullDestinationValues)
			{
				expression = Source.IfNullElse(Expression.Default(_typeMap.DestinationTypeToUse), expression);
			}
			return CheckReferencesCache(expression);
		}

		private Expression CheckReferencesCache(Expression valueBuilder)
		{
			if (!_typeMap.PreserveReferences)
			{
				return valueBuilder;
			}
			ParameterExpression parameterExpression = Expression.Variable(_typeMap.DestinationTypeToUse, "cachedDestination");
			MethodInfo declaredMethod = Context.Type.GetDeclaredMethod("GetDestination");
			BinaryExpression left = Expression.Assign(parameterExpression, ExpressionFactory.ToType(Expression.Call(Context, declaredMethod, Source, Expression.Constant(_destination.Type)), _destination.Type));
			ConditionalExpression conditionalExpression = Expression.Condition(Expression.AndAlso(Expression.NotEqual(Source, Expression.Constant(null)), Expression.NotEqual(left, Expression.Constant(null))), parameterExpression, valueBuilder);
			return Expression.Block(new ParameterExpression[1]
			{
				parameterExpression
			}, conditionalExpression);
		}

		private Expression CreateNewDestinationFunc(out bool constructorMapping)
		{
			constructorMapping = false;
			if (_typeMap.DestinationCtor != null)
			{
				return _typeMap.DestinationCtor.ReplaceParameters(Source, Context);
			}
			if (_typeMap.ConstructDestinationUsingServiceLocator)
			{
				return CreateInstance(_typeMap.DestinationTypeToUse);
			}
			if (_typeMap.ConstructorMap?.CanResolve ?? false)
			{
				constructorMapping = true;
				return CreateNewDestinationExpression(_typeMap.ConstructorMap);
			}
			if (_typeMap.DestinationTypeToUse.IsInterface())
			{
				return Expression.Invoke(Expression.Call(null, typeof(DelegateFactory).GetDeclaredMethod("CreateCtor", new Type[1]
				{
					typeof(Type)
				}), Expression.Call(null, typeof(ProxyGenerator).GetDeclaredMethod("GetProxyType"), Expression.Constant(_typeMap.DestinationTypeToUse))));
			}
			return DelegateFactory.GenerateConstructorExpression(_typeMap.DestinationTypeToUse);
		}

		private Expression CreateNewDestinationExpression(ConstructorMap constructorMap)
		{
			IEnumerable<Expression> second = constructorMap.CtorParams.Select(CreateConstructorParameterExpression);
			ParameterExpression[] array = (from parameter in constructorMap.Ctor.GetParameters()
				select Expression.Variable(parameter.ParameterType, parameter.Name)).ToArray();
			Expression[] expressions = ((IEnumerable<ParameterExpression>)array).Zip(second, (Func<ParameterExpression, Expression, Expression>)((ParameterExpression variable, Expression expression) => Expression.Assign(variable, ExpressionFactory.ToType(expression, variable.Type)))).Concat(new Expression[1]
			{
				CheckReferencesCache(Expression.New(constructorMap.Ctor, array))
			}).ToArray();
			return Expression.Block(array, expressions);
		}

		private Expression CreateConstructorParameterExpression(ConstructorParameterMap ctorParamMap)
		{
			Expression expression = ResolveSource(ctorParamMap);
			Type type = expression.Type;
			ParameterExpression parameterExpression = Expression.Variable(type, "resolvedValue");
			return Expression.Block(new ParameterExpression[1]
			{
				parameterExpression
			}, Expression.Assign(parameterExpression, expression), ExpressionBuilder.MapExpression(_configurationProvider, _typeMap.Profile, new TypePair(type, ctorParamMap.DestinationType), parameterExpression, Context));
		}

		private Expression ResolveSource(ConstructorParameterMap ctorParamMap)
		{
			if (ctorParamMap.CustomExpression != null)
			{
				return ctorParamMap.CustomExpression.ConvertReplaceParameters(Source).NullCheck(ctorParamMap.DestinationType);
			}
			if (ctorParamMap.CustomValueResolver != null)
			{
				return ctorParamMap.CustomValueResolver.ConvertReplaceParameters(Source, Context);
			}
			if (ctorParamMap.Parameter.IsOptional)
			{
				ctorParamMap.DefaultValue = true;
				return Expression.Constant(ctorParamMap.Parameter.GetDefaultValue(), ctorParamMap.Parameter.ParameterType);
			}
			return Chain(ctorParamMap.SourceMembers, ctorParamMap.DestinationType);
		}

		private Expression TryPropertyMap(PropertyMap propertyMap)
		{
			Expression expression = CreatePropertyMapFunc(propertyMap, _destination);
			if (expression == null)
			{
				return null;
			}
			ParameterExpression parameterExpression = Expression.Parameter(typeof(Exception), "ex");
			ConstructorInfo constructor = ((NewExpression)CtorExpression.Body).Constructor;
			return Expression.TryCatch(Expression.Block(typeof(void), expression), Expression.MakeCatchBlock(typeof(Exception), parameterExpression, Expression.Throw(Expression.New(constructor, Expression.Constant("Error mapping types."), parameterExpression, Expression.Constant(propertyMap.TypeMap.Types), Expression.Constant(propertyMap.TypeMap), Expression.Constant(propertyMap))), null));
		}

		private Expression CreatePropertyMapFunc(PropertyMap propertyMap, Expression destination)
		{
			MemberExpression memberExpression = Expression.MakeMemberAccess(destination, propertyMap.DestinationProperty);
			PropertyInfo propertyInfo;
			Expression expression = ((object)(propertyInfo = (propertyMap.DestinationProperty as PropertyInfo)) == null || !(propertyInfo.GetGetMethod(nonPublic: true) == null)) ? ((Expression)memberExpression) : ((Expression)Expression.Default(propertyMap.DestinationPropertyType));
			Expression destinationParameter = propertyMap.UseDestinationValue ? expression : ((!_initialDestination.Type.IsValueType()) ? ((Expression)Expression.Condition(Expression.Equal(_initialDestination, Expression.Constant(null)), Expression.Default(propertyMap.DestinationPropertyType), expression)) : ((Expression)Expression.Default(propertyMap.DestinationPropertyType)));
			Expression expression2 = BuildValueResolverFunc(propertyMap, expression);
			ParameterExpression parameterExpression = Expression.Variable(expression2.Type, "resolvedValue");
			BinaryExpression binaryExpression = Expression.Assign(parameterExpression, expression2);
			expression2 = parameterExpression;
			TypePair typePair = new TypePair(expression2.Type, propertyMap.DestinationPropertyType);
			expression2 = (propertyMap.Inline ? ExpressionBuilder.MapExpression(_configurationProvider, _typeMap.Profile, typePair, expression2, Context, propertyMap, destinationParameter) : ExpressionBuilder.ContextMap(typePair, expression2, Context, destinationParameter));
			expression2 = (from vt in propertyMap.ValueTransformers.Concat(_typeMap.ValueTransformers).Concat(_typeMap.Profile.ValueTransformers)
				where vt.IsMatch(propertyMap)
				select vt).Aggregate(expression2, (Expression current, ValueTransformerConfiguration vtConfig) => ExpressionFactory.ToType(ExpressionFactory.ReplaceParameters(vtConfig.TransformerExpression, ExpressionFactory.ToType(current, vtConfig.ValueType)), propertyMap.DestinationPropertyType));
			ParameterExpression parameterExpression2;
			Expression expression3;
			if (expression2 == parameterExpression)
			{
				parameterExpression2 = parameterExpression;
				expression3 = binaryExpression;
			}
			else
			{
				parameterExpression2 = Expression.Variable(expression2.Type, "propertyValue");
				expression3 = Expression.Assign(parameterExpression2, expression2);
			}
			Expression expression4 = (propertyMap.DestinationProperty is FieldInfo) ? ((propertyMap.SourceType != propertyMap.DestinationPropertyType) ? Expression.Assign(memberExpression, ExpressionFactory.ToType(parameterExpression2, propertyMap.DestinationPropertyType)) : Expression.Assign(expression, parameterExpression2)) : ((!(((PropertyInfo)propertyMap.DestinationProperty).GetSetMethod(nonPublic: true) == null)) ? ((Expression)Expression.Assign(memberExpression, ExpressionFactory.ToType(parameterExpression2, propertyMap.DestinationPropertyType))) : ((Expression)parameterExpression2));
			if (propertyMap.Condition != null)
			{
				expression4 = Expression.IfThen(propertyMap.Condition.ConvertReplaceParameters(Source, _destination, ExpressionFactory.ToType(parameterExpression2, propertyMap.Condition.Parameters[2].Type), ExpressionFactory.ToType(expression, propertyMap.Condition.Parameters[2].Type), Context), expression4);
			}
			expression4 = Expression.Block(new Expression[3]
			{
				binaryExpression,
				expression3,
				expression4
			}.Distinct());
			if (propertyMap.PreCondition != null)
			{
				expression4 = Expression.IfThen(propertyMap.PreCondition.ConvertReplaceParameters(Source, Context), expression4);
			}
			return Expression.Block(new ParameterExpression[2]
			{
				parameterExpression,
				parameterExpression2
			}.Distinct(), expression4);
		}

		private Expression BuildValueResolverFunc(PropertyMap propertyMap, Expression destValueExpr)
		{
			Type destinationPropertyType = propertyMap.DestinationPropertyType;
			ValueResolverConfiguration valueResolverConfig = propertyMap.ValueResolverConfig;
			TypeMap typeMap = propertyMap.TypeMap;
			Expression expression;
			if (valueResolverConfig != null)
			{
				expression = ExpressionFactory.ToType(BuildResolveCall(destValueExpr, valueResolverConfig), destinationPropertyType);
			}
			else if (propertyMap.CustomResolver != null)
			{
				expression = propertyMap.CustomResolver.ConvertReplaceParameters(Source, _destination, destValueExpr, Context);
			}
			else if (propertyMap.CustomExpression != null)
			{
				Expression expression2 = propertyMap.CustomExpression.ReplaceParameters(Source).NullCheck(destinationPropertyType);
				Type type = (destinationPropertyType.IsNullableType() && destinationPropertyType.GetTypeOfNullable() == expression2.Type) ? destinationPropertyType : expression2.Type;
				expression = Expression.TryCatch(ExpressionFactory.ToType(expression2, type), Expression.Catch(typeof(NullReferenceException), Expression.Default(type)), Expression.Catch(typeof(ArgumentNullException), Expression.Default(type)));
			}
			else if (!propertyMap.SourceMembers.Any() || !(propertyMap.SourceType != null))
			{
				expression = ((!(propertyMap.SourceMember != null)) ? ((Expression)Expression.Throw(Expression.Constant(new Exception("I done blowed up")))) : ((Expression)Expression.MakeMemberAccess(Source, propertyMap.SourceMember)));
			}
			else
			{
				MemberInfo memberInfo = propertyMap.SourceMembers.Last();
				PropertyInfo propertyInfo;
				expression = (((object)(propertyInfo = (memberInfo as PropertyInfo)) == null || !(propertyInfo.GetGetMethod(nonPublic: true) == null)) ? Chain(propertyMap.SourceMembers, destinationPropertyType) : Expression.Default(memberInfo.GetMemberType()));
			}
			if (propertyMap.NullSubstitute != null)
			{
				ConstantExpression expression3 = Expression.Constant(propertyMap.NullSubstitute);
				expression = Expression.Coalesce(expression, ExpressionFactory.ToType(expression3, expression.Type));
			}
			else if (!typeMap.Profile.AllowNullDestinationValues)
			{
				Type type2 = propertyMap.SourceType ?? destinationPropertyType;
				if (!type2.IsAbstract() && type2.IsClass())
				{
					expression = Expression.Coalesce(expression, ExpressionFactory.ToType(DelegateFactory.GenerateNonNullConstructorExpression(type2), propertyMap.SourceType));
				}
			}
			return expression;
		}

		private Expression Chain(IEnumerable<MemberInfo> members, Type destinationType)
		{
			return members.Aggregate<MemberInfo, Expression>(Source, delegate(Expression inner, MemberInfo getter)
			{
				MethodInfo method;
				if ((object)(method = (getter as MethodInfo)) == null)
				{
					return Expression.MakeMemberAccess(getter.IsStatic() ? null : inner, getter);
				}
				return (!getter.IsStatic()) ? Expression.Call(inner, method) : Expression.Call(null, method, inner);
			}).NullCheck(destinationType);
		}

		private Expression CreateInstance(Type type)
		{
			return Expression.Call(Expression.Property(Context, "Options"), "CreateInstance", new Type[1]
			{
				type
			});
		}

		private Expression BuildResolveCall(Expression destValueExpr, ValueResolverConfiguration valueResolverConfig)
		{
			Expression expression = (valueResolverConfig.Instance != null) ? Expression.Constant(valueResolverConfig.Instance) : CreateInstance(valueResolverConfig.ConcreteType);
			Expression expression2 = valueResolverConfig.SourceMember?.ReplaceParameters(Source) ?? ((valueResolverConfig.SourceMemberName != null) ? Expression.PropertyOrField(Source, valueResolverConfig.SourceMemberName) : null);
			Type interfaceType = valueResolverConfig.InterfaceType;
			IEnumerable<Expression> arguments = new Expression[4]
			{
				Source,
				_destination,
				expression2,
				destValueExpr
			}.Where((Expression p) => p != null).Zip(interfaceType.GetGenericArguments(), ExpressionFactory.ToType).Concat(new ParameterExpression[1]
			{
				Context
			});
			return Expression.Call(ExpressionFactory.ToType(expression, interfaceType), interfaceType.GetDeclaredMethod("Resolve"), arguments);
		}
	}
}
