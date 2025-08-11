using AutoMapper.Mappers.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper.Mappers
{
	public class ToStringDictionaryMapper : IObjectMapper
	{
		private static readonly MethodInfo MembersDictionaryMethodInfo = typeof(ToStringDictionaryMapper).GetDeclaredMethod("MembersDictionary");

		public bool IsMatch(TypePair context)
		{
			return typeof(IDictionary<string, object>).IsAssignableFrom(context.DestinationType);
		}

		public Expression MapExpression(IConfigurationProvider configurationProvider, ProfileMap profileMap, PropertyMap propertyMap, Expression sourceExpression, Expression destExpression, Expression contextExpression)
		{
			return CollectionMapperExpressionFactory.MapCollectionExpression(configurationProvider, profileMap, propertyMap, Expression.Call(MembersDictionaryMethodInfo, sourceExpression, Expression.Constant(profileMap)), destExpression, contextExpression, typeof(Dictionary<, >), CollectionMapperExpressionFactory.MapKeyPairValueExpr);
		}

		private static Dictionary<string, object> MembersDictionary(object source, ProfileMap profileMap)
		{
			return profileMap.CreateTypeDetails(source.GetType()).PublicReadAccessors.ToDictionary((MemberInfo p) => p.Name, (MemberInfo p) => p.GetMemberValue(source));
		}
	}
}
