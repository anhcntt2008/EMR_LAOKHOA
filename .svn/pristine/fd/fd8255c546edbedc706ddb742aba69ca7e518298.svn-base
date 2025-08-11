using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoMapper.Internal
{
	public struct MemberPath : IEquatable<MemberPath>
	{
		public MemberInfo[] Members
		{
			get;
		}

		public MemberInfo Last => Members[Members.Length - 1];

		public MemberInfo First => Members[0];

		public int Length => Members.Length;

		public MemberPath(IEnumerable<MemberInfo> members)
		{
			Members = members.ToArray();
		}

		public bool Equals(MemberPath other)
		{
			return Members.SequenceEqual(other.Members);
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (obj is MemberPath)
			{
				return Equals((MemberPath)obj);
			}
			return false;
		}

		public override int GetHashCode()
		{
			int num = 0;
			MemberInfo[] members = Members;
			foreach (MemberInfo memberInfo in members)
			{
				num = HashCodeCombiner.CombineCodes(num, memberInfo.GetHashCode());
			}
			return num;
		}

		public static bool operator ==(MemberPath left, MemberPath right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(MemberPath left, MemberPath right)
		{
			return !left.Equals(right);
		}
	}
}
