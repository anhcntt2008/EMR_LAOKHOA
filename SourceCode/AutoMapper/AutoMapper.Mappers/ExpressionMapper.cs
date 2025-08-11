using AutoMapper.Configuration;
using AutoMapper.XpressionMapper.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper.Mappers
{
	public class ExpressionMapper : IObjectMapper
	{
		internal class MappingVisitor : ExpressionVisitor
		{
			private class IsConstantExpressionVisitor : ExpressionVisitor
			{
				public bool IsConstant
				{
					get;
					private set;
				}

				protected override Expression VisitConstant(ConstantExpression node)
				{
					IsConstant = true;
					return base.VisitConstant(node);
				}
			}

			private IList<Type> _destSubTypes = new Type[0];

			private readonly IConfigurationProvider _configurationProvider;

			private readonly TypeMap _typeMap;

			private readonly Expression _oldParam;

			private readonly Expression _newParam;

			private readonly MappingVisitor _parentMappingVisitor;

			public MappingVisitor(IConfigurationProvider configurationProvider, IList<Type> destSubTypes)
				: this(configurationProvider, null, Expression.Parameter(typeof(Nullable)), Expression.Parameter(typeof(Nullable)), null, destSubTypes)
			{
			}

			internal MappingVisitor(IConfigurationProvider configurationProvider, TypeMap typeMap, Expression oldParam, Expression newParam, MappingVisitor parentMappingVisitor = null, IList<Type> destSubTypes = null)
			{
				_configurationProvider = configurationProvider;
				_typeMap = typeMap;
				_oldParam = oldParam;
				_newParam = newParam;
				_parentMappingVisitor = parentMappingVisitor;
				if (destSubTypes != null)
				{
					_destSubTypes = destSubTypes;
				}
			}

			protected override Expression VisitConstant(ConstantExpression node)
			{
				if (node != _oldParam)
				{
					return node;
				}
				return _newParam;
			}

			protected override Expression VisitParameter(ParameterExpression node)
			{
				if (node != _oldParam)
				{
					return node;
				}
				return _newParam;
			}

			protected override Expression VisitMethodCall(MethodCallExpression node)
			{
				return base.VisitMethodCall(GetConvertedMethodCall(node));
			}

			protected override Expression VisitExtension(Expression node)
			{
				if (node.NodeType != (ExpressionType)10000)
				{
					return base.VisitExtension(node);
				}
				return node;
			}

			private MethodCallExpression GetConvertedMethodCall(MethodCallExpression node)
			{
				if (!node.Method.IsGenericMethod)
				{
					return node;
				}
				ReadOnlyCollection<Expression> convertedArguments = Visit(node.Arguments);
				Type[] typeArguments = (from t in node.Method.GetGenericArguments()
					select GetConvertingTypeIfExists(node.Arguments, t, convertedArguments)).ToArray();
				return Expression.Call(node.Method.GetGenericMethodDefinition().MakeGenericMethod(typeArguments), convertedArguments);
			}

			private static Type GetConvertingTypeIfExists(IList<Expression> args, Type t, IList<Expression> arguments)
			{
				Expression expression = args.Where((Expression a) => !a.Type.IsGenericType()).FirstOrDefault((Expression a) => a.Type == t);
				if (expression != null)
				{
					int num = args.IndexOf(expression);
					if (num >= 0)
					{
						return arguments[num].Type;
					}
					return t;
				}
				Expression item = args.Where((Expression a) => a.Type.IsGenericType()).FirstOrDefault((Expression a) => a.Type.GetTypeInfo().GenericTypeArguments[0] == t);
				int num2 = args.IndexOf(item);
				if (num2 >= 0)
				{
					return arguments[num2].Type.GetTypeInfo().GenericTypeArguments[0];
				}
				return t;
			}

			protected override Expression VisitBinary(BinaryExpression node)
			{
				Expression newLeft = Visit(node.Left);
				Expression newRight = Visit(node.Right);
				if (newLeft.Type != newRight.Type && newRight.Type == typeof(string))
				{
					newLeft = Expression.Call(newLeft, typeof(object).GetDeclaredMethod("ToString"));
				}
				if (newRight.Type != newLeft.Type && newLeft.Type == typeof(string))
				{
					newRight = Expression.Call(newRight, typeof(object).GetDeclaredMethod("ToString"));
				}
				CheckNullableToNonNullableChanges(node.Left, node.Right, ref newLeft, ref newRight);
				CheckNullableToNonNullableChanges(node.Right, node.Left, ref newRight, ref newLeft);
				return Expression.MakeBinary(node.NodeType, newLeft, newRight);
			}

			private static void CheckNullableToNonNullableChanges(Expression left, Expression right, ref Expression newLeft, ref Expression newRight)
			{
				if (GoingFromNonNullableToNullable(left, newLeft))
				{
					if (BothAreNonNullable(right, newRight))
					{
						UpdateToNullableExpression(right, out newRight);
					}
					else if (BothAreNullable(right, newRight))
					{
						UpdateToNonNullableExpression(right, out newRight);
					}
				}
				if (GoingFromNonNullableToNullable(newLeft, left))
				{
					if (BothAreNonNullable(right, newRight))
					{
						UpdateToNullableExpression(right, out newRight);
					}
					else if (BothAreNullable(right, newRight))
					{
						UpdateToNonNullableExpression(right, out newRight);
					}
				}
			}

			private static void UpdateToNullableExpression(Expression right, out Expression newRight)
			{
				ConstantExpression constantExpression;
				if ((constantExpression = (right as ConstantExpression)) == null)
				{
					throw new AutoMapperMappingException("Mapping a BinaryExpression where one side is nullable and the other isn't");
				}
				newRight = Expression.Constant(constantExpression.Value, typeof(Nullable<>).MakeGenericType(right.Type));
			}

			private static void UpdateToNonNullableExpression(Expression right, out Expression newRight)
			{
				ConstantExpression constantExpression;
				if ((constantExpression = (right as ConstantExpression)) != null)
				{
					Type type = right.Type.IsNullableType() ? right.Type.GetGenericArguments()[0] : right.Type;
					newRight = Expression.Constant(constantExpression.Value, type);
					return;
				}
				if (right is UnaryExpression)
				{
					newRight = ((UnaryExpression)right).Operand;
					return;
				}
				throw new AutoMapperMappingException("Mapping a BinaryExpression where one side is nullable and the other isn't");
			}

			private static bool GoingFromNonNullableToNullable(Expression node, Expression newLeft)
			{
				if (!node.Type.IsNullableType())
				{
					return newLeft.Type.IsNullableType();
				}
				return false;
			}

			private static bool BothAreNullable(Expression node, Expression newLeft)
			{
				if (node.Type.IsNullableType())
				{
					return newLeft.Type.IsNullableType();
				}
				return false;
			}

			private static bool BothAreNonNullable(Expression node, Expression newLeft)
			{
				if (!node.Type.IsNullableType())
				{
					return !newLeft.Type.IsNullableType();
				}
				return false;
			}

			protected override Expression VisitLambda<T>(Expression<T> expression)
			{
				if (!expression.Parameters.Any((ParameterExpression b) => b.Type == _oldParam.Type))
				{
					return VisitAllParametersExpression(expression);
				}
				return VisitLambdaExpression(expression);
			}

			private Expression VisitLambdaExpression<T>(Expression<T> expression)
			{
				Expression body = Visit(expression.Body);
				List<ParameterExpression> parameters = expression.Parameters.Select((ParameterExpression e) => Visit(e) as ParameterExpression).ToList();
				return Expression.Lambda(body, parameters);
			}

			private Expression VisitAllParametersExpression<T>(Expression<T> expression)
			{
				return (from t in expression.Parameters
					let sourceParamType = t.Type
					from destParamType in from dt in _destSubTypes
						where dt != sourceParamType
						select dt
					let a = destParamType.IsGenericType() ? destParamType.GetTypeInfo().GenericTypeArguments[0] : destParamType
					let typeMap = _configurationProvider.ResolveTypeMap(a, sourceParamType)
					where typeMap != null
					let oldParam = t
					let newParam = Expression.Parameter(a, oldParam.Name)
					select new MappingVisitor(_configurationProvider, typeMap, oldParam, newParam, this)).Cast<ExpressionVisitor>().ToList().Aggregate(expression, (Expression e, ExpressionVisitor v) => v.Visit(e));
			}

			protected override Expression VisitMember(MemberExpression node)
			{
				if (node == _oldParam)
				{
					return _newParam;
				}
				PropertyMap propertyMap = PropertyMap(node);
				if (propertyMap == null)
				{
					if (node.Expression is MemberExpression)
					{
						return GetConvertedSubMemberCall(node);
					}
					return node;
				}
				IsConstantExpressionVisitor isConstantExpressionVisitor = new IsConstantExpressionVisitor();
				isConstantExpressionVisitor.Visit(node);
				if (isConstantExpressionVisitor.IsConstant)
				{
					return node;
				}
				SetSorceSubTypes(propertyMap);
				Expression expression = Visit(node.Expression);
				if (expression == node.Expression)
				{
					expression = _parentMappingVisitor.Visit(node.Expression);
				}
				if (propertyMap.CustomExpression != null)
				{
					return propertyMap.CustomExpression.ReplaceParameters(expression);
				}
				Func<Expression, MemberInfo, Expression> func = Expression.MakeMemberAccess;
				return propertyMap.SourceMembers.Aggregate(expression, func);
			}

			private Expression GetConvertedSubMemberCall(MemberExpression node)
			{
				Expression expression = Visit(node.Expression);
				PropertyMap propertyMap = FindPropertyMapOfExpression(node.Expression as MemberExpression);
				if (propertyMap == null)
				{
					return node;
				}
				Type sourceType = GetSourceType(propertyMap);
				Type destinationPropertyType = propertyMap.DestinationPropertyType;
				if (sourceType == destinationPropertyType)
				{
					return Expression.MakeMemberAccess(expression, node.Member);
				}
				TypeMap typeMap = _configurationProvider.ResolveTypeMap(sourceType, destinationPropertyType);
				MappingVisitor mappingVisitor = new MappingVisitor(_configurationProvider, typeMap, node.Expression, expression, this);
				Expression result = mappingVisitor.Visit(node);
				_destSubTypes = _destSubTypes.Concat(mappingVisitor._destSubTypes).ToArray();
				return result;
			}

			private Type GetSourceType(PropertyMap propertyMap)
			{
				return propertyMap.SourceType ?? throw new AutoMapperMappingException("Could not determine source property type. Make sure the property is mapped.", null, new TypePair(null, propertyMap.DestinationPropertyType), propertyMap.TypeMap, propertyMap);
			}

			private PropertyMap FindPropertyMapOfExpression(MemberExpression expression)
			{
				PropertyMap propertyMap = PropertyMap(expression);
				if (propertyMap != null || !(expression.Expression is MemberExpression))
				{
					return propertyMap;
				}
				return FindPropertyMapOfExpression((MemberExpression)expression.Expression);
			}

			private PropertyMap PropertyMap(MemberExpression node)
			{
				if (_typeMap != null)
				{
					if (!node.Member.IsStatic())
					{
						if (node.Member.DeclaringType.IsAssignableFrom(_typeMap.DestinationType))
						{
							return _typeMap.GetExistingPropertyMapFor(node.Member);
						}
						return null;
					}
					return null;
				}
				return null;
			}

			private void SetSorceSubTypes(PropertyMap propertyMap)
			{
				PropertyInfo propertyInfo;
				FieldInfo fieldInfo;
				if ((object)(propertyInfo = (propertyMap.SourceMember as PropertyInfo)) != null)
				{
					_destSubTypes = propertyInfo.PropertyType.GetTypeInfo().GenericTypeArguments.Concat(new Type[1]
					{
						propertyInfo.PropertyType
					}).ToList();
				}
				else if ((object)(fieldInfo = (propertyMap.SourceMember as FieldInfo)) != null)
				{
					_destSubTypes = fieldInfo.FieldType.GetTypeInfo().GenericTypeArguments;
				}
			}
		}

		private static readonly MethodInfo MapMethodInfo = typeof(ExpressionMapper).GetDeclaredMethod("Map");

		private static TDestination Map<TSource, TDestination>(TSource expression, ResolutionContext context) where TSource : LambdaExpression where TDestination : LambdaExpression
		{
			return context.Mapper.MapExpression<TDestination>(expression);
		}

		public bool IsMatch(TypePair context)
		{
			if (typeof(LambdaExpression).IsAssignableFrom(context.SourceType) && context.SourceType != typeof(LambdaExpression) && typeof(LambdaExpression).IsAssignableFrom(context.DestinationType))
			{
				return context.DestinationType != typeof(LambdaExpression);
			}
			return false;
		}

		public Expression MapExpression(IConfigurationProvider configurationProvider, ProfileMap profileMap, PropertyMap propertyMap, Expression sourceExpression, Expression destExpression, Expression contextExpression)
		{
			return Expression.Call(null, MapMethodInfo.MakeGenericMethod(sourceExpression.Type, destExpression.Type), sourceExpression, contextExpression);
		}
	}
}
