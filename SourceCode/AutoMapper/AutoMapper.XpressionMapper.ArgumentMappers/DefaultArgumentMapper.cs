using System.Linq.Expressions;

namespace AutoMapper.XpressionMapper.ArgumentMappers
{
	internal class DefaultArgumentMapper : ArgumentMapper
	{
		public override Expression MappedArgumentExpression => ExpressionVisitor.Visit(base.Argument);

		public DefaultArgumentMapper(XpressionMapperVisitor expressionVisitor, Expression argument)
			: base(expressionVisitor, argument)
		{
		}
	}
}
