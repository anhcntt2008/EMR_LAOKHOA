using AutoMapper.Configuration;
using AutoMapper.Execution;
using AutoMapper.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper
{
	[DebuggerDisplay("{SourceType.Name} -> {DestinationType.Name}")]
	public class TypeMap
	{
		private readonly List<LambdaExpression> _afterMapActions = new List<LambdaExpression>();

		private readonly List<LambdaExpression> _beforeMapActions = new List<LambdaExpression>();

		private readonly HashSet<TypePair> _includedDerivedTypes = new HashSet<TypePair>();

		private readonly HashSet<TypePair> _includedBaseTypes = new HashSet<TypePair>();

		private readonly List<PropertyMap> _propertyMaps = new List<PropertyMap>();

		private readonly List<PathMap> _pathMaps = new List<PathMap>();

		private readonly List<SourceMemberConfig> _sourceMemberConfigs = new List<SourceMemberConfig>();

		private readonly IList<PropertyMap> _inheritedMaps = new List<PropertyMap>();

		private PropertyMap[] _orderedPropertyMaps;

		private bool _sealed;

		private readonly IList<TypeMap> _inheritedTypeMaps = new List<TypeMap>();

		private readonly List<ValueTransformerConfiguration> _valueTransformerConfigs = new List<ValueTransformerConfiguration>();

		public LambdaExpression MapExpression
		{
			get;
			private set;
		}

		public TypePair Types
		{
			get;
		}

		public ConstructorMap ConstructorMap
		{
			get;
			set;
		}

		public TypeDetails SourceTypeDetails
		{
			get;
		}

		public TypeDetails DestinationTypeDetails
		{
			get;
		}

		public Type SourceType => SourceTypeDetails.Type;

		public Type DestinationType => DestinationTypeDetails.Type;

		public ProfileMap Profile
		{
			get;
		}

		public LambdaExpression CustomMapper
		{
			get;
			set;
		}

		public LambdaExpression CustomProjection
		{
			get;
			set;
		}

		public LambdaExpression DestinationCtor
		{
			get;
			set;
		}

		public Type DestinationTypeOverride
		{
			get;
			set;
		}

		public Type DestinationTypeToUse => DestinationTypeOverride ?? DestinationType;

		public bool ConstructDestinationUsingServiceLocator
		{
			get;
			set;
		}

		public MemberList ConfiguredMemberList
		{
			get;
			set;
		}

		public IEnumerable<TypePair> IncludedDerivedTypes => _includedDerivedTypes;

		public IEnumerable<TypePair> IncludedBaseTypes => _includedBaseTypes;

		public IEnumerable<LambdaExpression> BeforeMapActions => _beforeMapActions;

		public IEnumerable<LambdaExpression> AfterMapActions => _afterMapActions;

		public IEnumerable<ValueTransformerConfiguration> ValueTransformers => _valueTransformerConfigs;

		public bool PreserveReferences
		{
			get;
			set;
		}

		public LambdaExpression Condition
		{
			get;
			set;
		}

		public int MaxDepth
		{
			get;
			set;
		}

		public LambdaExpression Substitution
		{
			get;
			set;
		}

		public LambdaExpression ConstructExpression
		{
			get;
			set;
		}

		public Type TypeConverterType
		{
			get;
			set;
		}

		public bool DisableConstructorValidation
		{
			get;
			set;
		}

		public IEnumerable<PathMap> PathMaps => _pathMaps;

		public bool IsConventionMap
		{
			get;
			set;
		}

		public bool? IsValid
		{
			get;
			set;
		}

		public TypeMap(TypeDetails sourceType, TypeDetails destinationType, ProfileMap profile)
		{
			SourceTypeDetails = sourceType;
			DestinationTypeDetails = destinationType;
			Types = new TypePair(sourceType.Type, destinationType.Type);
			Profile = profile;
		}

		public PathMap FindOrCreatePathMapFor(LambdaExpression destinationExpression, MemberPath path, TypeMap typeMap)
		{
			PathMap pathMap = _pathMaps.SingleOrDefault((PathMap p) => p.MemberPath == path);
			if (pathMap == null)
			{
				pathMap = new PathMap(destinationExpression, path, typeMap);
				_pathMaps.Add(pathMap);
			}
			return pathMap;
		}

		public PathMap FindPathMapByDestinationPath(string destinationFullPath)
		{
			return PathMaps.SingleOrDefault((PathMap item) => string.Join(".", item.MemberPath.Members.Select((MemberInfo m) => m.Name)) == destinationFullPath);
		}

		public PropertyMap[] GetPropertyMaps()
		{
			return _orderedPropertyMaps ?? _propertyMaps.Concat(_inheritedMaps).ToArray();
		}

		public bool ConstructorParameterMatches(string destinationPropertyName)
		{
			return ConstructorMap?.CtorParams.Any((ConstructorParameterMap c) => !c.DefaultValue && string.Equals(c.Parameter.Name, destinationPropertyName, StringComparison.OrdinalIgnoreCase)) ?? false;
		}

		public void AddPropertyMap(MemberInfo destProperty, IEnumerable<MemberInfo> resolvers)
		{
			PropertyMap propertyMap = new PropertyMap(destProperty, this);
			propertyMap.ChainMembers(resolvers);
			_propertyMaps.Add(propertyMap);
		}

		public string[] GetUnmappedPropertyNames()
		{
			string[] second = GetPropertyNames(_propertyMaps);
			string[] second2 = GetPropertyNames(_inheritedMaps);
			IEnumerable<string> source;
			if (ConfiguredMemberList == MemberList.Destination)
			{
				source = DestinationTypeDetails.PublicWriteAccessors.Select((MemberInfo p) => p.Name).Except(second).Except(second2);
			}
			else
			{
				IEnumerable<string> second3 = from pm in _propertyMaps
					where pm.IsMapped() && pm.SourceMember != null && pm.SourceMember.Name != pm.DestinationProperty.Name
					select pm.SourceMember.Name;
				List<string> second4 = (from smc in _sourceMemberConfigs
					where smc.IsIgnored()
					select smc into pm
					select pm.SourceMember.Name).ToList();
				source = SourceTypeDetails.PublicReadAccessors.Select((MemberInfo p) => p.Name).Except(second).Except(second2)
					.Except(second3)
					.Except(second4);
			}
			return source.Where((string memberName) => !Profile.GlobalIgnores.Any(memberName.StartsWith)).ToArray();
			string GetPropertyName(PropertyMap pm)
			{
				if (ConfiguredMemberList != 0)
				{
					if (!(pm.SourceMember != null))
					{
						return pm.DestinationProperty.Name;
					}
					return pm.SourceMember.Name;
				}
				return pm.DestinationProperty.Name;
			}
			string[] GetPropertyNames(IEnumerable<PropertyMap> propertyMaps)
			{
				return propertyMaps.Where((PropertyMap pm) => pm.IsMapped()).Select(GetPropertyName).ToArray();
			}
		}

		public bool PassesCtorValidation()
		{
			if (DisableConstructorValidation)
			{
				return true;
			}
			if (DestinationCtor != null)
			{
				return true;
			}
			if (ConstructDestinationUsingServiceLocator)
			{
				return true;
			}
			if (ConstructorMap?.CanResolve ?? false)
			{
				return true;
			}
			if (DestinationTypeToUse.IsInterface())
			{
				return true;
			}
			if (DestinationTypeToUse.IsAbstract())
			{
				return true;
			}
			if (DestinationTypeToUse.IsGenericTypeDefinition())
			{
				return true;
			}
			if (DestinationTypeToUse.IsValueType())
			{
				return true;
			}
			return (from ci in DestinationTypeToUse.GetDeclaredConstructors()
				where !ci.IsStatic
				select ci).FirstOrDefault((ConstructorInfo c) => c.GetParameters().All((ParameterInfo p) => p.IsOptional)) != null;
		}

		public PropertyMap FindOrCreatePropertyMapFor(MemberInfo destinationProperty)
		{
			PropertyMap existingPropertyMapFor = GetExistingPropertyMapFor(destinationProperty);
			if (existingPropertyMapFor != null)
			{
				return existingPropertyMapFor;
			}
			existingPropertyMapFor = new PropertyMap(destinationProperty, this);
			_propertyMaps.Add(existingPropertyMapFor);
			return existingPropertyMapFor;
		}

		public void IncludeDerivedTypes(Type derivedSourceType, Type derivedDestinationType)
		{
			TypePair item = new TypePair(derivedSourceType, derivedDestinationType);
			if (item.Equals(Types))
			{
				throw new InvalidOperationException("You cannot include a type map into itself.");
			}
			_includedDerivedTypes.Add(item);
		}

		public void IncludeBaseTypes(Type baseSourceType, Type baseDestinationType)
		{
			TypePair item = new TypePair(baseSourceType, baseDestinationType);
			if (item.Equals(Types))
			{
				throw new InvalidOperationException("You cannot include a type map into itself.");
			}
			_includedBaseTypes.Add(item);
		}

		internal void IgnorePaths(MemberInfo destinationMember)
		{
			foreach (PathMap item in _pathMaps.Where((PathMap pm) => pm.MemberPath.First == destinationMember))
			{
				item.Ignored = true;
			}
		}

		public Type GetDerivedTypeFor(Type derivedSourceType)
		{
			if (DestinationTypeOverride != null)
			{
				return DestinationTypeOverride;
			}
			return _includedDerivedTypes.FirstOrDefault((TypePair tp) => tp.SourceType == derivedSourceType).DestinationType ?? DestinationType;
		}

		public bool TypeHasBeenIncluded(TypePair derivedTypes)
		{
			return _includedDerivedTypes.Contains(derivedTypes);
		}

		public bool HasDerivedTypesToInclude()
		{
			if (!_includedDerivedTypes.Any())
			{
				return DestinationTypeOverride != null;
			}
			return true;
		}

		public void AddBeforeMapAction(LambdaExpression beforeMap)
		{
			if (!_beforeMapActions.Contains(beforeMap))
			{
				_beforeMapActions.Add(beforeMap);
			}
		}

		public void AddAfterMapAction(LambdaExpression afterMap)
		{
			if (!_afterMapActions.Contains(afterMap))
			{
				_afterMapActions.Add(afterMap);
			}
		}

		public void AddValueTransformation(ValueTransformerConfiguration valueTransformerConfiguration)
		{
			_valueTransformerConfigs.Add(valueTransformerConfiguration);
		}

		public void Seal(IConfigurationProvider configurationProvider, Stack<TypeMap> typeMapsPath = null)
		{
			if (_sealed)
			{
				return;
			}
			_sealed = true;
			foreach (TypeMap inheritedTypeMap in _inheritedTypeMaps)
			{
				ApplyInheritedTypeMap(inheritedTypeMap);
			}
			_orderedPropertyMaps = (from map in _propertyMaps.Union(_inheritedMaps)
				orderby map.MappingOrder
				select map).ToArray();
			MapExpression = new TypeMapPlanBuilder(configurationProvider, this).CreateMapperLambda(typeMapsPath);
		}

		public PropertyMap GetExistingPropertyMapFor(MemberInfo destinationProperty)
		{
			if (!destinationProperty.DeclaringType.IsAssignableFrom(DestinationType))
			{
				return null;
			}
			PropertyMap propertyMap = _propertyMaps.FirstOrDefault((PropertyMap pm) => pm.DestinationProperty.Name.Equals(destinationProperty.Name));
			if (propertyMap != null)
			{
				return propertyMap;
			}
			propertyMap = _inheritedMaps.FirstOrDefault((PropertyMap pm) => pm.DestinationProperty.Name.Equals(destinationProperty.Name));
			if (propertyMap == null)
			{
				return null;
			}
			PropertyInfo propertyInfo = propertyMap.DestinationProperty as PropertyInfo;
			if (propertyInfo == null)
			{
				return propertyMap;
			}
			MethodInfo getMethod = propertyInfo.GetGetMethod();
			if (getMethod.IsAbstract || getMethod.IsVirtual)
			{
				return propertyMap;
			}
			MethodInfo getMethod2 = ((PropertyInfo)destinationProperty).GetGetMethod();
			if (getMethod.DeclaringType == getMethod2.DeclaringType)
			{
				return propertyMap;
			}
			return null;
		}

		public void InheritTypes(TypeMap inheritedTypeMap)
		{
			foreach (TypePair item in inheritedTypeMap._includedDerivedTypes.Where((TypePair includedDerivedType) => !_includedDerivedTypes.Contains(includedDerivedType)))
			{
				_includedDerivedTypes.Add(item);
			}
		}

		public SourceMemberConfig FindOrCreateSourceMemberConfigFor(MemberInfo sourceMember)
		{
			SourceMemberConfig sourceMemberConfig = _sourceMemberConfigs.FirstOrDefault((SourceMemberConfig smc) => object.Equals(smc.SourceMember, sourceMember));
			if (sourceMemberConfig != null)
			{
				return sourceMemberConfig;
			}
			sourceMemberConfig = new SourceMemberConfig(sourceMember);
			_sourceMemberConfigs.Add(sourceMemberConfig);
			return sourceMemberConfig;
		}

		public void AddInheritedMap(TypeMap inheritedTypeMap)
		{
			_inheritedTypeMaps.Add(inheritedTypeMap);
		}

		public bool ShouldCheckForValid()
		{
			if (CustomMapper == null && CustomProjection == null && TypeConverterType == null && DestinationTypeOverride == null && ConfiguredMemberList != MemberList.None)
			{
				return !(IsValid ?? false);
			}
			return false;
		}

		private void ApplyInheritedTypeMap(TypeMap inheritedTypeMap)
		{
			foreach (PropertyMap inheritedMappedProperty in from m in inheritedTypeMap.GetPropertyMaps()
				where m.IsMapped()
				select m)
			{
				PropertyMap propertyMap = GetPropertyMaps().SingleOrDefault((PropertyMap m) => m.DestinationProperty.Name == inheritedMappedProperty.DestinationProperty.Name);
				if (propertyMap != null)
				{
					propertyMap.ApplyInheritedPropertyMap(inheritedMappedProperty);
					continue;
				}
				PropertyMap item = new PropertyMap(inheritedMappedProperty, this);
				_inheritedMaps.Add(item);
			}
			foreach (LambdaExpression beforeMapAction in inheritedTypeMap._beforeMapActions)
			{
				AddBeforeMapAction(beforeMapAction);
			}
			foreach (LambdaExpression afterMapAction in inheritedTypeMap._afterMapActions)
			{
				AddAfterMapAction(afterMapAction);
			}
			IEnumerable<SourceMemberConfig> collection = inheritedTypeMap._sourceMemberConfigs.Where((SourceMemberConfig baseConfig) => _sourceMemberConfigs.All((SourceMemberConfig derivedConfig) => derivedConfig.SourceMember != baseConfig.SourceMember));
			_sourceMemberConfigs.AddRange(collection);
			IEnumerable<PathMap> collection2 = inheritedTypeMap.PathMaps.Where((PathMap baseConfig) => PathMaps.All((PathMap derivedConfig) => derivedConfig.MemberPath != baseConfig.MemberPath));
			_pathMaps.AddRange(collection2);
		}
	}
}
