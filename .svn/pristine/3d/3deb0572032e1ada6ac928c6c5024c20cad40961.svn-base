using AutoMapper.Configuration;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AutoMapper
{
	public interface IConfigurationProvider
	{
		Func<Type, object> ServiceCtor
		{
			get;
		}

		bool EnableNullPropagationForQueryMapping
		{
			get;
		}

		int MaxExecutionPlanDepth
		{
			get;
		}

		IExpressionBuilder ExpressionBuilder
		{
			get;
		}

		void Validate(ValidationContext context);

		TypeMap[] GetAllTypeMaps();

		TypeMap FindTypeMapFor(Type sourceType, Type destinationType);

		TypeMap FindTypeMapFor(TypePair typePair);

		TypeMap FindTypeMapFor<TSource, TDestination>();

		TypeMap ResolveTypeMap(Type sourceType, Type destinationType);

		TypeMap ResolveTypeMap(Type sourceType, Type destinationType, ITypeMapConfiguration inlineConfiguration);

		TypeMap ResolveTypeMap(TypePair typePair, ITypeMapConfiguration inlineConfiguration);

		TypeMap ResolveTypeMap(TypePair typePair);

		void AssertConfigurationIsValid();

		void AssertConfigurationIsValid(TypeMap typeMap);

		void AssertConfigurationIsValid(string profileName);

		void AssertConfigurationIsValid<TProfile>() where TProfile : Profile, new();

		IEnumerable<IObjectMapper> GetMappers();

		IObjectMapper FindMapper(TypePair types);

		IMapper CreateMapper();

		IMapper CreateMapper(Func<Type, object> serviceCtor);

		Func<TSource, TDestination, ResolutionContext, TDestination> GetMapperFunc<TSource, TDestination>(TypePair types);

		Func<TSource, TDestination, ResolutionContext, TDestination> GetMapperFunc<TSource, TDestination>(MapRequest mapRequest);

		void CompileMappings();

		Delegate GetMapperFunc(MapRequest request);

		Func<object, object, ResolutionContext, object> GetUntypedMapperFunc(MapRequest mapRequest);

		LambdaExpression BuildExecutionPlan(Type sourceType, Type destinationType);

		LambdaExpression BuildExecutionPlan(MapRequest mapRequest);
	}
}
