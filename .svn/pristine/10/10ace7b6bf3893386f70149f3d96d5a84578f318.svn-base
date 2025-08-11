using AutoMapper.Configuration;
using AutoMapper.Mappers.Internal;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AutoMapper.Mappers
{
	public class HashSetMapper : IObjectMapper
	{
		public bool IsMatch(TypePair context)
		{
			if (context.SourceType.IsEnumerableType())
			{
				return IsSetType(context.DestinationType);
			}
			return false;
		}

		public Expression MapExpression(IConfigurationProvider configurationProvider, ProfileMap profileMap, PropertyMap propertyMap, Expression sourceExpression, Expression destExpression, Expression contextExpression)
		{
			return CollectionMapperExpressionFactory.MapCollectionExpression(configurationProvider, profileMap, propertyMap, sourceExpression, destExpression, contextExpression, typeof(HashSet<>), CollectionMapperExpressionFactory.MapItemExpr);
		}

		private static bool IsSetType(Type type)
		{
			return type.IsSetType();
		}
	}
}
