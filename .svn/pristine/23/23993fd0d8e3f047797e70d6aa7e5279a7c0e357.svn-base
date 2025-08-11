using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AutoMapper.QueryableExtensions
{
	public class LetPropertyMaps
	{
		public struct PropertyPath
		{
			public PropertyMap[] PropertyMaps
			{
				get;
			}

			public Expression Marker
			{
				get;
			}

			public PropertyMap Last => PropertyMaps[PropertyMaps.Length - 1];

			public PropertyPath(PropertyMap[] propertyMaps, Expression marker)
			{
				PropertyMaps = propertyMaps;
				Marker = marker;
			}
		}

		public static readonly LetPropertyMaps Default = new LetPropertyMaps();

		public virtual int Count => 0;

		protected LetPropertyMaps()
		{
		}

		public virtual Expression GetSubQueryMarker()
		{
			return null;
		}

		public virtual void Push(PropertyMap propertyMap)
		{
		}

		public virtual void Pop()
		{
		}

		public virtual LetPropertyMaps New()
		{
			return Default;
		}

		public virtual QueryExpressions GetSubQueryExpression(ExpressionBuilder builder, Expression projection, TypeMap typeMap, ExpressionRequest request, Expression instanceParameter, IDictionary<ExpressionRequest, int> typePairCount)
		{
			throw new NotImplementedException();
		}
	}
}
