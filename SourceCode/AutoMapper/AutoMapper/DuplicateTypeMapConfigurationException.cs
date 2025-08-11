using System;
using System.Text;

namespace AutoMapper
{
	public class DuplicateTypeMapConfigurationException : Exception
	{
		public class TypeMapConfigErrors
		{
			public string[] ProfileNames
			{
				get;
			}

			public TypePair Types
			{
				get;
			}

			public TypeMapConfigErrors(TypePair types, string[] profileNames)
			{
				Types = types;
				ProfileNames = profileNames;
			}
		}

		public TypeMapConfigErrors[] Errors
		{
			get;
		}

		public override string Message
		{
			get;
		}

		public DuplicateTypeMapConfigurationException(TypeMapConfigErrors[] errors)
		{
			Errors = errors;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("The following type maps were found in multiple profiles:");
			TypeMapConfigErrors[] errors2 = Errors;
			foreach (TypeMapConfigErrors typeMapConfigErrors in errors2)
			{
				stringBuilder.AppendLine($"{typeMapConfigErrors.Types.SourceType.FullName} to {typeMapConfigErrors.Types.DestinationType.FullName} defined in profiles:");
				stringBuilder.AppendLine(string.Join(Environment.NewLine, typeMapConfigErrors.ProfileNames));
			}
			stringBuilder.AppendLine("This can cause configuration collisions and inconsistent mapping.");
			stringBuilder.AppendLine("Consolidate the CreateMap calls into one profile, or set the root Advanced.AllowAdditiveTypeMapCreation configuration value to 'true'.");
			Message = stringBuilder.ToString();
		}
	}
}
