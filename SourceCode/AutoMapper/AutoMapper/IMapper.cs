using System;

namespace AutoMapper
{
	public interface IMapper
	{
		IConfigurationProvider ConfigurationProvider
		{
			get;
		}

		Func<Type, object> ServiceCtor
		{
			get;
		}

		TDestination Map<TDestination>(object source);

		TDestination Map<TDestination>(object source, Action<IMappingOperationOptions> opts);

		TDestination Map<TSource, TDestination>(TSource source);

		TDestination Map<TSource, TDestination>(TSource source, Action<IMappingOperationOptions<TSource, TDestination>> opts);

		TDestination Map<TSource, TDestination>(TSource source, TDestination destination);

		TDestination Map<TSource, TDestination>(TSource source, TDestination destination, Action<IMappingOperationOptions<TSource, TDestination>> opts);

		object Map(object source, Type sourceType, Type destinationType);

		object Map(object source, Type sourceType, Type destinationType, Action<IMappingOperationOptions> opts);

		object Map(object source, object destination, Type sourceType, Type destinationType);

		object Map(object source, object destination, Type sourceType, Type destinationType, Action<IMappingOperationOptions> opts);
	}
}
