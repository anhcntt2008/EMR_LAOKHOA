using AutoMapper.Configuration;
using AutoMapper.Mappers.Internal;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AutoMapper.Mappers
{
	public class DictionaryMapper : IObjectMapper
	{
		public bool IsMatch(TypePair context)
		{
			if (context.SourceType.IsDictionaryType())
			{
				return context.DestinationType.IsDictionaryType();
			}
			return false;
		}

		public Expression MapExpression(IConfigurationProvider configurationProvider, ProfileMap profileMap, PropertyMap propertyMap, Expression sourceExpression, Expression destExpression, Expression contextExpression)
		{
			return CollectionMapperExpressionFactory.MapCollectionExpression(configurationProvider, profileMap, propertyMap, sourceExpression, destExpression, contextExpression, typeof(Dictionary<, >), CollectionMapperExpressionFactory.MapKeyPairValueExpr);
		}
	}
}
