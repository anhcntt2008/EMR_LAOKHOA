using AutoMapper.Mappers.Internal;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper.Mappers
{
	public class EnumToEnumMapper : IObjectMapper
	{
		private static readonly MethodInfo MapMethodInfo = typeof(EnumToEnumMapper).GetAllMethods().First((MethodInfo _) => _.IsStatic);

		public static TDestination Map<TSource, TDestination>(TSource source)
		{
			Type enumerationType = ElementTypeHelper.GetEnumerationType(typeof(TSource));
			Type enumerationType2 = ElementTypeHelper.GetEnumerationType(typeof(TDestination));
			if (!Enum.IsDefined(enumerationType, source))
			{
				return (TDestination)Enum.ToObject(enumerationType2, source);
			}
			if (!Enum.GetNames(enumerationType2).Contains(source.ToString()))
			{
				Type underlyingType = Enum.GetUnderlyingType(enumerationType);
				object value = Convert.ChangeType(source, underlyingType);
				return (TDestination)Enum.ToObject(enumerationType2, value);
			}
			return (TDestination)Enum.Parse(enumerationType2, Enum.GetName(enumerationType, source), ignoreCase: true);
		}

		public bool IsMatch(TypePair context)
		{
			Type enumerationType = ElementTypeHelper.GetEnumerationType(context.SourceType);
			Type enumerationType2 = ElementTypeHelper.GetEnumerationType(context.DestinationType);
			if (enumerationType != null)
			{
				return enumerationType2 != null;
			}
			return false;
		}

		public Expression MapExpression(IConfigurationProvider configurationProvider, ProfileMap profileMap, PropertyMap propertyMap, Expression sourceExpression, Expression destExpression, Expression contextExpression)
		{
			return Expression.Call(null, MapMethodInfo.MakeGenericMethod(sourceExpression.Type, destExpression.Type), sourceExpression);
		}
	}
}
