using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper.Configuration
{
	public class MemberConfigurationExpression<TSource, TDestination, TMember> : IMemberConfigurationExpression<TSource, TDestination, TMember>, IPropertyMapConfiguration
	{
		private readonly MemberInfo _destinationMember;

		private LambdaExpression _sourceMember;

		private readonly Type _sourceType;

		protected List<Action<PropertyMap>> PropertyMapActions
		{
			get;
		} = new List<Action<PropertyMap>>();


		public MemberInfo DestinationMember => _destinationMember;

		public MemberConfigurationExpression(MemberInfo destinationMember, Type sourceType)
		{
			_destinationMember = destinationMember;
			_sourceType = sourceType;
		}

		public void MapAtRuntime()
		{
			PropertyMapActions.Add(delegate(PropertyMap pm)
			{
				pm.Inline = false;
			});
		}

		public void NullSubstitute(object nullSubstitute)
		{
			PropertyMapActions.Add(delegate(PropertyMap pm)
			{
				pm.NullSubstitute = nullSubstitute;
			});
		}

		public void ResolveUsing<TValueResolver>() where TValueResolver : IValueResolver<TSource, TDestination, TMember>
		{
			ValueResolverConfiguration config = new ValueResolverConfiguration(typeof(TValueResolver), typeof(IValueResolver<TSource, TDestination, TMember>));
			PropertyMapActions.Add(delegate(PropertyMap pm)
			{
				pm.ValueResolverConfig = config;
			});
		}

		public void ResolveUsing<TValueResolver, TSourceMember>(Expression<Func<TSource, TSourceMember>> sourceMember) where TValueResolver : IMemberValueResolver<TSource, TDestination, TSourceMember, TMember>
		{
			ValueResolverConfiguration config = new ValueResolverConfiguration(typeof(TValueResolver), typeof(IMemberValueResolver<TSource, TDestination, TSourceMember, TMember>))
			{
				SourceMember = sourceMember
			};
			PropertyMapActions.Add(delegate(PropertyMap pm)
			{
				pm.ValueResolverConfig = config;
			});
		}

		public void ResolveUsing<TValueResolver, TSourceMember>(string sourceMemberName) where TValueResolver : IMemberValueResolver<TSource, TDestination, TSourceMember, TMember>
		{
			ValueResolverConfiguration config = new ValueResolverConfiguration(typeof(TValueResolver), typeof(IMemberValueResolver<TSource, TDestination, TSourceMember, TMember>))
			{
				SourceMemberName = sourceMemberName
			};
			PropertyMapActions.Add(delegate(PropertyMap pm)
			{
				pm.ValueResolverConfig = config;
			});
		}

		public void ResolveUsing(IValueResolver<TSource, TDestination, TMember> valueResolver)
		{
			ValueResolverConfiguration config = new ValueResolverConfiguration(valueResolver, typeof(IValueResolver<TSource, TDestination, TMember>));
			PropertyMapActions.Add(delegate(PropertyMap pm)
			{
				pm.ValueResolverConfig = config;
			});
		}

		public void ResolveUsing<TSourceMember>(IMemberValueResolver<TSource, TDestination, TSourceMember, TMember> valueResolver, Expression<Func<TSource, TSourceMember>> sourceMember)
		{
			ValueResolverConfiguration config = new ValueResolverConfiguration(valueResolver, typeof(IMemberValueResolver<TSource, TDestination, TSourceMember, TMember>))
			{
				SourceMember = sourceMember
			};
			PropertyMapActions.Add(delegate(PropertyMap pm)
			{
				pm.ValueResolverConfig = config;
			});
		}

		public void ResolveUsing<TResult>(Func<TSource, TResult> resolver)
		{
			PropertyMapActions.Add(delegate(PropertyMap pm)
			{
				Expression<Func<TSource, TDestination, TMember, ResolutionContext, TResult>> expression = (Expression<Func<TSource, TDestination, TMember, ResolutionContext, TResult>>)(pm.CustomResolver = (Expression<Func<TSource, TDestination, TMember, ResolutionContext, TResult>>)((TSource src, TDestination dest, TMember destMember, ResolutionContext ctxt) => resolver(src)));
			});
		}

		public void ResolveUsing<TResult>(Func<TSource, TDestination, TResult> resolver)
		{
			PropertyMapActions.Add(delegate(PropertyMap pm)
			{
				Expression<Func<TSource, TDestination, TMember, ResolutionContext, TResult>> expression = (Expression<Func<TSource, TDestination, TMember, ResolutionContext, TResult>>)(pm.CustomResolver = (Expression<Func<TSource, TDestination, TMember, ResolutionContext, TResult>>)((TSource src, TDestination dest, TMember destMember, ResolutionContext ctxt) => resolver(src, dest)));
			});
		}

		public void ResolveUsing<TResult>(Func<TSource, TDestination, TMember, TResult> resolver)
		{
			PropertyMapActions.Add(delegate(PropertyMap pm)
			{
				Expression<Func<TSource, TDestination, TMember, ResolutionContext, TResult>> expression = (Expression<Func<TSource, TDestination, TMember, ResolutionContext, TResult>>)(pm.CustomResolver = (Expression<Func<TSource, TDestination, TMember, ResolutionContext, TResult>>)((TSource src, TDestination dest, TMember destMember, ResolutionContext ctxt) => resolver(src, dest, destMember)));
			});
		}

		public void ResolveUsing<TResult>(Func<TSource, TDestination, TMember, ResolutionContext, TResult> resolver)
		{
			PropertyMapActions.Add(delegate(PropertyMap pm)
			{
				Expression<Func<TSource, TDestination, TMember, ResolutionContext, TResult>> expression = (Expression<Func<TSource, TDestination, TMember, ResolutionContext, TResult>>)(pm.CustomResolver = (Expression<Func<TSource, TDestination, TMember, ResolutionContext, TResult>>)((TSource src, TDestination dest, TMember destMember, ResolutionContext ctxt) => resolver(src, dest, destMember, ctxt)));
			});
		}

		public void MapFrom<TSourceMember>(Expression<Func<TSource, TSourceMember>> sourceMember)
		{
			MapFromUntyped(sourceMember);
		}

		internal void MapFromUntyped(LambdaExpression sourceExpression)
		{
			_sourceMember = sourceExpression;
			PropertyMapActions.Add(delegate(PropertyMap pm)
			{
				pm.MapFrom(sourceExpression);
			});
		}

		public void MapFrom(string sourceMember)
		{
			_sourceType.GetFieldOrProperty(sourceMember);
			PropertyMapActions.Add(delegate(PropertyMap pm)
			{
				pm.CustomSourceMemberName = sourceMember;
			});
		}

		public void UseValue<TValue>(TValue value)
		{
			MapFrom((TSource s) => value);
		}

		public void Condition(Func<TSource, TDestination, TMember, TMember, ResolutionContext, bool> condition)
		{
			PropertyMapActions.Add(delegate(PropertyMap pm)
			{
				Expression<Func<TSource, TDestination, TMember, TMember, ResolutionContext, bool>> expression = (Expression<Func<TSource, TDestination, TMember, TMember, ResolutionContext, bool>>)(pm.Condition = (Expression<Func<TSource, TDestination, TMember, TMember, ResolutionContext, bool>>)((TSource src, TDestination dest, TMember srcMember, TMember destMember, ResolutionContext ctxt) => condition(src, dest, srcMember, destMember, ctxt)));
			});
		}

		public void Condition(Func<TSource, TDestination, TMember, TMember, bool> condition)
		{
			PropertyMapActions.Add(delegate(PropertyMap pm)
			{
				Expression<Func<TSource, TDestination, TMember, TMember, ResolutionContext, bool>> expression = (Expression<Func<TSource, TDestination, TMember, TMember, ResolutionContext, bool>>)(pm.Condition = (Expression<Func<TSource, TDestination, TMember, TMember, ResolutionContext, bool>>)((TSource src, TDestination dest, TMember srcMember, TMember destMember, ResolutionContext ctxt) => condition(src, dest, srcMember, destMember)));
			});
		}

		public void Condition(Func<TSource, TDestination, TMember, bool> condition)
		{
			PropertyMapActions.Add(delegate(PropertyMap pm)
			{
				Expression<Func<TSource, TDestination, TMember, TMember, ResolutionContext, bool>> expression = (Expression<Func<TSource, TDestination, TMember, TMember, ResolutionContext, bool>>)(pm.Condition = (Expression<Func<TSource, TDestination, TMember, TMember, ResolutionContext, bool>>)((TSource src, TDestination dest, TMember srcMember, TMember destMember, ResolutionContext ctxt) => condition(src, dest, srcMember)));
			});
		}

		public void Condition(Func<TSource, TDestination, bool> condition)
		{
			PropertyMapActions.Add(delegate(PropertyMap pm)
			{
				Expression<Func<TSource, TDestination, TMember, TMember, ResolutionContext, bool>> expression = (Expression<Func<TSource, TDestination, TMember, TMember, ResolutionContext, bool>>)(pm.Condition = (Expression<Func<TSource, TDestination, TMember, TMember, ResolutionContext, bool>>)((TSource src, TDestination dest, TMember srcMember, TMember destMember, ResolutionContext ctxt) => condition(src, dest)));
			});
		}

		public void Condition(Func<TSource, bool> condition)
		{
			PropertyMapActions.Add(delegate(PropertyMap pm)
			{
				Expression<Func<TSource, TDestination, TMember, TMember, ResolutionContext, bool>> expression = (Expression<Func<TSource, TDestination, TMember, TMember, ResolutionContext, bool>>)(pm.Condition = (Expression<Func<TSource, TDestination, TMember, TMember, ResolutionContext, bool>>)((TSource src, TDestination dest, TMember srcMember, TMember destMember, ResolutionContext ctxt) => condition(src)));
			});
		}

		public void PreCondition(Func<TSource, bool> condition)
		{
			PropertyMapActions.Add(delegate(PropertyMap pm)
			{
				Expression<Func<TSource, ResolutionContext, bool>> expression = (Expression<Func<TSource, ResolutionContext, bool>>)(pm.PreCondition = (Expression<Func<TSource, ResolutionContext, bool>>)((TSource src, ResolutionContext ctxt) => condition(src)));
			});
		}

		public void PreCondition(Func<ResolutionContext, bool> condition)
		{
			PropertyMapActions.Add(delegate(PropertyMap pm)
			{
				Expression<Func<TSource, ResolutionContext, bool>> expression = (Expression<Func<TSource, ResolutionContext, bool>>)(pm.PreCondition = (Expression<Func<TSource, ResolutionContext, bool>>)((TSource src, ResolutionContext ctxt) => condition(ctxt)));
			});
		}

		public void PreCondition(Func<TSource, ResolutionContext, bool> condition)
		{
			PropertyMapActions.Add(delegate(PropertyMap pm)
			{
				Expression<Func<TSource, ResolutionContext, bool>> expression = (Expression<Func<TSource, ResolutionContext, bool>>)(pm.PreCondition = (Expression<Func<TSource, ResolutionContext, bool>>)((TSource src, ResolutionContext ctxt) => condition(src, ctxt)));
			});
		}

		public void AddTransform(Expression<Func<TMember, TMember>> transformer)
		{
			PropertyMapActions.Add(delegate(PropertyMap pm)
			{
				ValueTransformerConfiguration valueTransformerConfiguration = new ValueTransformerConfiguration(typeof(TMember), transformer);
				pm.AddValueTransformation(valueTransformerConfiguration);
			});
		}

		public void ExplicitExpansion()
		{
			PropertyMapActions.Add(delegate(PropertyMap pm)
			{
				pm.ExplicitExpansion = true;
			});
		}

		public void Ignore()
		{
			Ignore(ignorePaths: true);
		}

		internal void Ignore(bool ignorePaths)
		{
			PropertyMapActions.Add(delegate(PropertyMap pm)
			{
				pm.Ignored = true;
				if (ignorePaths)
				{
					pm.TypeMap.IgnorePaths(DestinationMember);
				}
			});
		}

		public void AllowNull()
		{
			PropertyMapActions.Add(delegate(PropertyMap pm)
			{
				pm.AllowNull = true;
			});
		}

		public void UseDestinationValue()
		{
			PropertyMapActions.Add(delegate(PropertyMap pm)
			{
				pm.UseDestinationValue = true;
			});
		}

		public void SetMappingOrder(int mappingOrder)
		{
			PropertyMapActions.Add(delegate(PropertyMap pm)
			{
				pm.MappingOrder = mappingOrder;
			});
		}

		public void Configure(TypeMap typeMap)
		{
			MemberInfo destMember = _destinationMember;
			if (destMember.DeclaringType.IsGenericType())
			{
				destMember = typeMap.DestinationTypeDetails.PublicReadAccessors.Single((MemberInfo m) => m.Name == destMember.Name);
			}
			PropertyMap propertyMap = typeMap.FindOrCreatePropertyMapFor(destMember);
			Apply(propertyMap);
		}

		private void Apply(PropertyMap propertyMap)
		{
			foreach (Action<PropertyMap> propertyMapAction in PropertyMapActions)
			{
				propertyMapAction(propertyMap);
			}
		}

		public IPropertyMapConfiguration Reverse()
		{
			ParameterExpression parameterExpression = Expression.Parameter(DestinationMember.DeclaringType, "source");
			LambdaExpression source = Expression.Lambda(Expression.MakeMemberAccess(parameterExpression, _destinationMember), parameterExpression);
			return PathConfigurationExpression<TDestination, TSource, object>.Create(_sourceMember, source);
		}
	}
}
