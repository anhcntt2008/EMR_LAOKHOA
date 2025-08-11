using AutoMapper.Internal;
using AutoMapper.Mappers.Internal;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper.Mappers
{
	public class UnderlyingTypeToEnumMapper : IObjectMapper
	{
		private static readonly MethodInfo EnumToObject = ExpressionFactory.Method(() => Enum.ToObject(typeof(object), null));

		public bool IsMatch(TypePair context)
		{
			Type enumerationType = ElementTypeHelper.GetEnumerationType(context.DestinationType);
			if (enumerationType != null)
			{
				return context.SourceType.IsAssignableFrom(Enum.GetUnderlyingType(enumerationType));
			}
			return false;
		}

		public Expression MapExpression(IConfigurationProvider configurationProvider, ProfileMap profileMap, PropertyMap propertyMap, Expression sourceExpression, Expression destExpression, Expression contextExpression)
		{
			return ExpressionFactory.ToType(Expression.Call(EnumToObject, Expression.Constant(destExpression.Type), ExpressionFactory.ToObject(sourceExpression)), destExpression.Type);
		}
	}
}
