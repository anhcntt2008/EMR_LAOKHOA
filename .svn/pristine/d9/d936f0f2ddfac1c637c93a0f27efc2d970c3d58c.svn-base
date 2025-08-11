using AutoMapper.Configuration;
using AutoMapper.Mappers.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AutoMapper.QueryableExtensions.Impl
{
	public class EnumerableExpressionBinder : IExpressionBinder
	{
		public bool IsMatch(PropertyMap propertyMap, TypeMap propertyTypeMap, ExpressionResolutionResult result)
		{
			if (propertyMap.DestinationPropertyType.IsEnumerableType())
			{
				return propertyMap.SourceType.IsEnumerableType();
			}
			return false;
		}

		public MemberAssignment Build(IConfigurationProvider configuration, PropertyMap propertyMap, TypeMap propertyTypeMap, ExpressionRequest request, ExpressionResolutionResult result, IDictionary<ExpressionRequest, int> typePairCount, LetPropertyMaps letPropertyMaps)
		{
			return BindEnumerableExpression(configuration, propertyMap, request, result, typePairCount, letPropertyMaps);
		}

		private static MemberAssignment BindEnumerableExpression(IConfigurationProvider configuration, PropertyMap propertyMap, ExpressionRequest request, ExpressionResolutionResult result, IDictionary<ExpressionRequest, int> typePairCount, LetPropertyMaps letPropertyMaps)
		{
			Type elementType = ElementTypeHelper.GetElementType(propertyMap.DestinationPropertyType);
			Type elementType2 = ElementTypeHelper.GetElementType(propertyMap.SourceType);
			Expression expression = result.ResolutionExpression;
			if (elementType2 != elementType)
			{
				ExpressionRequest request2 = new ExpressionRequest(elementType2, elementType, request.MembersToExpand, request);
				LambdaExpression[] array = configuration.ExpressionBuilder.CreateMapExpression(request2, typePairCount, letPropertyMaps.New());
				if (array == null)
				{
					return null;
				}
				expression = array.Aggregate(expression, (Expression source, LambdaExpression lambda) => Select(source, lambda));
			}
			expression = Expression.Call(typeof(Enumerable), propertyMap.DestinationPropertyType.IsArray ? "ToArray" : "ToList", new Type[1]
			{
				elementType
			}, expression);
			return Expression.Bind(propertyMap.DestinationProperty, expression);
		}

		private static Expression Select(Expression source, LambdaExpression lambda)
		{
			return Expression.Call(typeof(Enumerable), "Select", new Type[2]
			{
				lambda.Parameters[0].Type,
				lambda.ReturnType
			}, source, lambda);
		}
	}
}
