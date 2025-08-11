using AutoMapper.Internal;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper
{
	internal static class ReflectionExtensions
	{
		public static object GetDefaultValue(this ParameterInfo parameter)
		{
			return ReflectionHelper.GetDefaultValue(parameter);
		}

		public static object MapMember(this ResolutionContext context, MemberInfo member, object value, object destination)
		{
			return ReflectionHelper.MapMember(context, member, value, destination);
		}

		public static object MapMember(this ResolutionContext context, MemberInfo member, object value)
		{
			return ReflectionHelper.MapMember(context, member, value);
		}

		public static bool IsDynamic(this object obj)
		{
			return ReflectionHelper.IsDynamic(obj);
		}

		public static bool IsDynamic(this Type type)
		{
			return ReflectionHelper.IsDynamic(type);
		}

		public static void SetMemberValue(this MemberInfo propertyOrField, object target, object value)
		{
			ReflectionHelper.SetMemberValue(propertyOrField, target, value);
		}

		public static object GetMemberValue(this MemberInfo propertyOrField, object target)
		{
			return ReflectionHelper.GetMemberValue(propertyOrField, target);
		}

		public static IEnumerable<MemberInfo> GetMemberPath(Type type, string fullMemberName)
		{
			return ReflectionHelper.GetMemberPath(type, fullMemberName);
		}

		public static MemberInfo GetFieldOrProperty(this LambdaExpression expression)
		{
			return ReflectionHelper.GetFieldOrProperty(expression);
		}

		public static MemberInfo FindProperty(LambdaExpression lambdaExpression)
		{
			return ReflectionHelper.FindProperty(lambdaExpression);
		}

		public static Type GetMemberType(this MemberInfo memberInfo)
		{
			return ReflectionHelper.GetMemberType(memberInfo);
		}

		public static Type ReplaceItemType(this Type targetType, Type oldType, Type newType)
		{
			return ReflectionHelper.ReplaceItemType(targetType, oldType, newType);
		}

		public static IEnumerable<TypeInfo> GetDefinedTypes(this Assembly assembly)
		{
			return assembly.DefinedTypes;
		}

		public static bool GetHasDefaultValue(this ParameterInfo info)
		{
			return info.HasDefaultValue;
		}

		public static bool GetIsConstructedGenericType(this Type type)
		{
			return type.IsConstructedGenericType;
		}
	}
}
