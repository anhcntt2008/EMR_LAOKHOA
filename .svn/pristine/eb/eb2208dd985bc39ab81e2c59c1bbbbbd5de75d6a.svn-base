using AutoMapper.Execution;
using AutoMapper.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper.Mappers.Internal
{
	public static class CollectionMapperExpressionFactory
	{
		public delegate Expression MapItem(IConfigurationProvider configurationProvider, ProfileMap profileMap, Type sourceType, Type destType, Expression contextParam, out ParameterExpression itemParam);

		public static Expression MapCollectionExpression(IConfigurationProvider configurationProvider, ProfileMap profileMap, PropertyMap propertyMap, Expression sourceExpression, Expression destExpression, Expression contextExpression, Type ifInterfaceType, MapItem mapItem)
		{
			ParameterExpression passedDestination = Expression.Variable(destExpression.Type, "passedDestination");
			ParameterExpression newExpression = Expression.Variable(passedDestination.Type, "collectionDestination");
			Type elementType = ElementTypeHelper.GetElementType(sourceExpression.Type);
			ParameterExpression itemParam;
			Expression expression = mapItem(configurationProvider, profileMap, sourceExpression.Type, passedDestination.Type, contextExpression, out itemParam);
			Type type = expression.Type;
			Type destinationCollectionType = typeof(ICollection<>).MakeGenericType(type);
			if (!destinationCollectionType.IsAssignableFrom(destExpression.Type))
			{
				destinationCollectionType = typeof(IList);
			}
			MethodInfo declaredMethod = destinationCollectionType.GetDeclaredMethod("Add");
			Expression destination = default(Expression);
			Expression assignNewExpression = default(Expression);
			UseDestinationValue();
			BlockExpression blockExpression = Expression.Block(ExpressionFactory.ForEach(sourceExpression, itemParam, Expression.Call(destination, declaredMethod, expression)), destination);
			MethodInfo declaredMethod2 = destinationCollectionType.GetDeclaredMethod("Clear");
			BlockExpression blockExpression2 = Expression.Block(new ParameterExpression[2]
			{
				newExpression,
				passedDestination
			}, Expression.Assign(passedDestination, destExpression), assignNewExpression, Expression.Call(destination, declaredMethod2), blockExpression);
			if (propertyMap != null)
			{
				return blockExpression2;
			}
			TypeMap typeMap = configurationProvider.ResolveTypeMap(elementType, type);
			if (typeMap == null)
			{
				return blockExpression2;
			}
			ConditionalExpression conditionalExpression = ExpressionBuilder.CheckContext(typeMap, contextExpression);
			if (conditionalExpression == null)
			{
				return blockExpression2;
			}
			return Expression.Block(conditionalExpression, blockExpression2);
			void UseDestinationValue()
			{
				if (propertyMap?.UseDestinationValue ?? false)
				{
					destination = passedDestination;
					assignNewExpression = Expression.Empty();
				}
				else
				{
					destination = newExpression;
					Expression expression2 = passedDestination.Type.NewExpr(ifInterfaceType);
					MemberExpression right = Expression.Property(ExpressionFactory.ToType(passedDestination, destinationCollectionType), "IsReadOnly");
					assignNewExpression = Expression.Assign(newExpression, Expression.Condition(Expression.OrElse(Expression.Equal(passedDestination, Expression.Constant(null)), right), ExpressionFactory.ToType(expression2, passedDestination.Type), passedDestination));
				}
			}
		}

		private static Expression NewExpr(this Type baseType, Type ifInterfaceType)
		{
			if (!baseType.IsInterface())
			{
				return DelegateFactory.GenerateConstructorExpression(baseType);
			}
			return Expression.New(ifInterfaceType.MakeGenericType(ElementTypeHelper.GetElementTypes(baseType, ElementTypeFlags.BreakKeyValuePair)));
		}

		public static Expression MapItemExpr(IConfigurationProvider configurationProvider, ProfileMap profileMap, Type sourceType, Type destType, Expression contextParam, out ParameterExpression itemParam)
		{
			Type elementType = ElementTypeHelper.GetElementType(sourceType);
			Type elementType2 = ElementTypeHelper.GetElementType(destType);
			itemParam = Expression.Parameter(elementType, "item");
			TypePair typePair = new TypePair(elementType, elementType2);
			return ExpressionFactory.ToType(ExpressionBuilder.MapExpression(configurationProvider, profileMap, typePair, itemParam, contextParam), elementType2);
		}

		public static Expression MapKeyPairValueExpr(IConfigurationProvider configurationProvider, ProfileMap profileMap, Type sourceType, Type destType, Expression contextParam, out ParameterExpression itemParam)
		{
			Type[] elementTypes = ElementTypeHelper.GetElementTypes(sourceType, ElementTypeFlags.BreakKeyValuePair);
			Type[] elementTypes2 = ElementTypeHelper.GetElementTypes(destType, ElementTypeFlags.BreakKeyValuePair);
			TypePair typePair = new TypePair(elementTypes[0], elementTypes2[0]);
			TypePair typePair2 = new TypePair(elementTypes[1], elementTypes2[1]);
			Type type = typeof(KeyValuePair<, >).MakeGenericType(elementTypes);
			itemParam = Expression.Parameter(type, "item");
			Type type2 = typeof(KeyValuePair<, >).MakeGenericType(elementTypes2);
			Expression expression = ExpressionBuilder.MapExpression(configurationProvider, profileMap, typePair, Expression.Property(itemParam, "Key"), contextParam);
			Expression expression2 = ExpressionBuilder.MapExpression(configurationProvider, profileMap, typePair2, Expression.Property(itemParam, "Value"), contextParam);
			return Expression.New(type2.GetDeclaredConstructors().First(), expression, expression2);
		}
	}
}
