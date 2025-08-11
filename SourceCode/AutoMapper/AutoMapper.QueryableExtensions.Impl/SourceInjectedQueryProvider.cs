using AutoMapper.Configuration;
using AutoMapper.Mappers;
using AutoMapper.Mappers.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper.QueryableExtensions.Impl
{
	public class SourceInjectedQueryProvider<TSource, TDestination> : IQueryProvider
	{
		private readonly IMapper _mapper;

		private readonly IQueryable<TSource> _dataSource;

		private readonly IQueryable<TDestination> _destQuery;

		private readonly IEnumerable<ExpressionVisitor> _beforeVisitors;

		private readonly IEnumerable<ExpressionVisitor> _afterVisitors;

		private readonly IDictionary<string, object> _parameters;

		private readonly IEnumerable<IEnumerable<MemberInfo>> _membersToExpand;

		private readonly Action<Exception> _exceptionHandler;

		private static readonly MethodInfo QueryableSelectMethod = FindQueryableSelectMethod();

		public SourceInjectedQueryInspector Inspector
		{
			get;
			set;
		}

		internal Action<IEnumerable<object>> EnumerationHandler
		{
			get;
			set;
		}

		public SourceInjectedQueryProvider(IMapper mapper, IQueryable<TSource> dataSource, IQueryable<TDestination> destQuery, IEnumerable<ExpressionVisitor> beforeVisitors, IEnumerable<ExpressionVisitor> afterVisitors, Action<Exception> exceptionHandler, IDictionary<string, object> parameters, IEnumerable<IEnumerable<MemberInfo>> membersToExpand)
		{
			_mapper = mapper;
			_dataSource = dataSource;
			_destQuery = destQuery;
			_beforeVisitors = beforeVisitors;
			_afterVisitors = afterVisitors;
			_parameters = (parameters ?? new Dictionary<string, object>());
			_membersToExpand = (membersToExpand ?? Enumerable.Empty<IEnumerable<MemberInfo>>());
			_exceptionHandler = (exceptionHandler ?? ((Action<Exception>)delegate
			{
			}));
		}

		public IQueryable CreateQuery(Expression expression)
		{
			return new SourceSourceInjectedQuery<TSource, TDestination>(this, expression, EnumerationHandler, _exceptionHandler);
		}

		public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
		{
			return new SourceSourceInjectedQuery<TSource, TElement>(this, expression, EnumerationHandler, _exceptionHandler);
		}

		public object Execute(Expression expression)
		{
			try
			{
				Inspector.StartQueryExecuteInterceptor(null, expression);
				Expression expression2 = ConvertDestinationExpressionToSourceExpression(expression);
				object obj = InvokeSourceQuery(null, expression2);
				Inspector.SourceResult(expression2, obj);
				return obj;
			}
			catch (Exception obj2)
			{
				_exceptionHandler(obj2);
				throw;
			}
		}

		public TResult Execute<TResult>(Expression expression)
		{
			try
			{
				Type typeFromHandle = typeof(TResult);
				Inspector.StartQueryExecuteInterceptor(typeFromHandle, expression);
				Expression expression2 = ConvertDestinationExpressionToSourceExpression(expression);
				Type typeFromHandle2 = typeof(TResult);
				Type type = CreateSourceResultType(typeFromHandle2);
				object obj = null;
				if (IsProjection<TDestination>(typeFromHandle))
				{
					IQueryable queryable = _dataSource.Provider.CreateQuery(expression2);
					Inspector.SourceResult(expression2, queryable);
					obj = new ProjectionExpression((IQueryable<TSource>)queryable, _mapper.ConfigurationProvider.ExpressionBuilder).To<TDestination>(_parameters, _membersToExpand);
				}
				else if (IsProjection(typeFromHandle, expression2))
				{
					IEnumerator enumerator = _dataSource.Provider.CreateQuery(expression2).GetEnumerator();
					Type elementType = ElementTypeHelper.GetElementType(typeof(TResult));
					ConstructorInfo declaredConstructor = typeof(List<>).MakeGenericType(elementType).GetDeclaredConstructor(new Type[0]);
					if (declaredConstructor != null)
					{
						IList list = (IList)declaredConstructor.Invoke(null);
						while (enumerator.MoveNext())
						{
							list.Add(enumerator.Current);
						}
						obj = list;
					}
				}
				else
				{
					ReplaceableMethodNodeFinder<TSource> replaceableMethodNodeFinder = new ReplaceableMethodNodeFinder<TSource>();
					replaceableMethodNodeFinder.Visit(expression2);
					MethodNodeReplacer<TSource> replacer = new MethodNodeReplacer<TSource>(replaceableMethodNodeFinder.MethodNode);
					expression2 = replacer.Visit(expression2);
					if (replacer.FoundElementOperator)
					{
						if (type == typeFromHandle2)
						{
							type = typeof(TSource);
							typeFromHandle2 = typeof(TDestination);
						}
						MemberInfo[] membersToExpand = _membersToExpand.SelectMany((IEnumerable<MemberInfo> m) => m).Distinct().ToArray();
						Expression expression3 = _mapper.ConfigurationProvider.ExpressionBuilder.GetMapExpression(type, typeFromHandle2, _parameters, membersToExpand).Aggregate(expression2, (Expression source, LambdaExpression lambda) => Select(source, lambda));
						MethodInfo methodInfo = replacer.ElementOperator;
						if (replacer.ReplacedMethod != null)
						{
							methodInfo = typeof(Queryable).GetAllMethods().Single((MethodInfo m) => m.Name == replacer.ReplacedMethod.Name && m.GetParameters().All((ParameterInfo p) => typeof(Queryable).IsAssignableFrom(p.Member.ReflectedType)) && m.GetParameters().Length == replacer.ReplacedMethod.GetParameters().Length - 1);
						}
						expression3 = Expression.Call(null, methodInfo.MakeGenericMethod(typeFromHandle2), expression3);
						obj = _dataSource.Provider.Execute(expression3);
					}
					else
					{
						object obj2 = _dataSource.Provider.Execute(expression2);
						Inspector.SourceResult(expression2, obj2);
						obj = _mapper.Map(obj2, type, typeFromHandle2);
					}
				}
				Inspector.DestResult(obj);
				if (typeof(TResult).IsValueType() && obj?.GetType() != typeof(TResult))
				{
					return (TResult)Convert.ChangeType(obj, typeof(TResult));
				}
				return (TResult)obj;
			}
			catch (Exception obj3)
			{
				_exceptionHandler(obj3);
				throw;
			}
		}

		private static Expression Select(Expression source, LambdaExpression lambda)
		{
			return Expression.Call(null, QueryableSelectMethod.MakeGenericMethod(lambda.Parameters[0].Type, lambda.ReturnType), new Expression[2]
			{
				source,
				Expression.Quote(lambda)
			});
		}

		private object InvokeSourceQuery(Type sourceResultType, Expression sourceExpression)
		{
			if (!IsProjection<TSource>(sourceResultType))
			{
				return _dataSource.Provider.Execute(sourceExpression);
			}
			return _dataSource.Provider.CreateQuery(sourceExpression);
		}

		private static bool IsProjection<T>(Type resultType)
		{
			if (IsProjection(resultType))
			{
				return resultType.GetGenericElementType() == typeof(T);
			}
			return false;
		}

		private static bool IsProjection(Type resultType, Expression sourceExpression)
		{
			if (!IsProjection(resultType))
			{
				return false;
			}
			ElementOperatorSearcher elementOperatorSearcher = new ElementOperatorSearcher();
			elementOperatorSearcher.Visit(sourceExpression);
			return !elementOperatorSearcher.ContainsElementOperator;
		}

		private static bool IsProjection(Type resultType)
		{
			if (resultType.IsEnumerableType() && !resultType.IsQueryableType())
			{
				return resultType != typeof(string);
			}
			return false;
		}

		private static Type CreateSourceResultType(Type destResultType)
		{
			return destResultType.ReplaceItemType(typeof(TDestination), typeof(TSource));
		}

		private Expression ConvertDestinationExpressionToSourceExpression(Expression expression)
		{
			expression = _beforeVisitors.Aggregate(expression, (Expression current, ExpressionVisitor before) => before.Visit(current));
			TypeMap typeMap = _mapper.ConfigurationProvider.ResolveTypeMap(typeof(TDestination), typeof(TSource));
			Expression expression2 = new ExpressionMapper.MappingVisitor(_mapper.ConfigurationProvider, typeMap, _destQuery.Expression, _dataSource.Expression, null, new Type[1]
			{
				typeof(TSource)
			}).Visit(expression);
			if (_parameters != null && _parameters.Any())
			{
				expression2 = new ExpressionBuilder.ConstantExpressionReplacementVisitor(_parameters).Visit(expression2);
			}
			if (_mapper.ConfigurationProvider.EnableNullPropagationForQueryMapping)
			{
				expression2 = new ExpressionBuilder.NullsafeQueryRewriter().Visit(expression2);
			}
			return _afterVisitors.Aggregate(expression2, (Expression current, ExpressionVisitor after) => after.Visit(current));
		}

		private static MethodInfo FindQueryableSelectMethod()
		{
			return ((MethodCallExpression)((Expression<Func<IQueryable<object>>>)(() => ((IQueryable<object>)null).Select((Expression<Func<object, object>>)null))).Body).Method.GetGenericMethodDefinition();
		}
	}
}
