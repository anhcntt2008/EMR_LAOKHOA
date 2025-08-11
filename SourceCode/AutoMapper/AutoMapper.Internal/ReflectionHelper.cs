using AutoMapper.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper.Internal
{
	public static class ReflectionHelper
	{
		public static bool CanBeSet(MemberInfo propertyOrField)
		{
			FieldInfo fieldInfo;
			if ((object)(fieldInfo = (propertyOrField as FieldInfo)) == null)
			{
				return ((PropertyInfo)propertyOrField).CanWrite;
			}
			return !fieldInfo.IsInitOnly;
		}

		public static object GetDefaultValue(ParameterInfo parameter)
		{
			if (parameter.DefaultValue == null && parameter.ParameterType.IsValueType())
			{
				return Activator.CreateInstance(parameter.ParameterType);
			}
			return parameter.DefaultValue;
		}

		public static object MapMember(ResolutionContext context, MemberInfo member, object value, object destination)
		{
			Type memberType = GetMemberType(member);
			object memberValue = GetMemberValue(member, destination);
			return context.Mapper.Map(value, memberValue, value?.GetType() ?? memberType, memberType, context);
		}

		public static object MapMember(ResolutionContext context, MemberInfo member, object value)
		{
			Type memberType = GetMemberType(member);
			return context.Mapper.Map(value, null, value?.GetType() ?? memberType, memberType, context);
		}

		public static bool IsDynamic(object obj)
		{
			return obj is IDynamicMetaObjectProvider;
		}

		public static bool IsDynamic(Type type)
		{
			return typeof(IDynamicMetaObjectProvider).IsAssignableFrom(type);
		}

		public static void SetMemberValue(MemberInfo propertyOrField, object target, object value)
		{
			PropertyInfo propertyInfo;
			if ((object)(propertyInfo = (propertyOrField as PropertyInfo)) != null)
			{
				propertyInfo.SetValue(target, value, null);
				return;
			}
			FieldInfo fieldInfo;
			if ((object)(fieldInfo = (propertyOrField as FieldInfo)) != null)
			{
				fieldInfo.SetValue(target, value);
				return;
			}
			throw Expected(propertyOrField);
		}

		private static ArgumentOutOfRangeException Expected(MemberInfo propertyOrField)
		{
			return new ArgumentOutOfRangeException("propertyOrField", "Expected a property or field, not " + propertyOrField);
		}

		public static object GetMemberValue(MemberInfo propertyOrField, object target)
		{
			PropertyInfo propertyInfo;
			if ((object)(propertyInfo = (propertyOrField as PropertyInfo)) != null)
			{
				return propertyInfo.GetValue(target, null);
			}
			FieldInfo fieldInfo;
			if ((object)(fieldInfo = (propertyOrField as FieldInfo)) != null)
			{
				return fieldInfo.GetValue(target);
			}
			throw Expected(propertyOrField);
		}

		public static IEnumerable<MemberInfo> GetMemberPath(Type type, string fullMemberName)
		{
			MemberInfo property = null;
			string[] array = fullMemberName.Split('.');
			foreach (string name in array)
			{
				Type currentType = GetCurrentType(property, type);
				MemberInfo fieldOrProperty;
				property = (fieldOrProperty = currentType.GetFieldOrProperty(name));
				yield return fieldOrProperty;
			}
		}

		private static Type GetCurrentType(MemberInfo member, Type type)
		{
			Type type2 = member?.GetMemberType() ?? type;
			if (type2.IsGenericType() && typeof(IEnumerable).IsAssignableFrom(type2))
			{
				type2 = type2.GetTypeInfo().GenericTypeArguments[0];
			}
			return type2;
		}

		public static MemberInfo GetFieldOrProperty(LambdaExpression expression)
		{
			MemberExpression memberExpression = expression.Body as MemberExpression;
			if (memberExpression == null)
			{
				throw new ArgumentOutOfRangeException("expression", "Expected a property/field access expression, not " + expression);
			}
			return memberExpression.Member;
		}

		public static MemberInfo FindProperty(LambdaExpression lambdaExpression)
		{
			Expression expression = lambdaExpression;
			bool flag = false;
			while (!flag)
			{
				switch (expression.NodeType)
				{
				case ExpressionType.Convert:
					expression = ((UnaryExpression)expression).Operand;
					break;
				case ExpressionType.Lambda:
					expression = ((LambdaExpression)expression).Body;
					break;
				case ExpressionType.MemberAccess:
				{
					MemberExpression memberExpression = (MemberExpression)expression;
					if (memberExpression.Expression.NodeType != ExpressionType.Parameter && memberExpression.Expression.NodeType != ExpressionType.Convert)
					{
						throw new ArgumentException($"Expression '{lambdaExpression}' must resolve to top-level member and not any child object's properties. You can use ForPath, a custom resolver on the child type or the AfterMap option instead.", "lambdaExpression");
					}
					return memberExpression.Member;
				}
				default:
					flag = true;
					break;
				}
			}
			throw new AutoMapperConfigurationException("Custom configuration for members is only supported for top-level individual members on a type.");
		}

		public static Type GetMemberType(MemberInfo memberInfo)
		{
			if ((object)memberInfo != null)
			{
				MethodInfo methodInfo;
				if ((object)(methodInfo = (memberInfo as MethodInfo)) == null)
				{
					PropertyInfo propertyInfo;
					if ((object)(propertyInfo = (memberInfo as PropertyInfo)) == null)
					{
						FieldInfo fieldInfo;
						if ((object)(fieldInfo = (memberInfo as FieldInfo)) != null)
						{
							return fieldInfo.FieldType;
						}
						throw new ArgumentOutOfRangeException("memberInfo");
					}
					return propertyInfo.PropertyType;
				}
				return methodInfo.ReturnType;
			}
			throw new ArgumentNullException("memberInfo");
		}

		public static Type ReplaceItemType(Type targetType, Type oldType, Type newType)
		{
			if (targetType == oldType)
			{
				return newType;
			}
			if (targetType.IsGenericType())
			{
				Type[] genericTypeArguments = targetType.GetTypeInfo().GenericTypeArguments;
				Type[] array = new Type[genericTypeArguments.Length];
				for (int i = 0; i < genericTypeArguments.Length; i++)
				{
					array[i] = ReplaceItemType(genericTypeArguments[i], oldType, newType);
				}
				return targetType.GetGenericTypeDefinition().MakeGenericType(array);
			}
			return targetType;
		}
	}
}
