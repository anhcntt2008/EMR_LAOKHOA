using System.Linq;
using System.Linq.Expressions;

namespace AutoMapper.QueryableExtensions.Impl
{
	internal class ElementOperatorSearcher : ExpressionVisitor
	{
		public bool ContainsElementOperator
		{
			get;
			private set;
		}

		protected override Expression VisitMethodCall(MethodCallExpression node)
		{
			bool containsElementOperator = node.Method.DeclaringType == typeof(Queryable) && !typeof(IQueryable).IsAssignableFrom(node.Method.ReturnType);
			if (!ContainsElementOperator)
			{
				ContainsElementOperator = containsElementOperator;
			}
			return base.VisitMethodCall(node);
		}
	}
}
