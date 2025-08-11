using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper.QueryableExtensions.Impl
{
	public class MemberGetterExpressionResultConverter : IExpressionResultConverter
	{
		public ExpressionResolutionResult GetExpressionResolutionResult(ExpressionResolutionResult expressionResolutionResult, PropertyMap propertyMap, LetPropertyMaps letPropertyMaps)
		{
			return ExpressionResolutionResult(expressionResolutionResult, propertyMap.SourceMembers);
		}

		public ExpressionResolutionResult GetExpressionResolutionResult(ExpressionResolutionResult expressionResolutionResult, ConstructorParameterMap propertyMap)
		{
			return ExpressionResolutionResult(expressionResolutionResult, propertyMap.SourceMembers);
		}

		private static ExpressionResolutionResult ExpressionResolutionResult(ExpressionResolutionResult expressionResolutionResult, IEnumerable<MemberInfo> sourceMembers)
		{
			return sourceMembers.Aggregate(expressionResolutionResult, ExpressionResolutionResult);
		}

		private static ExpressionResolutionResult ExpressionResolutionResult(ExpressionResolutionResult expressionResolutionResult, MemberInfo getter)
		{
			MemberExpression memberExpression = Expression.MakeMemberAccess(expressionResolutionResult.ResolutionExpression, getter);
			return new ExpressionResolutionResult(memberExpression, memberExpression.Type);
		}

		public bool CanGetExpressionResolutionResult(ExpressionResolutionResult expressionResolutionResult, PropertyMap propertyMap)
		{
			return propertyMap.SourceMembers.Any();
		}

		public bool CanGetExpressionResolutionResult(ExpressionResolutionResult expressionResolutionResult, ConstructorParameterMap propertyMap)
		{
			return propertyMap.SourceMembers.Any();
		}
	}
}
