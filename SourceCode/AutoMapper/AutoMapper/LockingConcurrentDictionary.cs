using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace AutoMapper
{
	internal struct LockingConcurrentDictionary<TKey, TValue>
	{
		private readonly ConcurrentDictionary<TKey, Lazy<TValue>> _dictionary;

		private readonly Func<TKey, Lazy<TValue>> _valueFactory;

		public TValue this[TKey key]
		{
			get
			{
				return _dictionary[key].Value;
			}
			set
			{
				_dictionary[key] = new Lazy<TValue>(() => value);
			}
		}

		public ICollection<TKey> Keys => _dictionary.Keys;

		public LockingConcurrentDictionary(Func<TKey, TValue> valueFactory)
		{
			_dictionary = new ConcurrentDictionary<TKey, Lazy<TValue>>();
			_valueFactory = ((TKey key) => new Lazy<TValue>(() => valueFactory(key)));
		}

		public TValue GetOrAdd(TKey key)
		{
			return _dictionary.GetOrAdd(key, _valueFactory).Value;
		}

		public TValue GetOrAdd(TKey key, Func<TKey, Lazy<TValue>> valueFactory)
		{
			return _dictionary.GetOrAdd(key, valueFactory).Value;
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			if (_dictionary.TryGetValue(key, out Lazy<TValue> value2))
			{
				value = value2.Value;
				return true;
			}
			value = default(TValue);
			return false;
		}

		public bool ContainsKey(TKey key)
		{
			return _dictionary.ContainsKey(key);
		}
	}
}
