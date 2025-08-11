using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoMapper.Configuration.Internal
{
	public static class PrimitiveHelper
	{
		public static TValue GetOrDefault<TKey, TValue>(IDictionary<TKey, TValue> dictionary, TKey key)
		{
			dictionary.TryGetValue(key, out TValue value);
			return value;
		}

		private static IEnumerable<MemberInfo> GetAllMembers(this Type type)
		{
			return type.GetTypeInheritance().Concat(type.GetTypeInfo().ImplementedInterfaces).SelectMany((Type i) => i.GetDeclaredMembers());
		}

		public static MemberInfo GetInheritedMember(this Type type, string name)
		{
			return type.GetAllMembers().FirstOrDefault((MemberInfo mi) => mi.Name == name);
		}

		public static MethodInfo GetInheritedMethod(Type type, string name)
		{
			return (type.GetInheritedMember(name) as MethodInfo) ?? throw new ArgumentOutOfRangeException("name", $"Cannot find method {name} of type {type}.");
		}

		public static MemberInfo GetFieldOrProperty(Type type, string name)
		{
			return type.GetInheritedMember(name) ?? throw new ArgumentOutOfRangeException("name", $"Cannot find member {name} of type {type}.");
		}

		public static bool IsNullableType(Type type)
		{
			return type.IsGenericType(typeof(Nullable<>));
		}

		public static Type GetTypeOfNullable(Type type)
		{
			return type.GetTypeInfo().GenericTypeArguments[0];
		}

		public static bool IsCollectionType(Type type)
		{
			return type.ImplementsGenericInterface(typeof(ICollection<>));
		}

		public static bool IsEnumerableType(Type type)
		{
			return typeof(IEnumerable).IsAssignableFrom(type);
		}

		public static bool IsQueryableType(Type type)
		{
			return typeof(IQueryable).IsAssignableFrom(type);
		}

		public static bool IsListType(Type type)
		{
			return typeof(IList).IsAssignableFrom(type);
		}

		public static bool IsListOrDictionaryType(Type type)
		{
			if (!type.IsListType())
			{
				return type.IsDictionaryType();
			}
			return true;
		}

		public static bool IsDictionaryType(Type type)
		{
			return type.ImplementsGenericInterface(typeof(IDictionary<, >));
		}

		public static bool ImplementsGenericInterface(Type type, Type interfaceType)
		{
			if (!type.IsGenericType(interfaceType))
			{
				return type.GetTypeInfo().ImplementedInterfaces.Any((Type @interface) => @interface.IsGenericType(interfaceType));
			}
			return true;
		}

		public static bool IsGenericType(Type type, Type genericType)
		{
			if (type.IsGenericType())
			{
				return type.GetGenericTypeDefinition() == genericType;
			}
			return false;
		}

		public static Type GetIEnumerableType(Type type)
		{
			return type.GetGenericInterface(typeof(IEnumerable<>));
		}

		public static Type GetDictionaryType(Type type)
		{
			return type.GetGenericInterface(typeof(IDictionary<, >));
		}

		public static Type GetGenericInterface(Type type, Type genericInterface)
		{
			if (!type.IsGenericType(genericInterface))
			{
				return type.GetTypeInfo().ImplementedInterfaces.FirstOrDefault((Type t) => t.IsGenericType(genericInterface));
			}
			return type;
		}

		public static Type GetGenericElementType(Type type)
		{
			if (!type.HasElementType)
			{
				return type.GetTypeInfo().GenericTypeArguments[0];
			}
			return type.GetElementType();
		}
	}
}
