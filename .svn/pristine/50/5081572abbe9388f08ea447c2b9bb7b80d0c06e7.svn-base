using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper.Mappers
{
	public class TypeConverterMapper : IObjectMapper
	{
		private static readonly MethodInfo MapMethodInfo = typeof(TypeConverterMapper).GetDeclaredMethod("Map");

		private static TDestination Map<TSource, TDestination>(TSource source)
		{
			TypeConverter typeConverter = GetTypeConverter(typeof(TSource));
			if (typeConverter.CanConvertTo(typeof(TDestination)))
			{
				return (TDestination)typeConverter.ConvertTo(source, typeof(TDestination));
			}
			typeConverter = GetTypeConverter(typeof(TDestination));
			if (typeConverter.CanConvertFrom(typeof(TSource)))
			{
				return (TDestination)typeConverter.ConvertFrom(source);
			}
			return default(TDestination);
		}

		public bool IsMatch(TypePair context)
		{
			TypeConverter typeConverter = GetTypeConverter(context.SourceType);
			TypeConverter typeConverter2 = GetTypeConverter(context.DestinationType);
			if (!typeConverter.CanConvertTo(context.DestinationType))
			{
				return typeConverter2.CanConvertFrom(context.SourceType);
			}
			return true;
		}

		public Expression MapExpression(IConfigurationProvider configurationProvider, ProfileMap profileMap, PropertyMap propertyMap, Expression sourceExpression, Expression destExpression, Expression contextExpression)
		{
			return Expression.Call(null, MapMethodInfo.MakeGenericMethod(sourceExpression.Type, destExpression.Type), sourceExpression);
		}

		private static TypeConverter GetTypeConverter(Type type)
		{
			return TypeDescriptor.GetConverter(type);
		}
	}
}
