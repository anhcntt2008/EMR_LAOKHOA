using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AutoMapper.QueryableExtensions
{
	public interface IProjectionExpression
	{
		IQueryable<TResult> To<TResult>(object parameters = null);

		IQueryable<TResult> To<TResult>(IDictionary<string, object> parameters);

		IQueryable<TResult> To<TResult>(object parameters = null, params string[] membersToExpand);

		IQueryable<TResult> To<TResult>(IDictionary<string, object> parameters, params string[] membersToExpand);

		IQueryable<TResult> To<TResult>(object parameters = null, params Expression<Func<TResult, object>>[] membersToExpand);

		IQueryable<TResult> To<TResult>(IDictionary<string, object> parameters, params Expression<Func<TResult, object>>[] membersToExpand);
	}
}
