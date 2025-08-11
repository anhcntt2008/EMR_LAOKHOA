using System;

namespace AutoMapper
{
	public interface IRuntimeMapper : IMapper
	{
		ResolutionContext DefaultContext
		{
			get;
		}

		object Map(object source, object destination, Type sourceType, Type destinationType, ResolutionContext parent);

		TDestination Map<TSource, TDestination>(TSource source, TDestination destination, ResolutionContext parent);
	}
}
