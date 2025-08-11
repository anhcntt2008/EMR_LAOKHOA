using AutoMapper.Internal;
using AutoMapper.Mappers.Internal;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper.Mappers
{
	public class EnumToUnderlyingTypeMapper : IObjectMapper
	{
		private static readonly MethodInfo ChangeTypeMethod = ExpressionFactory.Method(() => Convert.ChangeType(null, typeof(object)));

		public bool IsMatch(TypePair context)
		{
			Type enumerationType = ElementTypeHelper.GetEnumerationType(context.SourceType);
			if (enumerationType != null)
			{
				return context.DestinationType.IsAssignableFrom(Enum.GetUnderlyingType(enumerationType));
			}
			return false;
		}

		public Expression MapExpression(IConfigurationProvider configurationProvider, ProfileMap profileMap, PropertyMap propertyMap, Expression sourceExpression, Expression destExpression, Expression contextExpression)
		{
			return ExpressionFactory.ToType(Expression.Call(ChangeTypeMethod, ExpressionFactory.ToObject(sourceExpression), Expression.Constant(destExpression.Type)), destExpression.Type);
		}
	}
}
