using AutoMapper.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper.QueryableExtensions
{
	public class ProjectionExpression : IProjectionExpression
	{
		private static readonly MethodInfo QueryableSelectMethod = FindQueryableSelectMethod();

		private readonly IQueryable _source;

		private readonly IExpressionBuilder _builder;

		public ProjectionExpression(IQueryable source, IExpressionBuilder builder)
		{
			_source = source;
			_builder = builder;
		}

		private static MethodInfo FindQueryableSelectMethod()
		{
			return ((MethodCallExpression)((Expression<Func<IQueryable<object>>>)(() => ((IQueryable<object>)null).Select((Expression<Func<object, object>>)null))).Body).Method.GetGenericMethodDefinition();
		}

		public IQueryable<TResult> To<TResult>(object parameters = null)
		{
			return To<TResult>(parameters, new string[0]);
		}

		public IQueryable<TResult> To<TResult>(object parameters = null, params string[] membersToExpand)
		{
			IDictionary<string, object> parameters2 = GetParameters(parameters);
			return To<TResult>(parameters2, membersToExpand);
		}

		private static IDictionary<string, object> GetParameters(object parameters)
		{
			return (parameters ?? new object()).GetType().GetDeclaredProperties().ToDictionary((PropertyInfo pi) => pi.Name, (PropertyInfo pi) => pi.GetValue(parameters, null));
		}

		public IQueryable<TResult> To<TResult>(IDictionary<string, object> parameters)
		{
			return To<TResult>(parameters, new string[0]);
		}

		public IQueryable<TResult> To<TResult>(IDictionary<string, object> parameters, params string[] membersToExpand)
		{
			IEnumerable<IEnumerable<MemberInfo>> memberPaths = GetMemberPaths(typeof(TResult), membersToExpand);
			return To<TResult>(parameters, memberPaths);
		}

		public IQueryable<TResult> To<TResult>(object parameters = null, params Expression<Func<TResult, object>>[] membersToExpand)
		{
			return To<TResult>(GetParameters(parameters), GetMemberPaths(membersToExpand));
		}

		public static IEnumerable<IEnumerable<MemberInfo>> GetMemberPaths(Type type, string[] membersToExpand)
		{
			return membersToExpand.Select((string m) => ReflectionHelper.GetMemberPath(type, m));
		}

		public static IEnumerable<IEnumerable<MemberInfo>> GetMemberPaths<TResult>(Expression<Func<TResult, object>>[] membersToExpand)
		{
			return membersToExpand.Select((Expression<Func<TResult, object>> expr) => MemberVisitor.GetMemberPath(expr));
		}

		public IQueryable<TResult> To<TResult>(IDictionary<string, object> parameters, params Expression<Func<TResult, object>>[] membersToExpand)
		{
			IEnumerable<IEnumerable<MemberInfo>> memberPaths = GetMemberPaths(membersToExpand);
			return To<TResult>(parameters, memberPaths);
		}

		internal IQueryable<TResult> To<TResult>(IDictionary<string, object> parameters, IEnumerable<IEnumerable<MemberInfo>> memberPathsToExpand)
		{
			MemberInfo[] membersToExpand = memberPathsToExpand.SelectMany((IEnumerable<MemberInfo> m) => m).Distinct().ToArray();
			parameters = (parameters ?? new Dictionary<string, object>());
			return (IQueryable<TResult>)_builder.GetMapExpression(_source.ElementType, typeof(TResult), parameters, membersToExpand).Aggregate(_source, (IQueryable source, LambdaExpression lambda) => Select(source, lambda));
		}

		private static IQueryable Select(IQueryable source, LambdaExpression lambda)
		{
			return source.Provider.CreateQuery(Expression.Call(null, QueryableSelectMethod.MakeGenericMethod(source.ElementType, lambda.ReturnType), new Expression[2]
			{
				source.Expression,
				Expression.Quote(lambda)
			}));
		}
	}
}
