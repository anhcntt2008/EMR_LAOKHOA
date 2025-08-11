using System.Linq;
using System.Linq.Expressions;

namespace AutoMapper.QueryableExtensions.Impl
{
	internal class ReplaceableMethodNodeFinder<TDestination> : ExpressionVisitor
	{
		private bool _ignoredMethodFound;

		private static readonly string[] IgnoredMethods = new string[1]
		{
			"Select"
		};

		public MethodCallExpression MethodNode
		{
			get;
			private set;
		}

		protected override Expression VisitMethodCall(MethodCallExpression node)
		{
			if (_ignoredMethodFound)
			{
				return base.VisitMethodCall(node);
			}
			bool flag = node.Method.DeclaringType == typeof(Queryable) && !IgnoredMethods.Contains(node.Method.Name) && !typeof(IQueryable).IsAssignableFrom(node.Method.ReturnType);
			if (flag && !node.Method.ReturnType.IsPrimitive() && node.Method.ReturnType != typeof(TDestination))
			{
				return base.VisitMethodCall(node);
			}
			if (flag)
			{
				MethodNode = node;
			}
			else if (IgnoredMethods.Contains(node.Method.Name))
			{
				_ignoredMethodFound = true;
				MethodNode = null;
			}
			return base.VisitMethodCall(node);
		}
	}
}
