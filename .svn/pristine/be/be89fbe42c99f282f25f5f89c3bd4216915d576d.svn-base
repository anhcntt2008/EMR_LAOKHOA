using AutoMapper.Configuration.Internal;
using AutoMapper.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper.Configuration
{
	public class MappingExpression : MappingExpression<object, object>, IMappingExpression
	{
		internal class MemberConfigurationExpression : MemberConfigurationExpression<object, object, object>, IMemberConfigurationExpression, IMemberConfigurationExpression<object, object, object>
		{
			public MemberConfigurationExpression(MemberInfo destinationMember, Type sourceType)
				: base(destinationMember, sourceType)
			{
			}

			public void ResolveUsing(Type valueResolverType)
			{
				ValueResolverConfiguration config = new ValueResolverConfiguration(valueResolverType, valueResolverType.GetGenericInterface(typeof(IValueResolver<, , >)));
				base.PropertyMapActions.Add(delegate(PropertyMap pm)
				{
					pm.ValueResolverConfig = config;
				});
			}

			public void ResolveUsing(Type valueResolverType, string memberName)
			{
				ValueResolverConfiguration config = new ValueResolverConfiguration(valueResolverType, valueResolverType.GetGenericInterface(typeof(IMemberValueResolver<, , , >)))
				{
					SourceMemberName = memberName
				};
				base.PropertyMapActions.Add(delegate(PropertyMap pm)
				{
					pm.ValueResolverConfig = config;
				});
			}

			public void ResolveUsing<TSource, TDestination, TSourceMember, TDestMember>(IMemberValueResolver<TSource, TDestination, TSourceMember, TDestMember> resolver, string memberName)
			{
				ValueResolverConfiguration config = new ValueResolverConfiguration(resolver, typeof(IMemberValueResolver<TSource, TDestination, TSourceMember, TDestMember>))
				{
					SourceMemberName = memberName
				};
				base.PropertyMapActions.Add(delegate(PropertyMap pm)
				{
					pm.ValueResolverConfig = config;
				});
			}
		}

		public MappingExpression(TypePair types, MemberList memberList)
			: base(memberList, types)
		{
		}

		public new IMappingExpression ReverseMap()
		{
			return (IMappingExpression)base.ReverseMap();
		}

		public IMappingExpression Substitute(Func<object, object> substituteFunc)
		{
			return (IMappingExpression)base.Substitute(substituteFunc);
		}

		public new IMappingExpression ConstructUsingServiceLocator()
		{
			return (IMappingExpression)base.ConstructUsingServiceLocator();
		}

		public void ForAllMembers(Action<IMemberConfigurationExpression> memberOptions)
		{
			ForAllMembers(delegate(IMemberConfigurationExpression<object, object, object> opts)
			{
				memberOptions((IMemberConfigurationExpression)opts);
			});
		}

		void IMappingExpression.ConvertUsing<TTypeConverter>()
		{
			ConvertUsing(typeof(TTypeConverter));
		}

		public void ConvertUsing(Type typeConverterType)
		{
			base.TypeMapActions.Add(delegate(TypeMap tm)
			{
				tm.TypeConverterType = typeConverterType;
			});
		}

		public void ForAllOtherMembers(Action<IMemberConfigurationExpression> memberOptions)
		{
			ForAllOtherMembers(delegate(IMemberConfigurationExpression<object, object, object> o)
			{
				memberOptions((IMemberConfigurationExpression)o);
			});
		}

		public IMappingExpression ForMember(string name, Action<IMemberConfigurationExpression> memberOptions)
		{
			return (IMappingExpression)ForMember(name, delegate(IMemberConfigurationExpression<object, object, object> c)
			{
				memberOptions((IMemberConfigurationExpression)c);
			});
		}

		public new IMappingExpression ForSourceMember(string sourceMemberName, Action<ISourceMemberConfigurationExpression> memberOptions)
		{
			return (IMappingExpression)base.ForSourceMember(sourceMemberName, memberOptions);
		}

		public new IMappingExpression Include(Type otherSourceType, Type otherDestinationType)
		{
			return (IMappingExpression)base.Include(otherSourceType, otherDestinationType);
		}

		public new IMappingExpression IgnoreAllPropertiesWithAnInaccessibleSetter()
		{
			return (IMappingExpression)base.IgnoreAllPropertiesWithAnInaccessibleSetter();
		}

		public new IMappingExpression IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
		{
			return (IMappingExpression)base.IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
		}

		public new IMappingExpression IncludeBase(Type sourceBase, Type destinationBase)
		{
			return (IMappingExpression)base.IncludeBase(sourceBase, destinationBase);
		}

		public new IMappingExpression BeforeMap(Action<object, object> beforeFunction)
		{
			return (IMappingExpression)base.BeforeMap(beforeFunction);
		}

		public new IMappingExpression BeforeMap<TMappingAction>() where TMappingAction : IMappingAction<object, object>
		{
			return (IMappingExpression)base.BeforeMap<TMappingAction>();
		}

		public new IMappingExpression AfterMap(Action<object, object> afterFunction)
		{
			return (IMappingExpression)base.AfterMap(afterFunction);
		}

		public new IMappingExpression AfterMap<TMappingAction>() where TMappingAction : IMappingAction<object, object>
		{
			return (IMappingExpression)base.AfterMap<TMappingAction>();
		}

		public new IMappingExpression ConstructUsing(Func<object, object> ctor)
		{
			return (IMappingExpression)base.ConstructUsing(ctor);
		}

		public new IMappingExpression ConstructUsing(Func<object, ResolutionContext, object> ctor)
		{
			return (IMappingExpression)base.ConstructUsing(ctor);
		}

		public IMappingExpression ConstructProjectionUsing(LambdaExpression ctor)
		{
			base.TypeMapActions.Add(delegate(TypeMap tm)
			{
				tm.ConstructExpression = ctor;
			});
			return this;
		}

		public new IMappingExpression ValidateMemberList(MemberList memberList)
		{
			return (IMappingExpression)base.ValidateMemberList(memberList);
		}

		public new IMappingExpression MaxDepth(int depth)
		{
			return (IMappingExpression)base.MaxDepth(depth);
		}

		public new IMappingExpression ForCtorParam(string ctorParamName, Action<ICtorParamConfigurationExpression<object>> paramOptions)
		{
			return (IMappingExpression)base.ForCtorParam(ctorParamName, paramOptions);
		}

		public new IMappingExpression PreserveReferences()
		{
			return (IMappingExpression)base.PreserveReferences();
		}

		protected override IPropertyMapConfiguration CreateMemberConfigurationExpression<TMember>(MemberInfo member, Type sourceType)
		{
			return new MemberConfigurationExpression(member, sourceType);
		}

		protected override MappingExpression<object, object> CreateReverseMapExpression()
		{
			return new MappingExpression(new TypePair(base.DestinationType, base.SourceType), MemberList.Source);
		}
	}
	public class MappingExpression<TSource, TDestination> : IMappingExpression<TSource, TDestination>, ITypeMapConfiguration
	{
		private readonly List<IPropertyMapConfiguration> _memberConfigurations = new List<IPropertyMapConfiguration>();

		private readonly List<SourceMappingExpression> _sourceMemberConfigurations = new List<SourceMappingExpression>();

		private readonly List<CtorParamConfigurationExpression<TSource>> _ctorParamConfigurations = new List<CtorParamConfigurationExpression<TSource>>();

		private readonly List<ValueTransformerConfiguration> _valueTransformers = new List<ValueTransformerConfiguration>();

		private MappingExpression<TDestination, TSource> _reverseMap;

		private Action<IMemberConfigurationExpression<TSource, TDestination, object>> _allMemberOptions;

		private Func<MemberInfo, bool> _memberFilter;

		public TypePair Types
		{
			get;
		}

		public Type SourceType => Types.SourceType;

		public Type DestinationType => Types.DestinationType;

		public bool IsOpenGeneric
		{
			get;
		}

		public ITypeMapConfiguration ReverseTypeMap => _reverseMap;

		public IList<ValueTransformerConfiguration> ValueTransformers => _valueTransformers;

		protected List<Action<TypeMap>> TypeMapActions
		{
			get;
		} = new List<Action<TypeMap>>();


		public MappingExpression(MemberList memberList)
			: this(memberList, typeof(TSource), typeof(TDestination))
		{
		}

		public MappingExpression(MemberList memberList, Type sourceType, Type destinationType)
			: this(memberList, new TypePair(sourceType, destinationType))
		{
		}

		public MappingExpression(MemberList memberList, TypePair types)
		{
			Types = types;
			IsOpenGeneric = (types.SourceType.IsGenericTypeDefinition() || types.DestinationType.IsGenericTypeDefinition());
			TypeMapActions.Add(delegate(TypeMap tm)
			{
				tm.ConfiguredMemberList = memberList;
			});
		}

		public IMappingExpression<TSource, TDestination> PreserveReferences()
		{
			TypeMapActions.Add(delegate(TypeMap tm)
			{
				tm.PreserveReferences = true;
			});
			return this;
		}

		protected virtual IPropertyMapConfiguration CreateMemberConfigurationExpression<TMember>(MemberInfo member, Type sourceType)
		{
			return new MemberConfigurationExpression<TSource, TDestination, TMember>(member, sourceType);
		}

		protected virtual MappingExpression<TDestination, TSource> CreateReverseMapExpression()
		{
			return new MappingExpression<TDestination, TSource>(MemberList.None, DestinationType, SourceType);
		}

		public IMappingExpression<TSource, TDestination> ForPath<TMember>(Expression<Func<TDestination, TMember>> destinationMember, Action<IPathConfigurationExpression<TSource, TDestination, TMember>> memberOptions)
		{
			if (!destinationMember.IsMemberPath())
			{
				throw new ArgumentOutOfRangeException("destinationMember", "Only member accesses are allowed.");
			}
			PathConfigurationExpression<TSource, TDestination, TMember> pathConfigurationExpression = new PathConfigurationExpression<TSource, TDestination, TMember>(destinationMember);
			MemberInfo first = pathConfigurationExpression.MemberPath.First;
			if (GetDestinationMemberConfiguration(first) == null)
			{
				IgnoreDestinationMember(first, ignorePaths: false);
			}
			_memberConfigurations.Add(pathConfigurationExpression);
			memberOptions(pathConfigurationExpression);
			return this;
		}

		public IMappingExpression<TSource, TDestination> ForMember<TMember>(Expression<Func<TDestination, TMember>> destinationMember, Action<IMemberConfigurationExpression<TSource, TDestination, TMember>> memberOptions)
		{
			MemberInfo destinationProperty = ReflectionHelper.FindProperty(destinationMember);
			return ForDestinationMember(destinationProperty, memberOptions);
		}

		public IMappingExpression<TSource, TDestination> ForMember(string name, Action<IMemberConfigurationExpression<TSource, TDestination, object>> memberOptions)
		{
			MemberInfo fieldOrProperty = DestinationType.GetFieldOrProperty(name);
			return ForDestinationMember(fieldOrProperty, memberOptions);
		}

		public void ForAllOtherMembers(Action<IMemberConfigurationExpression<TSource, TDestination, object>> memberOptions)
		{
			_allMemberOptions = memberOptions;
			_memberFilter = ((MemberInfo m) => GetDestinationMemberConfiguration(m) == null);
		}

		public void ForAllMembers(Action<IMemberConfigurationExpression<TSource, TDestination, object>> memberOptions)
		{
			_allMemberOptions = memberOptions;
			_memberFilter = ((MemberInfo _) => true);
		}

		public IMappingExpression<TSource, TDestination> IgnoreAllPropertiesWithAnInaccessibleSetter()
		{
			foreach (PropertyInfo item in DestinationType.PropertiesWithAnInaccessibleSetter())
			{
				IgnoreDestinationMember(item);
			}
			return this;
		}

		private void IgnoreDestinationMember(MemberInfo property, bool ignorePaths = true)
		{
			ForDestinationMember(property, delegate(MemberConfigurationExpression<TSource, TDestination, object> options)
			{
				options.Ignore(ignorePaths);
			});
		}

		public IMappingExpression<TSource, TDestination> IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
		{
			foreach (PropertyInfo item in SourceType.PropertiesWithAnInaccessibleSetter())
			{
				ForSourceMember(item.Name, delegate(ISourceMemberConfigurationExpression options)
				{
					options.Ignore();
				});
			}
			return this;
		}

		public IMappingExpression<TSource, TDestination> Include<TOtherSource, TOtherDestination>() where TOtherSource : TSource where TOtherDestination : TDestination
		{
			return IncludeCore(typeof(TOtherSource), typeof(TOtherDestination));
		}

		public IMappingExpression<TSource, TDestination> Include(Type otherSourceType, Type otherDestinationType)
		{
			CheckIsDerived(otherSourceType, SourceType);
			CheckIsDerived(otherDestinationType, DestinationType);
			return IncludeCore(otherSourceType, otherDestinationType);
		}

		private IMappingExpression<TSource, TDestination> IncludeCore(Type otherSourceType, Type otherDestinationType)
		{
			TypeMapActions.Add(delegate(TypeMap tm)
			{
				tm.IncludeDerivedTypes(otherSourceType, otherDestinationType);
			});
			return this;
		}

		public IMappingExpression<TSource, TDestination> IncludeBase<TSourceBase, TDestinationBase>()
		{
			return IncludeBase(typeof(TSourceBase), typeof(TDestinationBase));
		}

		public IMappingExpression<TSource, TDestination> IncludeBase(Type sourceBase, Type destinationBase)
		{
			CheckIsDerived(SourceType, sourceBase);
			CheckIsDerived(DestinationType, destinationBase);
			TypeMapActions.Add(delegate(TypeMap tm)
			{
				tm.IncludeBaseTypes(sourceBase, destinationBase);
			});
			return this;
		}

		public void ProjectUsing(Expression<Func<TSource, TDestination>> projectionExpression)
		{
			TypeMapActions.Add(delegate(TypeMap tm)
			{
				tm.CustomProjection = projectionExpression;
			});
		}

		public IMappingExpression<TSource, TDestination> MaxDepth(int depth)
		{
			TypeMapActions.Add(delegate(TypeMap tm)
			{
				tm.MaxDepth = depth;
			});
			return this;
		}

		public IMappingExpression<TSource, TDestination> ConstructUsingServiceLocator()
		{
			TypeMapActions.Add(delegate(TypeMap tm)
			{
				tm.ConstructDestinationUsingServiceLocator = true;
			});
			return this;
		}

		public IMappingExpression<TDestination, TSource> ReverseMap()
		{
			_reverseMap = CreateReverseMapExpression();
			_reverseMap._memberConfigurations.AddRange(from m in _memberConfigurations
				select m.Reverse() into m
				where m != null
				select m);
			return _reverseMap;
		}

		public IMappingExpression<TSource, TDestination> ForSourceMember(Expression<Func<TSource, object>> sourceMember, Action<ISourceMemberConfigurationExpression> memberOptions)
		{
			SourceMappingExpression sourceMappingExpression = new SourceMappingExpression(ReflectionHelper.FindProperty(sourceMember));
			memberOptions(sourceMappingExpression);
			_sourceMemberConfigurations.Add(sourceMappingExpression);
			return this;
		}

		public IMappingExpression<TSource, TDestination> ForSourceMember(string sourceMemberName, Action<ISourceMemberConfigurationExpression> memberOptions)
		{
			SourceMappingExpression sourceMappingExpression = new SourceMappingExpression(SourceType.GetFieldOrProperty(sourceMemberName));
			memberOptions(sourceMappingExpression);
			_sourceMemberConfigurations.Add(sourceMappingExpression);
			return this;
		}

		public IMappingExpression<TSource, TDestination> Substitute<TSubstitute>(Func<TSource, TSubstitute> substituteFunc)
		{
			TypeMapActions.Add(delegate(TypeMap tm)
			{
				Expression<Func<TSource, TDestination, ResolutionContext, TSubstitute>> expression = (Expression<Func<TSource, TDestination, ResolutionContext, TSubstitute>>)(tm.Substitution = (Expression<Func<TSource, TDestination, ResolutionContext, TSubstitute>>)((TSource src, TDestination dest, ResolutionContext ctxt) => substituteFunc(src)));
			});
			return this;
		}

		public void ConvertUsing(Func<TSource, TDestination> mappingFunction)
		{
			TypeMapActions.Add(delegate(TypeMap tm)
			{
				Expression<Func<TSource, TDestination, ResolutionContext, TDestination>> expression = (Expression<Func<TSource, TDestination, ResolutionContext, TDestination>>)(tm.CustomMapper = (Expression<Func<TSource, TDestination, ResolutionContext, TDestination>>)((TSource src, TDestination dest, ResolutionContext ctxt) => mappingFunction(src)));
			});
		}

		public void ConvertUsing(Func<TSource, TDestination, TDestination> mappingFunction)
		{
			TypeMapActions.Add(delegate(TypeMap tm)
			{
				Expression<Func<TSource, TDestination, ResolutionContext, TDestination>> expression = (Expression<Func<TSource, TDestination, ResolutionContext, TDestination>>)(tm.CustomMapper = (Expression<Func<TSource, TDestination, ResolutionContext, TDestination>>)((TSource src, TDestination dest, ResolutionContext ctxt) => mappingFunction(src, dest)));
			});
		}

		public void ConvertUsing(Func<TSource, TDestination, ResolutionContext, TDestination> mappingFunction)
		{
			TypeMapActions.Add(delegate(TypeMap tm)
			{
				Expression<Func<TSource, TDestination, ResolutionContext, TDestination>> expression = (Expression<Func<TSource, TDestination, ResolutionContext, TDestination>>)(tm.CustomMapper = (Expression<Func<TSource, TDestination, ResolutionContext, TDestination>>)((TSource src, TDestination dest, ResolutionContext ctxt) => mappingFunction(src, dest, ctxt)));
			});
		}

		public void ConvertUsing(ITypeConverter<TSource, TDestination> converter)
		{
			ConvertUsing(converter.Convert);
		}

		public void ConvertUsing<TTypeConverter>() where TTypeConverter : ITypeConverter<TSource, TDestination>
		{
			TypeMapActions.Add(delegate(TypeMap tm)
			{
				tm.TypeConverterType = typeof(TTypeConverter);
			});
		}

		public IMappingExpression<TSource, TDestination> BeforeMap(Action<TSource, TDestination> beforeFunction)
		{
			TypeMapActions.Add(delegate(TypeMap tm)
			{
				Expression<Action<TSource, TDestination, ResolutionContext>> beforeMap = (TSource src, TDestination dest, ResolutionContext ctxt) => beforeFunction(src, dest);
				tm.AddBeforeMapAction(beforeMap);
			});
			return this;
		}

		public IMappingExpression<TSource, TDestination> BeforeMap(Action<TSource, TDestination, ResolutionContext> beforeFunction)
		{
			TypeMapActions.Add(delegate(TypeMap tm)
			{
				Expression<Action<TSource, TDestination, ResolutionContext>> beforeMap = (TSource src, TDestination dest, ResolutionContext ctxt) => beforeFunction(src, dest, ctxt);
				tm.AddBeforeMapAction(beforeMap);
			});
			return this;
		}

		public IMappingExpression<TSource, TDestination> BeforeMap<TMappingAction>() where TMappingAction : IMappingAction<TSource, TDestination>
		{
			return BeforeMap(BeforeFunction);
			static void BeforeFunction(TSource src, TDestination dest, ResolutionContext ctxt)
			{
				((TMappingAction)ctxt.Options.ServiceCtor(typeof(TMappingAction))).Process(src, dest);
			}
		}

		public IMappingExpression<TSource, TDestination> AfterMap(Action<TSource, TDestination> afterFunction)
		{
			TypeMapActions.Add(delegate(TypeMap tm)
			{
				Expression<Action<TSource, TDestination, ResolutionContext>> afterMap = (TSource src, TDestination dest, ResolutionContext ctxt) => afterFunction(src, dest);
				tm.AddAfterMapAction(afterMap);
			});
			return this;
		}

		public IMappingExpression<TSource, TDestination> AfterMap(Action<TSource, TDestination, ResolutionContext> afterFunction)
		{
			TypeMapActions.Add(delegate(TypeMap tm)
			{
				Expression<Action<TSource, TDestination, ResolutionContext>> afterMap = (TSource src, TDestination dest, ResolutionContext ctxt) => afterFunction(src, dest, ctxt);
				tm.AddAfterMapAction(afterMap);
			});
			return this;
		}

		public IMappingExpression<TSource, TDestination> AfterMap<TMappingAction>() where TMappingAction : IMappingAction<TSource, TDestination>
		{
			return AfterMap(AfterFunction);
			static void AfterFunction(TSource src, TDestination dest, ResolutionContext ctxt)
			{
				((TMappingAction)ctxt.Options.ServiceCtor(typeof(TMappingAction))).Process(src, dest);
			}
		}

		public IMappingExpression<TSource, TDestination> ConstructUsing(Func<TSource, TDestination> ctor)
		{
			TypeMapActions.Add(delegate(TypeMap tm)
			{
				Expression<Func<TSource, ResolutionContext, TDestination>> expression = (Expression<Func<TSource, ResolutionContext, TDestination>>)(tm.DestinationCtor = (Expression<Func<TSource, ResolutionContext, TDestination>>)((TSource src, ResolutionContext ctxt) => ctor(src)));
			});
			return this;
		}

		public IMappingExpression<TSource, TDestination> ConstructUsing(Func<TSource, ResolutionContext, TDestination> ctor)
		{
			TypeMapActions.Add(delegate(TypeMap tm)
			{
				Expression<Func<TSource, ResolutionContext, TDestination>> expression = (Expression<Func<TSource, ResolutionContext, TDestination>>)(tm.DestinationCtor = (Expression<Func<TSource, ResolutionContext, TDestination>>)((TSource src, ResolutionContext ctxt) => ctor(src, ctxt)));
			});
			return this;
		}

		public IMappingExpression<TSource, TDestination> ConstructProjectionUsing(Expression<Func<TSource, TDestination>> ctor)
		{
			TypeMapActions.Add(delegate(TypeMap tm)
			{
				tm.ConstructExpression = ctor;
				ParameterExpression parameterExpression = Expression.Parameter(typeof(ResolutionContext), "ctxt");
				ParameterExpression parameterExpression2 = Expression.Parameter(typeof(TSource), "src");
				Expression body = ctor.ReplaceParameters(parameterExpression2);
				tm.DestinationCtor = Expression.Lambda(body, parameterExpression2, parameterExpression);
			});
			return this;
		}

		private IMappingExpression<TSource, TDestination> ForDestinationMember<TMember>(MemberInfo destinationProperty, Action<MemberConfigurationExpression<TSource, TDestination, TMember>> memberOptions)
		{
			MemberConfigurationExpression<TSource, TDestination, TMember> memberConfigurationExpression = (MemberConfigurationExpression<TSource, TDestination, TMember>)CreateMemberConfigurationExpression<TMember>(destinationProperty, SourceType);
			_memberConfigurations.Add(memberConfigurationExpression);
			memberOptions(memberConfigurationExpression);
			return this;
		}

		public void As<T>() where T : TDestination
		{
			As(typeof(T));
		}

		public void As(Type typeOverride)
		{
			CheckIsDerived(typeOverride, DestinationType);
			TypeMapActions.Add(delegate(TypeMap tm)
			{
				tm.DestinationTypeOverride = typeOverride;
			});
		}

		private void CheckIsDerived(Type derivedType, Type baseType)
		{
			if (!baseType.IsAssignableFrom(derivedType) && !derivedType.IsGenericTypeDefinition() && !baseType.IsGenericTypeDefinition())
			{
				throw new ArgumentOutOfRangeException("derivedType", $"{derivedType} is not derived from {baseType}.");
			}
		}

		public IMappingExpression<TSource, TDestination> ForCtorParam(string ctorParamName, Action<ICtorParamConfigurationExpression<TSource>> paramOptions)
		{
			CtorParamConfigurationExpression<TSource> ctorParamConfigurationExpression = new CtorParamConfigurationExpression<TSource>(ctorParamName);
			paramOptions(ctorParamConfigurationExpression);
			_ctorParamConfigurations.Add(ctorParamConfigurationExpression);
			return this;
		}

		public IMappingExpression<TSource, TDestination> DisableCtorValidation()
		{
			TypeMapActions.Add(delegate(TypeMap tm)
			{
				tm.DisableConstructorValidation = true;
			});
			return this;
		}

		public IMappingExpression<TSource, TDestination> AddTransform<TValue>(Expression<Func<TValue, TValue>> transformer)
		{
			ValueTransformerConfiguration item = new ValueTransformerConfiguration(typeof(TValue), transformer);
			_valueTransformers.Add(item);
			return this;
		}

		public IMappingExpression<TSource, TDestination> ValidateMemberList(MemberList memberList)
		{
			TypeMapActions.Add(delegate(TypeMap tm)
			{
				tm.ConfiguredMemberList = memberList;
			});
			return this;
		}

		private IPropertyMapConfiguration GetDestinationMemberConfiguration(MemberInfo destinationMember)
		{
			return _memberConfigurations.FirstOrDefault((IPropertyMapConfiguration m) => m.DestinationMember == destinationMember);
		}

		public void Configure(TypeMap typeMap)
		{
			foreach (MemberInfo publicWriteAccessor in typeMap.DestinationTypeDetails.PublicWriteAccessors)
			{
				if (publicWriteAccessor.GetCustomAttributes(inherit: true).Any((object x) => x is IgnoreMapAttribute))
				{
					IgnoreDestinationMember(publicWriteAccessor);
					MemberInfo inheritedMember = typeMap.SourceType.GetInheritedMember(publicWriteAccessor.Name);
					if (inheritedMember != null)
					{
						_reverseMap?.IgnoreDestinationMember(inheritedMember);
					}
				}
				if (typeMap.Profile.GlobalIgnores.Contains(publicWriteAccessor.Name) && GetDestinationMemberConfiguration(publicWriteAccessor) == null)
				{
					IgnoreDestinationMember(publicWriteAccessor);
				}
			}
			if (_allMemberOptions != null)
			{
				foreach (MemberInfo item in typeMap.DestinationTypeDetails.PublicReadAccessors.Where(_memberFilter))
				{
					ForDestinationMember(item, _allMemberOptions);
				}
			}
			foreach (Action<TypeMap> typeMapAction in TypeMapActions)
			{
				typeMapAction(typeMap);
			}
			foreach (IPropertyMapConfiguration memberConfiguration in _memberConfigurations)
			{
				memberConfiguration.Configure(typeMap);
			}
			foreach (SourceMappingExpression sourceMemberConfiguration in _sourceMemberConfigurations)
			{
				sourceMemberConfiguration.Configure(typeMap);
			}
			foreach (CtorParamConfigurationExpression<TSource> ctorParamConfiguration in _ctorParamConfigurations)
			{
				ctorParamConfiguration.Configure(typeMap);
			}
			foreach (ValueTransformerConfiguration valueTransformer in _valueTransformers)
			{
				typeMap.AddValueTransformation(valueTransformer);
			}
			if (_reverseMap == null)
			{
				return;
			}
			ReverseSourceMembers(typeMap);
			foreach (PropertyMap item2 in from pm in typeMap.GetPropertyMaps()
				where pm.Ignored
				select pm)
			{
				_reverseMap.ForSourceMember(item2.DestinationProperty.Name, delegate(ISourceMemberConfigurationExpression opt)
				{
					opt.Ignore();
				});
			}
			foreach (TypePair includedDerivedType in typeMap.IncludedDerivedTypes)
			{
				_reverseMap.Include(includedDerivedType.DestinationType, includedDerivedType.SourceType);
			}
			foreach (TypePair includedBaseType in typeMap.IncludedBaseTypes)
			{
				_reverseMap.IncludeBase(includedBaseType.DestinationType, includedBaseType.SourceType);
			}
		}

		private void ReverseSourceMembers(TypeMap typeMap)
		{
			foreach (PropertyMap propertyMap in from p in typeMap.GetPropertyMaps()
				where p.SourceMembers.Count > 1 && !p.SourceMembers.Any((MemberInfo s) => s is MethodInfo)
				select p)
			{
				_reverseMap.TypeMapActions.Add(delegate(TypeMap reverseTypeMap)
				{
					MemberPath path = new MemberPath(propertyMap.SourceMembers);
					ParameterExpression parameterExpression = Expression.Parameter(reverseTypeMap.DestinationType, "destination");
					LambdaExpression destinationExpression = Expression.Lambda(propertyMap.SourceMembers.MemberAccesses(parameterExpression), parameterExpression);
					PathMap pathMap = reverseTypeMap.FindOrCreatePathMapFor(destinationExpression, path, reverseTypeMap);
					ParameterExpression parameterExpression2 = Expression.Parameter(reverseTypeMap.SourceType, "source");
					pathMap.SourceExpression = Expression.Lambda(Expression.MakeMemberAccess(parameterExpression2, propertyMap.DestinationProperty), parameterExpression2);
				});
			}
		}
	}
}
