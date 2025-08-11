using System;
using System.Linq.Expressions;

namespace AutoMapper
{
	public struct ValueTransformerConfiguration
	{
		public Type ValueType
		{
			get;
		}

		public LambdaExpression TransformerExpression
		{
			get;
		}

		public ValueTransformerConfiguration(Type valueType, LambdaExpression transformerExpression)
		{
			ValueType = valueType;
			TransformerExpression = transformerExpression;
		}

		public bool IsMatch(PropertyMap propertyMap)
		{
			return propertyMap.DestinationPropertyType.IsAssignableFrom(ValueType);
		}
	}
}
