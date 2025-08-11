using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper.QueryableExtensions.Impl
{
	internal class MethodNodeReplacer<TDestination> : ExpressionVisitor
	{
		private readonly MethodCallExpression _foundExpression;

		private static readonly MethodInfo QueryableWhereMethod = FindQueryableWhereMethod();

		public MethodInfo ReplacedMethod
		{
			get;
			private set;
		}

		public MethodInfo ElementOperator
		{
			get;
			private set;
		}

		public bool FoundElementOperator
		{
			get;
			private set;
		}

		private static MethodInfo FindQueryableWhereMethod()
		{
			return ((MethodCallExpression)((Expression<Func<IQueryable<object>>>)(() => ((IQueryable<object>)null).Where((Expression<Func<object, bool>>)null))).Body).Method.GetGenericMethodDefinition();
		}

		public MethodNodeReplacer(MethodCallExpression foundExpression)
		{
			_foundExpression = foundExpression;
		}

		protected override Expression VisitMethodCall(MethodCallExpression node)
		{
			if (ReplacedMethod != null || _foundExpression == null)
			{
				return base.VisitMethodCall(node);
			}
			if (node == _foundExpression)
			{
				ParameterInfo[] parameters = node.Method.GetParameters();
				if (parameters.Length > 1 && typeof(Expression).IsAssignableFrom(parameters[1].ParameterType))
				{
					FoundElementOperator = true;
					ReplacedMethod = node.Method.GetGenericMethodDefinition();
					return Expression.Call(null, QueryableWhereMethod.MakeGenericMethod(typeof(TDestination)), node.Arguments);
				}
				if (parameters.Length == 1)
				{
					FoundElementOperator = true;
					ElementOperator = node.Method.GetGenericMethodDefinition();
					return node.Arguments[0];
				}
			}
			return base.VisitMethodCall(node);
		}
	}
}
