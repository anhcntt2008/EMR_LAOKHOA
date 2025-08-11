using AutoMapper.Configuration;
using System.Linq;

namespace AutoMapper
{
	public class MapperConfigurationExpressionValidator
	{
		private readonly MapperConfigurationExpression _expression;

		public MapperConfigurationExpressionValidator(MapperConfigurationExpression expression)
		{
			_expression = expression;
		}

		public void AssertConfigurationExpressionIsValid()
		{
			if (_expression.Advanced.AllowAdditiveTypeMapCreation)
			{
				return;
			}
			DuplicateTypeMapConfigurationException.TypeMapConfigErrors[] array = (from x in new MapperConfigurationExpression[1]
				{
					_expression
				}.Concat(_expression.Profiles).SelectMany((IProfileConfiguration p) => p.TypeMapConfigs, (IProfileConfiguration profile, ITypeMapConfiguration typeMap) => new
				{
					profile,
					typeMap
				})
				group x by x.typeMap.Types into g
				where g.Count() > 1
				select new
				{
					TypePair = g.Key,
					ProfileNames = g.Select(tmc => tmc.profile.ProfileName).ToArray()
				} into g
				select new DuplicateTypeMapConfigurationException.TypeMapConfigErrors(g.TypePair, g.ProfileNames)).ToArray();
			if (!array.Any())
			{
				return;
			}
			throw new DuplicateTypeMapConfigurationException(array);
		}
	}
}
