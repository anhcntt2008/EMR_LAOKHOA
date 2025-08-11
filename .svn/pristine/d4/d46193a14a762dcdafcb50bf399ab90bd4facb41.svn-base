using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AutoMapper.QueryableExtensions
{
	internal class NullableSourceExpressionBinder : IExpressionBinder
	{
		public MemberAssignment Build(IConfigurationProvider configuration, PropertyMap propertyMap, TypeMap propertyTypeMap, ExpressionRequest request, ExpressionResolutionResult result, IDictionary<ExpressionRequest, int> typePairCount, LetPropertyMaps letPropertyMaps)
		{
			object value = Activator.CreateInstance(propertyMap.DestinationPropertyType);
			return Expression.Bind(propertyMap.DestinationProperty, Expression.Coalesce(result.ResolutionExpression, Expression.Constant(value)));
		}

		public bool IsMatch(PropertyMap propertyMap, TypeMap propertyTypeMap, ExpressionResolutionResult result)
		{
			if (result.Type.IsNullableType() && !propertyMap.DestinationPropertyType.IsNullableType())
			{
				return propertyMap.DestinationPropertyType.IsValueType();
			}
			return false;
		}
	}
}
