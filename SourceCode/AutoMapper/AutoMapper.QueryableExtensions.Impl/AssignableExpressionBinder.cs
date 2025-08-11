using System.Collections.Generic;
using System.Linq.Expressions;

namespace AutoMapper.QueryableExtensions.Impl
{
	public class AssignableExpressionBinder : IExpressionBinder
	{
		public bool IsMatch(PropertyMap propertyMap, TypeMap propertyTypeMap, ExpressionResolutionResult result)
		{
			if (propertyMap.DestinationPropertyType.IsAssignableFrom(result.Type))
			{
				return propertyTypeMap == null;
			}
			return false;
		}

		public MemberAssignment Build(IConfigurationProvider configuration, PropertyMap propertyMap, TypeMap propertyTypeMap, ExpressionRequest request, ExpressionResolutionResult result, IDictionary<ExpressionRequest, int> typePairCount, LetPropertyMaps letPropertyMaps)
		{
			return BindAssignableExpression(propertyMap, result);
		}

		private static MemberAssignment BindAssignableExpression(PropertyMap propertyMap, ExpressionResolutionResult result)
		{
			return Expression.Bind(propertyMap.DestinationProperty, result.ResolutionExpression);
		}
	}
}
