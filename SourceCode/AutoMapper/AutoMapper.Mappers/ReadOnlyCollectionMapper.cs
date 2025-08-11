using AutoMapper.Configuration;
using AutoMapper.Mappers.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;

namespace AutoMapper.Mappers
{
	public class ReadOnlyCollectionMapper : IObjectMapper
	{
		public bool IsMatch(TypePair context)
		{
			if (!context.SourceType.IsEnumerableType() || !context.DestinationType.IsGenericType())
			{
				return false;
			}
			return context.DestinationType.GetGenericTypeDefinition() == typeof(ReadOnlyCollection<>);
		}

		public Expression MapExpression(IConfigurationProvider configurationProvider, ProfileMap profileMap, PropertyMap propertyMap, Expression sourceExpression, Expression destExpression, Expression contextExpression)
		{
			Type type = typeof(List<>).MakeGenericType(ElementTypeHelper.GetElementType(destExpression.Type));
			Expression right = CollectionMapperExpressionFactory.MapCollectionExpression(configurationProvider, profileMap, propertyMap, sourceExpression, Expression.Default(type), contextExpression, typeof(List<>), CollectionMapperExpressionFactory.MapItemExpr);
			ParameterExpression parameterExpression = Expression.Variable(type, "dest");
			return Expression.Block(new ParameterExpression[1]
			{
				parameterExpression
			}, Expression.Assign(parameterExpression, right), Expression.Condition(Expression.NotEqual(parameterExpression, Expression.Default(type)), Expression.New(destExpression.Type.GetDeclaredConstructors().First(), parameterExpression), Expression.Default(destExpression.Type)));
		}
	}
}
