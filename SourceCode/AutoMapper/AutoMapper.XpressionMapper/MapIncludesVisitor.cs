using AutoMapper.Internal;
using AutoMapper.XpressionMapper.Extensions;
using AutoMapper.XpressionMapper.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper.XpressionMapper
{
	public class MapIncludesVisitor : XpressionMapperVisitor
	{
		public MapIncludesVisitor(IConfigurationProvider configurationProvider, Dictionary<Type, Type> typeMappings)
			: base(configurationProvider, typeMappings)
		{
		}

		protected override Expression VisitUnary(UnaryExpression node)
		{
			ExpressionType nodeType = node.NodeType;
			if ((uint)(nodeType - 10) <= 1u)
			{
				MemberExpression memberExpression = node.Operand as MemberExpression;
				Type left = node.GetParameterExpression()?.Type;
				if (memberExpression != null && left != null && memberExpression.Expression.NodeType == ExpressionType.MemberAccess && memberExpression.Type.IsLiteralType())
				{
					return Visit(memberExpression);
				}
				return base.VisitUnary(node);
			}
			return base.VisitUnary(node);
		}

		protected override Expression VisitMember(MemberExpression node)
		{
			ParameterExpression parameterExpression = node.GetParameterExpression();
			if (parameterExpression == null)
			{
				return base.VisitMember(node);
			}
			base.InfoDictionary.Add(parameterExpression, base.TypeMappings);
			Type type = parameterExpression.Type;
			if (type != null && base.InfoDictionary.ContainsKey(parameterExpression) && node.IsMemberExpression())
			{
				string propertyFullName = node.GetPropertyFullName();
				List<PropertyMapInfo> propertyMapInfoList = new List<PropertyMapInfo>();
				FindDestinationFullName(type, base.InfoDictionary[parameterExpression].DestType, propertyFullName, propertyMapInfoList);
				string parentFullName;
				if (propertyMapInfoList.Any((PropertyMapInfo x) => x.CustomExpression != null))
				{
					PropertyMapInfo last = propertyMapInfoList.Last((PropertyMapInfo x) => x.CustomExpression != null);
					List<PropertyMapInfo> propertyMapInfoList2 = propertyMapInfoList.Aggregate(new List<PropertyMapInfo>(), delegate(List<PropertyMapInfo> list, PropertyMapInfo next)
					{
						if (propertyMapInfoList.IndexOf(next) < propertyMapInfoList.IndexOf(last))
						{
							list.Add(next);
						}
						return list;
					});
					List<PropertyMapInfo> list2 = propertyMapInfoList.Aggregate(new List<PropertyMapInfo>(), delegate(List<PropertyMapInfo> list, PropertyMapInfo next)
					{
						if (propertyMapInfoList.IndexOf(next) > propertyMapInfoList.IndexOf(last))
						{
							list.Add(next);
						}
						return list;
					});
					parentFullName = BuildFullName(propertyMapInfoList2);
					PrependParentNameVisitor prependParentNameVisitor = new PrependParentNameVisitor(last.CustomExpression.Parameters[0].Type, parentFullName, base.InfoDictionary[parameterExpression].NewParameter);
					Expression node2 = (propertyMapInfoList[propertyMapInfoList.Count - 1] != last) ? prependParentNameVisitor.Visit(last.CustomExpression.Body.MemberAccesses(list2)) : prependParentNameVisitor.Visit(last.CustomExpression.Body);
					FindMemberExpressionsVisitor findMemberExpressionsVisitor = new FindMemberExpressionsVisitor(base.InfoDictionary[parameterExpression].NewParameter);
					findMemberExpressionsVisitor.Visit(node2);
					return findMemberExpressionsVisitor.Result;
				}
				parentFullName = BuildFullName(propertyMapInfoList);
				MemberExpression memberExpression = ExpressionFactory.MemberAccesses(parentFullName, base.InfoDictionary[parameterExpression].NewParameter);
				if (memberExpression.Expression.NodeType == ExpressionType.MemberAccess && (memberExpression.Type == typeof(string) || memberExpression.Type.GetTypeInfo().IsValueType || (memberExpression.Type.GetTypeInfo().IsGenericType && memberExpression.Type.GetGenericTypeDefinition() == typeof(Nullable<>) && Nullable.GetUnderlyingType(memberExpression.Type).GetTypeInfo().IsValueType)))
				{
					return memberExpression.Expression;
				}
				return memberExpression;
			}
			return base.VisitMember(node);
		}
	}
}
