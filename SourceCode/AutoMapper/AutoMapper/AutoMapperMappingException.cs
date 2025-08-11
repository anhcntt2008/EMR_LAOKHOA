using System;
using System.Linq;

namespace AutoMapper
{
	public class AutoMapperMappingException : Exception
	{
		private readonly string _message;

		public TypePair? Types
		{
			get;
			set;
		}

		public TypeMap TypeMap
		{
			get;
			set;
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
				string text = _message;
				string newLine = Environment.NewLine;
				if (Types?.SourceType != null && Types?.DestinationType != null)
				{
					text = text + newLine + newLine + "Mapping types:";
					text = text + newLine + $"{Types?.SourceType.Name} -> {Types?.DestinationType.Name}";
					text = text + newLine + $"{Types?.SourceType.FullName} -> {Types?.DestinationType.FullName}";
				}
				if (TypeMap != null)
				{
					text = text + newLine + newLine + "Type Map configuration:";
					text = text + newLine + $"{TypeMap.SourceType.Name} -> {TypeMap.DestinationType.Name}";
					text = text + newLine + $"{TypeMap.SourceType.FullName} -> {TypeMap.DestinationType.FullName}";
				}
				if (PropertyMap != null)
				{
					text = text + newLine + newLine + "Property:";
					text = text + newLine + $"{PropertyMap.DestinationProperty.Name}";
				}
				return text;
			}
		}

		public override string StackTrace => string.Join(Environment.NewLine, from str in base.StackTrace.Split(new string[1]
			{
				Environment.NewLine
			}, StringSplitOptions.None)
			where !str.TrimStart().StartsWith("at AutoMapper.")
			select str);

		public AutoMapperMappingException()
		{
		}

		public AutoMapperMappingException(string message)
			: base(message)
		{
			_message = message;
		}

		public AutoMapperMappingException(string message, Exception innerException)
			: base(message, innerException)
		{
			_message = message;
		}

		public AutoMapperMappingException(string message, Exception innerException, TypePair types)
			: this(message, innerException)
		{
			Types = types;
		}

		public AutoMapperMappingException(string message, Exception innerException, TypePair types, TypeMap typeMap)
			: this(message, innerException, types)
		{
			TypeMap = typeMap;
		}

		public AutoMapperMappingException(string message, Exception innerException, TypePair types, TypeMap typeMap, PropertyMap propertyMap)
			: this(message, innerException, types, typeMap)
		{
			PropertyMap = propertyMap;
		}
	}
}
