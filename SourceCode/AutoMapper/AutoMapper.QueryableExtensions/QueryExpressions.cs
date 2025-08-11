using System.Linq.Expressions;

namespace AutoMapper.QueryableExtensions
{
	public struct QueryExpressions
	{
		public Expression First
		{
			get;
		}

		public Expression Second
		{
			get;
		}

		public ParameterExpression SecondParameter
		{
			get;
		}

		public QueryExpressions(Expression first, Expression second = null, ParameterExpression secondParameter = null)
		{
			First = first;
			Second = second;
			SecondParameter = secondParameter;
		}
	}
}
