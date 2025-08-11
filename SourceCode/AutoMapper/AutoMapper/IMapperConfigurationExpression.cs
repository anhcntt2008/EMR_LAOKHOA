using System;
using System.Collections.Generic;
using System.Reflection;

namespace AutoMapper
{
	public interface IMapperConfigurationExpression : IProfileExpression
	{
		bool? CreateMissingTypeMaps
		{
			get;
			set;
		}

		IList<IObjectMapper> Mappers
		{
			get;
		}

		AdvancedConfiguration Advanced
		{
			get;
		}

		void AddProfile(Profile profile);

		void AddProfile<TProfile>() where TProfile : Profile, new();

		void AddProfile(Type profileType);

		void AddProfiles(IEnumerable<Assembly> assembliesToScan);

		void AddProfiles(params Assembly[] assembliesToScan);

		void AddProfiles(IEnumerable<string> assemblyNamesToScan);

		void AddProfiles(params string[] assemblyNamesToScan);

		void AddProfiles(IEnumerable<Type> typesFromAssembliesContainingProfiles);

		void AddProfiles(params Type[] typesFromAssembliesContainingProfiles);

		void ConstructServicesUsing(Func<Type, object> constructor);

		void CreateProfile(string profileName, Action<IProfileExpression> config);
	}
}
