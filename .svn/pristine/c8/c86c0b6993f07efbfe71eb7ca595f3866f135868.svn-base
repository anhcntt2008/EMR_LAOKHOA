using System;
using System.Reflection;

namespace AutoMapper.Configuration.Conventions
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class MapToAttribute : SourceToDestinationMapperAttribute
	{
		public string MatchingName
		{
			get;
		}

		public MapToAttribute(string matchingName)
		{
			MatchingName = matchingName;
		}

		public override bool IsMatch(TypeDetails typeInfo, MemberInfo memberInfo, Type destType, Type destMemberType, string nameToSearch)
		{
			return string.Compare(MatchingName, nameToSearch, StringComparison.OrdinalIgnoreCase) == 0;
		}
	}
}
