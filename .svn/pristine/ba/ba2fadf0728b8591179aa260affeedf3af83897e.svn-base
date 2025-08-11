using AutoMapper.Internal;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper
{
	public abstract class ObjectMapper<TSource, TDestination> : IObjectMapper
	{
		private static readonly MethodInfo MapMethod = typeof(ObjectMapper<TSource, TDestination>).GetDeclaredMethod("Map");

		public abstract bool IsMatch(TypePair context);

		public abstract TDestination Map(TSource source, TDestination destination, ResolutionContext context);

		public Expression MapExpression(IConfigurationProvider configurationProvider, ProfileMap profileMap, PropertyMap propertyMap, Expression sourceExpression, Expression destExpression, Expression contextExpression)
		{
			return Expression.Call(Expression.Constant(this), MapMethod, ExpressionFactory.ToType(sourceExpression, typeof(TSource)), ExpressionFactory.ToType(destExpression, typeof(TDestination)), contextExpression);
		}
	}
}
