using AutoMapper.Configuration;
using AutoMapper.Internal;
using AutoMapper.Mappers.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper.Mappers
{
	public class ArrayMapper : EnumerableMapperBase
	{
		public override bool IsMatch(TypePair context)
		{
			if (context.DestinationType.IsArray)
			{
				return context.SourceType.IsEnumerableType();
			}
			return false;
		}

		public override Expression MapExpression(IConfigurationProvider configurationProvider, ProfileMap profileMap, PropertyMap propertyMap, Expression sourceExpression, Expression destExpression, Expression contextExpression)
		{
			Type elementType = ElementTypeHelper.GetElementType(sourceExpression.Type);
			Type elementType2 = ElementTypeHelper.GetElementType(destExpression.Type);
			ParameterExpression itemParam;
			Expression right = CollectionMapperExpressionFactory.MapItemExpr(configurationProvider, profileMap, sourceExpression.Type, destExpression.Type, contextExpression, out itemParam);
			ParameterExpression parameterExpression = Expression.Parameter(typeof(int), "count");
			ParameterExpression parameterExpression2 = Expression.Parameter(destExpression.Type, "destinationArray");
			ParameterExpression parameterExpression3 = Expression.Parameter(typeof(int), "destinationArrayIndex");
			List<Expression> list = new List<Expression>();
			List<ParameterExpression> variables = new List<ParameterExpression>
			{
				parameterExpression,
				parameterExpression2,
				parameterExpression3
			};
			MethodInfo method = typeof(Enumerable).GetTypeInfo().DeclaredMethods.Single((MethodInfo mi) => mi.Name == "Count" && mi.GetParameters().Length == 1).MakeGenericMethod(elementType);
			list.Add(Expression.Assign(parameterExpression, Expression.Call(method, sourceExpression)));
			list.Add(Expression.Assign(parameterExpression2, Expression.NewArrayBounds(elementType2, parameterExpression)));
			list.Add(Expression.Assign(parameterExpression3, Expression.Constant(0)));
			list.Add(ExpressionFactory.ForEach(sourceExpression, itemParam, Expression.Assign(Expression.ArrayAccess(parameterExpression2, Expression.PostIncrementAssign(parameterExpression3)), right)));
			list.Add(parameterExpression2);
			return Expression.Block(variables, list);
		}
	}
}
