using System;
using System.Linq;
using System.Reflection;

namespace AutoMapper.QueryableExtensions.Impl
{
	public static class QueryMapperHelper
	{
		public static PropertyMap GetPropertyMap(this IConfigurationProvider config, MemberInfo sourceMemberInfo, Type destinationMemberType)
		{
			TypeMap typeMap = config.CheckIfMapExists(sourceMemberInfo.DeclaringType, destinationMemberType);
			PropertyMap propertyMap = typeMap.GetPropertyMaps().FirstOrDefault((PropertyMap pm) => pm.CanResolveValue() && pm.SourceMember != null && pm.SourceMember.Name == sourceMemberInfo.Name);
			if (propertyMap == null)
			{
				throw PropertyConfigurationException(typeMap, sourceMemberInfo.Name);
			}
			return propertyMap;
		}

		public static PropertyMap GetPropertyMapByDestinationProperty(this TypeMap typeMap, string destinationPropertyName)
		{
			PropertyMap propertyMap = typeMap.GetPropertyMaps().SingleOrDefault((PropertyMap item) => item.DestinationProperty.Name == destinationPropertyName);
			if (propertyMap == null)
			{
				throw PropertyConfigurationException(typeMap, destinationPropertyName);
			}
			return propertyMap;
		}

		public static TypeMap CheckIfMapExists(this IConfigurationProvider config, Type sourceType, Type destinationType)
		{
			return config.ResolveTypeMap(sourceType, destinationType) ?? throw MissingMapException(sourceType, destinationType);
		}

		public static Exception PropertyConfigurationException(TypeMap typeMap, params string[] unmappedPropertyNames)
		{
			return new AutoMapperConfigurationException(new AutoMapperConfigurationException.TypeMapConfigErrors[1]
			{
				new AutoMapperConfigurationException.TypeMapConfigErrors(typeMap, unmappedPropertyNames, canConstruct: true)
			});
		}

		public static Exception MissingMapException(Type sourceType, Type destinationType)
		{
			return new InvalidOperationException($"Missing map from {sourceType} to {destinationType}. Create using Mapper.CreateMap<{sourceType.Name}, {destinationType.Name}>.");
		}
	}
}
