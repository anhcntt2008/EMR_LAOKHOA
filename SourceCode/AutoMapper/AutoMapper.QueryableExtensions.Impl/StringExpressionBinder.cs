using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AutoMapper.QueryableExtensions.Impl
{
	public class StringExpressionBinder : IExpressionBinder
	{
		public bool IsMatch(PropertyMap propertyMap, TypeMap propertyTypeMap, ExpressionResolutionResult result)
		{
			return propertyMap.DestinationPropertyType == typeof(string);
		}

		public MemberAssignment Build(IConfigurationProvider configuration, PropertyMap propertyMap, TypeMap propertyTypeMap, ExpressionRequest request, ExpressionResolutionResult result, IDictionary<ExpressionRequest, int> typePairCount, LetPropertyMaps letPropertyMaps)
		{
			return BindStringExpression(propertyMap, result);
		}

		private static MemberAssignment BindStringExpression(PropertyMap propertyMap, ExpressionResolutionResult result)
		{
			return Expression.Bind(propertyMap.DestinationProperty, Expression.Call(result.ResolutionExpression, "ToString", (Type[])null, (Expression[])null));
		}
	}
}
