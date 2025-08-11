using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper.Mappers
{
	public class ConvertMapper : IObjectMapper
	{
		private readonly Dictionary<TypePair, Lazy<LambdaExpression>> _converters = GetConverters();

		private static Dictionary<TypePair, Lazy<LambdaExpression>> GetConverters()
		{
			Type[] primitiveTypes = new Type[13]
			{
				typeof(string),
				typeof(bool),
				typeof(byte),
				typeof(short),
				typeof(int),
				typeof(long),
				typeof(float),
				typeof(double),
				typeof(decimal),
				typeof(sbyte),
				typeof(ushort),
				typeof(uint),
				typeof(ulong)
			};
			return (from sourceType in primitiveTypes
				from destinationType in primitiveTypes
				select new
				{
					Key = new TypePair(sourceType, destinationType),
					Value = new Lazy<LambdaExpression>(() => ConvertExpression(sourceType, destinationType), isThreadSafe: false)
				}).ToDictionary(i => i.Key, i => i.Value);
		}

		private static LambdaExpression ConvertExpression(Type sourceType, Type destinationType)
		{
			MethodInfo declaredMethod = typeof(Convert).GetDeclaredMethod("To" + destinationType.Name, new Type[1]
			{
				sourceType
			});
			ParameterExpression parameterExpression = Expression.Parameter(sourceType, "source");
			return Expression.Lambda(Expression.Call(declaredMethod, parameterExpression), parameterExpression);
		}

		public bool IsMatch(TypePair types)
		{
			return _converters.ContainsKey(types);
		}

		public Expression MapExpression(IConfigurationProvider configurationProvider, ProfileMap profileMap, PropertyMap propertyMap, Expression sourceExpression, Expression destExpression, Expression contextExpression)
		{
			TypePair key = new TypePair(sourceExpression.Type, destExpression.Type);
			return _converters[key].Value.ReplaceParameters(sourceExpression);
		}
	}
}
