using AutoMapper.Internal;
using AutoMapper.XpressionMapper.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;

namespace AutoMapper.XpressionMapper
{
	internal class FindMemberExpressionsVisitor : ExpressionVisitor
	{
		private readonly ParameterExpression _newParameter;

		private readonly List<MemberExpression> _memberExpressions = new List<MemberExpression>();

		public MemberExpression Result => ExpressionFactory.MemberAccesses((from m in _memberExpressions
			select m.GetPropertyFullName() into n
			group n by n into grp
			select grp.Key into a
			orderby a.Length
			select a).ToList().Aggregate(string.Empty, delegate(string result, string next)
		{
			if (!string.IsNullOrEmpty(result) && !next.Contains(result))
			{
				throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resource.includeExpressionTooComplex, new object[2]
				{
					_newParameter.Type.Name + "." + result,
					_newParameter.Type.Name + "." + next
				}));
			}
			result = next;
			return result;
		}), _newParameter);

		internal FindMemberExpressionsVisitor(ParameterExpression newParameter)
		{
			_newParameter = newParameter;
		}

		protected override Expression VisitMember(MemberExpression node)
		{
			Type type = node.GetParameterExpression()?.Type;
			if (type != null && _newParameter.Type == type && node.IsMemberExpression())
			{
				if (node.Expression.NodeType == ExpressionType.MemberAccess && node.Type.IsLiteralType())
				{
					_memberExpressions.Add((MemberExpression)node.Expression);
				}
				else
				{
					if (node.Expression.NodeType == ExpressionType.Parameter && node.Type.IsLiteralType())
					{
						throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resource.mappedMemberIsChildOfTheParameterFormat, new object[3]
						{
							node.GetPropertyFullName(),
							node.Type.FullName,
							type.FullName
						}));
					}
					_memberExpressions.Add(node);
				}
			}
			return base.VisitMember(node);
		}
	}
}
