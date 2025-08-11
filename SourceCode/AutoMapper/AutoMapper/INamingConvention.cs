using System.Text.RegularExpressions;

namespace AutoMapper
{
	public interface INamingConvention
	{
		Regex SplittingExpression
		{
			get;
		}

		string SeparatorCharacter
		{
			get;
		}

		string ReplaceValue(Match match);
	}
}
