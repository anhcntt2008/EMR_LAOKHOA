using System;
using System.Linq.Expressions;

namespace AutoMapper
{
	public interface IResolutionExpression<TSource> : IResolutionExpression
	{
		void FromMember(Expression<Func<TSource, object>> sourceMember);
	}
	public interface IResolutionExpression
	{
		void FromMember(string sourcePropertyName);
	}
}
