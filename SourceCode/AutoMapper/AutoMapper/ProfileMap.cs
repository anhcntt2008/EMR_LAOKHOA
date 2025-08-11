using AutoMapper.Configuration;
using AutoMapper.Configuration.Conventions;
using AutoMapper.Mappers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace AutoMapper
{
	[DebuggerDisplay("{Name}")]
	public class ProfileMap
	{
		private readonly TypeMapFactory _typeMapFactory = new TypeMapFactory();

		private readonly IEnumerable<ITypeMapConfiguration> _typeMapConfigs;

		private readonly IEnumerable<ITypeMapConfiguration> _openTypeMapConfigs;

		private readonly LockingConcurrentDictionary<Type, TypeDetails> _typeDetails;

		public bool AllowNullCollections
		{
			get;
		}

		public bool AllowNullDestinationValues
		{
			get;
		}

		public bool ConstructorMappingEnabled
		{
			get;
		}

		public bool CreateMissingTypeMaps
		{
			get;
		}

		public bool ValidateInlineMaps
		{
			get;
		}

		public bool EnableNullPropagationForQueryMapping
		{
			get;
		}

		public string Name
		{
			get;
		}

		public Func<FieldInfo, bool> ShouldMapField
		{
			get;
		}

		public Func<PropertyInfo, bool> ShouldMapProperty
		{
			get;
		}

		public IEnumerable<Action<PropertyMap, IMemberConfigurationExpression>> AllPropertyMapActions
		{
			get;
		}

		public IEnumerable<Action<TypeMap, IMappingExpression>> AllTypeMapActions
		{
			get;
		}

		public IEnumerable<string> GlobalIgnores
		{
			get;
		}

		public IEnumerable<IMemberConfiguration> MemberConfigurations
		{
			get;
		}

		public IEnumerable<MethodInfo> SourceExtensionMethods
		{
			get;
		}

		public IEnumerable<IConditionalObjectMapper> TypeConfigurations
		{
			get;
		}

		public IEnumerable<string> Prefixes
		{
			get;
		}

		public IEnumerable<string> Postfixes
		{
			get;
		}

		public IEnumerable<ValueTransformerConfiguration> ValueTransformers
		{
			get;
		}

		public ProfileMap(IProfileConfiguration profile)
			: this(profile, null)
		{
		}

		public ProfileMap(IProfileConfiguration profile, IConfiguration configuration)
		{
			_typeDetails = new LockingConcurrentDictionary<Type, TypeDetails>(TypeDetailsFactory);
			Name = profile.ProfileName;
			AllowNullCollections = (profile.AllowNullCollections ?? configuration?.AllowNullCollections ?? false);
			AllowNullDestinationValues = (profile.AllowNullDestinationValues ?? configuration?.AllowNullDestinationValues ?? true);
			EnableNullPropagationForQueryMapping = (profile.EnableNullPropagationForQueryMapping ?? configuration?.EnableNullPropagationForQueryMapping ?? false);
			ConstructorMappingEnabled = (profile.ConstructorMappingEnabled ?? configuration?.ConstructorMappingEnabled ?? true);
			ShouldMapField = (profile.ShouldMapField ?? configuration?.ShouldMapField ?? ((Func<FieldInfo, bool>)((FieldInfo p) => p.IsPublic())));
			ShouldMapProperty = (profile.ShouldMapProperty ?? configuration?.ShouldMapProperty ?? ((Func<PropertyInfo, bool>)((PropertyInfo p) => p.IsPublic())));
			CreateMissingTypeMaps = (profile.CreateMissingTypeMaps ?? configuration?.CreateMissingTypeMaps ?? true);
			ValidateInlineMaps = (profile.ValidateInlineMaps ?? configuration?.ValidateInlineMaps ?? true);
			TypeConfigurations = profile.TypeConfigurations.Concat(configuration?.TypeConfigurations ?? Enumerable.Empty<IConditionalObjectMapper>()).ToArray();
			ValueTransformers = profile.ValueTransformers.Concat(configuration?.ValueTransformers ?? Enumerable.Empty<ValueTransformerConfiguration>()).ToArray();
			MemberConfigurations = profile.MemberConfigurations.ToArray();
			MemberConfigurations.FirstOrDefault()?.AddMember(delegate(NameSplitMember _)
			{
				_.SourceMemberNamingConvention = profile.SourceMemberNamingConvention;
			});
			MemberConfigurations.FirstOrDefault()?.AddMember(delegate(NameSplitMember _)
			{
				_.DestinationMemberNamingConvention = profile.DestinationMemberNamingConvention;
			});
			GlobalIgnores = profile.GlobalIgnores.Concat(configuration?.GlobalIgnores ?? Enumerable.Empty<string>()).ToArray();
			SourceExtensionMethods = profile.SourceExtensionMethods.Concat(configuration?.SourceExtensionMethods ?? Enumerable.Empty<MethodInfo>()).ToArray();
			AllPropertyMapActions = profile.AllPropertyMapActions.Concat(configuration?.AllPropertyMapActions ?? Enumerable.Empty<Action<PropertyMap, IMemberConfigurationExpression>>()).ToArray();
			AllTypeMapActions = profile.AllTypeMapActions.Concat(configuration?.AllTypeMapActions ?? Enumerable.Empty<Action<TypeMap, IMappingExpression>>()).ToArray();
			Prefixes = profile.MemberConfigurations.Select((IMemberConfiguration m) => m.NameMapper).SelectMany((IParentSourceToDestinationNameMapper m) => m.NamedMappers).OfType<PrePostfixName>()
				.SelectMany((PrePostfixName m) => m.Prefixes)
				.ToArray();
			Postfixes = profile.MemberConfigurations.Select((IMemberConfiguration m) => m.NameMapper).SelectMany((IParentSourceToDestinationNameMapper m) => m.NamedMappers).OfType<PrePostfixName>()
				.SelectMany((PrePostfixName m) => m.Postfixes)
				.ToArray();
			_typeMapConfigs = profile.TypeMapConfigs.ToArray();
			_openTypeMapConfigs = profile.OpenTypeMapConfigs.ToArray();
		}

		public TypeDetails CreateTypeDetails(Type type)
		{
			return _typeDetails.GetOrAdd(type);
		}

		private TypeDetails TypeDetailsFactory(Type type)
		{
			return new TypeDetails(type, this);
		}

		public void Register(TypeMapRegistry typeMapRegistry)
		{
			foreach (ITypeMapConfiguration item in _typeMapConfigs.Where((ITypeMapConfiguration c) => !c.IsOpenGeneric))
			{
				BuildTypeMap(typeMapRegistry, item);
				if (item.ReverseTypeMap != null)
				{
					BuildTypeMap(typeMapRegistry, item.ReverseTypeMap);
				}
			}
		}

		public void Configure(TypeMapRegistry typeMapRegistry)
		{
			foreach (ITypeMapConfiguration item in _typeMapConfigs.Where((ITypeMapConfiguration c) => !c.IsOpenGeneric))
			{
				Configure(typeMapRegistry, item);
				if (item.ReverseTypeMap != null)
				{
					Configure(typeMapRegistry, item.ReverseTypeMap);
				}
			}
		}

		private void BuildTypeMap(TypeMapRegistry typeMapRegistry, ITypeMapConfiguration config)
		{
			TypeMap typeMap = _typeMapFactory.CreateTypeMap(config.SourceType, config.DestinationType, this);
			config.Configure(typeMap);
			typeMapRegistry.RegisterTypeMap(typeMap);
		}

		private void Configure(TypeMapRegistry typeMapRegistry, ITypeMapConfiguration typeMapConfiguration)
		{
			TypeMap typeMap = typeMapRegistry.GetTypeMap(typeMapConfiguration.Types);
			Configure(typeMapRegistry, typeMap);
		}

		private void Configure(TypeMapRegistry typeMapRegistry, TypeMap typeMap)
		{
			foreach (Action<TypeMap, IMappingExpression> allTypeMapAction in AllTypeMapActions)
			{
				MappingExpression mappingExpression = new MappingExpression(typeMap.Types, typeMap.ConfiguredMemberList);
				allTypeMapAction(typeMap, mappingExpression);
				mappingExpression.Configure(typeMap);
			}
			foreach (Action<PropertyMap, IMemberConfigurationExpression> allPropertyMapAction in AllPropertyMapActions)
			{
				PropertyMap[] propertyMaps = typeMap.GetPropertyMaps();
				foreach (PropertyMap propertyMap in propertyMaps)
				{
					MappingExpression.MemberConfigurationExpression memberConfigurationExpression = new MappingExpression.MemberConfigurationExpression(propertyMap.DestinationProperty, typeMap.SourceType);
					allPropertyMapAction(propertyMap, memberConfigurationExpression);
					memberConfigurationExpression.Configure(typeMap);
				}
			}
			ApplyBaseMaps(typeMapRegistry, typeMap, typeMap);
			ApplyDerivedMaps(typeMapRegistry, typeMap, typeMap);
		}

		public bool IsConventionMap(TypePair types)
		{
			return TypeConfigurations.Any((IConditionalObjectMapper c) => c.IsMatch(types));
		}

		public TypeMap CreateConventionTypeMap(TypeMapRegistry typeMapRegistry, TypePair types)
		{
			TypeMap typeMap = _typeMapFactory.CreateTypeMap(types.SourceType, types.DestinationType, this);
			typeMap.IsConventionMap = true;
			new MappingExpression(typeMap.Types, typeMap.ConfiguredMemberList).Configure(typeMap);
			Configure(typeMapRegistry, typeMap);
			return typeMap;
		}

		public TypeMap CreateInlineMap(TypeMapRegistry typeMapRegistry, TypePair types)
		{
			TypeMap typeMap = _typeMapFactory.CreateTypeMap(types.SourceType, types.DestinationType, this);
			typeMap.IsConventionMap = true;
			Configure(typeMapRegistry, typeMap);
			return typeMap;
		}

		public TypeMap CreateClosedGenericTypeMap(ITypeMapConfiguration openMapConfig, TypeMapRegistry typeMapRegistry, TypePair closedTypes)
		{
			TypeMap typeMap = _typeMapFactory.CreateTypeMap(closedTypes.SourceType, closedTypes.DestinationType, this);
			openMapConfig.Configure(typeMap);
			Configure(typeMapRegistry, typeMap);
			if (typeMap.TypeConverterType != null)
			{
				IEnumerable<Type> source = (openMapConfig.SourceType.IsGenericTypeDefinition() ? closedTypes.SourceType.GetGenericArguments() : new Type[0]).Concat(openMapConfig.DestinationType.IsGenericTypeDefinition() ? closedTypes.DestinationType.GetGenericArguments() : new Type[0]);
				int count = typeMap.TypeConverterType.GetGenericParameters().Length;
				typeMap.TypeConverterType = typeMap.TypeConverterType.MakeGenericType(source.Take(count).ToArray());
			}
			if (typeMap.DestinationTypeOverride?.IsGenericTypeDefinition() ?? false)
			{
				int count2 = typeMap.DestinationTypeOverride.GetGenericParameters().Length;
				typeMap.DestinationTypeOverride = typeMap.DestinationTypeOverride.MakeGenericType(closedTypes.DestinationType.GetGenericArguments().Take(count2).ToArray());
			}
			return typeMap;
		}

		public ITypeMapConfiguration GetGenericMap(TypePair closedTypes)
		{
			return (from tm in _openTypeMapConfigs.SelectMany((ITypeMapConfiguration tm) => (tm.ReverseTypeMap == null) ? new ITypeMapConfiguration[1]
				{
					tm
				} : new ITypeMapConfiguration[2]
				{
					tm,
					tm.ReverseTypeMap
				})
				where tm.Types.SourceType.GetGenericTypeDefinitionIfGeneric() == closedTypes.SourceType.GetGenericTypeDefinitionIfGeneric() && tm.Types.DestinationType.GetGenericTypeDefinitionIfGeneric() == closedTypes.DestinationType.GetGenericTypeDefinitionIfGeneric()
				orderby tm.DestinationType == closedTypes.DestinationType descending, tm.SourceType == closedTypes.SourceType descending
				select tm).FirstOrDefault();
		}

		private static void ApplyBaseMaps(TypeMapRegistry typeMapRegistry, TypeMap derivedMap, TypeMap currentMap)
		{
			foreach (TypeMap item in from baseMap in currentMap.IncludedBaseTypes.Select(typeMapRegistry.GetTypeMap)
				where baseMap != null
				select baseMap)
			{
				item.IncludeDerivedTypes(currentMap.SourceType, currentMap.DestinationType);
				derivedMap.AddInheritedMap(item);
				ApplyBaseMaps(typeMapRegistry, derivedMap, item);
			}
		}

		private void ApplyDerivedMaps(TypeMapRegistry typeMapRegistry, TypeMap baseMap, TypeMap typeMap)
		{
			foreach (TypeMap item in from map in typeMap.IncludedDerivedTypes.Select(typeMapRegistry.GetTypeMap)
				where map != null
				select map)
			{
				item.AddInheritedMap(baseMap);
				ApplyDerivedMaps(typeMapRegistry, baseMap, item);
			}
		}
	}
}
