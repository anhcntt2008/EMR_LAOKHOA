using AutoMapper.Execution;
using AutoMapper.Internal;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace AutoMapper.Mappers
{
	public class ToDynamicMapper : IObjectMapper
	{
		private static readonly MethodInfo MapMethodInfo = typeof(ToDynamicMapper).GetDeclaredMethod("Map");

		public static TDestination Map<TSource, TDestination>(TSource source, TDestination destination, ResolutionContext context, ProfileMap profileMap)
		{
			foreach (MemberInfo publicReadAccessor in profileMap.CreateTypeDetails(typeof(TSource)).PublicReadAccessors)
			{
				object memberValue;
				try
				{
					memberValue = publicReadAccessor.GetMemberValue(source);
				}
				catch (RuntimeBinderException)
				{
					continue;
				}
				object value = context.MapMember(publicReadAccessor, memberValue);
				SetDynamically(publicReadAccessor.Name, destination, value);
			}
			return destination;
		}

		private static void SetDynamically(string memberName, object target, object value)
		{
			CallSite<Func<CallSite, object, object, object>> callSite = CallSite<Func<CallSite, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.SetMember(CSharpBinderFlags.None, memberName, null, new CSharpArgumentInfo[2]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
			}));
			callSite.Target(callSite, target, value);
		}

		public bool IsMatch(TypePair context)
		{
			if (context.DestinationType.IsDynamic())
			{
				return !context.SourceType.IsDynamic();
			}
			return false;
		}

		public Expression MapExpression(IConfigurationProvider configurationProvider, ProfileMap profileMap, PropertyMap propertyMap, Expression sourceExpression, Expression destExpression, Expression contextExpression)
		{
			return Expression.Call(null, MapMethodInfo.MakeGenericMethod(sourceExpression.Type, destExpression.Type), sourceExpression, ExpressionFactory.ToType(Expression.Coalesce(ExpressionFactory.ToObject(destExpression), DelegateFactory.GenerateConstructorExpression(destExpression.Type)), destExpression.Type), contextExpression, Expression.Constant(profileMap));
		}
	}
}
