using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper
{
	[DebuggerDisplay("{DestinationProperty.Name}")]
	public class PropertyMap
	{
		private class MemberFinderVisitor : ExpressionVisitor
		{
			public MemberExpression Member
			{
				get;
				private set;
			}

			protected override Expression VisitMember(MemberExpression node)
			{
				Member = node;
				return base.VisitMember(node);
			}
		}

		private readonly List<MemberInfo> _memberChain = new List<MemberInfo>();

		private readonly List<ValueTransformerConfiguration> _valueTransformerConfigs = new List<ValueTransformerConfiguration>();

		public TypeMap TypeMap
		{
			get;
		}

		public MemberInfo DestinationProperty
		{
			get;
		}

		public Type DestinationPropertyType => DestinationProperty.GetMemberType();

		public ICollection<MemberInfo> SourceMembers => _memberChain;

		public bool Inline
		{
			get;
			set;
		} = true;


		public bool Ignored
		{
			get;
			set;
		}

		public bool AllowNull
		{
			get;
			set;
		}

		public int? MappingOrder
		{
			get;
			set;
		}

		public LambdaExpression CustomResolver
		{
			get;
			set;
		}

		public LambdaExpression Condition
		{
			get;
			set;
		}

		public LambdaExpression PreCondition
		{
			get;
			set;
		}

		public LambdaExpression CustomExpression
		{
			get;
			set;
		}

		public bool UseDestinationValue
		{
			get;
			set;
		}

		public bool ExplicitExpansion
		{
			get;
			set;
		}

		public object NullSubstitute
		{
			get;
			set;
		}

		public ValueResolverConfiguration ValueResolverConfig
		{
			get;
			set;
		}

		public IEnumerable<ValueTransformerConfiguration> ValueTransformers => _valueTransformerConfigs;

		public string CustomSourceMemberName
		{
			get;
			set;
		}

		public MemberInfo SourceMember
		{
			get
			{
				if (CustomSourceMemberName != null)
				{
					return TypeMap.SourceType.GetFieldOrProperty(CustomSourceMemberName);
				}
				if (CustomExpression != null)
				{
					MemberFinderVisitor memberFinderVisitor = new MemberFinderVisitor();
					memberFinderVisitor.Visit(CustomExpression);
					if (memberFinderVisitor.Member != null)
					{
						return memberFinderVisitor.Member.Member;
					}
				}
				return _memberChain.LastOrDefault();
			}
		}

		public Type SourceType
		{
			get
			{
				if (CustomExpression != null)
				{
					return CustomExpression.ReturnType;
				}
				if (CustomResolver != null)
				{
					return CustomResolver.ReturnType;
				}
				if (ValueResolverConfig != null)
				{
					return typeof(object);
				}
				return SourceMember?.GetMemberType();
			}
		}

		public PropertyMap(PathMap pathMap)
		{
			Condition = pathMap.Condition;
			DestinationProperty = pathMap.DestinationMember;
			CustomExpression = pathMap.SourceExpression;
			TypeMap = pathMap.TypeMap;
		}

		public PropertyMap(MemberInfo destinationProperty, TypeMap typeMap)
		{
			TypeMap = typeMap;
			DestinationProperty = destinationProperty;
		}

		public PropertyMap(PropertyMap inheritedMappedProperty, TypeMap typeMap)
			: this(inheritedMappedProperty.DestinationProperty, typeMap)
		{
			ApplyInheritedPropertyMap(inheritedMappedProperty);
		}

		public void ChainMembers(IEnumerable<MemberInfo> members)
		{
			IList<MemberInfo> collection = (members as IList<MemberInfo>) ?? members.ToList();
			_memberChain.AddRange(collection);
		}

		public void ApplyInheritedPropertyMap(PropertyMap inheritedMappedProperty)
		{
			if (inheritedMappedProperty.Ignored && !ResolveConfigured())
			{
				Ignored = true;
			}
			CustomExpression = (CustomExpression ?? inheritedMappedProperty.CustomExpression);
			CustomResolver = (CustomResolver ?? inheritedMappedProperty.CustomResolver);
			Condition = (Condition ?? inheritedMappedProperty.Condition);
			PreCondition = (PreCondition ?? inheritedMappedProperty.PreCondition);
			NullSubstitute = (NullSubstitute ?? inheritedMappedProperty.NullSubstitute);
			MappingOrder = (MappingOrder ?? inheritedMappedProperty.MappingOrder);
			ValueResolverConfig = (ValueResolverConfig ?? inheritedMappedProperty.ValueResolverConfig);
			CustomSourceMemberName = (CustomSourceMemberName ?? inheritedMappedProperty.CustomSourceMemberName);
		}

		public bool IsMapped()
		{
			if (!HasSource())
			{
				return Ignored;
			}
			return true;
		}

		public bool CanResolveValue()
		{
			if (HasSource())
			{
				return !Ignored;
			}
			return false;
		}

		public bool HasSource()
		{
			if (_memberChain.Count <= 0)
			{
				return ResolveConfigured();
			}
			return true;
		}

		public bool ResolveConfigured()
		{
			if (ValueResolverConfig == null && CustomResolver == null && CustomExpression == null)
			{
				return CustomSourceMemberName != null;
			}
			return true;
		}

		public void MapFrom(LambdaExpression sourceMember)
		{
			CustomExpression = sourceMember;
			Ignored = false;
		}

		public void AddValueTransformation(ValueTransformerConfiguration valueTransformerConfiguration)
		{
			_valueTransformerConfigs.Add(valueTransformerConfiguration);
		}
	}
}
