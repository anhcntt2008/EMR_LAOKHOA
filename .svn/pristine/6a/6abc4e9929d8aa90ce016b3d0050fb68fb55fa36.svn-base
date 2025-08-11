using AutoMapper.Configuration.Conventions;
using AutoMapper.Mappers;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace AutoMapper.Configuration
{
	public interface IProfileConfiguration
	{
		IEnumerable<IMemberConfiguration> MemberConfigurations
		{
			get;
		}

		IEnumerable<IConditionalObjectMapper> TypeConfigurations
		{
			get;
		}

		bool? ConstructorMappingEnabled
		{
			get;
		}

		bool? AllowNullDestinationValues
		{
			get;
		}

		bool? AllowNullCollections
		{
			get;
		}

		bool? EnableNullPropagationForQueryMapping
		{
			get;
		}

		bool? CreateMissingTypeMaps
		{
			get;
		}

		bool? ValidateInlineMaps
		{
			get;
		}

		IEnumerable<Action<TypeMap, IMappingExpression>> AllTypeMapActions
		{
			get;
		}

		IEnumerable<Action<PropertyMap, IMemberConfigurationExpression>> AllPropertyMapActions
		{
			get;
		}

		IEnumerable<MethodInfo> SourceExtensionMethods
		{
			get;
		}

		Func<PropertyInfo, bool> ShouldMapProperty
		{
			get;
		}

		Func<FieldInfo, bool> ShouldMapField
		{
			get;
		}

		string ProfileName
		{
			get;
		}

		IEnumerable<string> GlobalIgnores
		{
			get;
		}

		INamingConvention SourceMemberNamingConvention
		{
			get;
		}

		INamingConvention DestinationMemberNamingConvention
		{
			get;
		}

		IEnumerable<ITypeMapConfiguration> TypeMapConfigs
		{
			get;
		}

		IEnumerable<ITypeMapConfiguration> OpenTypeMapConfigs
		{
			get;
		}

		IEnumerable<ValueTransformerConfiguration> ValueTransformers
		{
			get;
		}
	}
}
