using AutoMapper.Configuration;
using AutoMapper.Mappers.Internal;
using System;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper.Mappers
{
	public class MultidimensionalArrayMapper : IObjectMapper
	{
		public class MultidimensionalArrayFiller
		{
			private readonly int[] _indices;

			private readonly Array _destination;

			public MultidimensionalArrayFiller(Array destination)
			{
				_indices = new int[destination.Rank];
				_destination = destination;
			}

			public void NewValue(object value)
			{
				int num = _destination.Rank - 1;
				bool flag = false;
				while (_indices[num] == _destination.GetLength(num))
				{
					_indices[num] = 0;
					num--;
					if (num < 0)
					{
						throw new InvalidOperationException("Not enough room in destination array " + _destination);
					}
					_indices[num]++;
					flag = true;
				}
				_destination.SetValue(value, _indices);
				if (flag)
				{
					_indices[num + 1]++;
				}
				else
				{
					_indices[num]++;
				}
			}
		}

		private static readonly MethodInfo MapMethodInfo = typeof(MultidimensionalArrayMapper).GetDeclaredMethod("Map");

		private static Array Map<TDestination, TSource, TSourceElement>(TSource source, ResolutionContext context, ProfileMap profileMap) where TSource : IEnumerable
		{
			Type elementType = ElementTypeHelper.GetElementType(typeof(TDestination));
			if (typeof(TDestination).IsAssignableFrom(typeof(TSource)) && context.ConfigurationProvider.ResolveTypeMap(typeof(TSourceElement), elementType) == null)
			{
				return source as Array;
			}
			IEnumerable enumerable = source;
			Array array = source as Array;
			Array array2 = (array == null) ? Array.CreateInstance(elementType, enumerable.Cast<object>().Count()) : Array.CreateInstance(elementType, Enumerable.Range(0, array.Rank).Select(array.GetLength).ToArray());
			MultidimensionalArrayFiller multidimensionalArrayFiller = new MultidimensionalArrayFiller(array2);
			foreach (object item in enumerable)
			{
				multidimensionalArrayFiller.NewValue(context.Map(item, null, typeof(TSourceElement), elementType));
			}
			return array2;
		}

		public bool IsMatch(TypePair context)
		{
			if (context.DestinationType.IsArray && context.DestinationType.GetArrayRank() > 1)
			{
				return context.SourceType.IsEnumerableType();
			}
			return false;
		}

		public Expression MapExpression(IConfigurationProvider configurationProvider, ProfileMap profileMap, PropertyMap propertyMap, Expression sourceExpression, Expression destExpression, Expression contextExpression)
		{
			return Expression.Call(null, MapMethodInfo.MakeGenericMethod(destExpression.Type, sourceExpression.Type, ElementTypeHelper.GetElementType(sourceExpression.Type)), sourceExpression, contextExpression, Expression.Constant(profileMap));
		}
	}
}
