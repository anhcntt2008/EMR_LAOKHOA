using AutoMapper.XpressionMapper.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace AutoMapper.XpressionMapper.Extensions
{
	internal static class VisitorExtensions
	{
		public static bool IsMemberExpression(this Expression expression)
		{
			if (expression.NodeType == ExpressionType.MemberAccess)
			{
				return IsMemberOrParameterExpression(((MemberExpression)expression).Expression);
			}
			return false;
		}

		private static bool IsMemberOrParameterExpression(Expression expression)
		{
			switch (expression.NodeType)
			{
			case ExpressionType.Parameter:
				return true;
			case ExpressionType.MemberAccess:
				return IsMemberOrParameterExpression(((MemberExpression)expression).Expression);
			default:
				return false;
			}
		}

		public static string GetPropertyFullName(this Expression expression)
		{
			switch (expression.NodeType)
			{
			case ExpressionType.Parameter:
				return string.Empty;
			case ExpressionType.MemberAccess:
			{
				MemberExpression memberExpression = (MemberExpression)expression;
				if (!string.IsNullOrEmpty(memberExpression.Expression.GetPropertyFullName()))
				{
					return memberExpression.Expression.GetPropertyFullName() + "." + memberExpression.Member.Name;
				}
				return memberExpression.Member.Name;
			}
			default:
				throw new InvalidOperationException(Resource.invalidExpErr);
			}
		}

		private static MemberExpression GetMemberExpression(LambdaExpression expr)
		{
			ExpressionType nodeType = expr.Body.NodeType;
			MemberExpression memberExpression;
			if ((uint)(nodeType - 10) <= 1u)
			{
				memberExpression = ((expr.Body as UnaryExpression)?.Operand as MemberExpression);
			}
			else
			{
				memberExpression = (expr.Body as MemberExpression);
				BinaryExpression binaryExpression;
				if (memberExpression == null && (binaryExpression = (expr.Body as BinaryExpression)) != null)
				{
					MemberExpression result;
					if ((result = (binaryExpression.Left as MemberExpression)) != null)
					{
						return result;
					}
					MemberExpression result2;
					if ((result2 = (binaryExpression.Right as MemberExpression)) != null)
					{
						return result2;
					}
				}
			}
			return memberExpression;
		}

		public static ParameterExpression GetParameterExpression(this Expression expression)
		{
			if (expression == null)
			{
				return null;
			}
			switch (expression.NodeType)
			{
			case ExpressionType.Parameter:
				return (ParameterExpression)expression;
			case ExpressionType.Quote:
				return GetMemberExpression((LambdaExpression)((UnaryExpression)expression).Operand).GetParameterExpression();
			case ExpressionType.Lambda:
				return GetMemberExpression((LambdaExpression)expression).GetParameterExpression();
			case ExpressionType.Convert:
			case ExpressionType.ConvertChecked:
				return ((expression as UnaryExpression)?.Operand).GetParameterExpression();
			case ExpressionType.MemberAccess:
				return ((MemberExpression)expression).Expression.GetParameterExpression();
			case ExpressionType.Call:
			{
				MethodCallExpression methodCallExpression = expression as MethodCallExpression;
				MemberExpression memberExpression = methodCallExpression?.Object as MemberExpression;
				bool num = methodCallExpression?.Method.IsDefined(typeof(ExtensionAttribute), inherit: true) ?? false;
				if (num && memberExpression == null && methodCallExpression.Arguments.Count > 0)
				{
					memberExpression = (methodCallExpression.Arguments[0] as MemberExpression);
				}
				if (!num || memberExpression != null || methodCallExpression.Arguments.Count <= 0)
				{
					return memberExpression?.Expression.GetParameterExpression();
				}
				return methodCallExpression.Arguments[0].GetParameterExpression();
			}
			default:
				return null;
			}
		}

		public static MemberExpression MemberAccesses(this Expression exp, List<PropertyMapInfo> list)
		{
			return (MemberExpression)list.SelectMany((PropertyMapInfo propertyMapInfo) => propertyMapInfo.DestinationPropertyInfos).MemberAccesses(exp);
		}

		public static string GetMemberFullName(this LambdaExpression expr)
		{
			if (expr.Body.NodeType == ExpressionType.Parameter)
			{
				return string.Empty;
			}
			ExpressionType nodeType = expr.Body.NodeType;
			MemberExpression expression = ((uint)(nodeType - 10) > 1u) ? (expr.Body as MemberExpression) : ((expr.Body as UnaryExpression)?.Operand as MemberExpression);
			return expression.GetPropertyFullName();
		}

		public static List<Type> GetUnderlyingGenericTypes(this Type type)
		{
			if (!(type == null) && type.GetTypeInfo().IsGenericType)
			{
				return type.GetGenericArguments().ToList();
			}
			return new List<Type>();
		}
	}
}
