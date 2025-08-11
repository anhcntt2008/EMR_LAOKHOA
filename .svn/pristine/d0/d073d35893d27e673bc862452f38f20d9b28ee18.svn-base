using System.Linq.Expressions;

namespace AutoMapper.XpressionMapper.ArgumentMappers
{
	internal abstract class ArgumentMapper
	{
		protected Expression Argument
		{
			get;
		}

		protected virtual XpressionMapperVisitor ExpressionVisitor
		{
			get;
		}

		public abstract Expression MappedArgumentExpression
		{
			get;
		}

		protected ArgumentMapper(XpressionMapperVisitor expressionVisitor, Expression argument)
		{
			ExpressionVisitor = expressionVisitor;
			Argument = argument;
		}

		public static ArgumentMapper Create(XpressionMapperVisitor expressionVisitor, Expression argument)
		{
			switch (argument.NodeType)
			{
			case ExpressionType.Lambda:
				return new LambdaArgumentMapper(expressionVisitor, argument);
			case ExpressionType.Quote:
				return new QuoteArgumentMapper(expressionVisitor, argument);
			default:
				return new DefaultArgumentMapper(expressionVisitor, argument);
			}
		}
	}
}
