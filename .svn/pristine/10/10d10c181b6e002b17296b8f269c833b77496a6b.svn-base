using AutoMapper.Configuration;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper.Internal
{
	public static class ExpressionFactory
	{
		internal class ConvertingVisitor : ExpressionVisitor
		{
			private readonly Expression _newParam;

			private readonly ParameterExpression _oldParam;

			public ConvertingVisitor(ParameterExpression oldParam, Expression newParam)
			{
				_newParam = newParam;
				_oldParam = oldParam;
			}

			protected override Expression VisitMember(MemberExpression node)
			{
				if (node.Expression == _oldParam)
				{
					node = Expression.MakeMemberAccess(ToType(_newParam, _oldParam.Type), node.Member);
				}
				return base.VisitMember(node);
			}

			protected override Expression VisitParameter(ParameterExpression node)
			{
				if (node != _oldParam)
				{
					return base.VisitParameter(node);
				}
				return ToType(_newParam, _oldParam.Type);
			}

			protected override Expression VisitMethodCall(MethodCallExpression node)
			{
				if (node.Object == _oldParam)
				{
					node = Expression.Call(ToType(_newParam, _oldParam.Type), node.Method, node.Arguments);
				}
				return base.VisitMethodCall(node);
			}
		}

		internal class ReplaceExpressionVisitor : ExpressionVisitor
		{
			private readonly Expression _oldExpression;

			private readonly Expression _newExpression;

			public ReplaceExpressionVisitor(Expression oldExpression, Expression newExpression)
			{
				_oldExpression = oldExpression;
				_newExpression = newExpression;
			}

			public override Expression Visit(Expression node)
			{
				if (_oldExpression == node)
				{
					node = _newExpression;
				}
				return base.Visit(node);
			}
		}

		internal class ExpressionConcatVisitor : ExpressionVisitor
		{
			private readonly LambdaExpression _overrideExpression;

			public ExpressionConcatVisitor(LambdaExpression overrideExpression)
			{
				_overrideExpression = overrideExpression;
			}

			public override Expression Visit(Expression node)
			{
				if (_overrideExpression == null)
				{
					return node;
				}
				if (node.NodeType != ExpressionType.Lambda && node.NodeType != ExpressionType.Parameter)
				{
					Expression expression = node;
					if (node.Type == typeof(object))
					{
						expression = Expression.Convert(node, _overrideExpression.Parameters[0].Type);
					}
					return ReplaceParameters(_overrideExpression, expression);
				}
				return base.Visit(node);
			}

			protected override Expression VisitLambda<T>(Expression<T> node)
			{
				return Expression.Lambda(Visit(node.Body), node.Parameters);
			}
		}

		public static MemberExpression MemberAccesses(string members, Expression obj)
		{
			return (MemberExpression)ReflectionHelper.GetMemberPath(obj.Type, members).MemberAccesses(obj);
		}

		public static Expression GetSetter(MemberExpression memberExpression)
		{
			MemberInfo member = memberExpression.Member;
			if (!ReflectionHelper.CanBeSet(member))
			{
				return null;
			}
			return Expression.MakeMemberAccess(memberExpression.Expression, member);
		}

		public static MethodInfo Method<T>(Expression<Func<T>> expression)
		{
			return GetExpressionBodyMethod(expression);
		}

		public static MethodInfo Method<TType, TResult>(Expression<Func<TType, TResult>> expression)
		{
			return GetExpressionBodyMethod(expression);
		}

		private static MethodInfo GetExpressionBodyMethod(LambdaExpression expression)
		{
			return ((MethodCallExpression)expression.Body).Method;
		}

		public static Expression ForEach(Expression collection, ParameterExpression loopVar, Expression loopContent)
		{
			if (collection.Type.IsArray)
			{
				return ForEachArrayItem(collection, (Expression arrayItem) => Expression.Block(new ParameterExpression[1]
				{
					loopVar
				}, Expression.Assign(loopVar, arrayItem), loopContent));
			}
			MethodInfo inheritedMethod = collection.Type.GetInheritedMethod("GetEnumerator");
			MethodCallExpression methodCallExpression = Expression.Call(collection, inheritedMethod);
			Type type = methodCallExpression.Type;
			ParameterExpression parameterExpression = Expression.Variable(type, "enumerator");
			BinaryExpression binaryExpression = Expression.Assign(parameterExpression, methodCallExpression);
			MethodInfo inheritedMethod2 = type.GetInheritedMethod("MoveNext");
			MethodCallExpression left = Expression.Call(parameterExpression, inheritedMethod2);
			LabelTarget labelTarget = Expression.Label("LoopBreak");
			return Expression.Block(new ParameterExpression[1]
			{
				parameterExpression
			}, binaryExpression, Expression.Loop(Expression.IfThenElse(Expression.Equal(left, Expression.Constant(true)), Expression.Block(new ParameterExpression[1]
			{
				loopVar
			}, Expression.Assign(loopVar, ToType(Expression.Property(parameterExpression, "Current"), loopVar.Type)), loopContent), Expression.Break(labelTarget)), labelTarget));
		}

		public static Expression ForEachArrayItem(Expression array, Func<Expression, Expression> body)
		{
			return For(Expression.Property(array, "Length"), (Expression index) => body(Expression.ArrayAccess(array, index)));
		}

		public static Expression For(Expression count, Func<Expression, Expression> body)
		{
			LabelTarget labelTarget = Expression.Label("LoopBreak");
			ParameterExpression parameterExpression = Expression.Variable(typeof(int), "sourceArrayIndex");
			BinaryExpression binaryExpression = Expression.Assign(parameterExpression, Expression.Constant(0, typeof(int)));
			return Expression.Block(new ParameterExpression[1]
			{
				parameterExpression
			}, binaryExpression, Expression.Loop(Expression.IfThenElse(Expression.LessThan(parameterExpression, count), Expression.Block(body(parameterExpression), Expression.PostIncrementAssign(parameterExpression)), Expression.Break(labelTarget)), labelTarget));
		}

		public static Expression ToObject(Expression expression)
		{
			return ToType(expression, typeof(object));
		}

		public static Expression ToType(Expression expression, Type type)
		{
			if (!(expression.Type == type))
			{
				return Expression.Convert(expression, type);
			}
			return expression;
		}

		public static Expression ReplaceParameters(LambdaExpression exp, params Expression[] replace)
		{
			Expression expression = exp.Body;
			for (int i = 0; i < Math.Min(replace.Length, exp.Parameters.Count); i++)
			{
				expression = Replace(expression, exp.Parameters[i], replace[i]);
			}
			return expression;
		}

		public static Expression ConvertReplaceParameters(LambdaExpression exp, params Expression[] replace)
		{
			Expression expression = exp.Body;
			for (int i = 0; i < Math.Min(replace.Length, exp.Parameters.Count); i++)
			{
				expression = new ConvertingVisitor(exp.Parameters[i], replace[i]).Visit(expression);
			}
			return expression;
		}

		public static Expression Replace(Expression exp, Expression old, Expression replace)
		{
			return new ReplaceExpressionVisitor(old, replace).Visit(exp);
		}

		public static LambdaExpression Concat(LambdaExpression expr, LambdaExpression concat)
		{
			return (LambdaExpression)new ExpressionConcatVisitor(expr).Visit(concat);
		}

		public static Expression NullCheck(Expression expression, Type destinationType)
		{
			Expression target = expression;
			Expression nullConditions = Expression.Constant(false);
			while (true)
			{
				MemberExpression memberExpression;
				if ((memberExpression = (target as MemberExpression)) != null)
				{
					target = memberExpression.Expression;
					NullCheck();
					continue;
				}
				MethodCallExpression methodCallExpression;
				if ((methodCallExpression = (target as MethodCallExpression)) == null)
				{
					break;
				}
				target = (methodCallExpression.Method.IsStatic() ? methodCallExpression.Arguments.FirstOrDefault() : methodCallExpression.Object);
				NullCheck();
			}
			Expression expression2 = target;
			if (expression2 != null && expression2.NodeType == ExpressionType.Parameter)
			{
				Type type = (Nullable.GetUnderlyingType(destinationType) == expression.Type) ? destinationType : expression.Type;
				return Expression.Condition(nullConditions, Expression.Default(type), ToType(expression, type));
			}
			return expression;
			void NullCheck()
			{
				if (target != null && !target.Type.IsValueType())
				{
					nullConditions = Expression.OrElse(Expression.Equal(target, Expression.Constant(null, target.Type)), nullConditions);
				}
			}
		}

		public static Expression IfNullElse(Expression expression, Expression then, Expression @else = null)
		{
			Expression expression2 = ToType(@else ?? Expression.Default(then.Type), then.Type);
			if (expression.Type.IsValueType() && !expression.Type.IsNullableType())
			{
				return expression2;
			}
			return Expression.Condition(Expression.Equal(expression, Expression.Constant(null)), then, expression2);
		}
	}
}
