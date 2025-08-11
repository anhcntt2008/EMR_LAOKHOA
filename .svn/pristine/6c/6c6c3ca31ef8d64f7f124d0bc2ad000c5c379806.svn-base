using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AutoMapper
{
	public class CtorParamConfigurationExpression<TSource> : ICtorParamConfigurationExpression<TSource>
	{
		private readonly string _ctorParamName;

		private readonly List<Action<ConstructorParameterMap>> _ctorParamActions = new List<Action<ConstructorParameterMap>>();

		public CtorParamConfigurationExpression(string ctorParamName)
		{
			_ctorParamName = ctorParamName;
		}

		public void MapFrom<TMember>(Expression<Func<TSource, TMember>> sourceMember)
		{
			_ctorParamActions.Add(delegate(ConstructorParameterMap cpm)
			{
				cpm.CustomExpression = sourceMember;
			});
		}

		public void ResolveUsing<TMember>(Func<TSource, TMember> resolver)
		{
			Expression<Func<TSource, ResolutionContext, TMember>> resolverExpression = (TSource src, ResolutionContext ctxt) => resolver(src);
			_ctorParamActions.Add(delegate(ConstructorParameterMap cpm)
			{
				cpm.CustomValueResolver = resolverExpression;
			});
		}

		public void ResolveUsing<TMember>(Func<TSource, ResolutionContext, TMember> resolver)
		{
			Expression<Func<TSource, ResolutionContext, TMember>> resolverExpression = (TSource src, ResolutionContext ctxt) => resolver(src, ctxt);
			_ctorParamActions.Add(delegate(ConstructorParameterMap cpm)
			{
				cpm.CustomValueResolver = resolverExpression;
			});
		}

		public void Configure(TypeMap typeMap)
		{
			ConstructorParameterMap constructorParameterMap = (typeMap.ConstructorMap?.CtorParams ?? throw new AutoMapperConfigurationException($"The type {typeMap.Types.DestinationType.Name} does not have a constructor.\n{typeMap.Types.DestinationType.FullName}")).SingleOrDefault((ConstructorParameterMap p) => p.Parameter.Name == _ctorParamName);
			if (constructorParameterMap == null)
			{
				throw new AutoMapperConfigurationException($"{typeMap.Types.DestinationType.Name} does not have a constructor with a parameter named '{_ctorParamName}'.\n{typeMap.Types.DestinationType.FullName}");
			}
			constructorParameterMap.CanResolve = true;
			foreach (Action<ConstructorParameterMap> ctorParamAction in _ctorParamActions)
			{
				ctorParamAction(constructorParameterMap);
			}
		}
	}
}
