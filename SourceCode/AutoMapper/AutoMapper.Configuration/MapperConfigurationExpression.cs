using AutoMapper.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoMapper.Configuration
{
	public class MapperConfigurationExpression : Profile, IMapperConfigurationExpression, IProfileExpression, IConfiguration, IProfileConfiguration
	{
		private class NamedProfile : Profile
		{
			public NamedProfile(string profileName, Action<IProfileExpression> config)
				: base(profileName, config)
			{
			}
		}

		private readonly IList<Profile> _profiles = new List<Profile>();

		public IEnumerable<IProfileConfiguration> Profiles => _profiles;

		public Func<Type, object> ServiceCtor
		{
			get;
			private set;
		} = Activator.CreateInstance;


		public IList<IObjectMapper> Mappers
		{
			get;
		}

		public AdvancedConfiguration Advanced
		{
			get;
		} = new AdvancedConfiguration();


		public MapperConfigurationExpression()
			: base("")
		{
			IncludeSourceExtensionMethods(typeof(Enumerable));
			Mappers = MapperRegistry.Mappers();
		}

		public void CreateProfile(string profileName, Action<IProfileExpression> config)
		{
			AddProfile(new NamedProfile(profileName, config));
		}

		public void AddProfile(Profile profile)
		{
			_profiles.Add(profile);
		}

		public void AddProfile<TProfile>() where TProfile : Profile, new()
		{
			AddProfile(new TProfile());
		}

		public void AddProfile(Type profileType)
		{
			AddProfile((Profile)Activator.CreateInstance(profileType));
		}

		public void AddProfiles(IEnumerable<Assembly> assembliesToScan)
		{
			AddProfilesCore(assembliesToScan);
		}

		public void AddProfiles(params Assembly[] assembliesToScan)
		{
			AddProfilesCore(assembliesToScan);
		}

		public void AddProfiles(IEnumerable<string> assemblyNamesToScan)
		{
			AddProfilesCore(assemblyNamesToScan.Select((string name) => Assembly.Load(new AssemblyName(name))));
		}

		public void AddProfiles(params string[] assemblyNamesToScan)
		{
			AddProfilesCore(assemblyNamesToScan.Select((string name) => Assembly.Load(new AssemblyName(name))));
		}

		public void AddProfiles(IEnumerable<Type> typesFromAssembliesContainingProfiles)
		{
			AddProfilesCore(typesFromAssembliesContainingProfiles.Select((Type t) => t.GetTypeInfo().Assembly));
		}

		public void AddProfiles(params Type[] typesFromAssembliesContainingProfiles)
		{
			AddProfilesCore(typesFromAssembliesContainingProfiles.Select((Type t) => t.GetTypeInfo().Assembly));
		}

		private void AddProfilesCore(IEnumerable<Assembly> assembliesToScan)
		{
			foreach (Type item in from t in assembliesToScan.Where((Assembly a) => !a.IsDynamic).SelectMany((Assembly a) => a.GetDefinedTypes()).ToArray()
				where typeof(Profile).GetTypeInfo().IsAssignableFrom(t)
				where !t.IsAbstract
				select t.AsType())
			{
				AddProfile(item);
			}
		}

		public void ConstructServicesUsing(Func<Type, object> constructor)
		{
			ServiceCtor = constructor;
		}
	}
}
