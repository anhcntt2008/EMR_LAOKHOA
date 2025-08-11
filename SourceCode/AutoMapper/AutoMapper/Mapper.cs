using AutoMapper.Configuration;
using System;

namespace AutoMapper
{
	public class Mapper : IRuntimeMapper, IMapper
	{
		private const string InvalidOperationMessage = "Mapper not initialized. Call Initialize with appropriate configuration. If you are trying to use mapper instances through a container or otherwise, make sure you do not have any calls to the static Mapper.Map methods, and if you're using ProjectTo or UseAsDataSource extension methods, make sure you pass in the appropriate IConfigurationProvider instance.";

		private const string AlreadyInitialized = "Mapper already initialized. You must call Initialize once per application domain/process.";

		private static IConfigurationProvider _configuration;

		private static IMapper _instance;

		private readonly IConfigurationProvider _configurationProvider;

		private readonly Func<Type, object> _serviceCtor;

		public static IConfigurationProvider Configuration
		{
			get
			{
				return _configuration ?? throw new InvalidOperationException("Mapper not initialized. Call Initialize with appropriate configuration. If you are trying to use mapper instances through a container or otherwise, make sure you do not have any calls to the static Mapper.Map methods, and if you're using ProjectTo or UseAsDataSource extension methods, make sure you pass in the appropriate IConfigurationProvider instance.");
			}
			private set
			{
				if (_configuration != null)
				{
					throw new InvalidOperationException("Mapper already initialized. You must call Initialize once per application domain/process.");
				}
				_configuration = value;
			}
		}

		public static IMapper Instance
		{
			get
			{
				return _instance ?? throw new InvalidOperationException("Mapper not initialized. Call Initialize with appropriate configuration. If you are trying to use mapper instances through a container or otherwise, make sure you do not have any calls to the static Mapper.Map methods, and if you're using ProjectTo or UseAsDataSource extension methods, make sure you pass in the appropriate IConfigurationProvider instance.");
			}
			private set
			{
				_instance = value;
			}
		}

		public ResolutionContext DefaultContext
		{
			get;
		}

		Func<Type, object> IMapper.ServiceCtor => _serviceCtor;

		IConfigurationProvider IMapper.ConfigurationProvider => _configurationProvider;

		public static void Initialize(Action<IMapperConfigurationExpression> config)
		{
			Configuration = new MapperConfiguration(config);
			Instance = new Mapper(Configuration);
		}

		public static void Initialize(MapperConfigurationExpression config)
		{
			Configuration = new MapperConfiguration(config);
			Instance = new Mapper(Configuration);
		}

		public static void Reset()
		{
			_configuration = null;
			_instance = null;
		}

		public static TDestination Map<TDestination>(object source)
		{
			return Instance.Map<TDestination>(source);
		}

		public static TDestination Map<TDestination>(object source, Action<IMappingOperationOptions> opts)
		{
			return Instance.Map<TDestination>(source, opts);
		}

		public static TDestination Map<TSource, TDestination>(TSource source)
		{
			return Instance.Map<TSource, TDestination>(source);
		}

		public static TDestination Map<TSource, TDestination>(TSource source, Action<IMappingOperationOptions<TSource, TDestination>> opts)
		{
			return Instance.Map(source, opts);
		}

		public static TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
		{
			return Instance.Map(source, destination);
		}

		public static TDestination Map<TSource, TDestination>(TSource source, TDestination destination, Action<IMappingOperationOptions<TSource, TDestination>> opts)
		{
			return Instance.Map(source, destination, opts);
		}

		public static object Map(object source, Type sourceType, Type destinationType)
		{
			return Instance.Map(source, sourceType, destinationType);
		}

		public static object Map(object source, Type sourceType, Type destinationType, Action<IMappingOperationOptions> opts)
		{
			return Instance.Map(source, sourceType, destinationType, opts);
		}

		public static object Map(object source, object destination, Type sourceType, Type destinationType)
		{
			return Instance.Map(source, destination, sourceType, destinationType);
		}

		public static object Map(object source, object destination, Type sourceType, Type destinationType, Action<IMappingOperationOptions> opts)
		{
			return Instance.Map(source, destination, sourceType, destinationType, opts);
		}

		public static void AssertConfigurationIsValid()
		{
			Configuration.AssertConfigurationIsValid();
		}

		public Mapper(IConfigurationProvider configurationProvider)
			: this(configurationProvider, configurationProvider.ServiceCtor)
		{
		}

		public Mapper(IConfigurationProvider configurationProvider, Func<Type, object> serviceCtor)
		{
			_configurationProvider = configurationProvider;
			_serviceCtor = serviceCtor;
			DefaultContext = new ResolutionContext(new MappingOperationOptions<object, object>(serviceCtor), this);
		}

		TDestination IMapper.Map<TDestination>(object source)
		{
			if (source == null)
			{
				return default(TDestination);
			}
			TypePair typePair = new TypePair(source.GetType(), typeof(TDestination));
			return (TDestination)_configurationProvider.GetUntypedMapperFunc(new MapRequest(typePair, typePair))(source, null, DefaultContext);
		}

		TDestination IMapper.Map<TDestination>(object source, Action<IMappingOperationOptions> opts)
		{
			TDestination result = default(TDestination);
			if (source == null)
			{
				return result;
			}
			Type type = source.GetType();
			Type typeFromHandle = typeof(TDestination);
			return (TDestination)((IMapper)this).Map(source, type, typeFromHandle, opts);
		}

		TDestination IMapper.Map<TSource, TDestination>(TSource source)
		{
			TypePair types = TypePair.Create(source, typeof(TSource), typeof(TDestination));
			return _configurationProvider.GetMapperFunc<TSource, TDestination>(types)(source, default(TDestination), DefaultContext);
		}

		TDestination IMapper.Map<TSource, TDestination>(TSource source, Action<IMappingOperationOptions<TSource, TDestination>> opts)
		{
			TypePair runtimeTypes = TypePair.Create(source, typeof(TSource), typeof(TDestination));
			TypePair requestedTypes = new TypePair(typeof(TSource), typeof(TDestination));
			MappingOperationOptions<TSource, TDestination> mappingOperationOptions = new MappingOperationOptions<TSource, TDestination>(_serviceCtor);
			opts(mappingOperationOptions);
			MapRequest mapRequest = new MapRequest(requestedTypes, runtimeTypes, mappingOperationOptions.InlineConfiguration);
			Func<TSource, TDestination, ResolutionContext, TDestination> mapperFunc = _configurationProvider.GetMapperFunc<TSource, TDestination>(mapRequest);
			TDestination arg = default(TDestination);
			mappingOperationOptions.BeforeMapAction(source, arg);
			ResolutionContext arg2 = new ResolutionContext(mappingOperationOptions, this);
			arg = mapperFunc(source, arg, arg2);
			mappingOperationOptions.AfterMapAction(source, arg);
			return arg;
		}

		TDestination IMapper.Map<TSource, TDestination>(TSource source, TDestination destination)
		{
			TypePair types = TypePair.Create(source, destination, typeof(TSource), typeof(TDestination));
			return _configurationProvider.GetMapperFunc<TSource, TDestination>(types)(source, destination, DefaultContext);
		}

		TDestination IMapper.Map<TSource, TDestination>(TSource source, TDestination destination, Action<IMappingOperationOptions<TSource, TDestination>> opts)
		{
			TypePair runtimeTypes = TypePair.Create(source, destination, typeof(TSource), typeof(TDestination));
			TypePair requestedTypes = new TypePair(typeof(TSource), typeof(TDestination));
			MappingOperationOptions<TSource, TDestination> mappingOperationOptions = new MappingOperationOptions<TSource, TDestination>(_serviceCtor);
			opts(mappingOperationOptions);
			MapRequest mapRequest = new MapRequest(requestedTypes, runtimeTypes, mappingOperationOptions.InlineConfiguration);
			Func<TSource, TDestination, ResolutionContext, TDestination> mapperFunc = _configurationProvider.GetMapperFunc<TSource, TDestination>(mapRequest);
			mappingOperationOptions.BeforeMapAction(source, destination);
			ResolutionContext arg = new ResolutionContext(mappingOperationOptions, this);
			destination = mapperFunc(source, destination, arg);
			mappingOperationOptions.AfterMapAction(source, destination);
			return destination;
		}

		object IMapper.Map(object source, Type sourceType, Type destinationType)
		{
			TypePair runtimeTypes = TypePair.Create(source, sourceType, destinationType);
			return _configurationProvider.GetUntypedMapperFunc(new MapRequest(new TypePair(sourceType, destinationType), runtimeTypes))(source, null, DefaultContext);
		}

		object IMapper.Map(object source, Type sourceType, Type destinationType, Action<IMappingOperationOptions> opts)
		{
			TypePair runtimeTypes = TypePair.Create(source, sourceType, destinationType);
			MappingOperationOptions<object, object> mappingOperationOptions = new MappingOperationOptions<object, object>(_serviceCtor);
			opts(mappingOperationOptions);
			Func<object, object, ResolutionContext, object> untypedMapperFunc = _configurationProvider.GetUntypedMapperFunc(new MapRequest(new TypePair(sourceType, destinationType), runtimeTypes, mappingOperationOptions.InlineConfiguration));
			mappingOperationOptions.BeforeMapAction(source, null);
			ResolutionContext arg = new ResolutionContext(mappingOperationOptions, this);
			object obj = untypedMapperFunc(source, null, arg);
			mappingOperationOptions.AfterMapAction(source, obj);
			return obj;
		}

		object IMapper.Map(object source, object destination, Type sourceType, Type destinationType)
		{
			TypePair runtimeTypes = TypePair.Create(source, destination, sourceType, destinationType);
			return _configurationProvider.GetUntypedMapperFunc(new MapRequest(new TypePair(sourceType, destinationType), runtimeTypes))(source, destination, DefaultContext);
		}

		object IMapper.Map(object source, object destination, Type sourceType, Type destinationType, Action<IMappingOperationOptions> opts)
		{
			TypePair runtimeTypes = TypePair.Create(source, destination, sourceType, destinationType);
			MappingOperationOptions<object, object> mappingOperationOptions = new MappingOperationOptions<object, object>(_serviceCtor);
			opts(mappingOperationOptions);
			Func<object, object, ResolutionContext, object> untypedMapperFunc = _configurationProvider.GetUntypedMapperFunc(new MapRequest(new TypePair(sourceType, destinationType), runtimeTypes, mappingOperationOptions.InlineConfiguration));
			mappingOperationOptions.BeforeMapAction(source, destination);
			ResolutionContext arg = new ResolutionContext(mappingOperationOptions, this);
			destination = untypedMapperFunc(source, destination, arg);
			mappingOperationOptions.AfterMapAction(source, destination);
			return destination;
		}

		object IRuntimeMapper.Map(object source, object destination, Type sourceType, Type destinationType, ResolutionContext context)
		{
			TypePair runtimeTypes = TypePair.Create(source, destination, sourceType, destinationType);
			return _configurationProvider.GetUntypedMapperFunc(new MapRequest(new TypePair(sourceType, destinationType), runtimeTypes))(source, destination, context);
		}

		TDestination IRuntimeMapper.Map<TSource, TDestination>(TSource source, TDestination destination, ResolutionContext context)
		{
			TypePair types = TypePair.Create(source, destination, typeof(TSource), typeof(TDestination));
			return _configurationProvider.GetMapperFunc<TSource, TDestination>(types)(source, destination, context);
		}
	}
}
