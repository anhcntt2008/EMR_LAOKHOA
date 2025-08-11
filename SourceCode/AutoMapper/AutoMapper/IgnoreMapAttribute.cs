using System;

namespace AutoMapper
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class IgnoreMapAttribute : Attribute
	{
	}
}
