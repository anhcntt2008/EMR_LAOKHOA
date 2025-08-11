using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace AutoMapper.QueryableExtensions
{
	[DebuggerDisplay("{SourceType.Name}, {DestinationType.Name}")]
	public class ExpressionRequest : IEquatable<ExpressionRequest>
	{
		public Type SourceType
		{
			get;
		}

		public Type DestinationType
		{
			get;
		}

		public MemberInfo[] MembersToExpand
		{
			get;
		}

		internal ICollection<ExpressionRequest> PreviousRequests
		{
			get;
		}

		internal bool AlreadyExists => PreviousRequests.Contains(this);

		internal IEnumerable<ExpressionRequest> GetPreviousRequestsAndSelf()
		{
			return PreviousRequests.Concat(new ExpressionRequest[1]
			{
				this
			});
		}

		public ExpressionRequest(Type sourceType, Type destinationType, MemberInfo[] membersToExpand, ExpressionRequest parentRequest)
		{
			SourceType = sourceType;
			DestinationType = destinationType;
			MembersToExpand = membersToExpand.OrderBy((MemberInfo p) => p.Name).ToArray();
			PreviousRequests = ((parentRequest == null) ? new HashSet<ExpressionRequest>() : new HashSet<ExpressionRequest>(parentRequest.GetPreviousRequestsAndSelf()));
		}

		public bool Equals(ExpressionRequest other)
		{
			if ((object)other == null)
			{
				return false;
			}
			if ((object)this == other)
			{
				return true;
			}
			if (MembersToExpand.SequenceEqual(other.MembersToExpand) && SourceType == other.SourceType)
			{
				return DestinationType == other.DestinationType;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (this == obj)
			{
				return true;
			}
			if (obj.GetType() != GetType())
			{
				return false;
			}
			return Equals((ExpressionRequest)obj);
		}

		public override int GetHashCode()
		{
			int num = HashCodeCombiner.Combine(SourceType, DestinationType);
			MemberInfo[] membersToExpand = MembersToExpand;
			foreach (MemberInfo memberInfo in membersToExpand)
			{
				num = HashCodeCombiner.CombineCodes(num, memberInfo.GetHashCode());
			}
			return num;
		}

		public static bool operator ==(ExpressionRequest left, ExpressionRequest right)
		{
			return object.Equals(left, right);
		}

		public static bool operator !=(ExpressionRequest left, ExpressionRequest right)
		{
			return !object.Equals(left, right);
		}
	}
}
