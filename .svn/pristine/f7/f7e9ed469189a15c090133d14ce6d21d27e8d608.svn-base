using AutoMapper.Mappers.Internal;
using System;
using System.Linq.Expressions;

namespace AutoMapper.Mappers
{
	public abstract class EnumerableMapperBase : IObjectMapperInfo, IObjectMapper
	{
		public TypePair GetAssociatedTypes(TypePair initialTypes)
		{
			Type elementType = ElementTypeHelper.GetElementType(initialTypes.SourceType);
			Type elementType2 = ElementTypeHelper.GetElementType(initialTypes.DestinationType);
			return new TypePair(elementType, elementType2);
		}

		public abstract bool IsMatch(TypePair context);

		public abstract Expression MapExpression(IConfigurationProvider configurationProvider, ProfileMap profileMap, PropertyMap propertyMap, Expression sourceExpression, Expression destExpression, Expression contextExpression);
	}
}
