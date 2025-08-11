using System;
using System.Diagnostics;
using System.Reflection;

namespace AutoMapper.Execution
{
	[DebuggerDisplay("{Name}-{Type.Name}")]
	public struct PropertyDescription : IEquatable<PropertyDescription>
	{
		internal static PropertyDescription[] Empty = new PropertyDescription[0];

		public string Name
		{
			get;
		}

		public Type Type
		{
			get;
		}

		public bool CanWrite
		{
			get;
		}

		public PropertyDescription(string name, Type type, bool canWrite = true)
		{
			Name = name;
			Type = type;
			CanWrite = canWrite;
		}

		public PropertyDescription(PropertyInfo property)
		{
			Name = property.Name;
			Type = property.PropertyType;
			CanWrite = property.CanWrite;
		}

		public override int GetHashCode()
		{
			return HashCodeCombiner.CombineCodes(HashCodeCombiner.Combine(Name, Type), CanWrite.GetHashCode());
		}

		public override bool Equals(object other)
		{
			if (other is PropertyDescription)
			{
				return Equals((PropertyDescription)other);
			}
			return false;
		}

		public bool Equals(PropertyDescription other)
		{
			if (Name == other.Name && Type == other.Type)
			{
				return CanWrite == other.CanWrite;
			}
			return false;
		}

		public static bool operator ==(PropertyDescription left, PropertyDescription right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(PropertyDescription left, PropertyDescription right)
		{
			return !left.Equals(right);
		}
	}
}
