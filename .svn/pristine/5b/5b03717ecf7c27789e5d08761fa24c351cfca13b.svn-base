using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace AutoMapper
{
	[DebuggerDisplay("{SourceType.Name}, {DestinationType.Name}")]
	public struct TypePair : IEquatable<TypePair>
	{
		private class InterfaceComparer : IComparer<Type>
		{
			private readonly List<TypeInfo> _typeInheritance;

			public InterfaceComparer(Type target)
			{
				_typeInheritance = (from type in target.GetTypeInheritance()
					select type.GetTypeInfo()).Reverse().ToList();
			}

			public int Compare(Type x, Type y)
			{
				bool flag = x.IsAssignableFrom(y);
				bool flag2 = y.IsAssignableFrom(x);
				if (flag && !flag2)
				{
					return -1;
				}
				if (!flag && flag2)
				{
					return 1;
				}
				if (flag && flag2)
				{
					return 0;
				}
				int num = _typeInheritance.FindIndex((TypeInfo type) => type.ImplementedInterfaces.Contains(x));
				int num2 = _typeInheritance.FindIndex((TypeInfo type) => type.ImplementedInterfaces.Contains(y));
				if (num < num2)
				{
					return -1;
				}
				if (num2 > num)
				{
					return 1;
				}
				return 0;
			}
		}

		public Type SourceType
		{
			get;
		}

		public Type DestinationType
		{
			get;
		}

		public static bool operator ==(TypePair left, TypePair right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(TypePair left, TypePair right)
		{
			return !left.Equals(right);
		}

		public TypePair(Type sourceType, Type destinationType)
		{
			SourceType = sourceType;
			DestinationType = destinationType;
		}

		public static TypePair Create<TSource>(TSource source, Type sourceType, Type destinationType)
		{
			if (source != null)
			{
				sourceType = source.GetType();
			}
			return new TypePair(sourceType, destinationType);
		}

		public static TypePair Create<TSource, TDestination>(TSource source, TDestination destination, Type sourceType, Type destinationType)
		{
			if (source != null)
			{
				sourceType = source.GetType();
			}
			if (destination != null)
			{
				destinationType = destination.GetType();
			}
			return new TypePair(sourceType, destinationType);
		}

		public bool Equals(TypePair other)
		{
			if (SourceType == other.SourceType)
			{
				return DestinationType == other.DestinationType;
			}
			return false;
		}

		public override bool Equals(object other)
		{
			if (other is TypePair)
			{
				return Equals((TypePair)other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return HashCodeCombiner.Combine(SourceType, DestinationType);
		}

		public TypePair? GetOpenGenericTypePair()
		{
			if (!SourceType.IsGenericType() && !DestinationType.IsGenericType())
			{
				return null;
			}
			Type sourceType = SourceType.IsGenericType() ? SourceType.GetGenericTypeDefinition() : SourceType;
			Type destinationType = DestinationType.IsGenericType() ? DestinationType.GetGenericTypeDefinition() : DestinationType;
			return new TypePair(sourceType, destinationType);
		}

		public IEnumerable<TypePair> GetRelatedTypePairs()
		{
			TypePair @this = this;
			return from destinationType in GetAllTypes(DestinationType)
				from sourceType in GetAllTypes(@this.SourceType)
				select new TypePair(sourceType, destinationType);
		}

		private static IEnumerable<Type> GetAllTypes(Type type)
		{
			IEnumerable<Type> typeInheritance = type.GetTypeInheritance();
			foreach (Type item in typeInheritance)
			{
				yield return item;
			}
			InterfaceComparer comparer = new InterfaceComparer(type);
			IOrderedEnumerable<Type> orderedEnumerable = type.GetTypeInfo().ImplementedInterfaces.OrderByDescending((Type t) => t, comparer);
			foreach (Type item2 in orderedEnumerable)
			{
				yield return item2;
			}
		}
	}
}
