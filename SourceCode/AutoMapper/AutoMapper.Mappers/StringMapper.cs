using System.Linq.Expressions;

namespace AutoMapper.Mappers
{
	public class StringMapper : IObjectMapper
	{
		public bool IsMatch(TypePair context)
		{
			if (context.DestinationType == typeof(string))
			{
				return context.SourceType != typeof(string);
			}
			return false;
		}

		public Expression MapExpression(IConfigurationProvider configurationProvider, ProfileMap profileMap, PropertyMap propertyMap, Expression sourceExpression, Expression destExpression, Expression contextExpression)
		{
			return Expression.Call(sourceExpression, typeof(object).GetDeclaredMethod("ToString"));
		}
	}
}
