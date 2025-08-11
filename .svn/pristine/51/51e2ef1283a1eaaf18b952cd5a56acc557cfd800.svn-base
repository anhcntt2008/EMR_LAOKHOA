using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoMapper.Execution
{
	public struct TypeDescription : IEquatable<TypeDescription>
	{
		public Type Type
		{
			get;
		}

		public PropertyDescription[] AdditionalProperties
		{
			get;
		}

		public TypeDescription(Type type)
			: this(type, PropertyDescription.Empty)
		{
		}

		public TypeDescription(Type type, IEnumerable<PropertyDescription> additionalProperties)
		{
			Type = (type ?? throw new ArgumentNullException("type"));
			AdditionalProperties = (additionalProperties?.ToArray() ?? throw new ArgumentNullException("additionalProperties"));
		}

		public override int GetHashCode()
		{
			int num = Type.GetHashCode();
			PropertyDescription[] additionalProperties = AdditionalProperties;
			for (int i = 0; i < additionalProperties.Length; i++)
			{
				PropertyDescription propertyDescription = additionalProperties[i];
				num = HashCodeCombiner.CombineCodes(num, propertyDescription.GetHashCode());
			}
			return num;
		}

		public override bool Equals(object other)
		{
			if (other is TypeDescription)
			{
				return Equals((TypeDescription)other);
			}
			return false;
		}

		public bool Equals(TypeDescription other)
		{
			if (Type == other.Type)
			{
				return AdditionalProperties.SequenceEqual(other.AdditionalProperties);
			}
			return false;
		}

		public static bool operator ==(TypeDescription left, TypeDescription right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(TypeDescription left, TypeDescription right)
		{
			return !left.Equals(right);
		}
	}
}
