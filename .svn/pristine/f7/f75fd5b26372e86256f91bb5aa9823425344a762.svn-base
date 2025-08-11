using AutoMapper.Mappers.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper.XpressionMapper.Extensions
{
	public static class MapperExtensions
	{
		public static TDestDelegate MapExpression<TDestDelegate>(this IMapper mapper, LambdaExpression expression) where TDestDelegate : LambdaExpression
		{
			if (expression == null)
			{
				return null;
			}
			Type sourceType = expression.GetType().GetGenericArguments()[0];
			Type type = typeof(TDestDelegate).GetGenericArguments()[0];
			Dictionary<Type, Type> typeMappings = new Dictionary<Type, Type>().AddTypeMappingsFromDelegates(sourceType, type);
			XpressionMapperVisitor xpressionMapperVisitor = new XpressionMapperVisitor((mapper == null) ? Mapper.Configuration : mapper.ConfigurationProvider, typeMappings);
			Expression expression2 = xpressionMapperVisitor.Visit(expression.Body);
			if (expression2 == null)
			{
				throw new InvalidOperationException(Resource.cantRemapExpression);
			}
			return (TDestDelegate)Expression.Lambda(type, expression2, expression.GetDestinationParameterExpressions(xpressionMapperVisitor.InfoDictionary, typeMappings));
		}

		public static TDestDelegate MapExpression<TSourceDelegate, TDestDelegate>(this IMapper mapper, TSourceDelegate expression) where TSourceDelegate : LambdaExpression where TDestDelegate : LambdaExpression
		{
			return mapper.MapExpression<TDestDelegate>(expression);
		}

		public static TDestDelegate MapExpressionAsInclude<TDestDelegate>(this IMapper mapper, LambdaExpression expression) where TDestDelegate : LambdaExpression
		{
			if (expression == null)
			{
				return null;
			}
			Type sourceType = expression.GetType().GetGenericArguments()[0];
			Type type = typeof(TDestDelegate).GetGenericArguments()[0];
			Dictionary<Type, Type> typeMappings = new Dictionary<Type, Type>().AddTypeMappingsFromDelegates(sourceType, type);
			XpressionMapperVisitor xpressionMapperVisitor = new MapIncludesVisitor((mapper == null) ? Mapper.Configuration : mapper.ConfigurationProvider, typeMappings);
			Expression expression2 = xpressionMapperVisitor.Visit(expression.Body);
			if (expression2 == null)
			{
				throw new InvalidOperationException(Resource.cantRemapExpression);
			}
			return (TDestDelegate)Expression.Lambda(type, expression2, expression.GetDestinationParameterExpressions(xpressionMapperVisitor.InfoDictionary, typeMappings));
		}

		public static TDestDelegate MapExpressionAsInclude<TSourceDelegate, TDestDelegate>(this IMapper mapper, TSourceDelegate expression) where TSourceDelegate : LambdaExpression where TDestDelegate : LambdaExpression
		{
			return mapper.MapExpressionAsInclude<TDestDelegate>(expression);
		}

		public static ICollection<TDestDelegate> MapExpressionList<TSourceDelegate, TDestDelegate>(this IMapper mapper, ICollection<TSourceDelegate> collection) where TSourceDelegate : LambdaExpression where TDestDelegate : LambdaExpression
		{
			return collection?.Select((Func<TSourceDelegate, TDestDelegate>)mapper.MapExpression).ToList();
		}

		public static ICollection<TDestDelegate> MapExpressionList<TDestDelegate>(this IMapper mapper, IEnumerable<LambdaExpression> collection) where TDestDelegate : LambdaExpression
		{
			return collection?.Select((Func<LambdaExpression, TDestDelegate>)mapper.MapExpression).ToList();
		}

		public static ICollection<TDestDelegate> MapIncludesList<TSourceDelegate, TDestDelegate>(this IMapper mapper, ICollection<TSourceDelegate> collection) where TSourceDelegate : LambdaExpression where TDestDelegate : LambdaExpression
		{
			return collection?.Select((Func<TSourceDelegate, TDestDelegate>)mapper.MapExpressionAsInclude).ToList();
		}

		public static ICollection<TDestDelegate> MapIncludesList<TDestDelegate>(this IMapper mapper, IEnumerable<LambdaExpression> collection) where TDestDelegate : LambdaExpression
		{
			return collection?.Select((Func<LambdaExpression, TDestDelegate>)mapper.MapExpressionAsInclude).ToList();
		}

		public static List<ParameterExpression> GetDestinationParameterExpressions(this LambdaExpression expression, MapperInfoDictionary infoDictionary, Dictionary<Type, Type> typeMappings)
		{
			foreach (ParameterExpression item in expression.Parameters.Where((ParameterExpression p) => !infoDictionary.ContainsKey(p)))
			{
				infoDictionary.Add(item, typeMappings);
			}
			return expression.Parameters.Select((ParameterExpression p) => infoDictionary[p].NewParameter).ToList();
		}

		public static Dictionary<Type, Type> AddTypeMapping<TSource, TDest>(this Dictionary<Type, Type> typeMappings)
		{
			if (typeMappings != null)
			{
				return typeMappings.AddTypeMapping(typeof(TSource), typeof(TDest));
			}
			throw new ArgumentException(Resource.typeMappingsDictionaryIsNull);
		}

		private static bool HasUnderlyingType(this Type type)
		{
			if (!type.IsGenericType() || !typeof(IEnumerable).IsAssignableFrom(type))
			{
				return type.IsArray;
			}
			return true;
		}

		private static void AddUnderlyingTypes(this Dictionary<Type, Type> typeMappings, Type sourceType, Type destType)
		{
			List<Type> sourceArguments = (!sourceType.HasUnderlyingType()) ? new List<Type>() : ElementTypeHelper.GetElementTypes(sourceType).ToList();
			List<Type> destArguments = (!destType.HasUnderlyingType()) ? new List<Type>() : ElementTypeHelper.GetElementTypes(destType).ToList();
			if (sourceArguments.Count != destArguments.Count)
			{
				throw new ArgumentException(Resource.invalidArgumentCount);
			}
			sourceArguments.Aggregate(typeMappings, delegate(Dictionary<Type, Type> dic, Type next)
			{
				if (!dic.ContainsKey(next) && next != destArguments[sourceArguments.IndexOf(next)])
				{
					dic.AddTypeMapping(next, destArguments[sourceArguments.IndexOf(next)]);
				}
				return dic;
			});
		}

		public static Dictionary<Type, Type> AddTypeMapping(this Dictionary<Type, Type> typeMappings, Type sourceType, Type destType)
		{
			if (typeMappings == null)
			{
				throw new ArgumentException(Resource.typeMappingsDictionaryIsNull);
			}
			if (sourceType.GetTypeInfo().IsGenericType && sourceType.GetGenericTypeDefinition() == typeof(Expression<>))
			{
				sourceType = sourceType.GetGenericArguments()[0];
				destType = destType.GetGenericArguments()[0];
			}
			if (!typeMappings.ContainsKey(sourceType) && sourceType != destType)
			{
				typeMappings.Add(sourceType, destType);
				if (typeof(Delegate).IsAssignableFrom(sourceType))
				{
					typeMappings.AddTypeMappingsFromDelegates(sourceType, destType);
				}
				else
				{
					typeMappings.AddUnderlyingTypes(sourceType, destType);
				}
			}
			return typeMappings;
		}

		private static Dictionary<Type, Type> AddTypeMappingsFromDelegates(this Dictionary<Type, Type> typeMappings, Type sourceType, Type destType)
		{
			if (typeMappings == null)
			{
				throw new ArgumentException(Resource.typeMappingsDictionaryIsNull);
			}
			List<Type> sourceArguments = sourceType.GetGenericArguments().ToList();
			List<Type> destArguments = destType.GetGenericArguments().ToList();
			if (sourceArguments.Count != destArguments.Count)
			{
				throw new ArgumentException(Resource.invalidArgumentCount);
			}
			return sourceArguments.Aggregate(typeMappings, delegate(Dictionary<Type, Type> dic, Type next)
			{
				if (!dic.ContainsKey(next) && next != destArguments[sourceArguments.IndexOf(next)])
				{
					dic.AddTypeMapping(next, destArguments[sourceArguments.IndexOf(next)]);
				}
				return dic;
			});
		}
	}
}
