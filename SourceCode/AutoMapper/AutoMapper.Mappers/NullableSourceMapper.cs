using AutoMapper.Configuration;
using AutoMapper.Execution;
using System;
using System.Linq.Expressions;

namespace AutoMapper.Mappers
{
	public class NullableSourceMapper : IObjectMapperInfo, IObjectMapper
	{
		public bool IsMatch(TypePair context)
		{
			return context.SourceType.IsNullableType();
		}

		public Expression MapExpression(IConfigurationProvider configurationProvider, ProfileMap profileMap, PropertyMap propertyMap, Expression sourceExpression, Expression destExpression, Expression contextExpression)
		{
			return ExpressionBuilder.MapExpression(configurationProvider, profileMap, new TypePair(Nullable.GetUnderlyingType(sourceExpression.Type), destExpression.Type), Expression.Property(sourceExpression, sourceExpression.Type.GetDeclaredProperty("Value")), contextExpression, propertyMap, destExpression);
		}

		public TypePair GetAssociatedTypes(TypePair initialTypes)
		{
			return new TypePair(Nullable.GetUnderlyingType(initialTypes.SourceType), initialTypes.DestinationType);
		}
	}
}
