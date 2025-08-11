using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace AutoMapper.Configuration.Conventions
{
	public class ReplaceName : ISourceToDestinationNameMapper
	{
		private ICollection<MemberNameReplacer> MemberNameReplacers
		{
			get;
		}

		public ReplaceName()
		{
			MemberNameReplacers = new Collection<MemberNameReplacer>();
		}

		public ReplaceName AddReplace(string original, string newValue)
		{
			MemberNameReplacers.Add(new MemberNameReplacer(original, newValue));
			return this;
		}

		public MemberInfo GetMatchingMemberInfo(IGetTypeInfoMembers getTypeInfoMembers, TypeDetails typeInfo, Type destType, Type destMemberType, string nameToSearch)
		{
			IEnumerable<string> source = PossibleNames(nameToSearch);
			var possibleDestNames = from mi in getTypeInfoMembers.GetMemberInfos(typeInfo)
				select new
				{
					mi = mi,
					possibles = PossibleNames(mi.Name)
				};
			return (from sourceName in source
				from destName in possibleDestNames
				select new
				{
					sourceName,
					destName
				}).FirstOrDefault(pair => pair.destName.possibles.Any((string p) => string.Compare(p, pair.sourceName, StringComparison.OrdinalIgnoreCase) == 0))?.destName.mi;
		}

		private IEnumerable<string> PossibleNames(string nameToSearch)
		{
			return MemberNameReplacers.Select((MemberNameReplacer r) => nameToSearch.Replace(r.OriginalValue, r.NewValue)).Concat(new string[2]
			{
				MemberNameReplacers.Aggregate(nameToSearch, (string s, MemberNameReplacer r) => s.Replace(r.OriginalValue, r.NewValue)),
				nameToSearch
			}).ToList();
		}
	}
}
