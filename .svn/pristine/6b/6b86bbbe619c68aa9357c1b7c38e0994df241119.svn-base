using System;
using System.Linq.Expressions;

namespace AutoMapper
{
	public interface ICtorParamConfigurationExpression<TSource>
	{
		void MapFrom<TMember>(Expression<Func<TSource, TMember>> sourceMember);

		void ResolveUsing<TMember>(Func<TSource, TMember> resolver);

		void ResolveUsing<TMember>(Func<TSource, ResolutionContext, TMember> resolver);
	}
}
