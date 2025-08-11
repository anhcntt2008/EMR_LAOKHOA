using AutoMapper.Execution;
using AutoMapper.Internal;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace AutoMapper.Mappers
{
	public class FromDynamicMapper : IObjectMapper
	{
		private static readonly MethodInfo MapMethodInfo = typeof(FromDynamicMapper).GetDeclaredMethod("Map");

		private static TDestination Map<TSource, TDestination>(TSource source, TDestination destination, ResolutionContext context, ProfileMap profileMap)
		{
			object obj = destination;
			foreach (MemberInfo publicWriteAccessor in profileMap.CreateTypeDetails(typeof(TDestination)).PublicWriteAccessors)
			{
				object dynamically;
				try
				{
					dynamically = GetDynamically(publicWriteAccessor.Name, source);
				}
				catch (RuntimeBinderException)
				{
					continue;
				}
				object value = context.MapMember(publicWriteAccessor, dynamically, obj);
				publicWriteAccessor.SetMemberValue(obj, value);
			}
			return (TDestination)obj;
		}

		private static object GetDynamically(string memberName, object target)
		{
			CallSite<Func<CallSite, object, object>> callSite = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.None, memberName, null, new CSharpArgumentInfo[1]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
			}));
			return callSite.Target(callSite, target);
		}

		public bool IsMatch(TypePair context)
		{
			if (context.SourceType.IsDynamic())
			{
				return !context.DestinationType.IsDynamic();
			}
			return false;
		}

		public Expression MapExpression(IConfigurationProvider configurationProvider, ProfileMap profileMap, PropertyMap propertyMap, Expression sourceExpression, Expression destExpression, Expression contextExpression)
		{
			return Expression.Call(null, MapMethodInfo.MakeGenericMethod(sourceExpression.Type, destExpression.Type), sourceExpression, ExpressionFactory.ToType(Expression.Coalesce(ExpressionFactory.ToObject(destExpression), DelegateFactory.GenerateConstructorExpression(destExpression.Type)), destExpression.Type), contextExpression, Expression.Constant(profileMap));
		}
	}
}
