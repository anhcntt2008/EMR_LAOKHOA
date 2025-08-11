namespace AutoMapper
{
	public struct ValidationContext
	{
		public IObjectMapper ObjectMapper
		{
			get;
		}

		public PropertyMap PropertyMap
		{
			get;
		}

		public TypeMap TypeMap
		{
			get;
		}

		public TypePair Types
		{
			get;
		}

		public ValidationContext(TypePair types, PropertyMap propertyMap, IObjectMapper objectMapper)
			: this(types, propertyMap, objectMapper, null)
		{
		}

		public ValidationContext(TypePair types, PropertyMap propertyMap, TypeMap typeMap)
			: this(types, propertyMap, null, typeMap)
		{
		}

		private ValidationContext(TypePair types, PropertyMap propertyMap, IObjectMapper objectMapper, TypeMap typeMap)
		{
			ObjectMapper = objectMapper;
			TypeMap = typeMap;
			Types = types;
			PropertyMap = propertyMap;
		}
	}
}
