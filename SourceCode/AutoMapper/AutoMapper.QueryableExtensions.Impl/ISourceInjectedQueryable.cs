using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AutoMapper.QueryableExtensions.Impl
{
	public interface ISourceInjectedQueryable<out T> : IQueryable<T>, IEnumerable<T>, IEnumerable, IQueryable
	{
		IQueryable<T> OnEnumerated(Action<IEnumerable<object>> enumerationHandler);

		IQueryable<T> AsQueryable();
	}
}
