using AutoMapper.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoMapper.Mappers.Internal
{
	public static class ElementTypeHelper
	{
		public static Type GetElementType(Type enumerableType)
		{
			return GetElementTypes(enumerableType, null)[0];
		}

		public static Type[] GetElementTypes(Type enumerableType, ElementTypeFlags flags = ElementTypeFlags.None)
		{
			return GetElementTypes(enumerableType, null, flags);
		}

		public static Type GetElementType(Type enumerableType, IEnumerable enumerable)
		{
			return GetElementTypes(enumerableType, enumerable)[0];
		}

		public static Type[] GetElementTypes(Type enumerableType, IEnumerable enumerable, ElementTypeFlags flags = ElementTypeFlags.None)
		{
			if (enumerableType.HasElementType)
			{
				return new Type[1]
				{
					enumerableType.GetElementType()
				};
			}
			Type dictionaryType = enumerableType.GetDictionaryType();
			if (dictionaryType != null && flags.HasFlag(ElementTypeFlags.BreakKeyValuePair))
			{
				return dictionaryType.GetTypeInfo().GenericTypeArguments;
			}
			Type iEnumerableType = enumerableType.GetIEnumerableType();
			if (iEnumerableType != null)
			{
				return iEnumerableType.GetTypeInfo().GenericTypeArguments;
			}
			if (typeof(IEnumerable).IsAssignableFrom(enumerableType))
			{
				object obj = enumerable?.Cast<object>().FirstOrDefault();
				return new Type[1]
				{
					obj?.GetType() ?? typeof(object)
				};
			}
			throw new ArgumentException($"Unable to find the element type for type '{enumerableType}'.", "enumerableType");
		}

		public static Type GetEnumerationType(Type enumType)
		{
			if (enumType.IsEnum())
			{
				return enumType;
			}
			return null;
		}

		internal static IEnumerable<MethodInfo> GetStaticMethods(this Type type)
		{
			return from m in type.GetRuntimeMethods()
				where m.IsStatic
				select m;
		}
	}
}
