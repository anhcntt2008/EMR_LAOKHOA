using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper.QueryableExtensions
{
	public interface IExpressionBuilder
	{
		LambdaExpression[] GetMapExpression(Type sourceType, Type destinationType, IDictionary<string, object> parameters, MemberInfo[] membersToExpand);

		LambdaExpression[] CreateMapExpression(ExpressionRequest request, IDictionary<ExpressionRequest, int> typePairCount, LetPropertyMaps letPropertyMaps);

		Expression CreateMapExpression(ExpressionRequest request, Expression instanceParameter, IDictionary<ExpressionRequest, int> typePairCount, LetPropertyMaps letPropertyMaps);
	}
}
