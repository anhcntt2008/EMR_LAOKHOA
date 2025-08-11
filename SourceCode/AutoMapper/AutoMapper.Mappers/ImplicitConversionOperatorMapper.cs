using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper.Mappers
{
	public class ImplicitConversionOperatorMapper : IObjectMapper
	{
		public bool IsMatch(TypePair context)
		{
			return GetImplicitConversionOperator(context) != null;
		}

		private static MethodInfo GetImplicitConversionOperator(TypePair context)
		{
			Type destinationType = context.DestinationType;
			return context.SourceType.GetDeclaredMethods().FirstOrDefault((MethodInfo mi) => mi.IsPublic && mi.IsStatic && mi.Name == "op_Implicit" && mi.ReturnType == destinationType) ?? destinationType.GetDeclaredMethod("op_Implicit", new Type[1]
			{
				context.SourceType
			});
		}

		public Expression MapExpression(IConfigurationProvider configurationProvider, ProfileMap profileMap, PropertyMap propertyMap, Expression sourceExpression, Expression destExpression, Expression contextExpression)
		{
			MethodInfo implicitConversionOperator = GetImplicitConversionOperator(new TypePair(sourceExpression.Type, destExpression.Type));
			return Expression.Call(null, implicitConversionOperator, sourceExpression);
		}
	}
}
