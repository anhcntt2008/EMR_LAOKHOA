using AutoMapper.Configuration;
using AutoMapper.Internal;
using AutoMapper.Mappers.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper.Execution
{
	public static class ExpressionBuilder
	{
		private static readonly Expression<Func<IRuntimeMapper, ResolutionContext>> CreateContext = (IRuntimeMapper mapper) => new ResolutionContext(mapper.DefaultContext.Options, mapper);

		private static readonly MethodInfo ContextMapMethod = ExpressionFactory.Method((ResolutionContext a) => a.Map<object, object>(null, null)).GetGenericMethodDefinition();

		public static Expression MapExpression(IConfigurationProvider configurationProvider, ProfileMap profileMap, TypePair typePair, Expression sourceParameter, Expression contextParameter, PropertyMap propertyMap = null, Expression destinationParameter = null)
		{
			if (destinationParameter == null)
			{
				destinationParameter = Expression.Default(typePair.DestinationType);
			}
			TypeMap typeMap = configurationProvider.ResolveTypeMap(typePair);
			if (typeMap != null)
			{
				if (!typeMap.HasDerivedTypesToInclude())
				{
					typeMap.Seal(configurationProvider);
					if (typeMap.MapExpression == null)
					{
						return ContextMap(typePair, sourceParameter, contextParameter, destinationParameter);
					}
					return typeMap.MapExpression.ConvertReplaceParameters(sourceParameter, destinationParameter, contextParameter);
				}
				return ContextMap(typePair, sourceParameter, contextParameter, destinationParameter);
			}
			Expression objectMapperExpression = ObjectMapperExpression(configurationProvider, profileMap, typePair, sourceParameter, contextParameter, propertyMap, destinationParameter);
			return ExpressionFactory.ToType(NullCheckSource(profileMap, sourceParameter, destinationParameter, objectMapperExpression, propertyMap), typePair.DestinationType);
		}

		public static Expression NullCheckSource(ProfileMap profileMap, Expression sourceParameter, Expression destinationParameter, Expression objectMapperExpression, PropertyMap propertyMap = null)
		{
			Type type = destinationParameter.Type;
			Expression expression = DefaultDestination(objectMapperExpression.Type, type, profileMap);
			Expression destination = (propertyMap == null) ? destinationParameter.IfNullElse(expression, destinationParameter) : (propertyMap.UseDestinationValue ? destinationParameter : expression);
			Expression then = destinationParameter.Type.IsCollectionType() ? ClearDestinationCollection() : destination;
			return sourceParameter.IfNullElse(then, objectMapperExpression);
			Expression ClearDestinationCollection()
			{
				Type elementType = ElementTypeHelper.GetElementType(destinationParameter.Type);
				Type type2 = typeof(ICollection<>).MakeGenericType(elementType);
				ParameterExpression parameterExpression = Expression.Variable(type2, "collectionDestination");
				MethodCallExpression ifFalse = Expression.Call(parameterExpression, type2.GetDeclaredMethod("Clear"));
				MemberExpression right = Expression.Property(parameterExpression, "IsReadOnly");
				return Expression.Block(new ParameterExpression[1]
				{
					parameterExpression
				}, Expression.Assign(parameterExpression, ExpressionFactory.ToType(destinationParameter, type2)), Expression.Condition(Expression.OrElse(Expression.Equal(parameterExpression, Expression.Constant(null)), right), Expression.Empty(), ifFalse), destination);
			}
		}

		private static Expression DefaultDestination(Type destinationType, Type declaredDestinationType, ProfileMap profileMap)
		{
			if (profileMap.AllowNullCollections || destinationType == typeof(string) || !destinationType.IsEnumerableType())
			{
				return Expression.Default(declaredDestinationType);
			}
			if (destinationType.IsArray)
			{
				return Expression.NewArrayBounds(destinationType.GetElementType(), Enumerable.Repeat(Expression.Constant(0), destinationType.GetArrayRank()));
			}
			return DelegateFactory.GenerateNonNullConstructorExpression(destinationType);
		}

		private static Expression ObjectMapperExpression(IConfigurationProvider configurationProvider, ProfileMap profileMap, TypePair typePair, Expression sourceParameter, Expression contextParameter, PropertyMap propertyMap, Expression destinationParameter)
		{
			IObjectMapper objectMapper = configurationProvider.FindMapper(typePair);
			if (objectMapper != null)
			{
				return objectMapper.MapExpression(configurationProvider, profileMap, propertyMap, sourceParameter, destinationParameter, contextParameter);
			}
			return ContextMap(typePair, sourceParameter, contextParameter, destinationParameter);
		}

		public static Expression ContextMap(TypePair typePair, Expression sourceParameter, Expression contextParameter, Expression destinationParameter)
		{
			MethodInfo method = ContextMapMethod.MakeGenericMethod(typePair.SourceType, typePair.DestinationType);
			return Expression.Call(contextParameter, method, sourceParameter, destinationParameter);
		}

		public static ConditionalExpression CheckContext(TypeMap typeMap, Expression context)
		{
			if (typeMap.MaxDepth > 0 || typeMap.PreserveReferences)
			{
				MemberExpression memberExpression = Expression.Property(context, "Mapper");
				return Expression.IfThen(Expression.Property(context, "IsDefault"), Expression.Assign(context, Expression.Invoke(CreateContext, memberExpression)));
			}
			return null;
		}
	}
}
