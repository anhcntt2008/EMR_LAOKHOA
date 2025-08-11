using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper.QueryableExtensions.Impl
{
	public class QueryDataSourceInjection<TSource> : IQueryDataSourceInjection<TSource>
	{
		private readonly IQueryable<TSource> _dataSource;

		private readonly IMapper _mapper;

		private readonly List<ExpressionVisitor> _beforeMappingVisitors = new List<ExpressionVisitor>();

		private readonly List<ExpressionVisitor> _afterMappingVisitors = new List<ExpressionVisitor>();

		private readonly ExpressionVisitor _sourceExpressionTracer;

		private readonly ExpressionVisitor _destinationExpressionTracer;

		private Action<Exception> _exceptionHandler = delegate
		{
		};

		private IEnumerable<IEnumerable<MemberInfo>> _membersToExpand;

		private IDictionary<string, object> _parameters;

		private SourceInjectedQueryInspector _inspector;

		public QueryDataSourceInjection(IQueryable<TSource> dataSource, IMapper mapper)
		{
			_dataSource = dataSource;
			_mapper = mapper;
		}

		public ISourceInjectedQueryable<TDestination> For<TDestination>()
		{
			return CreateQueryable<TDestination>();
		}

		public ISourceInjectedQueryable<TDestination> For<TDestination>(object parameters, params Expression<Func<TDestination, object>>[] membersToExpand)
		{
			_parameters = GetParameters(parameters);
			_membersToExpand = ProjectionExpression.GetMemberPaths(membersToExpand);
			return CreateQueryable<TDestination>();
		}

		public ISourceInjectedQueryable<TDestination> For<TDestination>(params Expression<Func<TDestination, object>>[] membersToExpand)
		{
			_membersToExpand = ProjectionExpression.GetMemberPaths(membersToExpand);
			return CreateQueryable<TDestination>();
		}

		public ISourceInjectedQueryable<TDestination> For<TDestination>(IDictionary<string, object> parameters, params string[] membersToExpand)
		{
			_parameters = parameters;
			_membersToExpand = ProjectionExpression.GetMemberPaths(typeof(TDestination), membersToExpand);
			return CreateQueryable<TDestination>();
		}

		public IQueryDataSourceInjection<TSource> UsingInspector(SourceInjectedQueryInspector inspector)
		{
			_inspector = inspector;
			if (_sourceExpressionTracer != null)
			{
				_beforeMappingVisitors.Insert(0, _sourceExpressionTracer);
			}
			if (_destinationExpressionTracer != null)
			{
				_afterMappingVisitors.Add(_destinationExpressionTracer);
			}
			return this;
		}

		public IQueryDataSourceInjection<TSource> BeforeProjection(params ExpressionVisitor[] visitors)
		{
			foreach (ExpressionVisitor item in visitors.Where((ExpressionVisitor visitor) => !_beforeMappingVisitors.Contains(visitor)))
			{
				_beforeMappingVisitors.Add(item);
			}
			return this;
		}

		public IQueryDataSourceInjection<TSource> AfterProjection(params ExpressionVisitor[] visitors)
		{
			foreach (ExpressionVisitor item in visitors.Where((ExpressionVisitor visitor) => !_afterMappingVisitors.Contains(visitor)))
			{
				_afterMappingVisitors.Add(item);
			}
			return this;
		}

		public IQueryDataSourceInjection<TSource> OnError(Action<Exception> exceptionHandler)
		{
			_exceptionHandler = exceptionHandler;
			return this;
		}

		private ISourceInjectedQueryable<TDestination> CreateQueryable<TDestination>()
		{
			return new SourceSourceInjectedQuery<TSource, TDestination>(_dataSource, new TDestination[0].AsQueryable(), _mapper, _beforeMappingVisitors, _afterMappingVisitors, _exceptionHandler, _parameters, _membersToExpand, _inspector);
		}

		private static IDictionary<string, object> GetParameters(object parameters)
		{
			return (parameters ?? new object()).GetType().GetDeclaredProperties().ToDictionary((PropertyInfo pi) => pi.Name, (PropertyInfo pi) => pi.GetValue(parameters, null));
		}
	}
}
