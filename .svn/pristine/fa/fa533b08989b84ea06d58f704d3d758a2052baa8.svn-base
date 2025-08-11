using System.Linq.Expressions;

namespace AutoMapper.QueryableExtensions.Impl
{
	public class MemberAccessQueryMapperVisitor : ExpressionVisitor
	{
		private readonly ExpressionVisitor _rootVisitor;

		private readonly IConfigurationProvider _config;

		public MemberAccessQueryMapperVisitor(ExpressionVisitor rootVisitor, IConfigurationProvider config)
		{
			_rootVisitor = rootVisitor;
			_config = config;
		}

		protected override Expression VisitMember(MemberExpression node)
		{
			Expression expression = _rootVisitor.Visit(node.Expression);
			if (expression != null)
			{
				PropertyMap propertyMap = _config.GetPropertyMap(node.Member, expression.Type);
				return Expression.MakeMemberAccess(expression, propertyMap.DestinationProperty);
			}
			return node;
		}
	}
}
