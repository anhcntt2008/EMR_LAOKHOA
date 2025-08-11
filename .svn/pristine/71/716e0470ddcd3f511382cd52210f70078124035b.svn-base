namespace AutoMapper
{
	public static class HashCodeCombiner
	{
		public static int Combine<T1, T2>(T1 obj1, T2 obj2)
		{
			return CombineCodes(obj1.GetHashCode(), obj2.GetHashCode());
		}

		public static int CombineCodes(int h1, int h2)
		{
			return ((h1 << 5) + h1) ^ h2;
		}
	}
}
