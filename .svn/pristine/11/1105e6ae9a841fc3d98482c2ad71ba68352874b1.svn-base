using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AutoMapper.QueryableExtensions.Impl
{
	public interface IQueryDataSourceInjection<TSource>
	{
		ISourceInjectedQueryable<TDestination> For<TDestination>();

		ISourceInjectedQueryable<TDestination> For<TDestination>(object parameters, params Expression<Func<TDestination, object>>[] membersToExpand);

		ISourceInjectedQueryable<TDestination> For<TDestination>(params Expression<Func<TDestination, object>>[] membersToExpand);

		ISourceInjectedQueryable<TDestination> For<TDestination>(IDictionary<string, object> parameters, params string[] membersToExpand);

		IQueryDataSourceInjection<TSource> UsingInspector(SourceInjectedQueryInspector inspector);

		IQueryDataSourceInjection<TSource> BeforeProjection(params ExpressionVisitor[] visitors);

		IQueryDataSourceInjection<TSource> AfterProjection(params ExpressionVisitor[] visitors);

		IQueryDataSourceInjection<TSource> OnError(Action<Exception> exceptionHandler);
	}
}
