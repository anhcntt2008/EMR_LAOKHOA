using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoMapper
{
	public class ConfigurationValidator
	{
		private readonly IConfigurationProvider _config;

		public ConfigurationValidator(IConfigurationProvider config)
		{
			_config = config;
		}

		public void AssertConfigurationIsValid(IEnumerable<TypeMap> typeMaps)
		{
			TypeMap[] obj = (typeMaps as TypeMap[]) ?? typeMaps.ToArray();
			AutoMapperConfigurationException.TypeMapConfigErrors[] array = (from typeMap in obj
				where typeMap.ShouldCheckForValid()
				let unmappedPropertyNames = typeMap.GetUnmappedPropertyNames()
				let canConstruct = typeMap.PassesCtorValidation()
				where unmappedPropertyNames.Length != 0 || !canConstruct
				select new AutoMapperConfigurationException.TypeMapConfigErrors(typeMap, unmappedPropertyNames, canConstruct)).ToArray();
			if (array.Any())
			{
				throw new AutoMapperConfigurationException(array);
			}
			List<TypeMap> typeMapsChecked = new List<TypeMap>();
			List<Exception> list = new List<Exception>();
			TypeMap[] array2 = obj;
			foreach (TypeMap typeMap2 in array2)
			{
				try
				{
					DryRunTypeMap(typeMapsChecked, typeMap2.Types, typeMap2, null);
				}
				catch (Exception item)
				{
					list.Add(item);
				}
			}
			if (list.Count > 1)
			{
				throw new AggregateException(list);
			}
			if (list.Count > 0)
			{
				throw list[0];
			}
		}

		private void DryRunTypeMap(ICollection<TypeMap> typeMapsChecked, TypePair types, TypeMap typeMap, PropertyMap propertyMap)
		{
			if (typeMap == null)
			{
				typeMap = _config.ResolveTypeMap(types.SourceType, types.DestinationType);
			}
			if (typeMap != null)
			{
				if (!typeMapsChecked.Contains(typeMap))
				{
					typeMapsChecked.Add(typeMap);
					if (typeMap.CustomMapper == null && !(typeMap.TypeConverterType != null))
					{
						ValidationContext context = new ValidationContext(types, propertyMap, typeMap);
						_config.Validate(context);
						CheckPropertyMaps(typeMapsChecked, typeMap);
						typeMap.IsValid = true;
					}
				}
				return;
			}
			IObjectMapper objectMapper = _config.FindMapper(types);
			if (objectMapper == null)
			{
				if (propertyMap.TypeMap.Profile.CreateMissingTypeMaps)
				{
					return;
				}
				throw new AutoMapperConfigurationException(propertyMap.TypeMap.Types)
				{
					PropertyMap = propertyMap
				};
			}
			ValidationContext context2 = new ValidationContext(types, propertyMap, objectMapper);
			_config.Validate(context2);
			IObjectMapperInfo objectMapperInfo;
			if ((objectMapperInfo = (objectMapper as IObjectMapperInfo)) != null)
			{
				TypePair associatedTypes = objectMapperInfo.GetAssociatedTypes(types);
				DryRunTypeMap(typeMapsChecked, associatedTypes, null, propertyMap);
			}
		}

		private void CheckPropertyMaps(ICollection<TypeMap> typeMapsChecked, TypeMap typeMap)
		{
			PropertyMap[] propertyMaps = typeMap.GetPropertyMaps();
			foreach (PropertyMap propertyMap in propertyMaps)
			{
				if (propertyMap.Ignored)
				{
					continue;
				}
				Type sourceType = propertyMap.SourceType;
				if (!(sourceType == null))
				{
					if (sourceType.IsGenericParameter || sourceType == typeof(object))
					{
						break;
					}
					Type memberType = propertyMap.DestinationProperty.GetMemberType();
					DryRunTypeMap(typeMapsChecked, new TypePair(sourceType, memberType), null, propertyMap);
				}
			}
		}
	}
}
