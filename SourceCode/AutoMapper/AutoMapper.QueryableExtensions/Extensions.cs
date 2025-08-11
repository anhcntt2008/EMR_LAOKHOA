using AutoMapper.QueryableExtensions.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AutoMapper.QueryableExtensions
{
	public static class Extensions
	{
		public static IQueryable<TDestination> Map<TSource, TDestination>(this IQueryable<TSource> sourceQuery, IQueryable<TDestination> destQuery)
		{
			return sourceQuery.Map(destQuery, Mapper.Configuration);
		}

		public static IQueryable<TDestination> Map<TSource, TDestination>(this IQueryable<TSource> sourceQuery, IQueryable<TDestination> destQuery, IConfigurationProvider config)
		{
			return QueryMapperVisitor.Map(sourceQuery, destQuery, config);
		}

		[Obsolete("Uses static API internally (Mapper.Configuration) - will be dropped in v5")]
		public static IQueryDataSourceInjection<TSource> UseAsDataSource<TSource>(this IQueryable<TSource> dataSource)
		{
			return dataSource.UseAsDataSource(Mapper.Configuration?.CreateMapper());
		}

		public static IQueryDataSourceInjection<TSource> UseAsDataSource<TSource>(this IQueryable<TSource> dataSource, IConfigurationProvider config)
		{
			return dataSource.UseAsDataSource(config.CreateMapper());
		}

		public static IQueryDataSourceInjection<TSource> UseAsDataSource<TSource>(this IQueryable<TSource> dataSource, IMapper mapper)
		{
			return new QueryDataSourceInjection<TSource>(dataSource, mapper);
		}

		public static IQueryable<TDestination> ProjectTo<TDestination>(this IQueryable source, object parameters, params Expression<Func<TDestination, object>>[] membersToExpand)
		{
			return source.ProjectTo(Mapper.Configuration, parameters, membersToExpand);
		}

		public static IQueryable<TDestination> ProjectTo<TDestination>(this IQueryable source, IConfigurationProvider configuration, object parameters, params Expression<Func<TDestination, object>>[] membersToExpand)
		{
			return new ProjectionExpression(source, configuration.ExpressionBuilder).To(parameters, membersToExpand);
		}

		public static IQueryable<TDestination> ProjectTo<TDestination>(this IQueryable source, IConfigurationProvider configuration, params Expression<Func<TDestination, object>>[] membersToExpand)
		{
			return source.ProjectTo(configuration, null, membersToExpand);
		}

		public static IQueryable<TDestination> ProjectTo<TDestination>(this IQueryable source, params Expression<Func<TDestination, object>>[] membersToExpand)
		{
			return source.ProjectTo(Mapper.Configuration, null, membersToExpand);
		}

		public static IQueryable<TDestination> ProjectTo<TDestination>(this IQueryable source, IDictionary<string, object> parameters, params string[] membersToExpand)
		{
			return source.ProjectTo<TDestination>(Mapper.Configuration, parameters, membersToExpand);
		}

		public static IQueryable<TDestination> ProjectTo<TDestination>(this IQueryable source, IConfigurationProvider configuration, IDictionary<string, object> parameters, params string[] membersToExpand)
		{
			return new ProjectionExpression(source, configuration.ExpressionBuilder).To<TDestination>(parameters, membersToExpand);
		}
	}
}
