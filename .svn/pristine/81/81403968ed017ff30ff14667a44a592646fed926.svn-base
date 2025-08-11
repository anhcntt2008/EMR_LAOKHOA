using System.Collections.Generic;
using System.Linq.Expressions;

namespace AutoMapper.QueryableExtensions.Impl
{
	public class MappedTypeExpressionBinder : IExpressionBinder
	{
		public bool IsMatch(PropertyMap propertyMap, TypeMap propertyTypeMap, ExpressionResolutionResult result)
		{
			if (propertyTypeMap != null)
			{
				return propertyTypeMap.CustomProjection == null;
			}
			return false;
		}

		public MemberAssignment Build(IConfigurationProvider configuration, PropertyMap propertyMap, TypeMap propertyTypeMap, ExpressionRequest request, ExpressionResolutionResult result, IDictionary<ExpressionRequest, int> typePairCount, LetPropertyMaps letPropertyMaps)
		{
			return BindMappedTypeExpression(configuration, propertyMap, request, result, typePairCount, letPropertyMaps);
		}

		private static MemberAssignment BindMappedTypeExpression(IConfigurationProvider configuration, PropertyMap propertyMap, ExpressionRequest request, ExpressionResolutionResult result, IDictionary<ExpressionRequest, int> typePairCount, LetPropertyMaps letPropertyMaps)
		{
			Expression expression = configuration.ExpressionBuilder.CreateMapExpression(request, result.ResolutionExpression, typePairCount, letPropertyMaps);
			if (expression == null)
			{
				return null;
			}
			if (propertyMap.TypeMap.Profile.AllowNullDestinationValues && !propertyMap.AllowNull)
			{
				ConstantExpression ifFalse = Expression.Constant(null, propertyMap.DestinationPropertyType);
				expression = Expression.Condition(Expression.NotEqual(result.ResolutionExpression, Expression.Constant(null)), expression, ifFalse);
			}
			return Expression.Bind(propertyMap.DestinationProperty, expression);
		}
	}
}
