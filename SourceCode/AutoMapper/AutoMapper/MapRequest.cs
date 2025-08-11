using AutoMapper.Configuration;
using System;
using System.Diagnostics;

namespace AutoMapper
{
	[DebuggerDisplay("{RequestedTypes.SourceType.Name}, {RequestedTypes.DestinationType.Name} : {RuntimeTypes.SourceType.Name}, {RuntimeTypes.DestinationType.Name}")]
	public struct MapRequest : IEquatable<MapRequest>
	{
		public TypePair RequestedTypes
		{
			get;
		}

		public TypePair RuntimeTypes
		{
			get;
		}

		public ITypeMapConfiguration InlineConfig
		{
			get;
		}

		public MapRequest(TypePair requestedTypes, TypePair runtimeTypes)
			: this(requestedTypes, runtimeTypes, new MapperConfiguration.DefaultTypeMapConfig(requestedTypes))
		{
		}

		public MapRequest(TypePair requestedTypes, TypePair runtimeTypes, ITypeMapConfiguration inlineConfig)
		{
			RequestedTypes = requestedTypes;
			RuntimeTypes = runtimeTypes;
			InlineConfig = inlineConfig;
		}

		public bool Equals(MapRequest other)
		{
			if (RequestedTypes.Equals(other.RequestedTypes))
			{
				return RuntimeTypes.Equals(other.RuntimeTypes);
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (obj is MapRequest)
			{
				return Equals((MapRequest)obj);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return HashCodeCombiner.Combine(RequestedTypes, RuntimeTypes);
		}

		public static bool operator ==(MapRequest left, MapRequest right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(MapRequest left, MapRequest right)
		{
			return !left.Equals(right);
		}
	}
}
