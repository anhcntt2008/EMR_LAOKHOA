using System;
using System.Linq.Expressions;

namespace AutoMapper
{
	public interface IResolverConfigurationExpression<TSource>
	{
		void FromMember(Expression<Func<TSource, object>> sourceMember);

		void FromMember(string sourcePropertyName);
	}
}
