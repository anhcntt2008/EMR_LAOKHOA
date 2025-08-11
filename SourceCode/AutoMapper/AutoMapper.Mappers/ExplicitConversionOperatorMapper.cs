using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper.Mappers
{
	public class ExplicitConversionOperatorMapper : IObjectMapper
	{
		public bool IsMatch(TypePair context)
		{
			return GetExplicitConversionOperator(context) != null;
		}

		private static MethodInfo GetExplicitConversionOperator(TypePair context)
		{
			MethodInfo methodInfo = (from mi in context.SourceType.GetDeclaredMethods()
				where mi.IsPublic && mi.IsStatic
				where mi.Name == "op_Explicit"
				select mi).FirstOrDefault((MethodInfo mi) => mi.ReturnType == context.DestinationType);
			MethodInfo declaredMethod = context.DestinationType.GetDeclaredMethod("op_Explicit", new Type[1]
			{
				context.SourceType
			});
			return methodInfo ?? declaredMethod;
		}

		public Expression MapExpression(IConfigurationProvider configurationProvider, ProfileMap profileMap, PropertyMap propertyMap, Expression sourceExpression, Expression destExpression, Expression contextExpression)
		{
			MethodInfo explicitConversionOperator = GetExplicitConversionOperator(new TypePair(sourceExpression.Type, destExpression.Type));
			return Expression.Call(null, explicitConversionOperator, sourceExpression);
		}
	}
}
