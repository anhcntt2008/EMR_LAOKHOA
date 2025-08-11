using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace AutoMapper.Configuration.Conventions
{
	public class NameSplitMember : IChildMemberConfiguration
	{
		private class NameSnippet
		{
			public string First
			{
				get;
				set;
			}

			public string Second
			{
				get;
				set;
			}
		}

		public INamingConvention SourceMemberNamingConvention
		{
			get;
			set;
		}

		public INamingConvention DestinationMemberNamingConvention
		{
			get;
			set;
		}

		public NameSplitMember()
		{
			SourceMemberNamingConvention = new PascalCaseNamingConvention();
			DestinationMemberNamingConvention = new PascalCaseNamingConvention();
		}

		public bool MapDestinationPropertyToSource(ProfileMap options, TypeDetails sourceType, Type destType, Type destMemberType, string nameToSearch, LinkedList<MemberInfo> resolvers, IMemberConfiguration parent)
		{
			string[] array = (from Match m in DestinationMemberNamingConvention.SplittingExpression.Matches(nameToSearch)
				select SourceMemberNamingConvention.ReplaceValue(m)).ToArray();
			MemberInfo memberInfo = null;
			for (int i = 1; i <= array.Length; i++)
			{
				NameSnippet nameSnippet = CreateNameSnippet(array, i);
				memberInfo = parent.NameMapper.GetMatchingMemberInfo(sourceType, destType, destMemberType, nameSnippet.First);
				if (memberInfo != null)
				{
					resolvers.AddLast(memberInfo);
					TypeDetails sourceType2 = options.CreateTypeDetails(memberInfo.GetMemberType());
					if (parent.MapDestinationPropertyToSource(options, sourceType2, destType, destMemberType, nameSnippet.Second, resolvers))
					{
						break;
					}
					resolvers.RemoveLast();
				}
			}
			return memberInfo != null;
		}

		private NameSnippet CreateNameSnippet(IEnumerable<string> matches, int i)
		{
			string first = string.Join(SourceMemberNamingConvention.SeparatorCharacter, (from s in matches.Take(i)
				select SourceMemberNamingConvention.SplittingExpression.Replace(s, SourceMemberNamingConvention.ReplaceValue)).ToArray());
			string second = string.Join(SourceMemberNamingConvention.SeparatorCharacter, (from s in matches.Skip(i)
				select SourceMemberNamingConvention.SplittingExpression.Replace(s, SourceMemberNamingConvention.ReplaceValue)).ToArray());
			return new NameSnippet
			{
				First = first,
				Second = second
			};
		}
	}
}
