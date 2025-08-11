using AutoMapper.Internal;
using AutoMapper.Mappers.Internal;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper.Mappers
{
	public class FlagsEnumMapper : IObjectMapper
	{
		private static readonly MethodInfo EnumParseMethod = ExpressionFactory.Method(() => Enum.Parse(null, null, ignoreCase: true));

		public bool IsMatch(TypePair context)
		{
			Type enumerationType = ElementTypeHelper.GetEnumerationType(context.SourceType);
			Type enumerationType2 = ElementTypeHelper.GetEnumerationType(context.DestinationType);
			if (enumerationType != null && enumerationType2 != null && enumerationType.GetCustomAttributes(typeof(FlagsAttribute), inherit: false).Any())
			{
				return enumerationType2.GetCustomAttributes(typeof(FlagsAttribute), inherit: false).Any();
			}
			return false;
		}

		public Expression MapExpression(IConfigurationProvider configurationProvider, ProfileMap profileMap, PropertyMap propertyMap, Expression sourceExpression, Expression destExpression, Expression contextExpression)
		{
			return ExpressionFactory.ToType(Expression.Call(EnumParseMethod, Expression.Constant(destExpression.Type), Expression.Call(sourceExpression, sourceExpression.Type.GetDeclaredMethod("ToString")), Expression.Constant(true)), destExpression.Type);
		}
	}
}
