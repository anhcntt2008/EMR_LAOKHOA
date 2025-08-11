using System;
using System.Collections.Generic;

namespace AutoMapper
{
	public interface IMappingOperationOptions
	{
		Func<Type, object> ServiceCtor
		{
			get;
		}

		IDictionary<string, object> Items
		{
			get;
		}

		T CreateInstance<T>();

		void ConstructServicesUsing(Func<Type, object> constructor);

		void BeforeMap(Action<object, object> beforeFunction);

		void AfterMap(Action<object, object> afterFunction);
	}
	public interface IMappingOperationOptions<TSource, TDestination> : IMappingOperationOptions
	{
		void BeforeMap(Action<TSource, TDestination> beforeFunction);

		void AfterMap(Action<TSource, TDestination> afterFunction);

		IMappingExpression<TSource, TDestination> ConfigureMap();

		IMappingExpression<TSource, TDestination> ConfigureMap(MemberList memberList);
	}
}
