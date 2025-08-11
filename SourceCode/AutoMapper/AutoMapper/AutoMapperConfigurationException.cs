using System;
using System.Linq;
using System.Text;

namespace AutoMapper
{
	public class AutoMapperConfigurationException : Exception
	{
		public class TypeMapConfigErrors
		{
			public TypeMap TypeMap
			{
				get;
			}

			public string[] UnmappedPropertyNames
			{
				get;
			}

			public bool CanConstruct
			{
				get;
			}

			public TypeMapConfigErrors(TypeMap typeMap, string[] unmappedPropertyNames, bool canConstruct)
			{
				TypeMap = typeMap;
				UnmappedPropertyNames = unmappedPropertyNames;
				CanConstruct = canConstruct;
			}
		}

		public TypeMapConfigErrors[] Errors
		{
			get;
		}

		public TypePair? Types
		{
			get;
		}

		public PropertyMap PropertyMap
		{
			get;
			set;
		}

		public override string Message
		{
			get
			{
				if (Types.HasValue)
				{
					string str = string.Format("The following property on {0} cannot be mapped: \n\t{2} \nAdd a custom mapping expression, ignore, add a custom resolver, or modify the destination type {1}.", Types?.DestinationType.FullName, Types?.DestinationType.FullName, PropertyMap?.DestinationProperty.Name);
					str += "\nContext:";
					for (Exception ex = this; ex != null; ex = ex.InnerException)
					{
						AutoMapperConfigurationException ex2;
						if ((ex2 = (ex as AutoMapperConfigurationException)) != null)
						{
							str += ((ex2.PropertyMap == null) ? $"\n\tMapping from type {ex2.Types?.SourceType.FullName} to {ex2.Types?.DestinationType.FullName}" : $"\n\tMapping to property {ex2.PropertyMap.DestinationProperty.Name} from {ex2.Types?.SourceType.FullName} to {ex2.Types?.DestinationType.FullName}");
						}
					}
					return str + "\n" + base.Message;
				}
				if (Errors != null)
				{
					StringBuilder stringBuilder = new StringBuilder("\nUnmapped members were found. Review the types and members below.\nAdd a custom mapping expression, ignore, add a custom resolver, or modify the source/destination type\nFor no matching constructor, add a no-arg ctor, add optional arguments, or map all of the constructor parameters\n");
					TypeMapConfigErrors[] errors = Errors;
					foreach (TypeMapConfigErrors typeMapConfigErrors in errors)
					{
						int count = typeMapConfigErrors.TypeMap.SourceType.FullName.Length + typeMapConfigErrors.TypeMap.DestinationType.FullName.Length + 5;
						stringBuilder.AppendLine(new string('=', count));
						stringBuilder.AppendLine(string.Concat(typeMapConfigErrors.TypeMap.SourceType.Name, " -> ", typeMapConfigErrors.TypeMap.DestinationType.Name, " (", typeMapConfigErrors.TypeMap.ConfiguredMemberList, " member list)"));
						stringBuilder.AppendLine(string.Concat(typeMapConfigErrors.TypeMap.SourceType.FullName, " -> ", typeMapConfigErrors.TypeMap.DestinationType.FullName, " (", typeMapConfigErrors.TypeMap.ConfiguredMemberList, " member list)"));
						stringBuilder.AppendLine();
						if (typeMapConfigErrors.UnmappedPropertyNames.Any())
						{
							stringBuilder.AppendLine("Unmapped properties:");
							string[] unmappedPropertyNames = typeMapConfigErrors.UnmappedPropertyNames;
							foreach (string value in unmappedPropertyNames)
							{
								stringBuilder.AppendLine(value);
							}
						}
						if (!typeMapConfigErrors.CanConstruct)
						{
							stringBuilder.AppendLine("No available constructor.");
						}
					}
					return stringBuilder.ToString();
				}
				return base.Message;
			}
		}

		public override string StackTrace
		{
			get
			{
				if (Errors != null)
				{
					return string.Join(Environment.NewLine, (from str in base.StackTrace.Split(new string[1]
						{
							Environment.NewLine
						}, StringSplitOptions.None)
						where !str.TrimStart().StartsWith("at AutoMapper.")
						select str).ToArray());
				}
				return base.StackTrace;
			}
		}

		public AutoMapperConfigurationException(string message)
			: base(message)
		{
		}

		protected AutoMapperConfigurationException(string message, Exception inner)
			: base(message, inner)
		{
		}

		public AutoMapperConfigurationException(TypeMapConfigErrors[] errors)
		{
			Errors = errors;
		}

		public AutoMapperConfigurationException(TypePair types)
		{
			Types = types;
		}
	}
}
