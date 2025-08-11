using System;

namespace AutoMapper.Configuration
{
	public interface ITypeMapConfiguration
	{
		Type SourceType
		{
			get;
		}

		Type DestinationType
		{
			get;
		}

		bool IsOpenGeneric
		{
			get;
		}

		TypePair Types
		{
			get;
		}

		ITypeMapConfiguration ReverseTypeMap
		{
			get;
		}

		void Configure(TypeMap typeMap);
	}
}
