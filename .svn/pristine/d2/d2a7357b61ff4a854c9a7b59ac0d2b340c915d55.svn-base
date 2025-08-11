using AutoMapper.Configuration;
using AutoMapper.Internal;
using AutoMapper.QueryableExtensions.Impl;
using AutoMapper.XpressionMapper.ArgumentMappers;
using AutoMapper.XpressionMapper.Extensions;
using AutoMapper.XpressionMapper.Structures;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace AutoMapper.XpressionMapper
{
	public class XpressionMapperVisitor : ExpressionVisitor
	{
		public MapperInfoDictionary InfoDictionary
		{
			get;
		}

		public Dictionary<Type, Type> TypeMappings
		{
			get;
		}

		protected IConfigurationProvider ConfigurationProvider
		{
			get;
		}

		public XpressionMapperVisitor(IConfigurationProvider configurationProvider, Dictionary<Type, Type> typeMappings)
		{
			TypeMappings = typeMappings;
			InfoDictionary = new MapperInfoDictionary(new ParameterExpressionEqualityComparer());
			ConfigurationProvider = configurationProvider;
		}

		protected override Expression VisitParameter(ParameterExpression parameterExpression)
		{
			InfoDictionary.Add(parameterExpression, TypeMappings);
			KeyValuePair<ParameterExpression, MapperInfo> keyValuePair = InfoDictionary.SingleOrDefault((KeyValuePair<ParameterExpression, MapperInfo> a) => a.Key.Equals(parameterExpression));
			if (keyValuePair.Equals(default(KeyValuePair<Type, MapperInfo>)))
			{
				return base.VisitParameter(parameterExpression);
			}
			return keyValuePair.Value.NewParameter;
		}

		protected override Expression VisitMember(MemberExpression node)
		{
			ParameterExpression parameterExpression = node.GetParameterExpression();
			if (parameterExpression == null)
			{
				return base.VisitMember(node);
			}
			InfoDictionary.Add(parameterExpression, TypeMappings);
			Type type = parameterExpression.Type;
			if (InfoDictionary.ContainsKey(parameterExpression) && node.IsMemberExpression())
			{
				string propertyFullName = node.GetPropertyFullName();
				List<PropertyMapInfo> propertyMapInfoList = new List<PropertyMapInfo>();
				FindDestinationFullName(type, InfoDictionary[parameterExpression].DestType, propertyFullName, propertyMapInfoList);
				string parentFullName;
				if (propertyMapInfoList.Any((PropertyMapInfo x) => x.CustomExpression != null))
				{
					PropertyMapInfo last = propertyMapInfoList.Last((PropertyMapInfo x) => x.CustomExpression != null);
					List<PropertyMapInfo> propertyMapInfoList2 = propertyMapInfoList.Aggregate(new List<PropertyMapInfo>(), delegate(List<PropertyMapInfo> list, PropertyMapInfo next)
					{
						if (propertyMapInfoList.IndexOf(next) < propertyMapInfoList.IndexOf(last))
						{
							list.Add(next);
						}
						return list;
					});
					List<PropertyMapInfo> list2 = propertyMapInfoList.Aggregate(new List<PropertyMapInfo>(), delegate(List<PropertyMapInfo> list, PropertyMapInfo next)
					{
						if (propertyMapInfoList.IndexOf(next) > propertyMapInfoList.IndexOf(last))
						{
							list.Add(next);
						}
						return list;
					});
					parentFullName = BuildFullName(propertyMapInfoList2);
					PrependParentNameVisitor prependParentNameVisitor = new PrependParentNameVisitor(last.CustomExpression.Parameters[0].Type, parentFullName, InfoDictionary[parameterExpression].NewParameter);
					Expression expression = (propertyMapInfoList[propertyMapInfoList.Count - 1] != last) ? prependParentNameVisitor.Visit(last.CustomExpression.Body.MemberAccesses(list2)) : prependParentNameVisitor.Visit(last.CustomExpression.Body);
					TypeMappings.AddTypeMapping(node.Type, expression.Type);
					return expression;
				}
				parentFullName = BuildFullName(propertyMapInfoList);
				MemberExpression memberExpression = ExpressionFactory.MemberAccesses(parentFullName, InfoDictionary[parameterExpression].NewParameter);
				TypeMappings.AddTypeMapping(node.Type, memberExpression.Type);
				return memberExpression;
			}
			return base.VisitMember(node);
		}

		protected override Expression VisitConstant(ConstantExpression node)
		{
			if (TypeMappings.TryGetValue(node.Type, out Type value))
			{
				return base.VisitConstant(Expression.Constant(node.Value, value));
			}
			return base.VisitConstant(node);
		}

		protected override Expression VisitMethodCall(MethodCallExpression node)
		{
			ParameterExpression parameterExpression = node.GetParameterExpression();
			if (parameterExpression == null)
			{
				return base.VisitMethodCall(node);
			}
			InfoDictionary.Add(parameterExpression, TypeMappings);
			List<Expression> list = node.Arguments.Aggregate(new List<Expression>(), delegate(List<Expression> lst, Expression next)
			{
				Expression mappedArgumentExpression2 = ArgumentMapper.Create(this, next).MappedArgumentExpression;
				TypeMappings.AddTypeMapping(next.Type, mappedArgumentExpression2.Type);
				lst.Add(mappedArgumentExpression2);
				return lst;
			});
			List<Type> list2 = node.Method.IsGenericMethod ? (from i in node.Method.GetGenericArguments()
				select (!TypeMappings.ContainsKey(i)) ? i : TypeMappings[i]).ToList() : null;
			if (!node.Method.IsStatic)
			{
				Expression mappedArgumentExpression = ArgumentMapper.Create(this, node.Object).MappedArgumentExpression;
				return node.Method.IsGenericMethod ? Expression.Call(mappedArgumentExpression, node.Method.Name, list2.ToArray(), list.ToArray()) : Expression.Call(mappedArgumentExpression, node.Method, list.ToArray());
			}
			return node.Method.IsGenericMethod ? Expression.Call(node.Method.DeclaringType, node.Method.Name, list2.ToArray(), list.ToArray()) : Expression.Call(node.Method, list.ToArray());
		}

		protected string BuildFullName(List<PropertyMapInfo> propertyMapInfoList)
		{
			string text = string.Empty;
			foreach (PropertyMapInfo propertyMapInfo in propertyMapInfoList)
			{
				text = ((propertyMapInfo.CustomExpression == null) ? propertyMapInfo.DestinationPropertyInfos.Aggregate(new StringBuilder(text), delegate(StringBuilder sb, MemberInfo next)
				{
					if (sb.ToString() == string.Empty)
					{
						sb.Append(next.Name);
					}
					else
					{
						sb.Append(".");
						sb.Append(next.Name);
					}
					return sb;
				}).ToString() : (string.IsNullOrEmpty(text) ? propertyMapInfo.CustomExpression.GetMemberFullName() : (text + "." + propertyMapInfo.CustomExpression.GetMemberFullName())));
			}
			return text;
		}

		private static void AddPropertyMapInfo(Type parentType, string name, List<PropertyMapInfo> propertyMapInfoList)
		{
			MemberInfo fieldOrProperty = parentType.GetFieldOrProperty(name);
			if ((object)fieldOrProperty == null)
			{
				return;
			}
			PropertyInfo propertyInfo;
			if ((object)(propertyInfo = (fieldOrProperty as PropertyInfo)) == null)
			{
				FieldInfo fieldInfo;
				if ((object)(fieldInfo = (fieldOrProperty as FieldInfo)) != null)
				{
					FieldInfo item = fieldInfo;
					propertyMapInfoList.Add(new PropertyMapInfo(null, new List<MemberInfo>
					{
						item
					}));
				}
			}
			else
			{
				PropertyInfo item2 = propertyInfo;
				propertyMapInfoList.Add(new PropertyMapInfo(null, new List<MemberInfo>
				{
					item2
				}));
			}
		}

		protected void FindDestinationFullName(Type typeSource, Type typeDestination, string sourceFullName, List<PropertyMapInfo> propertyMapInfoList)
		{
			if (typeSource == typeDestination)
			{
				sourceFullName.Split(new char[1]
				{
					"."[0]
				}, StringSplitOptions.RemoveEmptyEntries).Aggregate(propertyMapInfoList, delegate(List<PropertyMapInfo> list, string next)
				{
					if (list.Count == 0)
					{
						AddPropertyMapInfo(typeSource, next, list);
					}
					else
					{
						PropertyMapInfo propertyMapInfo = list[list.Count - 1];
						AddPropertyMapInfo((propertyMapInfo.CustomExpression == null) ? propertyMapInfo.DestinationPropertyInfos[propertyMapInfo.DestinationPropertyInfos.Count - 1].GetMemberType() : propertyMapInfo.CustomExpression.ReturnType, next, list);
					}
					return list;
				});
				return;
			}
			TypeMap typeMap = ConfigurationProvider.CheckIfMapExists(typeDestination, typeSource);
			PathMap pathMap = typeMap.FindPathMapByDestinationPath(sourceFullName);
			if (pathMap != null)
			{
				propertyMapInfoList.Add(new PropertyMapInfo(pathMap.SourceExpression, new List<MemberInfo>()));
			}
			else if (sourceFullName.IndexOf(".", StringComparison.OrdinalIgnoreCase) < 0)
			{
				PropertyMap propertyMapByDestinationProperty = typeMap.GetPropertyMapByDestinationProperty(sourceFullName);
				MemberInfo fieldOrProperty = typeSource.GetFieldOrProperty(propertyMapByDestinationProperty.DestinationProperty.Name);
				if (propertyMapByDestinationProperty.ValueResolverConfig != null)
				{
					throw new InvalidOperationException(Resource.customResolversNotSupported);
				}
				if (propertyMapByDestinationProperty.CustomExpression != null)
				{
					if (propertyMapByDestinationProperty.CustomExpression.ReturnType.IsValueType() && fieldOrProperty.GetMemberType() != propertyMapByDestinationProperty.CustomExpression.ReturnType)
					{
						throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resource.expressionMapValueTypeMustMatchFormat, propertyMapByDestinationProperty.CustomExpression.ReturnType.Name, propertyMapByDestinationProperty.CustomExpression.ToString(), fieldOrProperty.GetMemberType().Name, propertyMapByDestinationProperty.DestinationProperty.Name));
					}
				}
				else if (propertyMapByDestinationProperty.SourceMember.GetMemberType().IsValueType() && fieldOrProperty.GetMemberType() != propertyMapByDestinationProperty.SourceMember.GetMemberType())
				{
					throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resource.expressionMapValueTypeMustMatchFormat, propertyMapByDestinationProperty.SourceMember.GetMemberType().Name, propertyMapByDestinationProperty.SourceMember.Name, fieldOrProperty.GetMemberType().Name, propertyMapByDestinationProperty.DestinationProperty.Name));
				}
				propertyMapInfoList.Add(new PropertyMapInfo(propertyMapByDestinationProperty.CustomExpression, propertyMapByDestinationProperty.SourceMembers.ToList()));
			}
			else
			{
				string text = sourceFullName.Substring(0, sourceFullName.IndexOf(".", StringComparison.OrdinalIgnoreCase));
				PropertyMap propertyMapByDestinationProperty2 = typeMap.GetPropertyMapByDestinationProperty(text);
				MemberInfo fieldOrProperty2 = typeSource.GetFieldOrProperty(propertyMapByDestinationProperty2.DestinationProperty.Name);
				if (propertyMapByDestinationProperty2.CustomExpression == null && propertyMapByDestinationProperty2.SourceMember == null)
				{
					throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resource.srcMemberCannotBeNullFormat, new object[3]
					{
						typeSource.Name,
						typeDestination.Name,
						text
					}));
				}
				propertyMapInfoList.Add(new PropertyMapInfo(propertyMapByDestinationProperty2.CustomExpression, propertyMapByDestinationProperty2.SourceMembers.ToList()));
				string sourceFullName2 = sourceFullName.Substring(sourceFullName.IndexOf(".", StringComparison.OrdinalIgnoreCase) + 1);
				FindDestinationFullName(fieldOrProperty2.GetMemberType(), (propertyMapByDestinationProperty2.CustomExpression == null) ? propertyMapByDestinationProperty2.SourceMember.GetMemberType() : propertyMapByDestinationProperty2.CustomExpression.ReturnType, sourceFullName2, propertyMapInfoList);
			}
		}
	}
}
