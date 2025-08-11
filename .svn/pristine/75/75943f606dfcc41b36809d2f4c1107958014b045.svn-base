using System;
using System.Linq.Expressions;

namespace AutoMapper
{
	public interface IPathConfigurationExpression<TSource, TDestination, TMember>
	{
		void MapFrom<TSourceMember>(Expression<Func<TSource, TSourceMember>> sourceMember);

		void Ignore();

		void Condition(Func<ConditionParameters<TSource, TDestination, TMember>, bool> condition);
	}
}
