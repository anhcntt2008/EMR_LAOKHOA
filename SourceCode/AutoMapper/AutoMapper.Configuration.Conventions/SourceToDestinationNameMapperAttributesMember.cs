using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoMapper.Configuration.Conventions
{
	public class SourceToDestinationNameMapperAttributesMember : ISourceToDestinationNameMapper
	{
		private struct SourceMember
		{
			public MemberInfo Member
			{
				get;
			}

			public SourceToDestinationMapperAttribute Attribute
			{
				get;
			}

			public SourceMember(MemberInfo sourceMember)
			{
				Member = sourceMember;
				Attribute = sourceMember.GetCustomAttribute<SourceToDestinationMapperAttribute>(inherit: true);
			}
		}

		private static readonly SourceMember[] Empty = new SourceMember[0];

		private readonly Dictionary<TypeDetails, SourceMember[]> _allSourceMembers = new Dictionary<TypeDetails, SourceMember[]>();

		public MemberInfo GetMatchingMemberInfo(IGetTypeInfoMembers getTypeInfoMembers, TypeDetails typeInfo, Type destType, Type destMemberType, string nameToSearch)
		{
			if (!_allSourceMembers.TryGetValue(typeInfo, out SourceMember[] value))
			{
				value = (from sourceMember in getTypeInfoMembers.GetMemberInfos(typeInfo)
					select new SourceMember(sourceMember) into s
					where s.Attribute != null
					select s).ToArray();
				_allSourceMembers[typeInfo] = ((value.Length == 0) ? Empty : value);
			}
			return value.FirstOrDefault((SourceMember d) => d.Attribute.IsMatch(typeInfo, d.Member, destType, destMemberType, nameToSearch)).Member;
		}
	}
}
