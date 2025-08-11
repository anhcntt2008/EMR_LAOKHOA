using System;
using System.Collections.Generic;
using System.Reflection;

namespace AutoMapper.Configuration.Conventions
{
	public interface IMemberConfiguration
	{
		IList<IChildMemberConfiguration> MemberMappers
		{
			get;
		}

		IParentSourceToDestinationNameMapper NameMapper
		{
			get;
			set;
		}

		IMemberConfiguration AddMember<TMemberMapper>(Action<TMemberMapper> setupAction = null) where TMemberMapper : IChildMemberConfiguration, new();

		IMemberConfiguration AddName<TNameMapper>(Action<TNameMapper> setupAction = null) where TNameMapper : ISourceToDestinationNameMapper, new();

		bool MapDestinationPropertyToSource(ProfileMap options, TypeDetails sourceType, Type destType, Type destMemberType, string nameToSearch, LinkedList<MemberInfo> resolvers);
	}
}
