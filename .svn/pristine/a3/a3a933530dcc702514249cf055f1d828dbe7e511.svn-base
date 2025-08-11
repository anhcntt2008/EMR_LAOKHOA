using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AutoMapper.Mappers
{
	public class ConditionalObjectMapper : IConditionalObjectMapper
	{
		public ICollection<Func<TypePair, bool>> Conventions
		{
			get;
		} = new Collection<Func<TypePair, bool>>();


		public bool IsMatch(TypePair typePair)
		{
			return Conventions.All((Func<TypePair, bool> c) => c(typePair));
		}
	}
}
