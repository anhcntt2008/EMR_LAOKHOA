using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace AutoMapper
{
	internal static class TypeExtensions
	{
		public static bool Has<TAttribute>(this Type type) where TAttribute : Attribute
		{
			return type.GetTypeInfo().IsDefined(typeof(TAttribute), inherit: false);
		}

		public static Type GetGenericTypeDefinitionIfGeneric(this Type type)
		{
			if (!type.IsGenericType())
			{
				return type;
			}
			return type.GetGenericTypeDefinition();
		}

		public static Type[] GetGenericArguments(this Type type)
		{
			return type.GetTypeInfo().GenericTypeArguments;
		}

		public static Type[] GetGenericParameters(this Type type)
		{
			return type.GetGenericTypeDefinition().GetTypeInfo().GenericTypeParameters;
		}

		public static IEnumerable<ConstructorInfo> GetDeclaredConstructors(this Type type)
		{
			return type.GetTypeInfo().DeclaredConstructors;
		}

		public static Type CreateType(this TypeBuilder type)
		{
			return type.CreateTypeInfo().AsType();
		}

		public static IEnumerable<MemberInfo> GetDeclaredMembers(this Type type)
		{
			return type.GetTypeInfo().DeclaredMembers;
		}

		public static IEnumerable<Type> GetTypeInheritance(this Type type)
		{
			yield return type;
			Type baseType = type.BaseType();
			while (baseType != null)
			{
				yield return baseType;
				baseType = baseType.BaseType();
			}
		}

		public static IEnumerable<MethodInfo> GetDeclaredMethods(this Type type)
		{
			return type.GetTypeInfo().DeclaredMethods;
		}

		public static MethodInfo GetDeclaredMethod(this Type type, string name)
		{
			return type.GetAllMethods().FirstOrDefault((MethodInfo mi) => mi.Name == name);
		}

		public static MethodInfo GetDeclaredMethod(this Type type, string name, Type[] parameters)
		{
			return (from mi in type.GetAllMethods()
				where mi.Name == name
				select mi).MatchParameters(parameters);
		}

		public static ConstructorInfo GetDeclaredConstructor(this Type type, Type[] parameters)
		{
			return type.GetDeclaredConstructors().MatchParameters(parameters);
		}

		private static TMethod MatchParameters<TMethod>(this IEnumerable<TMethod> methods, Type[] parameters) where TMethod : MethodBase
		{
			return methods.FirstOrDefault((TMethod mi) => (from pi in mi.GetParameters()
				select pi.ParameterType).SequenceEqual(parameters));
		}

		public static IEnumerable<MethodInfo> GetAllMethods(this Type type)
		{
			return type.GetRuntimeMethods();
		}

		public static IEnumerable<PropertyInfo> GetDeclaredProperties(this Type type)
		{
			return type.GetTypeInfo().DeclaredProperties;
		}

		public static PropertyInfo GetDeclaredProperty(this Type type, string name)
		{
			return type.GetTypeInfo().GetDeclaredProperty(name);
		}

		public static object[] GetCustomAttributes(this Type type, Type attributeType, bool inherit)
		{
			return type.GetTypeInfo().GetCustomAttributes(attributeType, inherit).Cast<object>()
				.ToArray();
		}

		public static bool IsStatic(this FieldInfo fieldInfo)
		{
			return fieldInfo?.IsStatic ?? false;
		}

		public static bool IsStatic(this PropertyInfo propertyInfo)
		{
			return propertyInfo?.GetGetMethod(nonPublic: true)?.IsStatic ?? propertyInfo?.GetSetMethod(nonPublic: true)?.IsStatic ?? false;
		}

		public static bool IsStatic(this MemberInfo memberInfo)
		{
			if (!(memberInfo as FieldInfo).IsStatic() && !(memberInfo as PropertyInfo).IsStatic())
			{
				return (memberInfo as MethodInfo)?.IsStatic ?? false;
			}
			return true;
		}

		public static bool IsPublic(this PropertyInfo propertyInfo)
		{
			if (!(propertyInfo?.GetGetMethod(nonPublic: true)?.IsPublic ?? false))
			{
				return propertyInfo?.GetSetMethod(nonPublic: true)?.IsPublic ?? false;
			}
			return true;
		}

		public static IEnumerable<PropertyInfo> PropertiesWithAnInaccessibleSetter(this Type type)
		{
			return from pm in type.GetDeclaredProperties()
				where pm.HasAnInaccessibleSetter()
				select pm;
		}

		public static bool HasAnInaccessibleSetter(this PropertyInfo property)
		{
			MethodInfo setMethod = property.GetSetMethod(nonPublic: true);
			if (!(setMethod == null) && !setMethod.IsPrivate)
			{
				return setMethod.IsFamily;
			}
			return true;
		}

		public static bool IsPublic(this MemberInfo memberInfo)
		{
			return (memberInfo as FieldInfo)?.IsPublic ?? (memberInfo as PropertyInfo).IsPublic();
		}

		public static bool IsNotPublic(this ConstructorInfo constructorInfo)
		{
			if (!constructorInfo.IsPrivate && !constructorInfo.IsFamilyAndAssembly && !constructorInfo.IsFamilyOrAssembly)
			{
				return constructorInfo.IsFamily;
			}
			return true;
		}

		public static Assembly Assembly(this Type type)
		{
			return type.GetTypeInfo().Assembly;
		}

		public static Type BaseType(this Type type)
		{
			return type.GetTypeInfo().BaseType;
		}

		public static bool IsAssignableFrom(this Type type, Type other)
		{
			return type.GetTypeInfo().IsAssignableFrom(other.GetTypeInfo());
		}

		public static bool IsAbstract(this Type type)
		{
			return type.GetTypeInfo().IsAbstract;
		}

		public static bool IsClass(this Type type)
		{
			return type.GetTypeInfo().IsClass;
		}

		public static bool IsEnum(this Type type)
		{
			return type.GetTypeInfo().IsEnum;
		}

		public static bool IsGenericType(this Type type)
		{
			return type.GetTypeInfo().IsGenericType;
		}

		public static bool IsGenericTypeDefinition(this Type type)
		{
			return type.GetTypeInfo().IsGenericTypeDefinition;
		}

		public static bool IsInterface(this Type type)
		{
			return type.GetTypeInfo().IsInterface;
		}

		public static bool IsPrimitive(this Type type)
		{
			return type.GetTypeInfo().IsPrimitive;
		}

		public static bool IsSealed(this Type type)
		{
			return type.GetTypeInfo().IsSealed;
		}

		public static bool IsValueType(this Type type)
		{
			return type.GetTypeInfo().IsValueType;
		}

		public static bool IsLiteralType(this Type type)
		{
			if (!(type == typeof(string)))
			{
				return type.GetTypeInfo().IsValueType;
			}
			return true;
		}

		public static bool IsInstanceOfType(this Type type, object o)
		{
			if (o != null)
			{
				return type.GetTypeInfo().IsAssignableFrom(o.GetType().GetTypeInfo());
			}
			return false;
		}

		public static PropertyInfo[] GetProperties(this Type type)
		{
			return type.GetRuntimeProperties().ToArray();
		}

		public static MethodInfo GetGetMethod(this PropertyInfo propertyInfo, bool ignored)
		{
			return propertyInfo.GetMethod;
		}

		public static MethodInfo GetSetMethod(this PropertyInfo propertyInfo, bool ignored)
		{
			return propertyInfo.SetMethod;
		}

		public static MethodInfo GetGetMethod(this PropertyInfo propertyInfo)
		{
			return propertyInfo.GetMethod;
		}

		public static MethodInfo GetSetMethod(this PropertyInfo propertyInfo)
		{
			return propertyInfo.SetMethod;
		}

		public static FieldInfo GetField(this Type type, string name)
		{
			return type.GetRuntimeField(name);
		}
	}
}
