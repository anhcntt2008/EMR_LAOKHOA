using System;
using System.Collections.Generic;

namespace AutoMapper
{
	public class ResolutionContext
	{
		private Dictionary<ContextCacheKey, object> _instanceCache;

		private Dictionary<TypePair, int> _typeDepth;

		public IMappingOperationOptions Options
		{
			get;
		}

		public Dictionary<ContextCacheKey, object> InstanceCache
		{
			get
			{
				CheckDefault();
				if (_instanceCache != null)
				{
					return _instanceCache;
				}
				_instanceCache = new Dictionary<ContextCacheKey, object>();
				return _instanceCache;
			}
		}

		private Dictionary<TypePair, int> TypeDepth
		{
			get
			{
				CheckDefault();
				if (_typeDepth != null)
				{
					return _typeDepth;
				}
				_typeDepth = new Dictionary<TypePair, int>();
				return _typeDepth;
			}
		}

		public IRuntimeMapper Mapper
		{
			get;
		}

		public IConfigurationProvider ConfigurationProvider => Mapper.ConfigurationProvider;

		public IDictionary<string, object> Items => Options.Items;

		internal bool IsDefault => this == Mapper.DefaultContext;

		internal object GetDestination(object source, Type destinationType)
		{
			InstanceCache.TryGetValue(new ContextCacheKey(source, destinationType), out object value);
			return value;
		}

		internal void CacheDestination(object source, Type destinationType, object destination)
		{
			InstanceCache[new ContextCacheKey(source, destinationType)] = destination;
		}

		private void CheckDefault()
		{
			if (IsDefault)
			{
				throw new InvalidOperationException();
			}
		}

		internal void IncrementTypeDepth(TypePair types)
		{
			TypeDepth[types]++;
		}

		internal void DecrementTypeDepth(TypePair types)
		{
			TypeDepth[types]--;
		}

		internal int GetTypeDepth(TypePair types)
		{
			if (!TypeDepth.ContainsKey(types))
			{
				TypeDepth[types] = 1;
			}
			return TypeDepth[types];
		}

		public ResolutionContext(IMappingOperationOptions options, IRuntimeMapper mapper)
		{
			Options = options;
			Mapper = mapper;
		}

		internal TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
		{
			return Mapper.Map(source, destination, this);
		}

		internal object Map(object source, object destination, Type sourceType, Type destinationType)
		{
			return Mapper.Map(source, destination, sourceType, destinationType, this);
		}

		internal void ValidateMap(TypeMap typeMap)
		{
			ConfigurationProvider.AssertConfigurationIsValid(typeMap);
		}
	}
}
