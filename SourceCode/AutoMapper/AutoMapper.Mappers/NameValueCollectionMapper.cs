using System.Collections.Specialized;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper.Mappers
{
	public class NameValueCollectionMapper : IObjectMapper
	{
		private static readonly MethodInfo MapMethodInfo = typeof(NameValueCollectionMapper).GetDeclaredMethod("Map");

		private static NameValueCollection Map(NameValueCollection source)
		{
			NameValueCollection nameValueCollection = new NameValueCollection();
			string[] allKeys = source.AllKeys;
			foreach (string name in allKeys)
			{
				nameValueCollection.Add(name, source[name]);
			}
			return nameValueCollection;
		}

		public bool IsMatch(TypePair context)
		{
			if (context.SourceType == typeof(NameValueCollection))
			{
				return context.DestinationType == typeof(NameValueCollection);
			}
			return false;
		}

		public Expression MapExpression(IConfigurationProvider configurationProvider, ProfileMap profileMap, PropertyMap propertyMap, Expression sourceExpression, Expression destExpression, Expression contextExpression)
		{
			return Expression.Call(null, MapMethodInfo, sourceExpression);
		}
	}
}
