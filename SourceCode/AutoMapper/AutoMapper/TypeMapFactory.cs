using AutoMapper.Configuration.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoMapper
{
	public class TypeMapFactory
	{
		public TypeMap CreateTypeMap(Type sourceType, Type destinationType, ProfileMap options)
		{
			TypeDetails typeDetails = options.CreateTypeDetails(sourceType);
			TypeDetails typeDetails2 = options.CreateTypeDetails(destinationType);
			TypeMap typeMap = new TypeMap(typeDetails, typeDetails2, options);
			foreach (MemberInfo publicWriteAccessor in typeDetails2.PublicWriteAccessors)
			{
				LinkedList<MemberInfo> linkedList = new LinkedList<MemberInfo>();
				if (MapDestinationPropertyToSource(options, typeDetails, publicWriteAccessor.DeclaringType, publicWriteAccessor.GetMemberType(), publicWriteAccessor.Name, linkedList))
				{
					typeMap.AddPropertyMap(publicWriteAccessor, linkedList);
				}
			}
			if (!destinationType.IsAbstract())
			{
				foreach (ConstructorInfo item in typeDetails2.Constructors.OrderByDescending((ConstructorInfo ci) => ci.GetParameters().Length))
				{
					if (MapDestinationCtorToSource(typeMap, item, typeDetails, options))
					{
						return typeMap;
					}
				}
				return typeMap;
			}
			return typeMap;
		}

		private bool MapDestinationPropertyToSource(ProfileMap options, TypeDetails sourceTypeInfo, Type destType, Type destMemberType, string destMemberInfo, LinkedList<MemberInfo> members)
		{
			return options.MemberConfigurations.Any((IMemberConfiguration _) => _.MapDestinationPropertyToSource(options, sourceTypeInfo, destType, destMemberType, destMemberInfo, members));
		}

		private bool MapDestinationCtorToSource(TypeMap typeMap, ConstructorInfo destCtor, TypeDetails sourceTypeInfo, ProfileMap options)
		{
			ParameterInfo[] parameters = destCtor.GetParameters();
			if (parameters.Length == 0 || !options.ConstructorMappingEnabled)
			{
				return false;
			}
			ConstructorMap constructorMap = new ConstructorMap(destCtor, typeMap);
			ParameterInfo[] array = parameters;
			foreach (ParameterInfo parameterInfo in array)
			{
				LinkedList<MemberInfo> linkedList = new LinkedList<MemberInfo>();
				bool flag = MapDestinationPropertyToSource(options, sourceTypeInfo, destCtor.DeclaringType, parameterInfo.GetType(), parameterInfo.Name, linkedList);
				if (!flag && parameterInfo.GetHasDefaultValue())
				{
					flag = true;
				}
				constructorMap.AddParameter(parameterInfo, linkedList.ToArray(), flag);
			}
			typeMap.ConstructorMap = constructorMap;
			return constructorMap.CanResolve;
		}
	}
}
