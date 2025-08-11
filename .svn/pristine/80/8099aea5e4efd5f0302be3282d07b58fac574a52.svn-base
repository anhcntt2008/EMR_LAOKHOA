using AutoMapper.Configuration;
using System;
using System.Collections.Generic;

namespace AutoMapper
{
	public class MappingOperationOptions<TSource, TDestination> : IMappingOperationOptions<TSource, TDestination>, IMappingOperationOptions
	{
		private Dictionary<string, object> _items;

		private static readonly Action<TSource, TDestination> Empty = delegate
		{
		};

		public Func<Type, object> ServiceCtor
		{
			get;
			private set;
		}

		public IDictionary<string, object> Items => _items ?? (_items = new Dictionary<string, object>());

		public Action<TSource, TDestination> BeforeMapAction
		{
			get;
			protected set;
		}

		public Action<TSource, TDestination> AfterMapAction
		{
			get;
			protected set;
		}

		public ITypeMapConfiguration InlineConfiguration
		{
			get;
			protected set;
		} = new MappingExpression<TSource, TDestination>(MemberList.Destination);


		public MappingOperationOptions(Func<Type, object> serviceCtor)
		{
			BeforeMapAction = (AfterMapAction = Empty);
			ServiceCtor = serviceCtor;
		}

		public void BeforeMap(Action<TSource, TDestination> beforeFunction)
		{
			BeforeMapAction = beforeFunction;
		}

		public void AfterMap(Action<TSource, TDestination> afterFunction)
		{
			AfterMapAction = afterFunction;
		}

		public IMappingExpression<TSource, TDestination> ConfigureMap()
		{
			return ConfigureMap(MemberList.Destination);
		}

		public IMappingExpression<TSource, TDestination> ConfigureMap(MemberList memberList)
		{
			return (IMappingExpression<TSource, TDestination>)(InlineConfiguration = new MappingExpression<TSource, TDestination>(memberList));
		}

		public T CreateInstance<T>()
		{
			return (T)(ServiceCtor(typeof(T)) ?? throw new AutoMapperMappingException("Cannot create an instance of type " + typeof(T)));
		}

		public void ConstructServicesUsing(Func<Type, object> constructor)
		{
			Func<Type, object> ctor = ServiceCtor;
			ServiceCtor = ((Type t) => constructor(t) ?? ctor(t));
		}

		void IMappingOperationOptions.BeforeMap(Action<object, object> beforeFunction)
		{
			BeforeMapAction = delegate(TSource s, TDestination d)
			{
				beforeFunction(s, d);
			};
		}

		void IMappingOperationOptions.AfterMap(Action<object, object> afterFunction)
		{
			AfterMapAction = delegate(TSource s, TDestination d)
			{
				afterFunction(s, d);
			};
		}
	}
}
