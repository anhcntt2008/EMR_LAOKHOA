using AutoMapper.Configuration;
using AutoMapper.Mappers.Internal;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AutoMapper.Mappers
{
	public class CollectionMapper : EnumerableMapperBase
	{
		public override bool IsMatch(TypePair context)
		{
			if (context.SourceType.IsEnumerableType())
			{
				return context.DestinationType.IsCollectionType();
			}
			return false;
		}

		public override Expression MapExpression(IConfigurationProvider configurationProvider, ProfileMap profileMap, PropertyMap propertyMap, Expression sourceExpression, Expression destExpression, Expression contextExpression)
		{
			return CollectionMapperExpressionFactory.MapCollectionExpression(configurationProvider, profileMap, propertyMap, sourceExpression, destExpression, contextExpression, typeof(List<>), CollectionMapperExpressionFactory.MapItemExpr);
		}
	}
}
