using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AutoMapper
{
	public static class ValueTransformerConfigurationExtensions
	{
		public static void Add<TValue>(this IList<ValueTransformerConfiguration> valueTransformers, Expression<Func<TValue, TValue>> transformer)
		{
			ValueTransformerConfiguration item = new ValueTransformerConfiguration(typeof(TValue), transformer);
			valueTransformers.Add(item);
		}
	}
}
