using System.Collections.Generic;
using System.Linq.Expressions;

namespace AutoMapper.QueryableExtensions.Impl
{
	public class CustomProjectionExpressionBinder : IExpressionBinder
	{
		public bool IsMatch(PropertyMap propertyMap, TypeMap propertyTypeMap, ExpressionResolutionResult result)
		{
			return propertyTypeMap?.CustomProjection != null;
		}

		public MemberAssignment Build(IConfigurationProvider configuration, PropertyMap propertyMap, TypeMap propertyTypeMap, ExpressionRequest request, ExpressionResolutionResult result, IDictionary<ExpressionRequest, int> typePairCount, LetPropertyMaps letPropertyMaps)
		{
			return BindCustomProjectionExpression(propertyMap, propertyTypeMap, result);
		}

		private static MemberAssignment BindCustomProjectionExpression(PropertyMap propertyMap, TypeMap propertyTypeMap, ExpressionResolutionResult result)
		{
			return Expression.Bind(propertyMap.DestinationProperty, propertyTypeMap.CustomProjection.ReplaceParameters(result.ResolutionExpression));
		}
	}
}
