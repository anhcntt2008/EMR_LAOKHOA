using AutoMapper.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper
{
	internal static class ExpressionExtensions
	{
		public static Expression MemberAccesses(this IEnumerable<MemberInfo> members, Expression obj)
		{
			return members.Aggregate(obj, (Expression expression, MemberInfo member) => Expression.MakeMemberAccess(expression, member));
		}

		public static IEnumerable<MemberExpression> GetMembers(this Expression expression)
		{
			MemberExpression memberExpression = expression as MemberExpression;
			if (memberExpression == null)
			{
				return new MemberExpression[0];
			}
			return memberExpression.GetMembers();
		}

		public static IEnumerable<MemberExpression> GetMembers(this MemberExpression expression)
		{
			while (expression != null)
			{
				yield return expression;
				expression = (expression.Expression as MemberExpression);
			}
		}

		public static bool IsMemberPath(this LambdaExpression exp)
		{
			return exp.Body.GetMembers().LastOrDefault()?.Expression == exp.Parameters.First();
		}

		public static Expression ReplaceParameters(this LambdaExpression exp, params Expression[] replace)
		{
			return ExpressionFactory.ReplaceParameters(exp, replace);
		}

		public static Expression ConvertReplaceParameters(this LambdaExpression exp, params Expression[] replace)
		{
			return ExpressionFactory.ConvertReplaceParameters(exp, replace);
		}

		public static Expression Replace(this Expression exp, Expression old, Expression replace)
		{
			return ExpressionFactory.Replace(exp, old, replace);
		}

		public static LambdaExpression Concat(this LambdaExpression expr, LambdaExpression concat)
		{
			return ExpressionFactory.Concat(expr, concat);
		}

		public static Expression NullCheck(this Expression expression, Type destinationType)
		{
			return ExpressionFactory.NullCheck(expression, destinationType);
		}

		public static Expression IfNullElse(this Expression expression, Expression then, Expression @else = null)
		{
			return ExpressionFactory.IfNullElse(expression, then, @else);
		}
	}
}
