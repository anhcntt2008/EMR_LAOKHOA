namespace AutoMapper
{
	public interface IMemberValueResolver<in TSource, in TDestination, in TSourceMember, TDestMember>
	{
		TDestMember Resolve(TSource source, TDestination destination, TSourceMember sourceMember, TDestMember destMember, ResolutionContext context);
	}
}
