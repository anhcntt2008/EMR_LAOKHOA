using System.Reflection;

namespace AutoMapper.Configuration
{
	public class SourceMemberConfig
	{
		private bool _ignored;

		public MemberInfo SourceMember
		{
			get;
		}

		public SourceMemberConfig(MemberInfo sourceMember)
		{
			SourceMember = sourceMember;
		}

		public void Ignore()
		{
			_ignored = true;
		}

		public bool IsIgnored()
		{
			return _ignored;
		}
	}
}
