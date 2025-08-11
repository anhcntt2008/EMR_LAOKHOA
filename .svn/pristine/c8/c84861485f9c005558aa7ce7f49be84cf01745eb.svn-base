using AutoMapper.Configuration;
using AutoMapper.Internal;
using AutoMapper.Mappers.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper.Execution
{
	public static class DelegateFactory
	{
		private static readonly LockingConcurrentDictionary<Type, Func<object>> CtorCache = new LockingConcurrentDictionary<Type, Func<object>>(GenerateConstructor);

		public static Func<object> CreateCtor(Type type)
		{
			return CtorCache.GetOrAdd(type);
		}

		private static Func<object> GenerateConstructor(Type type)
		{
			return Expression.Lambda<Func<object>>(Expression.Convert(GenerateConstructorExpression(type), typeof(object)), new ParameterExpression[0]).Compile();
		}

		public static Expression GenerateConstructorExpression(Type type, ProfileMap configuration)
		{
			if (!configuration.AllowNullDestinationValues)
			{
				return GenerateNonNullConstructorExpression(type);
			}
			return GenerateConstructorExpression(type);
		}

		public static Expression GenerateNonNullConstructorExpression(Type type)
		{
			if (!type.IsValueType())
			{
				if (!(type == typeof(string)))
				{
					return GenerateConstructorExpression(type);
				}
				return Expression.Constant(string.Empty);
			}
			return Expression.Default(type);
		}

		public static Expression GenerateConstructorExpression(Type type)
		{
			if (type.IsValueType())
			{
				return Expression.Default(type);
			}
			if (type == typeof(string))
			{
				return Expression.Constant(null, typeof(string));
			}
			if (type.IsInterface())
			{
				if (!type.ImplementsGenericInterface(typeof(IDictionary<, >)))
				{
					if (!type.ImplementsGenericInterface(typeof(ICollection<>)))
					{
						return InvalidType(type, $"Cannot create an instance of interface type {type}.");
					}
					return CreateCollection(type, typeof(List<>));
				}
				return CreateCollection(type, typeof(Dictionary<, >));
			}
			if (type.IsAbstract())
			{
				return InvalidType(type, $"Cannot create an instance of abstract type {type}.");
			}
			ConstructorInfo constructorInfo = (from ci in type.GetDeclaredConstructors()
				where !ci.IsStatic
				select ci).FirstOrDefault((ConstructorInfo c) => c.GetParameters().All((ParameterInfo p) => p.IsOptional));
			if (constructorInfo == null)
			{
				return InvalidType(type, $"{type} needs to have a constructor with 0 args or only optional args.");
			}
			ConstantExpression[] arguments = (from p in constructorInfo.GetParameters()
				select Expression.Constant(p.GetDefaultValue(), p.ParameterType)).ToArray();
			return Expression.New(constructorInfo, arguments);
		}

		private static Expression CreateCollection(Type type, Type collectionType)
		{
			Type type2 = collectionType.MakeGenericType(ElementTypeHelper.GetElementTypes(type, ElementTypeFlags.BreakKeyValuePair));
			if (type.IsAssignableFrom(type2))
			{
				return ExpressionFactory.ToType(Expression.New(type2), type);
			}
			return InvalidType(type, $"Cannot create an instance of interface type {type}.");
		}

		private static Expression InvalidType(Type type, string message)
		{
			return Expression.Block(Expression.Throw(Expression.Constant(new ArgumentException(message, "type"))), Expression.Constant(null, type));
		}
	}
}
