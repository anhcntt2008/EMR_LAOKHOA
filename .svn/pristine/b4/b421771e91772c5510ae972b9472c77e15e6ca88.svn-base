using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper.QueryableExtensions
{
	public static class ExpressionBuilderExtensions
	{
		public static Expression<Func<TSource, TDestination>> GetMapExpression<TSource, TDestination>(this IExpressionBuilder expressionBuilder)
		{
			return (Expression<Func<TSource, TDestination>>)expressionBuilder.GetMapExpression(typeof(TSource), typeof(TDestination), new Dictionary<string, object>(), new MemberInfo[0])[0];
		}
	}
}
