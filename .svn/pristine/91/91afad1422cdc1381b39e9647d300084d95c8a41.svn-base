using AutoMapper.XpressionMapper.Structures;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AutoMapper.XpressionMapper
{
	public class MapperInfoDictionary : Dictionary<ParameterExpression, MapperInfo>
	{
		public MapperInfoDictionary(ParameterExpressionEqualityComparer comparer)
			: base((IEqualityComparer<ParameterExpression>)comparer)
		{
		}

		public void Add(ParameterExpression key, Dictionary<Type, Type> typeMappings)
		{
			if (!ContainsKey(key))
			{
				Add(key, typeMappings.ContainsKey(key.Type) ? new MapperInfo(Expression.Parameter(typeMappings[key.Type], key.Name), key.Type, typeMappings[key.Type]) : new MapperInfo(Expression.Parameter(key.Type, key.Name), key.Type, key.Type));
			}
		}
	}
}
