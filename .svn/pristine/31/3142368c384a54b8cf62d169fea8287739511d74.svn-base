using AutoMapper.QueryableExtensions;
using AutoMapper.QueryableExtensions.Impl;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper
{
	public class ConstructorMap
	{
		private readonly IList<ConstructorParameterMap> _ctorParams = new List<ConstructorParameterMap>();

		private static readonly IExpressionResultConverter[] ExpressionResultConverters = new IExpressionResultConverter[2]
		{
			new MemberResolverExpressionResultConverter(),
			new MemberGetterExpressionResultConverter()
		};

		public ConstructorInfo Ctor
		{
			get;
		}

		public TypeMap TypeMap
		{
			get;
		}

		internal IEnumerable<ConstructorParameterMap> CtorParams => _ctorParams;

		public bool CanResolve => CtorParams.All((ConstructorParameterMap param) => param.CanResolve);

		public ConstructorMap(ConstructorInfo ctor, TypeMap typeMap)
		{
			Ctor = ctor;
			TypeMap = typeMap;
		}

		public Expression NewExpression(Expression instanceParameter)
		{
			IEnumerable<ExpressionResolutionResult> source = CtorParams.Select(delegate(ConstructorParameterMap map)
			{
				ExpressionResolutionResult result = new ExpressionResolutionResult(instanceParameter, Ctor.DeclaringType);
				result = (ExpressionResultConverters.FirstOrDefault((IExpressionResultConverter c) => c.CanGetExpressionResolutionResult(result, map))?.GetExpressionResolutionResult(result, map) ?? throw new AutoMapperMappingException($"Unable to generate the instantiation expression for the constructor {Ctor}: no expression could be mapped for constructor parameter '{map.Parameter}'.", null, TypeMap.Types));
				return result;
			});
			return Expression.New(Ctor, source.Select((ExpressionResolutionResult p) => p.ResolutionExpression));
		}

		public void AddParameter(ParameterInfo parameter, MemberInfo[] resolvers, bool canResolve)
		{
			_ctorParams.Add(new ConstructorParameterMap(parameter, resolvers, canResolve));
		}
	}
}
