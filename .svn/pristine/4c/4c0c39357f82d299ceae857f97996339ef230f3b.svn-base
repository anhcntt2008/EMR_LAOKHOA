using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace AutoMapper.Configuration.Conventions
{
	public class MemberConfiguration : IMemberConfiguration
	{
		public IParentSourceToDestinationNameMapper NameMapper
		{
			get;
			set;
		}

		public IList<IChildMemberConfiguration> MemberMappers
		{
			get;
		} = new Collection<IChildMemberConfiguration>();


		public IMemberConfiguration AddMember<TMemberMapper>(Action<TMemberMapper> setupAction = null) where TMemberMapper : IChildMemberConfiguration, new()
		{
			GetOrAdd((IMemberConfiguration _) => (IList)_.MemberMappers, setupAction);
			return this;
		}

		public IMemberConfiguration AddName<TNameMapper>(Action<TNameMapper> setupAction = null) where TNameMapper : ISourceToDestinationNameMapper, new()
		{
			GetOrAdd((IMemberConfiguration _) => (IList)_.NameMapper.NamedMappers, setupAction);
			return this;
		}

		private TMemberMapper GetOrAdd<TMemberMapper>(Func<IMemberConfiguration, IList> getList, Action<TMemberMapper> setupAction = null) where TMemberMapper : new()
		{
			TMemberMapper val = getList(this).OfType<TMemberMapper>().FirstOrDefault();
			if (val == null)
			{
				val = new TMemberMapper();
				getList(this).Add(val);
			}
			setupAction?.Invoke(val);
			return val;
		}

		public MemberConfiguration()
		{
			NameMapper = new ParentSourceToDestinationNameMapper();
			MemberMappers.Add(new DefaultMember
			{
				NameMapper = NameMapper
			});
		}

		public bool MapDestinationPropertyToSource(ProfileMap options, TypeDetails sourceType, Type destType, Type destMemberType, string nameToSearch, LinkedList<MemberInfo> resolvers)
		{
			bool flag = false;
			foreach (IChildMemberConfiguration memberMapper in MemberMappers)
			{
				flag = memberMapper.MapDestinationPropertyToSource(options, sourceType, destType, destMemberType, nameToSearch, resolvers, this);
				if (flag)
				{
					return flag;
				}
			}
			return flag;
		}
	}
}
