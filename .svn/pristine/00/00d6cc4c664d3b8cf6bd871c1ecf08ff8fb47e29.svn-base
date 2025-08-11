using AutoMapper.Mappers.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;

namespace AutoMapper.Mappers
{
	public class EnumToStringMapper : IObjectMapper
	{
		public bool IsMatch(TypePair context)
		{
			if (context.DestinationType == typeof(string))
			{
				return ElementTypeHelper.GetEnumerationType(context.SourceType) != null;
			}
			return false;
		}

		public Expression MapExpression(IConfigurationProvider configurationProvider, ProfileMap profileMap, PropertyMap propertyMap, Expression sourceExpression, Expression destExpression, Expression contextExpression)
		{
			Type enumerationType = ElementTypeHelper.GetEnumerationType(sourceExpression.Type);
			MethodCallExpression methodCallExpression = Expression.Call(sourceExpression, typeof(object).GetDeclaredMethod("ToString"));
			List<SwitchCase> list = new List<SwitchCase>();
			foreach (MemberInfo item2 in from x in enumerationType.GetDeclaredMembers()
				where x.IsStatic()
				select x)
			{
				EnumMemberAttribute enumMemberAttribute = item2.GetCustomAttribute(typeof(EnumMemberAttribute)) as EnumMemberAttribute;
				if (enumMemberAttribute != null && enumMemberAttribute.Value != null)
				{
					SwitchCase item = Expression.SwitchCase(Expression.Constant(enumMemberAttribute.Value), Expression.Constant(Enum.ToObject(enumerationType, item2.GetMemberValue(null))));
					list.Add(item);
				}
			}
			if (list.Count <= 0)
			{
				return methodCallExpression;
			}
			return Expression.Switch(sourceExpression, methodCallExpression, list.ToArray());
		}
	}
}
