using System;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper
{
	public interface IMemberConfigurationExpression<TSource, TDestination, TMember>
	{
		MemberInfo DestinationMember
		{
			get;
		}

		void MapAtRuntime();

		void NullSubstitute(object nullSubstitute);

		void ResolveUsing<TValueResolver>() where TValueResolver : IValueResolver<TSource, TDestination, TMember>;

		void ResolveUsing<TValueResolver, TSourceMember>(Expression<Func<TSource, TSourceMember>> sourceMember) where TValueResolver : IMemberValueResolver<TSource, TDestination, TSourceMember, TMember>;

		void ResolveUsing<TValueResolver, TSourceMember>(string sourceMemberName) where TValueResolver : IMemberValueResolver<TSource, TDestination, TSourceMember, TMember>;

		void ResolveUsing(IValueResolver<TSource, TDestination, TMember> valueResolver);

		void ResolveUsing<TSourceMember>(IMemberValueResolver<TSource, TDestination, TSourceMember, TMember> valueResolver, Expression<Func<TSource, TSourceMember>> sourceMember);

		void ResolveUsing<TResult>(Func<TSource, TResult> resolver);

		void ResolveUsing<TResult>(Func<TSource, TDestination, TResult> resolver);

		void ResolveUsing<TResult>(Func<TSource, TDestination, TMember, TResult> resolver);

		void ResolveUsing<TResult>(Func<TSource, TDestination, TMember, ResolutionContext, TResult> resolver);

		void MapFrom<TSourceMember>(Expression<Func<TSource, TSourceMember>> sourceMember);

		void MapFrom(string property);

		void Ignore();

		void AllowNull();

		void SetMappingOrder(int mappingOrder);

		void UseDestinationValue();

		void UseValue<TValue>(TValue value);

		void Condition(Func<TSource, TDestination, TMember, TMember, ResolutionContext, bool> condition);

		void Condition(Func<TSource, TDestination, TMember, TMember, bool> condition);

		void Condition(Func<TSource, TDestination, TMember, bool> condition);

		void Condition(Func<TSource, TDestination, bool> condition);

		void Condition(Func<TSource, bool> condition);

		void PreCondition(Func<TSource, bool> condition);

		void PreCondition(Func<ResolutionContext, bool> condition);

		void PreCondition(Func<TSource, ResolutionContext, bool> condition);

		void ExplicitExpansion();

		void AddTransform(Expression<Func<TMember, TMember>> transformer);
	}
	public interface IMemberConfigurationExpression : IMemberConfigurationExpression<object, object, object>
	{
		void ResolveUsing(Type valueResolverType);

		void ResolveUsing(Type valueResolverType, string memberName);

		void ResolveUsing<TSource, TDestination, TSourceMember, TDestMember>(IMemberValueResolver<TSource, TDestination, TSourceMember, TDestMember> valueResolver, string memberName);
	}
}
