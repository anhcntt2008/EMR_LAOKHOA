using System;

namespace AutoMapper
{
	public struct ContextCacheKey : IEquatable<ContextCacheKey>
	{
		private readonly object _source;

		private readonly Type _destinationType;

		public static bool operator ==(ContextCacheKey left, ContextCacheKey right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(ContextCacheKey left, ContextCacheKey right)
		{
			return !left.Equals(right);
		}

		public ContextCacheKey(object source, Type destinationType)
		{
			_source = source;
			_destinationType = destinationType;
		}

		public override int GetHashCode()
		{
			return HashCodeCombiner.Combine(_source, _destinationType);
		}

		public bool Equals(ContextCacheKey other)
		{
			if (_source == other._source)
			{
				return _destinationType == other._destinationType;
			}
			return false;
		}

		public override bool Equals(object other)
		{
			if (other is ContextCacheKey)
			{
				return Equals((ContextCacheKey)other);
			}
			return false;
		}
	}
}
