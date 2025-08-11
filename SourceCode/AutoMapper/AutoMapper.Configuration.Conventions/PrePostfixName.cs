using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace AutoMapper.Configuration.Conventions
{
	public class PrePostfixName : ISourceToDestinationNameMapper
	{
		public ICollection<string> Prefixes
		{
			get;
		} = new Collection<string>();


		public ICollection<string> Postfixes
		{
			get;
		} = new Collection<string>();


		public ICollection<string> DestinationPrefixes
		{
			get;
		} = new Collection<string>();


		public ICollection<string> DestinationPostfixes
		{
			get;
		} = new Collection<string>();


		public PrePostfixName AddStrings(Func<PrePostfixName, ICollection<string>> getStringsFunc, params string[] names)
		{
			ICollection<string> collection = getStringsFunc(this);
			foreach (string item in names)
			{
				collection.Add(item);
			}
			return this;
		}

		public MemberInfo GetMatchingMemberInfo(IGetTypeInfoMembers getTypeInfoMembers, TypeDetails typeInfo, Type destType, Type destMemberType, string nameToSearch)
		{
			IEnumerable<string> source;
			if (!DestinationPostfixes.Any() && !DestinationPrefixes.Any())
			{
				IEnumerable<string> enumerable = new string[1]
				{
					nameToSearch
				};
				source = enumerable;
			}
			else
			{
				source = PossibleNames(nameToSearch, DestinationPrefixes, DestinationPostfixes);
			}
			return (from sourceName in source
				from destName in typeInfo.DestinationMemberNames
				select new
				{
					sourceName,
					destName
				}).FirstOrDefault(pair => pair.destName.Possibles.Any((string p) => string.Compare(p, pair.sourceName, StringComparison.OrdinalIgnoreCase) == 0))?.destName.Member;
		}

		private IEnumerable<string> PossibleNames(string memberName, IEnumerable<string> prefixes, IEnumerable<string> postfixes)
		{
			string memberName2 = memberName;
			if (string.IsNullOrEmpty(memberName2))
			{
				yield break;
			}
			yield return memberName2;
			foreach (string withoutPrefix in from prefix in prefixes
				where memberName2.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)
				select memberName2.Substring(prefix.Length))
			{
				yield return withoutPrefix;
				foreach (string item in PostFixes(postfixes, withoutPrefix))
				{
					yield return item;
				}
			}
			foreach (string item2 in PostFixes(postfixes, memberName2))
			{
				yield return item2;
			}
		}

		private IEnumerable<string> PostFixes(IEnumerable<string> postfixes, string name)
		{
			return from postfix in postfixes
				where name.EndsWith(postfix, StringComparison.OrdinalIgnoreCase)
				select name.Remove(name.Length - postfix.Length);
		}
	}
}
