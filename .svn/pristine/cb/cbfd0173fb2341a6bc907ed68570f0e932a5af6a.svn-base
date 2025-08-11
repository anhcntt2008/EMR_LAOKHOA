using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AutoMapper
{
	public interface IMappingExpression
	{
		IList<ValueTransformerConfiguration> ValueTransformers
		{
			get;
		}

		IMappingExpression PreserveReferences();

		IMappingExpression ForCtorParam(string ctorParamName, Action<ICtorParamConfigurationExpression<object>> paramOptions);

		IMappingExpression ReverseMap();

		IMappingExpression Substitute(Func<object, object> substituteFunc);

		IMappingExpression ConstructUsingServiceLocator();

		IMappingExpression MaxDepth(int depth);

		IMappingExpression ConstructProjectionUsing(LambdaExpression ctor);

		IMappingExpression ConstructUsing(Func<object, ResolutionContext, object> ctor);

		IMappingExpression ConstructUsing(Func<object, object> ctor);

		void ProjectUsing(Expression<Func<object, object>> projectionExpression);

		void ForAllMembers(Action<IMemberConfigurationExpression> memberOptions);

		void ForAllOtherMembers(Action<IMemberConfigurationExpression> memberOptions);

		IMappingExpression ForSourceMember(string sourceMemberName, Action<ISourceMemberConfigurationExpression> memberOptions);

		void ConvertUsing<TTypeConverter>();

		void ConvertUsing(Type typeConverterType);

		void As(Type typeOverride);

		IMappingExpression ForMember(string name, Action<IMemberConfigurationExpression> memberOptions);

		IMappingExpression Include(Type derivedSourceType, Type derivedDestinationType);

		IMappingExpression IgnoreAllPropertiesWithAnInaccessibleSetter();

		IMappingExpression IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

		IMappingExpression IncludeBase(Type sourceBase, Type destinationBase);

		IMappingExpression BeforeMap(Action<object, object> beforeFunction);

		IMappingExpression BeforeMap<TMappingAction>() where TMappingAction : IMappingAction<object, object>;

		IMappingExpression AfterMap(Action<object, object> afterFunction);

		IMappingExpression AfterMap<TMappingAction>() where TMappingAction : IMappingAction<object, object>;

		IMappingExpression ValidateMemberList(MemberList memberList);
	}
	public interface IMappingExpression<TSource, TDestination>
	{
		IList<ValueTransformerConfiguration> ValueTransformers
		{
			get;
		}

		IMappingExpression<TSource, TDestination> ForPath<TMember>(Expression<Func<TDestination, TMember>> destinationMember, Action<IPathConfigurationExpression<TSource, TDestination, TMember>> memberOptions);

		IMappingExpression<TSource, TDestination> PreserveReferences();

		void ForAllOtherMembers(Action<IMemberConfigurationExpression<TSource, TDestination, object>> memberOptions);

		IMappingExpression<TSource, TDestination> ForMember<TMember>(Expression<Func<TDestination, TMember>> destinationMember, Action<IMemberConfigurationExpression<TSource, TDestination, TMember>> memberOptions);

		IMappingExpression<TSource, TDestination> ForMember(string name, Action<IMemberConfigurationExpression<TSource, TDestination, object>> memberOptions);

		void ForAllMembers(Action<IMemberConfigurationExpression<TSource, TDestination, object>> memberOptions);

		IMappingExpression<TSource, TDestination> IgnoreAllPropertiesWithAnInaccessibleSetter();

		IMappingExpression<TSource, TDestination> IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

		IMappingExpression<TSource, TDestination> Include<TOtherSource, TOtherDestination>() where TOtherSource : TSource where TOtherDestination : TDestination;

		IMappingExpression<TSource, TDestination> IncludeBase<TSourceBase, TDestinationBase>();

		IMappingExpression<TSource, TDestination> Include(Type derivedSourceType, Type derivedDestinationType);

		void ProjectUsing(Expression<Func<TSource, TDestination>> projectionExpression);

		void ConvertUsing(Func<TSource, TDestination> mappingFunction);

		void ConvertUsing(Func<TSource, TDestination, TDestination> mappingFunction);

		void ConvertUsing(Func<TSource, TDestination, ResolutionContext, TDestination> mappingFunction);

		void ConvertUsing(ITypeConverter<TSource, TDestination> converter);

		void ConvertUsing<TTypeConverter>() where TTypeConverter : ITypeConverter<TSource, TDestination>;

		IMappingExpression<TSource, TDestination> BeforeMap(Action<TSource, TDestination> beforeFunction);

		IMappingExpression<TSource, TDestination> BeforeMap(Action<TSource, TDestination, ResolutionContext> beforeFunction);

		IMappingExpression<TSource, TDestination> BeforeMap<TMappingAction>() where TMappingAction : IMappingAction<TSource, TDestination>;

		IMappingExpression<TSource, TDestination> AfterMap(Action<TSource, TDestination> afterFunction);

		IMappingExpression<TSource, TDestination> AfterMap(Action<TSource, TDestination, ResolutionContext> afterFunction);

		IMappingExpression<TSource, TDestination> AfterMap<TMappingAction>() where TMappingAction : IMappingAction<TSource, TDestination>;

		IMappingExpression<TSource, TDestination> ConstructUsing(Func<TSource, TDestination> ctor);

		IMappingExpression<TSource, TDestination> ConstructProjectionUsing(Expression<Func<TSource, TDestination>> ctor);

		IMappingExpression<TSource, TDestination> ConstructUsing(Func<TSource, ResolutionContext, TDestination> ctor);

		void As<T>() where T : TDestination;

		IMappingExpression<TSource, TDestination> MaxDepth(int depth);

		IMappingExpression<TSource, TDestination> ConstructUsingServiceLocator();

		IMappingExpression<TDestination, TSource> ReverseMap();

		IMappingExpression<TSource, TDestination> ForSourceMember(Expression<Func<TSource, object>> sourceMember, Action<ISourceMemberConfigurationExpression> memberOptions);

		IMappingExpression<TSource, TDestination> ForSourceMember(string sourceMemberName, Action<ISourceMemberConfigurationExpression> memberOptions);

		IMappingExpression<TSource, TDestination> Substitute<TSubstitute>(Func<TSource, TSubstitute> substituteFunc);

		IMappingExpression<TSource, TDestination> ForCtorParam(string ctorParamName, Action<ICtorParamConfigurationExpression<TSource>> paramOptions);

		IMappingExpression<TSource, TDestination> DisableCtorValidation();

		IMappingExpression<TSource, TDestination> AddTransform<TValue>(Expression<Func<TValue, TValue>> transformer);

		IMappingExpression<TSource, TDestination> ValidateMemberList(MemberList memberList);
	}
}
