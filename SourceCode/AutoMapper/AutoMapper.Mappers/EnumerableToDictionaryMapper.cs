using AutoMapper.Configuration;
using AutoMapper.Mappers.Internal;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AutoMapper.Mappers
{
	public class EnumerableToDictionaryMapper : IObjectMapper
	{
		public bool IsMatch(TypePair context)
		{
			if (context.DestinationType.IsDictionaryType() && context.SourceType.IsEnumerableType())
			{
				return !context.SourceType.IsDictionaryType();
			}
			return false;
		}

		public Expression MapExpression(IConfigurationProvider configurationProvider, ProfileMap profileMap, PropertyMap propertyMap, Expression sourceExpression, Expression destExpression, Expression contextExpression)
		{
			return CollectionMapperExpressionFactory.MapCollectionExpression(configurationProvider, profileMap, propertyMap, sourceExpression, destExpression, contextExpression, typeof(Dictionary<, >), CollectionMapperExpressionFactory.MapItemExpr);
		}
	}
}
