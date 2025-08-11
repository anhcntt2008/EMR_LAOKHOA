using System;
using System.Linq.Expressions;

namespace AutoMapper.QueryableExtensions.Impl
{
	public class MemberResolverExpressionResultConverter : IExpressionResultConverter
	{
		public ExpressionResolutionResult GetExpressionResolutionResult(ExpressionResolutionResult expressionResolutionResult, PropertyMap propertyMap, LetPropertyMaps letPropertyMaps)
		{
			Expression subQueryMarker;
			if ((subQueryMarker = letPropertyMaps.GetSubQueryMarker()) != null)
			{
				return new ExpressionResolutionResult(subQueryMarker, subQueryMarker.Type);
			}
			return ExpressionResolutionResult(expressionResolutionResult, propertyMap.CustomExpression);
		}

		private static ExpressionResolutionResult ExpressionResolutionResult(ExpressionResolutionResult expressionResolutionResult, LambdaExpression lambdaExpression)
		{
			Expression expression = lambdaExpression.ReplaceParameters(expressionResolutionResult.ResolutionExpression);
			Type type = expression.Type;
			return new ExpressionResolutionResult(expression, type);
		}

		public ExpressionResolutionResult GetExpressionResolutionResult(ExpressionResolutionResult expressionResolutionResult, ConstructorParameterMap propertyMap)
		{
			return ExpressionResolutionResult(expressionResolutionResult, null);
		}

		public bool CanGetExpressionResolutionResult(ExpressionResolutionResult expressionResolutionResult, PropertyMap propertyMap)
		{
			return propertyMap.CustomExpression != null;
		}

		public bool CanGetExpressionResolutionResult(ExpressionResolutionResult expressionResolutionResult, ConstructorParameterMap propertyMap)
		{
			return false;
		}
	}
}
