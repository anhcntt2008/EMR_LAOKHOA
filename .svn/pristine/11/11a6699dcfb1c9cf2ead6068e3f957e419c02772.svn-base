using AutoMapper.XpressionMapper.Extensions;
using System.Linq.Expressions;

namespace AutoMapper.XpressionMapper.ArgumentMappers
{
	internal class LambdaArgumentMapper : ArgumentMapper
	{
		public override Expression MappedArgumentExpression
		{
			get
			{
				LambdaExpression lambdaExpression = (LambdaExpression)base.Argument;
				return Expression.Lambda(ExpressionVisitor.Visit(lambdaExpression.Body), lambdaExpression.GetDestinationParameterExpressions(ExpressionVisitor.InfoDictionary, ExpressionVisitor.TypeMappings));
			}
		}

		public LambdaArgumentMapper(XpressionMapperVisitor expressionVisitor, Expression argument)
			: base(expressionVisitor, argument)
		{
		}
	}
}
