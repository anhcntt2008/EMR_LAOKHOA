using System;
using System.Collections.Generic;

namespace AutoMapper
{
	public class AdvancedConfiguration
	{
		private readonly List<Action<ValidationContext>> _validators = new List<Action<ValidationContext>>();

		private readonly IList<Action<IConfigurationProvider>> _beforeSealActions = new List<Action<IConfigurationProvider>>();

		public IEnumerable<Action<IConfigurationProvider>> BeforeSealActions => _beforeSealActions;

		public bool AllowAdditiveTypeMapCreation
		{
			get;
			set;
		}

		public int MaxExecutionPlanDepth
		{
			get;
			set;
		} = 1;


		public void BeforeSeal(Action<IConfigurationProvider> action)
		{
			_beforeSealActions.Add(action);
		}

		public void Validator(Action<ValidationContext> validator)
		{
			_validators.Add(validator);
		}

		internal Action<ValidationContext>[] GetValidators()
		{
			return _validators.ToArray();
		}
	}
}
