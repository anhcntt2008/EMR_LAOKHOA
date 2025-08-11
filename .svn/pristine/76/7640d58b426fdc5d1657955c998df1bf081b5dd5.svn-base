using AutoMapper.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper.Configuration
{
	public class PathConfigurationExpression<TSource, TDestination, TMember> : IPathConfigurationExpression<TSource, TDestination, TMember>, IPropertyMapConfiguration
	{
		private readonly LambdaExpression _destinationExpression;

		private LambdaExpression _sourceExpression;

		protected List<Action<PathMap>> PathMapActions
		{
			get;
		} = new List<Action<PathMap>>();


		public MemberPath MemberPath
		{
			get;
		}

		public MemberInfo DestinationMember => MemberPath.Last;

		public PathConfigurationExpression(LambdaExpression destinationExpression)
		{
			_destinationExpression = destinationExpression;
			MemberPath = new MemberPath(MemberVisitor.GetMemberPath(destinationExpression).Reverse());
		}

		public void MapFrom<TSourceMember>(Expression<Func<TSource, TSourceMember>> sourceExpression)
		{
			MapFromUntyped(sourceExpression);
		}

		public void Ignore()
		{
			PathMapActions.Add(delegate(PathMap pm)
			{
				pm.Ignored = true;
			});
		}

		public void MapFromUntyped(LambdaExpression sourceExpression)
		{
			_sourceExpression = sourceExpression;
			PathMapActions.Add(delegate(PathMap pm)
			{
				pm.SourceExpression = sourceExpression;
				pm.Ignored = false;
			});
		}

		public void Configure(TypeMap typeMap)
		{
			PathMap pathMap = typeMap.FindOrCreatePathMapFor(_destinationExpression, MemberPath, typeMap);
			Apply(pathMap);
		}

		private void Apply(PathMap pathMap)
		{
			foreach (Action<PathMap> pathMapAction in PathMapActions)
			{
				pathMapAction(pathMap);
			}
		}

		internal static IPropertyMapConfiguration Create(LambdaExpression destination, LambdaExpression source)
		{
			if (destination == null || !destination.IsMemberPath())
			{
				return null;
			}
			PathConfigurationExpression<TSource, TDestination, object> pathConfigurationExpression = new PathConfigurationExpression<TSource, TDestination, object>(destination);
			if (pathConfigurationExpression.MemberPath.Length == 1)
			{
				MemberConfigurationExpression<TSource, TDestination, object> memberConfigurationExpression = new MemberConfigurationExpression<TSource, TDestination, object>(pathConfigurationExpression.DestinationMember, typeof(TSource));
				memberConfigurationExpression.MapFromUntyped(source);
				return memberConfigurationExpression;
			}
			pathConfigurationExpression.MapFromUntyped(source);
			return pathConfigurationExpression;
		}

		public IPropertyMapConfiguration Reverse()
		{
			return Create(_sourceExpression, _destinationExpression);
		}

		public void Condition(Func<ConditionParameters<TSource, TDestination, TMember>, bool> condition)
		{
			PathMapActions.Add(delegate(PathMap pm)
			{
				Expression<Func<TSource, TDestination, TMember, TMember, ResolutionContext, bool>> expression = (Expression<Func<TSource, TDestination, TMember, TMember, ResolutionContext, bool>>)(pm.Condition = (Expression<Func<TSource, TDestination, TMember, TMember, ResolutionContext, bool>>)((TSource src, TDestination dest, TMember srcMember, TMember destMember, ResolutionContext ctxt) => condition(new ConditionParameters<TSource, TDestination, TMember>(src, dest, srcMember, destMember, ctxt))));
			});
		}
	}
}
