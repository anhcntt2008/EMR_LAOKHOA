namespace AutoMapper
{
	public struct ConditionParameters<TSource, TDestination, TMember>
	{
		public TSource Source
		{
			get;
		}

		public TDestination Destination
		{
			get;
		}

		public TMember SourceMember
		{
			get;
		}

		public TMember DestinationMember
		{
			get;
		}

		public ResolutionContext Context
		{
			get;
		}

		public ConditionParameters(TSource source, TDestination destination, TMember sourceMember, TMember destinationMember, ResolutionContext context)
		{
			Source = source;
			Destination = destination;
			SourceMember = sourceMember;
			DestinationMember = destinationMember;
			Context = context;
		}
	}
}
