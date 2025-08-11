using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper.QueryableExtensions.Impl
{
	public class SourceSourceInjectedQuery<TSource, TDestination> : IOrderedQueryable<TDestination>, IQueryable<TDestination>, IEnumerable<TDestination>, IEnumerable, IQueryable, IOrderedQueryable, ISourceInjectedQueryable<TDestination>
	{
		private readonly Action<Exception> _exceptionHandler;

		internal Action<IEnumerable<object>> EnumerationHandler
		{
			get;
			set;
		}

		internal IDictionary<string, object> Parameters
		{
			get;
			set;
		}

		public Type ElementType
		{
			get;
		}

		public Expression Expression
		{
			get;
		}

		public IQueryProvider Provider
		{
			get;
		}

		public SourceSourceInjectedQuery(IQueryable<TSource> dataSource, IQueryable<TDestination> destQuery, IMapper mapper, IEnumerable<ExpressionVisitor> beforeVisitors, IEnumerable<ExpressionVisitor> afterVisitors, Action<Exception> exceptionHandler, IDictionary<string, object> parameters, IEnumerable<IEnumerable<MemberInfo>> membersToExpand, SourceInjectedQueryInspector inspector)
		{
			Parameters = parameters;
			EnumerationHandler = delegate
			{
			};
			Expression = destQuery.Expression;
			ElementType = typeof(TDestination);
			Provider = new SourceInjectedQueryProvider<TSource, TDestination>(mapper, dataSource, destQuery, beforeVisitors, afterVisitors, exceptionHandler, parameters, membersToExpand)
			{
				Inspector = (inspector ?? new SourceInjectedQueryInspector())
			};
			_exceptionHandler = (exceptionHandler ?? ((Action<Exception>)delegate
			{
			}));
		}

		internal SourceSourceInjectedQuery(IQueryProvider provider, Expression expression, Action<IEnumerable<object>> enumerationHandler, Action<Exception> exceptionHandler)
		{
			_exceptionHandler = (exceptionHandler ?? ((Action<Exception>)delegate
			{
			}));
			Provider = provider;
			Expression = expression;
			EnumerationHandler = (enumerationHandler ?? ((Action<IEnumerable<object>>)delegate
			{
			}));
			ElementType = typeof(TDestination);
		}

		public IQueryable<TDestination> OnEnumerated(Action<IEnumerable<object>> enumerationHandler)
		{
			EnumerationHandler = (enumerationHandler ?? ((Action<IEnumerable<object>>)delegate
			{
			}));
			((SourceInjectedQueryProvider<TSource, TDestination>)Provider).EnumerationHandler = EnumerationHandler;
			return this;
		}

		public IQueryable<TDestination> AsQueryable()
		{
			return this;
		}

		public IEnumerator<TDestination> GetEnumerator()
		{
			try
			{
				object[] array = Provider.Execute<IEnumerable<TDestination>>(Expression).Cast<object>().ToArray();
				EnumerationHandler(array);
				return array.Cast<TDestination>().GetEnumerator();
			}
			catch (Exception obj)
			{
				_exceptionHandler(obj);
				throw;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
