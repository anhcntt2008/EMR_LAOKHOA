using AutoMapper.Configuration;
using AutoMapper.Execution;
using AutoMapper.Internal;
using AutoMapper.QueryableExtensions;
using AutoMapper.QueryableExtensions.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper
{
	public class MapperConfiguration : IConfigurationProvider
	{
		internal struct MapperFuncs
		{
			public Delegate Typed
			{
				get;
			}

			public Func<object, object, ResolutionContext, object> Untyped
			{
				get;
			}

			public MapperFuncs(MapRequest mapRequest, LambdaExpression typedExpression)
			{
				Typed = typedExpression.Compile();
				Untyped = Wrap(mapRequest, Typed).Compile();
			}

			private static Expression<Func<object, object, ResolutionContext, object>> Wrap(MapRequest mapRequest, Delegate typedDelegate)
			{
				ParameterExpression parameterExpression = Expression.Parameter(typeof(object), "source");
				ParameterExpression parameterExpression2 = Expression.Parameter(typeof(object), "destination");
				ParameterExpression parameterExpression3 = Expression.Parameter(typeof(ResolutionContext), "context");
				Type sourceType = mapRequest.RequestedTypes.SourceType;
				Type destinationType = mapRequest.RequestedTypes.DestinationType;
				Expression expression = destinationType.IsValueType() ? ((Expression)Expression.Coalesce(parameterExpression2, Expression.New(destinationType))) : ((Expression)parameterExpression2);
				return Expression.Lambda<Func<object, object, ResolutionContext, object>>(ExpressionFactory.ToType(Expression.Invoke(Expression.Constant(typedDelegate), ExpressionFactory.ToType(parameterExpression, sourceType), ExpressionFactory.ToType(expression, destinationType), parameterExpression3), typeof(object)), new ParameterExpression[3]
				{
					parameterExpression,
					parameterExpression2,
					parameterExpression3
				});
			}
		}

		internal class DefaultTypeMapConfig : ITypeMapConfiguration
		{
			public Type SourceType => Types.SourceType;

			public Type DestinationType => Types.DestinationType;

			public bool IsOpenGeneric => false;

			public TypePair Types
			{
				get;
			}

			public ITypeMapConfiguration ReverseTypeMap => null;

			public DefaultTypeMapConfig(TypePair types)
			{
				Types = types;
			}

			public void Configure(TypeMap typeMap)
			{
			}
		}

		private static readonly Type[] ExcludedTypes = new Type[3]
		{
			typeof(object),
			typeof(ValueType),
			typeof(Enum)
		};

		private static readonly ConstructorInfo ExceptionConstructor = typeof(AutoMapperMappingException).GetDeclaredConstructors().Single((ConstructorInfo c) => c.GetParameters().Length == 3);

		private readonly IEnumerable<IObjectMapper> _mappers;

		private readonly TypeMapRegistry _typeMapRegistry = new TypeMapRegistry();

		private LockingConcurrentDictionary<TypePair, TypeMap> _typeMapPlanCache;

		private readonly LockingConcurrentDictionary<MapRequest, MapperFuncs> _mapPlanCache;

		private readonly ConfigurationValidator _validator;

		private readonly MapperConfigurationExpressionValidator _expressionValidator;

		private Action<ValidationContext>[] Validators
		{
			get;
		}

		public IExpressionBuilder ExpressionBuilder
		{
			get;
		}

		public Func<Type, object> ServiceCtor
		{
			get;
		}

		public bool EnableNullPropagationForQueryMapping
		{
			get;
		}

		public int MaxExecutionPlanDepth
		{
			get;
		}

		private ProfileMap Configuration
		{
			get;
		}

		public IEnumerable<ProfileMap> Profiles
		{
			get;
		}

		public MapperConfiguration(MapperConfigurationExpression configurationExpression)
		{
			_mappers = configurationExpression.Mappers.ToArray();
			_typeMapPlanCache = new LockingConcurrentDictionary<TypePair, TypeMap>(GetTypeMap);
			_mapPlanCache = new LockingConcurrentDictionary<MapRequest, MapperFuncs>(CreateMapperFuncs);
			Validators = configurationExpression.Advanced.GetValidators();
			_validator = new ConfigurationValidator(this);
			_expressionValidator = new MapperConfigurationExpressionValidator(configurationExpression);
			ExpressionBuilder = new AutoMapper.QueryableExtensions.ExpressionBuilder(this);
			ServiceCtor = configurationExpression.ServiceCtor;
			EnableNullPropagationForQueryMapping = (configurationExpression.EnableNullPropagationForQueryMapping ?? false);
			MaxExecutionPlanDepth = configurationExpression.Advanced.MaxExecutionPlanDepth + 1;
			Configuration = new ProfileMap(configurationExpression);
			Profiles = new ProfileMap[1]
			{
				Configuration
			}.Concat(configurationExpression.Profiles.Select((IProfileConfiguration p) => new ProfileMap(p, configurationExpression))).ToArray();
			foreach (Action<IConfigurationProvider> beforeSealAction in configurationExpression.Advanced.BeforeSealActions)
			{
				beforeSealAction?.Invoke(this);
			}
			Seal();
		}

		public MapperConfiguration(Action<IMapperConfigurationExpression> configure)
			: this(Build(configure))
		{
		}

		public void Validate(ValidationContext context)
		{
			Action<ValidationContext>[] validators = Validators;
			for (int i = 0; i < validators.Length; i++)
			{
				validators[i](context);
			}
		}

		public Func<TSource, TDestination, ResolutionContext, TDestination> GetMapperFunc<TSource, TDestination>(TypePair types)
		{
			TypePair requestedTypes = new TypePair(typeof(TSource), typeof(TDestination));
			MapRequest mapRequest = new MapRequest(requestedTypes, types);
			return GetMapperFunc<TSource, TDestination>(mapRequest);
		}

		public Func<TSource, TDestination, ResolutionContext, TDestination> GetMapperFunc<TSource, TDestination>(MapRequest mapRequest)
		{
			return (Func<TSource, TDestination, ResolutionContext, TDestination>)GetMapperFunc(mapRequest);
		}

		public void CompileMappings()
		{
			MapRequest[] array = _typeMapPlanCache.Keys.Select((TypePair types) => new MapRequest(types, types)).ToArray();
			foreach (MapRequest mapRequest in array)
			{
				GetMapperFunc(mapRequest);
			}
		}

		public Delegate GetMapperFunc(MapRequest mapRequest)
		{
			return _mapPlanCache.GetOrAdd(mapRequest).Typed;
		}

		public Func<object, object, ResolutionContext, object> GetUntypedMapperFunc(MapRequest mapRequest)
		{
			return _mapPlanCache.GetOrAdd(mapRequest).Untyped;
		}

		private MapperFuncs CreateMapperFuncs(MapRequest mapRequest)
		{
			return new MapperFuncs(mapRequest, BuildExecutionPlan(mapRequest));
		}

		public LambdaExpression BuildExecutionPlan(Type sourceType, Type destinationType)
		{
			TypePair typePair = new TypePair(sourceType, destinationType);
			return BuildExecutionPlan(new MapRequest(typePair, typePair));
		}

		public LambdaExpression BuildExecutionPlan(MapRequest mapRequest)
		{
			TypeMap typeMap = ResolveTypeMap(mapRequest.RuntimeTypes, mapRequest.InlineConfig) ?? ResolveTypeMap(mapRequest.RequestedTypes, mapRequest.InlineConfig);
			if (typeMap != null)
			{
				return GenerateTypeMapExpression(mapRequest, typeMap);
			}
			IObjectMapper mapperToUse = FindMapper(mapRequest.RuntimeTypes);
			return GenerateObjectMapperExpression(mapRequest, mapperToUse, this);
		}

		private static LambdaExpression GenerateTypeMapExpression(MapRequest mapRequest, TypeMap typeMap)
		{
			LambdaExpression lambdaExpression = typeMap.MapExpression;
			ParameterExpression parameterExpression = lambdaExpression.Parameters[0];
			ParameterExpression parameterExpression2 = lambdaExpression.Parameters[1];
			Type sourceType = mapRequest.RequestedTypes.SourceType;
			Type destinationType = mapRequest.RequestedTypes.DestinationType;
			if (parameterExpression.Type != sourceType || parameterExpression2.Type != destinationType)
			{
				ParameterExpression parameterExpression3 = Expression.Parameter(sourceType, "source");
				ParameterExpression parameterExpression4 = Expression.Parameter(destinationType, "typeMapDestination");
				ParameterExpression parameterExpression5 = Expression.Parameter(typeof(ResolutionContext), "context");
				lambdaExpression = Expression.Lambda(ExpressionFactory.ToType(Expression.Invoke(typeMap.MapExpression, ExpressionFactory.ToType(parameterExpression3, parameterExpression.Type), ExpressionFactory.ToType(parameterExpression4, parameterExpression2.Type), parameterExpression5), mapRequest.RuntimeTypes.DestinationType), parameterExpression3, parameterExpression4, parameterExpression5);
			}
			return lambdaExpression;
		}

		private LambdaExpression GenerateObjectMapperExpression(MapRequest mapRequest, IObjectMapper mapperToUse, MapperConfiguration mapperConfiguration)
		{
			Type destinationType = mapRequest.RequestedTypes.DestinationType;
			ParameterExpression parameterExpression = Expression.Parameter(mapRequest.RequestedTypes.SourceType, "source");
			ParameterExpression parameterExpression2 = Expression.Parameter(destinationType, "mapperDestination");
			ParameterExpression parameterExpression3 = Expression.Parameter(typeof(ResolutionContext), "context");
			Expression objectMapperExpression;
			if (mapperToUse == null)
			{
				ConstantExpression constantExpression = Expression.Constant("Missing type map configuration or unsupported mapping.");
				objectMapperExpression = Expression.Block(Expression.Throw(Expression.New(ExceptionConstructor, constantExpression, Expression.Constant(null, typeof(Exception)), Expression.Constant(mapRequest.RequestedTypes))), Expression.Default(destinationType));
			}
			else
			{
				Expression expression = mapperToUse.MapExpression(mapperConfiguration, Configuration, null, ExpressionFactory.ToType(parameterExpression, mapRequest.RuntimeTypes.SourceType), ExpressionFactory.ToType(parameterExpression2, mapRequest.RuntimeTypes.DestinationType), parameterExpression3);
				ParameterExpression parameterExpression4 = Expression.Parameter(typeof(Exception), "ex");
				objectMapperExpression = Expression.TryCatch(ExpressionFactory.ToType(expression, destinationType), Expression.MakeCatchBlock(typeof(Exception), parameterExpression4, Expression.Block(Expression.Throw(Expression.New(ExceptionConstructor, Expression.Constant("Error mapping types."), parameterExpression4, Expression.Constant(mapRequest.RequestedTypes))), Expression.Default(parameterExpression2.Type)), null));
			}
			return Expression.Lambda(AutoMapper.Execution.ExpressionBuilder.NullCheckSource(Configuration, parameterExpression, parameterExpression2, objectMapperExpression), parameterExpression, parameterExpression2, parameterExpression3);
		}

		public TypeMap[] GetAllTypeMaps()
		{
			return _typeMapRegistry.TypeMaps.ToArray();
		}

		public TypeMap FindTypeMapFor(Type sourceType, Type destinationType)
		{
			return FindTypeMapFor(new TypePair(sourceType, destinationType));
		}

		public TypeMap FindTypeMapFor<TSource, TDestination>()
		{
			return FindTypeMapFor(new TypePair(typeof(TSource), typeof(TDestination)));
		}

		public TypeMap FindTypeMapFor(TypePair typePair)
		{
			return _typeMapRegistry.GetTypeMap(typePair);
		}

		public TypeMap ResolveTypeMap(Type sourceType, Type destinationType)
		{
			TypePair typePair = new TypePair(sourceType, destinationType);
			return ResolveTypeMap(typePair, new DefaultTypeMapConfig(typePair));
		}

		public TypeMap ResolveTypeMap(Type sourceType, Type destinationType, ITypeMapConfiguration inlineConfiguration)
		{
			TypePair typePair = new TypePair(sourceType, destinationType);
			return ResolveTypeMap(typePair, inlineConfiguration);
		}

		public TypeMap ResolveTypeMap(TypePair typePair)
		{
			return ResolveTypeMap(typePair, new DefaultTypeMapConfig(typePair));
		}

		public TypeMap ResolveTypeMap(TypePair typePair, ITypeMapConfiguration inlineConfiguration)
		{
			TypeMap orAdd = _typeMapPlanCache.GetOrAdd(typePair);
			if (orAdd != null && orAdd.MapExpression == null && _typeMapRegistry.GetTypeMap(typePair) == null)
			{
				lock (orAdd)
				{
					inlineConfiguration.Configure(orAdd);
					orAdd.Seal(this);
					return orAdd;
				}
			}
			return orAdd;
		}

		private TypeMap GetTypeMap(TypePair initialTypes)
		{
			bool flag = FindMapper(initialTypes) == null;
			foreach (TypePair relatedTypePair in initialTypes.GetRelatedTypePairs())
			{
				if (relatedTypePair != initialTypes && _typeMapPlanCache.TryGetValue(relatedTypePair, out TypeMap value) && value != null)
				{
					return value;
				}
				value = FindTypeMapFor(relatedTypePair);
				if (value != null)
				{
					return value;
				}
				value = FindClosedGenericTypeMapFor(relatedTypePair);
				if (value != null)
				{
					return value;
				}
				if (flag)
				{
					value = FindConventionTypeMapFor(relatedTypePair);
					if (value != null)
					{
						return value;
					}
				}
			}
			if (flag && Configuration.CreateMissingTypeMaps && (!initialTypes.SourceType.IsAbstract() || !initialTypes.SourceType.IsClass()) && (!initialTypes.DestinationType.IsAbstract() || !initialTypes.DestinationType.IsClass()) && !ExcludedTypes.Contains(initialTypes.SourceType) && !ExcludedTypes.Contains(initialTypes.DestinationType))
			{
				lock (this)
				{
					return Configuration.CreateInlineMap(_typeMapRegistry, initialTypes);
				}
			}
			return null;
		}

		public void AssertConfigurationIsValid(TypeMap typeMap)
		{
			_validator.AssertConfigurationIsValid(Enumerable.Repeat(typeMap, 1));
		}

		public void AssertConfigurationIsValid(string profileName)
		{
			_validator.AssertConfigurationIsValid(_typeMapRegistry.TypeMaps.Where((TypeMap typeMap) => typeMap.Profile.Name == profileName));
		}

		public void AssertConfigurationIsValid<TProfile>() where TProfile : Profile, new()
		{
			AssertConfigurationIsValid(new TProfile().ProfileName);
		}

		public void AssertConfigurationIsValid()
		{
			_expressionValidator.AssertConfigurationExpressionIsValid();
			_validator.AssertConfigurationIsValid(_typeMapRegistry.TypeMaps.Where((TypeMap tm) => !tm.SourceType.IsGenericTypeDefinition() && !tm.DestinationType.IsGenericTypeDefinition()));
		}

		public IMapper CreateMapper()
		{
			return new Mapper(this);
		}

		public IMapper CreateMapper(Func<Type, object> serviceCtor)
		{
			return new Mapper(this, serviceCtor);
		}

		public IEnumerable<IObjectMapper> GetMappers()
		{
			return _mappers;
		}

		private static MapperConfigurationExpression Build(Action<IMapperConfigurationExpression> configure)
		{
			MapperConfigurationExpression mapperConfigurationExpression = new MapperConfigurationExpression();
			configure(mapperConfigurationExpression);
			return mapperConfigurationExpression;
		}

		private void Seal()
		{
			List<Tuple<TypePair, TypeMap>> list = new List<Tuple<TypePair, TypeMap>>();
			List<Tuple<TypePair, TypePair>> list2 = new List<Tuple<TypePair, TypePair>>();
			foreach (ProfileMap profile in Profiles)
			{
				profile.Register(_typeMapRegistry);
			}
			foreach (ProfileMap profile2 in Profiles)
			{
				profile2.Configure(_typeMapRegistry);
			}
			foreach (TypeMap typeMap in _typeMapRegistry.TypeMaps)
			{
				_typeMapPlanCache[typeMap.Types] = typeMap;
				if (typeMap.DestinationTypeOverride != null)
				{
					list2.Add(Tuple.Create(typeMap.Types, new TypePair(typeMap.SourceType, typeMap.DestinationTypeOverride)));
				}
				list.AddRange(from derivedMap in GetDerivedTypeMaps(typeMap)
					select Tuple.Create(new TypePair(derivedMap.SourceType, typeMap.DestinationType), derivedMap));
			}
			foreach (Tuple<TypePair, TypePair> item in list2)
			{
				TypeMap typeMap2 = FindTypeMapFor(item.Item2);
				if (typeMap2 != null)
				{
					_typeMapPlanCache[item.Item1] = typeMap2;
				}
			}
			foreach (Tuple<TypePair, TypeMap> item2 in list.Where((Tuple<TypePair, TypeMap> derivedMap) => !_typeMapPlanCache.ContainsKey(derivedMap.Item1)))
			{
				_typeMapPlanCache[item2.Item1] = item2.Item2;
			}
			foreach (TypeMap typeMap3 in _typeMapRegistry.TypeMaps)
			{
				typeMap3.Seal(this);
			}
		}

		private IEnumerable<TypeMap> GetDerivedTypeMaps(TypeMap typeMap)
		{
			foreach (TypePair includedDerivedType in typeMap.IncludedDerivedTypes)
			{
				TypeMap derivedMap = FindTypeMapFor(includedDerivedType);
				if (derivedMap == null)
				{
					throw QueryMapperHelper.MissingMapException(includedDerivedType.SourceType, includedDerivedType.DestinationType);
				}
				yield return derivedMap;
				foreach (TypeMap derivedTypeMap in GetDerivedTypeMaps(derivedMap))
				{
					yield return derivedTypeMap;
				}
			}
		}

		private TypeMap FindConventionTypeMapFor(TypePair typePair)
		{
			ProfileMap profileMap = Profiles.FirstOrDefault((ProfileMap p) => p.IsConventionMap(typePair));
			if (profileMap == null)
			{
				return null;
			}
			lock (this)
			{
				return profileMap.CreateConventionTypeMap(_typeMapRegistry, typePair);
			}
		}

		private TypeMap FindClosedGenericTypeMapFor(TypePair typePair)
		{
			if (!typePair.GetOpenGenericTypePair().HasValue)
			{
				return null;
			}
			var anon = Profiles.Select((ProfileMap p) => new
			{
				GenericMap = p.GetGenericMap(typePair),
				Profile = p
			}).FirstOrDefault(p => p.GenericMap != null);
			if (anon == null)
			{
				return null;
			}
			lock (this)
			{
				return anon.Profile.CreateClosedGenericTypeMap(anon.GenericMap, _typeMapRegistry, typePair);
			}
		}

		public IObjectMapper FindMapper(TypePair types)
		{
			return _mappers.FirstOrDefault((IObjectMapper m) => m.IsMatch(types));
		}
	}
}
