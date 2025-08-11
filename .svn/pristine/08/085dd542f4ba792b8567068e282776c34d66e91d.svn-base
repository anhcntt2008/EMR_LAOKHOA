using AutoMapper.Configuration.Internal;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace AutoMapper.Configuration
{
	internal static class PrimitiveExtensions
	{
		public static bool IsSetType(this Type type)
		{
			return type.ImplementsGenericInterface(typeof(ISet<>));
		}

		public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
		{
			return PrimitiveHelper.GetOrDefault(dictionary, key);
		}

		public static MethodInfo GetInheritedMethod(this Type type, string name)
		{
			return PrimitiveHelper.GetInheritedMethod(type, name);
		}

		public static MemberInfo GetFieldOrProperty(this Type type, string name)
		{
			return PrimitiveHelper.GetFieldOrProperty(type, name);
		}

		public static bool IsNullableType(this Type type)
		{
			return PrimitiveHelper.IsNullableType(type);
		}

		public static Type GetTypeOfNullable(this Type type)
		{
			return PrimitiveHelper.GetTypeOfNullable(type);
		}

		public static bool IsCollectionType(this Type type)
		{
			return PrimitiveHelper.IsCollectionType(type);
		}

		public static bool IsEnumerableType(this Type type)
		{
			return PrimitiveHelper.IsEnumerableType(type);
		}

		public static bool IsQueryableType(this Type type)
		{
			return PrimitiveHelper.IsQueryableType(type);
		}

		public static bool IsListType(this Type type)
		{
			return PrimitiveHelper.IsListType(type);
		}

		public static bool IsListOrDictionaryType(this Type type)
		{
			return PrimitiveHelper.IsListOrDictionaryType(type);
		}

		public static bool IsDictionaryType(this Type type)
		{
			return PrimitiveHelper.IsDictionaryType(type);
		}

		public static bool ImplementsGenericInterface(this Type type, Type interfaceType)
		{
			return PrimitiveHelper.ImplementsGenericInterface(type, interfaceType);
		}

		public static bool IsGenericType(this Type type, Type genericType)
		{
			return PrimitiveHelper.IsGenericType(type, genericType);
		}

		public static Type GetIEnumerableType(this Type type)
		{
			return PrimitiveHelper.GetIEnumerableType(type);
		}

		public static Type GetDictionaryType(this Type type)
		{
			return PrimitiveHelper.GetDictionaryType(type);
		}

		public static Type GetGenericInterface(this Type type, Type genericInterface)
		{
			return PrimitiveHelper.GetGenericInterface(type, genericInterface);
		}

		public static Type GetGenericElementType(this Type type)
		{
			return PrimitiveHelper.GetGenericElementType(type);
		}
	}
}
