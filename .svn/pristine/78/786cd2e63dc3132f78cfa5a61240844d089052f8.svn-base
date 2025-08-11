using System;
using System.Linq.Expressions;

namespace AutoMapper.QueryableExtensions.Impl
{
	public class SourceInjectedQueryInspector
	{
		public Action<Expression, object> SourceResult
		{
			get;
			set;
		}

		public Action<object> DestResult
		{
			get;
			set;
		}

		public Action<Type, Expression> StartQueryExecuteInterceptor
		{
			get;
			set;
		}

		public SourceInjectedQueryInspector()
		{
			SourceResult = delegate
			{
			};
			DestResult = delegate
			{
			};
			StartQueryExecuteInterceptor = delegate
			{
			};
		}
	}
}
