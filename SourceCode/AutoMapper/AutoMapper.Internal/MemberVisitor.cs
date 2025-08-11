using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper.Internal
{
	public class MemberVisitor : ExpressionVisitor
	{
		public IEnumerable<MemberInfo> MemberPath
		{
			get;
			private set;
		}

		public static IEnumerable<MemberInfo> GetMemberPath(Expression expression)
		{
			MemberVisitor memberVisitor = new MemberVisitor();
			memberVisitor.Visit(expression);
			return memberVisitor.MemberPath;
		}

		protected override Expression VisitMember(MemberExpression node)
		{
			MemberPath = from e in node.GetMembers()
				select e.Member;
			return node;
		}
	}
}
