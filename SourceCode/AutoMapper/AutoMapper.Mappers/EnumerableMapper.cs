using AutoMapper.Configuration;
using AutoMapper.Mappers.Internal;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AutoMapper.Mappers
{
	public class EnumerableMapper : EnumerableMapperBase
	{
		public override bool IsMatch(TypePair context)
		{
			if ((context.DestinationType.IsInterface() && context.DestinationType.IsEnumerableType()) || context.DestinationType.IsListType())
			{
				return context.SourceType.IsEnumerableType();
			}
			return false;
		}

		public override Expression MapExpression(IConfigurationProvider configurationProvider, ProfileMap profileMap, PropertyMap propertyMap, Expression sourceExpression, Expression destExpression, Expression contextExpression)
		{
			if (destExpression.Type.IsInterface())
			{
				Type type = typeof(IList<>).MakeGenericType(ElementTypeHelper.GetElementType(destExpression.Type));
				destExpression = Expression.Convert(destExpression, type);
			}
			return CollectionMapperExpressionFactory.MapCollectionExpression(configurationProvider, profileMap, propertyMap, sourceExpression, destExpression, contextExpression, typeof(List<>), CollectionMapperExpressionFactory.MapItemExpr);
		}
	}
}
