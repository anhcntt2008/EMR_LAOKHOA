using AutoMapper.Configuration;
using AutoMapper.Execution;
using AutoMapper.Internal;
using AutoMapper.QueryableExtensions.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace AutoMapper.QueryableExtensions
{
	public class ExpressionBuilder : IExpressionBuilder
	{
		private class NewFinderVisitor : ExpressionVisitor
		{
			public NewExpression NewExpression
			{
				get;
				private set;
			}

			protected override Expression VisitNew(NewExpression node)
			{
				NewExpression = node;
				return base.VisitNew(node);
			}
		}

		private class NullSubstitutionConversionVisitor : ExpressionVisitor
		{
			private readonly Expression _newParameter;

			private readonly object _nullSubstitute;

			public NullSubstitutionConversionVisitor(Expression newParameter, object nullSubstitute)
			{
				_newParameter = newParameter;
				_nullSubstitute = nullSubstitute;
			}

			protected override Expression VisitMember(MemberExpression node)
			{
				if (node != _newParameter)
				{
					return node;
				}
				return NullCheck(node);
			}

			private Expression NullCheck(Expression input)
			{
				Type typeOfNullable = input.Type.GetTypeOfNullable();
				Expression ifFalse = ExpressionFactory.ToType(Expression.Constant(_nullSubstitute), typeOfNullable);
				return Expression.Condition(Expression.Property(input, "HasValue"), Expression.Property(input, "Value"), ifFalse, typeOfNullable);
			}
		}

		internal class ConstantExpressionReplacementVisitor : ExpressionVisitor
		{
			private readonly IDictionary<string, object> _paramValues;

			public ConstantExpressionReplacementVisitor(IDictionary<string, object> paramValues)
			{
				_paramValues = paramValues;
			}

			protected override Expression VisitMember(MemberExpression node)
			{
				if (!node.Member.DeclaringType.Has<CompilerGeneratedAttribute>())
				{
					return base.VisitMember(node);
				}
				string name = node.Member.Name;
				if (!_paramValues.TryGetValue(name, out object value) && (!name.StartsWith("$VB$Local_", StringComparison.Ordinal) || !_paramValues.TryGetValue(name.Substring("$VB$Local_".Length), out value)))
				{
					return base.VisitMember(node);
				}
				return Expression.Convert(Expression.Constant(value), node.Member.GetMemberType());
			}
		}

		internal class NullsafeQueryRewriter : ExpressionVisitor
		{
			private static readonly LockingConcurrentDictionary<Type, Expression> Cache = new LockingConcurrentDictionary<Type, Expression>(NodeFallback);

			protected override Expression VisitMember(MemberExpression node)
			{
				if (node?.Expression == null)
				{
					return base.VisitMember(node);
				}
				return MakeNullsafe(node, node.Expression);
			}

			protected override Expression VisitMethodCall(MethodCallExpression node)
			{
				if (node?.Object == null)
				{
					return base.VisitMethodCall(node);
				}
				return MakeNullsafe(node, node.Object);
			}

			private Expression MakeNullsafe(Expression node, Expression value)
			{
				Expression orAdd = Cache.GetOrAdd(node.Type);
				return Expression.Condition(Expression.NotEqual(Visit(value), Expression.Default(value.Type)), (orAdd.NodeType != ExpressionType.Default) ? Expression.Coalesce(node, orAdd) : node, orAdd);
			}

			private static Expression NodeFallback(Type type)
			{
				if (type.GetIsConstructedGenericType() && type.GetTypeInfo().GenericTypeArguments.Length == 1)
				{
					return GenericCollectionFallback(typeof(List<>), type) ?? GenericCollectionFallback(typeof(HashSet<>), type) ?? Expression.Default(type);
				}
				if (type.IsArray)
				{
					return Expression.NewArrayInit(type.GetElementType());
				}
				return Expression.Default(type);
			}

			private static Expression GenericCollectionFallback(Type collectionDefinition, Type type)
			{
				Type type2 = collectionDefinition.MakeGenericType(type.GetTypeInfo().GenericTypeArguments);
				if (!type.GetTypeInfo().IsAssignableFrom(type2.GetTypeInfo()))
				{
					return null;
				}
				return Expression.Convert(Expression.New(type2), type);
			}
		}

		public class FirstPassLetPropertyMaps : LetPropertyMaps
		{
			private class ReplaceMemberAccessesVisitor : ExpressionVisitor
			{
				private Expression _oldObject;

				private Expression _newObject;

				public ReplaceMemberAccessesVisitor(Expression oldObject, Expression newObject)
				{
					_oldObject = oldObject;
					_newObject = newObject;
				}

				protected override Expression VisitMember(MemberExpression node)
				{
					if (node.Expression != _oldObject)
					{
						return base.VisitMember(node);
					}
					return Expression.MakeMemberAccess(_newObject, _newObject.Type.GetFieldOrProperty(node.Member.Name));
				}
			}

			private Stack<PropertyMap> _currentPath = new Stack<PropertyMap>();

			private List<PropertyPath> _savedPaths = new List<PropertyPath>();

			private IConfigurationProvider _configurationProvider;

			public override int Count => _savedPaths.Count;

			public FirstPassLetPropertyMaps(IConfigurationProvider configurationProvider)
			{
				_configurationProvider = configurationProvider;
			}

			public override Expression GetSubQueryMarker()
			{
				PropertyMap propertyMap = _currentPath.Peek();
				LambdaExpression mapFrom = propertyMap.CustomExpression;
				if (!IsSubQuery() || _configurationProvider.ResolveTypeMap(propertyMap.SourceType, propertyMap.DestinationPropertyType) == null)
				{
					return null;
				}
				ParameterExpression parameterExpression = Expression.Parameter(mapFrom.Body.Type, "marker" + propertyMap.DestinationProperty.Name);
				_savedPaths.Add(new PropertyPath(_currentPath.Reverse().ToArray(), parameterExpression));
				return parameterExpression;
				bool IsSubQuery()
				{
					MethodCallExpression methodCallExpression;
					if ((methodCallExpression = (mapFrom.Body as MethodCallExpression)) == null)
					{
						return false;
					}
					MethodInfo method = methodCallExpression.Method;
					if (method.IsStatic)
					{
						return method.DeclaringType == typeof(Enumerable);
					}
					return false;
				}
			}

			public override void Push(PropertyMap propertyMap)
			{
				_currentPath.Push(propertyMap);
			}

			public override void Pop()
			{
				_currentPath.Pop();
			}

			public override LetPropertyMaps New()
			{
				return new FirstPassLetPropertyMaps(_configurationProvider);
			}

			public override QueryExpressions GetSubQueryExpression(ExpressionBuilder builder, Expression projection, TypeMap typeMap, ExpressionRequest request, Expression instanceParameter, IDictionary<ExpressionRequest, int> typePairCount)
			{
				var letMapInfos = _savedPaths.Select((PropertyPath path) => new
				{
					MapFrom = path.Last.CustomExpression,
					MapFromSource = (from pm in path.PropertyMaps.Take(path.PropertyMaps.Length - 1)
						select pm.SourceMember).MemberAccesses(instanceParameter),
					Property = new PropertyDescription(string.Join("_", path.PropertyMaps.Select((PropertyMap pm) => pm.DestinationProperty.Name)), path.Last.SourceType),
					Marker = path.Marker
				}).ToArray();
				IEnumerable<PropertyDescription> additionalProperties = letMapInfos.Select(m => m.Property);
				Type letType = ProxyGenerator.GetSimilarType(request.SourceType, additionalProperties);
				TypeMapFactory typeMapFactory = new TypeMapFactory();
				TypeMap firstTypeMap;
				lock (_configurationProvider)
				{
					firstTypeMap = typeMapFactory.CreateTypeMap(request.SourceType, letType, typeMap.Profile);
				}
				ParameterExpression secondParameter = Expression.Parameter(letType, "dto");
				ReplaceSubQueries();
				return new QueryExpressions(builder.CreateMapExpressionCore(request, instanceParameter, typePairCount, firstTypeMap, LetPropertyMaps.Default), projection, secondParameter);
				void ReplaceSubQueries()
				{
					var array = letMapInfos;
					foreach (var anon in array)
					{
						PropertyInfo declaredProperty = letType.GetDeclaredProperty(anon.Property.Name);
						firstTypeMap.FindOrCreatePropertyMapFor(declaredProperty).CustomExpression = Expression.Lambda(anon.MapFrom.ReplaceParameters(anon.MapFromSource), (ParameterExpression)instanceParameter);
						projection = projection.Replace(anon.Marker, Expression.MakeMemberAccess(secondParameter, declaredProperty));
					}
					projection = new ReplaceMemberAccessesVisitor(instanceParameter, secondParameter).Visit(projection);
				}
			}
		}

		private static readonly IExpressionResultConverter[] ExpressionResultConverters = new IExpressionResultConverter[2]
		{
			new MemberResolverExpressionResultConverter(),
			new MemberGetterExpressionResultConverter()
		};

		private static readonly IExpressionBinder[] Binders = new IExpressionBinder[7]
		{
			new CustomProjectionExpressionBinder(),
			new NullableDestinationExpressionBinder(),
			new NullableSourceExpressionBinder(),
			new AssignableExpressionBinder(),
			new EnumerableExpressionBinder(),
			new MappedTypeExpressionBinder(),
			new StringExpressionBinder()
		};

		private readonly LockingConcurrentDictionary<ExpressionRequest, LambdaExpression[]> _expressionCache;

		private readonly IConfigurationProvider _configurationProvider;

		public ExpressionBuilder(IConfigurationProvider configurationProvider)
		{
			_configurationProvider = configurationProvider;
			_expressionCache = new LockingConcurrentDictionary<ExpressionRequest, LambdaExpression[]>(CreateMapExpression);
		}

		public LambdaExpression[] GetMapExpression(Type sourceType, Type destinationType, IDictionary<string, object> parameters, MemberInfo[] membersToExpand)
		{
			if (sourceType == null)
			{
				throw new ArgumentNullException("sourceType");
			}
			if (destinationType == null)
			{
				throw new ArgumentNullException("destinationType");
			}
			if (parameters == null)
			{
				throw new ArgumentNullException("parameters");
			}
			if (membersToExpand == null)
			{
				throw new ArgumentNullException("membersToExpand");
			}
			return (from e in _expressionCache.GetOrAdd(new ExpressionRequest(sourceType, destinationType, membersToExpand, null))
				select Prepare(e, parameters)).Cast<LambdaExpression>().ToArray();
		}

		private Expression Prepare(Expression cachedExpression, IDictionary<string, object> parameters)
		{
			Expression expression = (!parameters.Any()) ? cachedExpression : new ConstantExpressionReplacementVisitor(parameters).Visit(cachedExpression);
			if (_configurationProvider.EnableNullPropagationForQueryMapping)
			{
				return new NullsafeQueryRewriter().Visit(expression);
			}
			return expression;
		}

		private LambdaExpression[] CreateMapExpression(ExpressionRequest request)
		{
			return CreateMapExpression(request, new Dictionary<ExpressionRequest, int>(), new FirstPassLetPropertyMaps(_configurationProvider));
		}

		public LambdaExpression[] CreateMapExpression(ExpressionRequest request, IDictionary<ExpressionRequest, int> typePairCount, LetPropertyMaps letPropertyMaps)
		{
			ParameterExpression parameterExpression = Expression.Parameter(request.SourceType, "dto");
			TypeMap typeMap;
			QueryExpressions queryExpressions = new QueryExpressions(CreateMapExpressionCore(request, parameterExpression, typePairCount, letPropertyMaps, out typeMap));
			if (letPropertyMaps.Count > 0)
			{
				queryExpressions = letPropertyMaps.GetSubQueryExpression(this, queryExpressions.First, typeMap, request, parameterExpression, typePairCount);
			}
			if (queryExpressions.First == null)
			{
				return null;
			}
			LambdaExpression lambdaExpression = Expression.Lambda(queryExpressions.First, parameterExpression);
			if (queryExpressions.Second != null)
			{
				return new LambdaExpression[2]
				{
					lambdaExpression,
					Expression.Lambda(queryExpressions.Second, queryExpressions.SecondParameter)
				};
			}
			return new LambdaExpression[1]
			{
				lambdaExpression
			};
		}

		public Expression CreateMapExpression(ExpressionRequest request, Expression instanceParameter, IDictionary<ExpressionRequest, int> typePairCount, LetPropertyMaps letPropertyMaps)
		{
			TypeMap typeMap;
			return CreateMapExpressionCore(request, instanceParameter, typePairCount, letPropertyMaps, out typeMap);
		}

		private Expression CreateMapExpressionCore(ExpressionRequest request, Expression instanceParameter, IDictionary<ExpressionRequest, int> typePairCount, LetPropertyMaps letPropertyMaps, out TypeMap typeMap)
		{
			typeMap = _configurationProvider.ResolveTypeMap(request.SourceType, request.DestinationType);
			if (typeMap == null)
			{
				throw QueryMapperHelper.MissingMapException(request.SourceType, request.DestinationType);
			}
			if (typeMap.CustomProjection != null)
			{
				return typeMap.CustomProjection.ReplaceParameters(instanceParameter);
			}
			return CreateMapExpressionCore(request, instanceParameter, typePairCount, typeMap, letPropertyMaps);
		}

		private Expression CreateMapExpressionCore(ExpressionRequest request, Expression instanceParameter, IDictionary<ExpressionRequest, int> typePairCount, TypeMap typeMap, LetPropertyMaps letPropertyMaps)
		{
			List<MemberBinding> list = new List<MemberBinding>();
			int depth = GetDepth(request, typePairCount);
			if (typeMap.MaxDepth > 0 && depth >= typeMap.MaxDepth)
			{
				if (typeMap.Profile.AllowNullDestinationValues)
				{
					return null;
				}
			}
			else
			{
				list = CreateMemberBindings(request, typeMap, instanceParameter, typePairCount, letPropertyMaps);
			}
			Expression expression = DestinationConstructorExpression(typeMap, instanceParameter);
			if (instanceParameter is ParameterExpression)
			{
				expression = ((LambdaExpression)expression).ReplaceParameters(instanceParameter);
			}
			NewFinderVisitor newFinderVisitor = new NewFinderVisitor();
			newFinderVisitor.Visit(expression);
			return Expression.MemberInit(newFinderVisitor.NewExpression, list.ToArray());
		}

		private static int GetDepth(ExpressionRequest request, IDictionary<ExpressionRequest, int> typePairCount)
		{
			if (typePairCount.TryGetValue(request, out int value))
			{
				value++;
			}
			typePairCount[request] = value;
			return value;
		}

		private LambdaExpression DestinationConstructorExpression(TypeMap typeMap, Expression instanceParameter)
		{
			LambdaExpression constructExpression = typeMap.ConstructExpression;
			if (constructExpression != null)
			{
				return constructExpression;
			}
			return Expression.Lambda((typeMap.ConstructorMap?.CanResolve ?? false) ? typeMap.ConstructorMap.NewExpression(instanceParameter) : Expression.New(typeMap.DestinationTypeToUse));
		}

		private List<MemberBinding> CreateMemberBindings(ExpressionRequest request, TypeMap typeMap, Expression instanceParameter, IDictionary<ExpressionRequest, int> typePairCount, LetPropertyMaps letPropertyMaps)
		{
			List<MemberBinding> bindings = new List<MemberBinding>();
			foreach (PropertyMap item in from pm in typeMap.GetPropertyMaps()
				where pm.CanResolveValue() && ReflectionHelper.CanBeSet(pm.DestinationProperty)
				select pm)
			{
				letPropertyMaps.Push(item);
				CreateMemberBinding(item);
				letPropertyMaps.Pop();
			}
			return bindings;
			void CreateMemberBinding(PropertyMap propertyMap)
			{
				ExpressionResolutionResult result = ResolveExpression(propertyMap, request.SourceType, instanceParameter, letPropertyMaps);
				if (!propertyMap.ExplicitExpansion || request.MembersToExpand.Contains(propertyMap.DestinationProperty))
				{
					TypeMap propertyTypeMap = _configurationProvider.ResolveTypeMap(result.Type, propertyMap.DestinationPropertyType);
					ExpressionRequest expressionRequest = new ExpressionRequest(result.Type, propertyMap.DestinationPropertyType, request.MembersToExpand, request);
					if (!expressionRequest.AlreadyExists)
					{
						IExpressionBinder expressionBinder = Binders.FirstOrDefault((IExpressionBinder b) => b.IsMatch(propertyMap, propertyTypeMap, result));
						if (expressionBinder == null)
						{
							throw new AutoMapperMappingException($"Unable to create a map expression from {propertyMap.SourceMember?.DeclaringType?.Name}.{propertyMap.SourceMember?.Name} ({result.Type}) to {propertyMap.DestinationProperty.DeclaringType?.Name}.{propertyMap.DestinationProperty.Name} ({propertyMap.DestinationPropertyType})", null, typeMap.Types, typeMap, propertyMap);
						}
						MemberAssignment memberAssignment = expressionBinder.Build(_configurationProvider, propertyMap, propertyTypeMap, expressionRequest, result, typePairCount, letPropertyMaps);
						if (memberAssignment != null)
						{
							Expression expression = (from vt in propertyMap.ValueTransformers.Concat(typeMap.ValueTransformers).Concat(typeMap.Profile.ValueTransformers)
								where vt.IsMatch(propertyMap)
								select vt).Aggregate(memberAssignment.Expression, (Expression current, ValueTransformerConfiguration vtConfig) => ExpressionFactory.ToType(ExpressionFactory.ReplaceParameters(vtConfig.TransformerExpression, ExpressionFactory.ToType(current, vtConfig.ValueType)), propertyMap.DestinationPropertyType));
							memberAssignment = memberAssignment.Update(expression);
							bindings.Add(memberAssignment);
						}
					}
				}
			}
		}

		private static ExpressionResolutionResult ResolveExpression(PropertyMap propertyMap, Type currentType, Expression instanceParameter, LetPropertyMaps letPropertyMaps)
		{
			ExpressionResolutionResult result = new ExpressionResolutionResult(instanceParameter, currentType);
			result = (ExpressionResultConverters.FirstOrDefault((IExpressionResultConverter c) => c.CanGetExpressionResolutionResult(result, propertyMap))?.GetExpressionResolutionResult(result, propertyMap, letPropertyMaps) ?? throw new Exception("Can't resolve this to Queryable Expression"));
			if (propertyMap.NullSubstitute != null && result.Type.IsNullableType())
			{
				Expression resolutionExpression = result.ResolutionExpression;
				Type type = result.Type;
				object nullSubstitute = propertyMap.NullSubstitute;
				resolutionExpression = new NullSubstitutionConversionVisitor(result.ResolutionExpression, nullSubstitute).Visit(resolutionExpression);
				type = type.GetTypeOfNullable();
				return new ExpressionResolutionResult(resolutionExpression, type);
			}
			return result;
		}
	}
}
