using AutoMapper.Execution;
using AutoMapper.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper.Mappers
{
	public class FromStringDictionaryMapper : IObjectMapper
	{
		private static readonly MethodInfo MapMethodInfo = typeof(FromStringDictionaryMapper).GetDeclaredMethod("Map");

		public bool IsMatch(TypePair context)
		{
			return typeof(IDictionary<string, object>).IsAssignableFrom(context.SourceType);
		}

		public Expression MapExpression(IConfigurationProvider configurationProvider, ProfileMap profileMap, PropertyMap propertyMap, Expression sourceExpression, Expression destExpression, Expression contextExpression)
		{
			return Expression.Call(null, MapMethodInfo.MakeGenericMethod(destExpression.Type), sourceExpression, Expression.Condition(Expression.Equal(ExpressionFactory.ToObject(destExpression), Expression.Constant(null)), DelegateFactory.GenerateConstructorExpression(destExpression.Type), destExpression), contextExpression, Expression.Constant(profileMap));
		}

		private static TDestination Map<TDestination>(IDictionary<string, object> source, TDestination destination, ResolutionContext context, ProfileMap profileMap)
		{
			TypeDetails typeDetails = profileMap.CreateTypeDetails(typeof(TDestination));
			IEnumerable<MemberInfo> enumerable = from name in source.Keys
				join member in typeDetails.PublicWriteAccessors on name equals member.Name
				select member;
			object obj = destination;
			foreach (MemberInfo item in enumerable)
			{
				object value = context.MapMember(item, source[item.Name], obj);
				item.SetMemberValue(obj, value);
			}
			return (TDestination)obj;
		}
	}
}
