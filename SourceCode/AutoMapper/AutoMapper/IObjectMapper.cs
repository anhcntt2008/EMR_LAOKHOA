using System.Linq.Expressions;

namespace AutoMapper
{
	public interface IObjectMapper
	{
		bool IsMatch(TypePair context);

		Expression MapExpression(IConfigurationProvider configurationProvider, ProfileMap profileMap, PropertyMap propertyMap, Expression sourceExpression, Expression destExpression, Expression contextExpression);
	}
}
