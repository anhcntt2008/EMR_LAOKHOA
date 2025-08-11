using AutoMapper.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace AutoMapper
{
	[DebuggerDisplay("{Type}")]
	public class TypeDetails
	{
		public struct DestinationMemberName
		{
			public MemberInfo Member
			{
				get;
				set;
			}

			public string[] Possibles
			{
				get;
				set;
			}
		}

		public Type Type
		{
			get;
		}

		public IEnumerable<ConstructorInfo> Constructors
		{
			get;
		}

		public IEnumerable<MemberInfo> PublicReadAccessors
		{
			get;
		}

		public IEnumerable<MemberInfo> PublicWriteAccessors
		{
			get;
		}

		public IEnumerable<MethodInfo> PublicNoArgMethods
		{
			get;
		}

		public IEnumerable<MethodInfo> PublicNoArgExtensionMethods
		{
			get;
		}

		public IEnumerable<MemberInfo> AllMembers
		{
			get;
		}

		public IEnumerable<DestinationMemberName> DestinationMemberNames
		{
			get;
			set;
		}

		public TypeDetails(Type type, ProfileMap config)
		{
			TypeDetails typeDetails = this;
			Type = type;
			Func<MemberInfo, bool> membersToMap = MembersToMap(config.ShouldMapProperty, config.ShouldMapField);
			IEnumerable<MemberInfo> allPublicReadableMembers = GetAllPublicReadableMembers(membersToMap);
			IEnumerable<MemberInfo> allPublicWritableMembers = GetAllPublicWritableMembers(membersToMap);
			PublicReadAccessors = BuildPublicReadAccessors(allPublicReadableMembers);
			PublicWriteAccessors = BuildPublicAccessors(allPublicWritableMembers);
			PublicNoArgMethods = BuildPublicNoArgMethods();
			Constructors = (from ci in type.GetDeclaredConstructors()
				where !ci.IsStatic
				select ci).ToArray();
			PublicNoArgExtensionMethods = BuildPublicNoArgExtensionMethods(config.SourceExtensionMethods);
			AllMembers = PublicReadAccessors.Concat(PublicNoArgMethods).Concat(PublicNoArgExtensionMethods).ToList();
			DestinationMemberNames = AllMembers.Select(delegate(MemberInfo mi)
			{
				DestinationMemberName result = default(DestinationMemberName);
				result.Member = mi;
				result.Possibles = typeDetails.PossibleNames(mi.Name, config.Prefixes, config.Postfixes).ToArray();
				return result;
			});
		}

		private IEnumerable<string> PossibleNames(string memberName, IEnumerable<string> prefixes, IEnumerable<string> postfixes)
		{
			string memberName2 = memberName;
			yield return memberName2;
			if (!postfixes.Any())
			{
				foreach (string item in from prefix in prefixes
					where memberName2.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)
					select memberName2.Substring(prefix.Length))
				{
					yield return item;
				}
				yield break;
			}
			foreach (string withoutPrefix in from prefix in prefixes
				where memberName2.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)
				select memberName2.Substring(prefix.Length))
			{
				yield return withoutPrefix;
				foreach (string item2 in PostFixes(postfixes, withoutPrefix))
				{
					yield return item2;
				}
			}
			foreach (string item3 in PostFixes(postfixes, memberName2))
			{
				yield return item3;
			}
		}

		private static IEnumerable<string> PostFixes(IEnumerable<string> postfixes, string name)
		{
			return from postfix in postfixes
				where name.EndsWith(postfix, StringComparison.OrdinalIgnoreCase)
				select name.Remove(name.Length - postfix.Length);
		}

		private static Func<MemberInfo, bool> MembersToMap(Func<PropertyInfo, bool> shouldMapProperty, Func<FieldInfo, bool> shouldMapField)
		{
			return delegate(MemberInfo m)
			{
				if ((object)m != null)
				{
					PropertyInfo propertyInfo;
					if ((object)(propertyInfo = (m as PropertyInfo)) != null)
					{
						PropertyInfo propertyInfo2 = propertyInfo;
						if (!propertyInfo2.IsStatic())
						{
							return shouldMapProperty(propertyInfo2);
						}
						return false;
					}
					FieldInfo fieldInfo;
					if ((object)(fieldInfo = (m as FieldInfo)) != null)
					{
						FieldInfo fieldInfo2 = fieldInfo;
						if (!fieldInfo2.IsStatic)
						{
							return shouldMapField(fieldInfo2);
						}
						return false;
					}
				}
				throw new ArgumentException("Should be a field or property.");
			};
		}

		private IEnumerable<MethodInfo> BuildPublicNoArgExtensionMethods(IEnumerable<MethodInfo> sourceExtensionMethodSearch)
		{
			IEnumerable<MethodInfo> first = sourceExtensionMethodSearch.Where((MethodInfo method) => method.GetParameters()[0].ParameterType == Type);
			IEnumerable<Type> genericInterfaces = Type.GetTypeInfo().ImplementedInterfaces.Where((Type t) => t.IsGenericType());
			if (Type.IsInterface() && Type.IsGenericType())
			{
				genericInterfaces = genericInterfaces.Union(new Type[1]
				{
					Type
				});
			}
			return first.Union(from genericMethod in sourceExtensionMethodSearch
				where genericMethod.IsGenericMethodDefinition
				from genericInterface in genericInterfaces
				let genericInterfaceArguments = genericInterface.GetTypeInfo().GenericTypeArguments
				where genericMethod.GetGenericArguments().Length == genericInterfaceArguments.Length
				let methodMatch = genericMethod.MakeGenericMethod(genericInterfaceArguments)
				where methodMatch.GetParameters()[0].ParameterType.GetTypeInfo().IsAssignableFrom(genericInterface.GetTypeInfo())
				select methodMatch).ToArray();
		}

		private static MemberInfo[] BuildPublicReadAccessors(IEnumerable<MemberInfo> allMembers)
		{
			return (from x in allMembers.OfType<PropertyInfo>()
				group x by x.Name into x
				select x.First()).Concat(allMembers.Where((MemberInfo x) => x is FieldInfo)).ToArray();
		}

		private static MemberInfo[] BuildPublicAccessors(IEnumerable<MemberInfo> allMembers)
		{
			return (from x in allMembers.OfType<PropertyInfo>()
				group x by x.Name into x
				select (!x.Any((PropertyInfo y) => y.CanWrite && y.CanRead)) ? x.First() : x.First((PropertyInfo y) => y.CanWrite && y.CanRead) into pi
				where pi.CanWrite || pi.PropertyType.IsListOrDictionaryType()
				select pi).Concat(allMembers.Where((MemberInfo x) => x is FieldInfo)).ToArray();
		}

		private IEnumerable<MemberInfo> GetAllPublicReadableMembers(Func<MemberInfo, bool> membersToMap)
		{
			return GetAllPublicMembers(PropertyReadable, FieldReadable, membersToMap);
		}

		private IEnumerable<MemberInfo> GetAllPublicWritableMembers(Func<MemberInfo, bool> membersToMap)
		{
			return GetAllPublicMembers(PropertyWritable, FieldWritable, membersToMap);
		}

		private static bool PropertyReadable(PropertyInfo propertyInfo)
		{
			return propertyInfo.CanRead;
		}

		private static bool FieldReadable(FieldInfo fieldInfo)
		{
			return true;
		}

		private static bool PropertyWritable(PropertyInfo propertyInfo)
		{
			bool flag = typeof(string) != propertyInfo.PropertyType && typeof(IEnumerable).GetTypeInfo().IsAssignableFrom(propertyInfo.PropertyType.GetTypeInfo());
			return propertyInfo.CanWrite || flag;
		}

		private static bool FieldWritable(FieldInfo fieldInfo)
		{
			return !fieldInfo.IsInitOnly;
		}

		private IEnumerable<MemberInfo> GetAllPublicMembers(Func<PropertyInfo, bool> propertyAvailableFor, Func<FieldInfo, bool> fieldAvailableFor, Func<MemberInfo, bool> memberAvailableFor)
		{
			List<Type> list = new List<Type>();
			Type type = Type;
			while (type != null)
			{
				list.Add(type);
				type = type.BaseType();
			}
			if (Type.IsInterface())
			{
				list.AddRange(Type.GetTypeInfo().ImplementedInterfaces);
			}
			return list.Where((Type x) => x != null).SelectMany((Type x) => (from mi in x.GetDeclaredMembers()
				where mi.DeclaringType != null && mi.DeclaringType == x
				select mi into m
				where (m is FieldInfo && fieldAvailableFor((FieldInfo)m)) || (m is PropertyInfo && propertyAvailableFor((PropertyInfo)m) && !((PropertyInfo)m).GetIndexParameters().Any())
				select m).Where(memberAvailableFor));
		}

		private MethodInfo[] BuildPublicNoArgMethods()
		{
			return (from mi in Type.GetAllMethods()
				where mi.IsPublic && !mi.IsStatic && mi.DeclaringType != typeof(object)
				select mi into m
				where m.ReturnType != typeof(void) && m.GetParameters().Length == 0
				select m).ToArray();
		}
	}
}
