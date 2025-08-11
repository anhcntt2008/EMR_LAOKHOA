using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper.QueryableExtensions.Impl
{
	public class QueryMapperVisitor : ExpressionVisitor
	{
		private readonly IQueryable _destQuery;

		private readonly ParameterExpression _instanceParameter;

		private readonly Type _sourceType;

		private readonly Type _destinationType;

		private readonly Stack<object> _tree = new Stack<object>();

		private readonly Stack<object> _newTree = new Stack<object>();

		private readonly MemberAccessQueryMapperVisitor _memberVisitor;

		internal QueryMapperVisitor(Type sourceType, Type destinationType, IQueryable destQuery, IConfigurationProvider config)
		{
			_sourceType = sourceType;
			_destinationType = destinationType;
			_destQuery = destQuery;
			_instanceParameter = Expression.Parameter(destinationType, "dto");
			_memberVisitor = new MemberAccessQueryMapperVisitor(this, config);
		}

		public static IQueryable<TDestination> Map<TSource, TDestination>(IQueryable<TSource> sourceQuery, IQueryable<TDestination> destQuery, IConfigurationProvider config)
		{
			Expression expression = new QueryMapperVisitor(typeof(TSource), typeof(TDestination), destQuery, config).Visit(sourceQuery.Expression);
			return destQuery.Provider.CreateQuery<TDestination>(expression);
		}

		public override Expression Visit(Expression node)
		{
			_tree.Push(node);
			if (node != null && node.NodeType == (ExpressionType)10000)
			{
				return node;
			}
			Expression expression = base.Visit(node);
			_newTree.Push(expression);
			return expression;
		}

		protected override Expression VisitParameter(ParameterExpression node)
		{
			return _instanceParameter;
		}

		protected override Expression VisitConstant(ConstantExpression node)
		{
			IQueryable queryable;
			if ((queryable = (node.Value as IQueryable)) != null && queryable.ElementType == _sourceType)
			{
				return _destQuery.Expression;
			}
			return node;
		}

		protected override Expression VisitBinary(BinaryExpression node)
		{
			Expression expression = Visit(node.Left);
			Expression expression2 = Visit(node.Right);
			if (expression.Type != expression2.Type && expression2.NodeType == ExpressionType.Constant)
			{
				expression2 = Expression.Constant(Convert.ChangeType(((ConstantExpression)expression2).Value, expression.Type, CultureInfo.CurrentCulture), expression.Type);
			}
			return Expression.MakeBinary(node.NodeType, expression, expression2);
		}

		protected override Expression VisitLambda<T>(Expression<T> node)
		{
			Expression expression = Visit(node.Body);
			IEnumerable<ParameterExpression> parameters = node.Parameters.Select((ParameterExpression p) => (ParameterExpression)Visit(p));
			return Expression.Lambda(ChangeLambdaArgTypeFormSourceToDest(node.Type, expression.Type), expression, parameters);
		}

		protected override Expression VisitMethodCall(MethodCallExpression node)
		{
			if (node.Method.Name == "OrderBy" || node.Method.Name == "OrderByDescending" || node.Method.Name == "ThenBy" || node.Method.Name == "ThenByDescending")
			{
				return VisitOrderBy(node);
			}
			List<Expression> arguments = node.Arguments.Select(Visit).ToList();
			Expression instance = Visit(node.Object);
			MethodInfo method = ChangeMethodArgTypeFormSourceToDest(node.Method);
			return Expression.Call(instance, method, arguments);
		}

		private Expression VisitOrderBy(MethodCallExpression node)
		{
			Expression node2 = node.Arguments[0];
			Expression node3 = node.Arguments[1];
			Expression arg = Visit(node2);
			Expression expression = Visit(node3);
			Expression instance = Visit(node.Object);
			MethodInfo genericMethodDefinition = node.Method.GetGenericMethodDefinition();
			Type[] genericArguments = node.Method.GetGenericArguments();
			genericArguments[0] = genericArguments[0].ReplaceItemType(_sourceType, _destinationType);
			UnaryExpression unaryExpression;
			if ((unaryExpression = (expression as UnaryExpression)) != null && unaryExpression.Operand.Type.IsGenericType())
			{
				genericArguments[1] = genericArguments[1].ReplaceItemType(typeof(string), unaryExpression.Operand.Type.GetGenericArguments().Last());
			}
			else
			{
				genericArguments[1] = genericArguments[1].ReplaceItemType(typeof(string), typeof(int));
			}
			MethodInfo method = genericMethodDefinition.MakeGenericMethod(genericArguments);
			return Expression.Call(instance, method, arg, expression);
		}

		protected override Expression VisitMember(MemberExpression node)
		{
			return _memberVisitor.Visit(node);
		}

		private MethodInfo ChangeMethodArgTypeFormSourceToDest(MethodInfo mi)
		{
			if (!mi.IsGenericMethod)
			{
				return mi;
			}
			MethodInfo genericMethodDefinition = mi.GetGenericMethodDefinition();
			Type[] genericArguments = mi.GetGenericArguments();
			genericArguments = genericArguments.Select((Type t) => t.ReplaceItemType(_sourceType, _destinationType)).ToArray();
			return genericMethodDefinition.MakeGenericMethod(genericArguments);
		}

		private Type ChangeLambdaArgTypeFormSourceToDest(Type lambdaType, Type returnType)
		{
			if (lambdaType.IsGenericType())
			{
				Type[] array = lambdaType.GetTypeInfo().GenericTypeArguments.Select((Type t) => t.ReplaceItemType(_sourceType, _destinationType)).ToArray();
				Type genericTypeDefinition = lambdaType.GetGenericTypeDefinition();
				if (genericTypeDefinition.FullName.StartsWith("System.Func"))
				{
					array[array.Length - 1] = returnType;
				}
				return genericTypeDefinition.MakeGenericType(array);
			}
			return lambdaType;
		}
	}
}
