using System;
using System.Collections.Generic;

namespace AutoMapper.Mappers
{
	public interface IConditionalObjectMapper
	{
		ICollection<Func<TypePair, bool>> Conventions
		{
			get;
		}

		bool IsMatch(TypePair context);
	}
}
