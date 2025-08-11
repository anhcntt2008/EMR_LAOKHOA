using AutoMapper.XpressionMapper.Extensions;
using System.Linq.Expressions;

namespace AutoMapper.XpressionMapper.ArgumentMappers
{
	internal class QuoteArgumentMapper : ArgumentMapper
	{
		public override Expression MappedArgumentExpression
		{
			get
			{
				LambdaExpression lambdaExpression = (LambdaExpression)((UnaryExpression)base.Argument).Operand;
				return Expression.Quote(Expression.Lambda(ExpressionVisitor.Visit(lambdaExpression.Body), lambdaExpression.GetDestinationParameterExpressions(ExpressionVisitor.InfoDictionary, ExpressionVisitor.TypeMappings)));
			}
		}

		public QuoteArgumentMapper(XpressionMapperVisitor expressionVisitor, Expression argument)
			: base(expressionVisitor, argument)
		{
		}
	}
}
