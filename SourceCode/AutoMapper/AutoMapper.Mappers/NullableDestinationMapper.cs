using AutoMapper.Configuration;
using AutoMapper.Execution;
using System;
using System.Linq.Expressions;

namespace AutoMapper.Mappers
{
	public class NullableDestinationMapper : IObjectMapperInfo, IObjectMapper
	{
		public bool IsMatch(TypePair context)
		{
			return context.DestinationType.IsNullableType();
		}

		public Expression MapExpression(IConfigurationProvider configurationProvider, ProfileMap profileMap, PropertyMap propertyMap, Expression sourceExpression, Expression destExpression, Expression contextExpression)
		{
			return ExpressionBuilder.MapExpression(configurationProvider, profileMap, new TypePair(sourceExpression.Type, Nullable.GetUnderlyingType(destExpression.Type)), sourceExpression, contextExpression, propertyMap, Expression.Property(destExpression, destExpression.Type.GetDeclaredProperty("Value")));
		}

		public TypePair GetAssociatedTypes(TypePair initialTypes)
		{
			return new TypePair(initialTypes.SourceType, Nullable.GetUnderlyingType(initialTypes.DestinationType));
		}
	}
}
