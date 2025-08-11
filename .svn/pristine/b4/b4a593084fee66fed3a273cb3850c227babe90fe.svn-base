using System;

namespace AutoMapper.Mappers
{
	public static class ConventionGeneratorExtensions
	{
		public static IConditionalObjectMapper Where(this IConditionalObjectMapper self, Func<Type, Type, bool> condition)
		{
			self.Conventions.Add((TypePair rc) => condition(rc.SourceType, rc.DestinationType));
			return self;
		}
	}
}
