using AutoMapper.Internal;
using AutoMapper.XpressionMapper.Extensions;
using System;
using System.Linq.Expressions;

namespace AutoMapper.XpressionMapper
{
	internal class PrependParentNameVisitor : ExpressionVisitor
	{
		public Type CurrentParameterType
		{
			get;
		}

		public string ParentFullName
		{
			get;
		}

		public ParameterExpression NewParameter
		{
			get;
		}

		public PrependParentNameVisitor(Type currentParameterType, string parentFullName, ParameterExpression newParameter)
		{
			CurrentParameterType = currentParameterType;
			ParentFullName = parentFullName;
			NewParameter = newParameter;
		}

		protected override Expression VisitMember(MemberExpression node)
		{
			if (node.NodeType == ExpressionType.Constant)
			{
				return base.VisitMember(node);
			}
			Type left = node.GetParameterExpression()?.Type;
			if (left != null && left == CurrentParameterType && node.IsMemberExpression())
			{
				string propertyFullName = node.GetPropertyFullName();
				return ExpressionFactory.MemberAccesses(string.IsNullOrEmpty(ParentFullName) ? propertyFullName : (ParentFullName + "." + propertyFullName), NewParameter);
			}
			return base.VisitMember(node);
		}
	}
}
