using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AutoMapper.QueryableExtensions.Impl
{
	public class NullableDestinationExpressionBinder : IExpressionBinder
	{
		public bool IsMatch(PropertyMap propertyMap, TypeMap propertyTypeMap, ExpressionResolutionResult result)
		{
			if (propertyMap.DestinationPropertyType.IsNullableType())
			{
				return !result.Type.IsNullableType();
			}
			return false;
		}

		public MemberAssignment Build(IConfigurationProvider configuration, PropertyMap propertyMap, TypeMap propertyTypeMap, ExpressionRequest request, ExpressionResolutionResult result, IDictionary<ExpressionRequest, int> typePairCount, LetPropertyMaps letPropertyMaps)
		{
			return BindNullableExpression(propertyMap, result);
		}

		private static MemberAssignment BindNullableExpression(PropertyMap propertyMap, ExpressionResolutionResult result)
		{
			if (result.ResolutionExpression.NodeType == ExpressionType.MemberAccess)
			{
				MemberExpression memberExpression = (MemberExpression)result.ResolutionExpression;
				if (memberExpression.Expression != null && memberExpression.Expression.NodeType == ExpressionType.MemberAccess)
				{
					Type destinationPropertyType = propertyMap.DestinationPropertyType;
					Expression expression = memberExpression.Expression;
					Expression expression2 = Expression.Convert(memberExpression, destinationPropertyType);
					UnaryExpression ifTrue = Expression.Convert(Expression.Constant(null), destinationPropertyType);
					while (expression.NodeType != ExpressionType.Parameter)
					{
						memberExpression = (MemberExpression)memberExpression.Expression;
						expression = memberExpression.Expression;
						expression2 = Expression.Condition(Expression.Equal(memberExpression, Expression.Constant(null)), ifTrue, expression2);
					}
					return Expression.Bind(propertyMap.DestinationProperty, expression2);
				}
			}
			return Expression.Bind(propertyMap.DestinationProperty, Expression.Convert(result.ResolutionExpression, propertyMap.DestinationPropertyType));
		}
	}
}
