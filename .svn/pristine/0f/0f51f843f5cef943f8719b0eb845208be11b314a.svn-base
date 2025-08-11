using AutoMapper.Internal;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper
{
	[DebuggerDisplay("{DestinationExpression}")]
	public class PathMap
	{
		public TypeMap TypeMap
		{
			get;
		}

		public LambdaExpression DestinationExpression
		{
			get;
		}

		public LambdaExpression SourceExpression
		{
			get;
			set;
		}

		public MemberPath MemberPath
		{
			get;
		}

		public MemberInfo DestinationMember => MemberPath.Last;

		public bool Ignored
		{
			get;
			set;
		}

		public LambdaExpression Condition
		{
			get;
			set;
		}

		public PathMap(LambdaExpression destinationExpression, MemberPath memberPath, TypeMap typeMap)
		{
			MemberPath = memberPath;
			TypeMap = typeMap;
			DestinationExpression = destinationExpression;
		}
	}
}
