using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoMapper.Configuration.Conventions
{
	public class AllMemberInfo : IGetTypeInfoMembers
	{
		private readonly IList<Func<MemberInfo, bool>> _predicates = new List<Func<MemberInfo, bool>>();

		public IEnumerable<MemberInfo> GetMemberInfos(TypeDetails typeInfo)
		{
			if (_predicates.Any())
			{
				return typeInfo.AllMembers.Where((MemberInfo m) => _predicates.All((Func<MemberInfo, bool> p) => p(m))).ToList();
			}
			return typeInfo.AllMembers;
		}

		public IGetTypeInfoMembers AddCondition(Func<MemberInfo, bool> predicate)
		{
			_predicates.Add(predicate);
			return this;
		}
	}
}
