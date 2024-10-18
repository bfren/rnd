// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.NumberF_Tests;

public class GetUInt32_Tests
{
	public class without_args
	{
		[Fact]
		public void never_returns_out_of_bounds() =>
			Helpers.CheckBounds(() => Rnd.NumberF.GetUInt32(), 0u, uint.MaxValue);
	}

	public class with_max
	{
		public static TheoryData<uint> Max =>
			new() { { Rnd.UInt } };

		[Theory]
		[MemberData(nameof(Max))]
		public void never_returns_out_of_bounds(uint max) =>
			Helpers.CheckBounds(max => Rnd.NumberF.GetUInt32(max), 0u, max);
	}

	public class with_min_and_max
	{
		public class when_min_is_more_than_max
		{
			[Fact]
			public void throws_MaximumNotMoreThanMinimumException() =>
				Helpers.MaximumLessThanMinimum(nameof(Rnd.NumberF.GetUInt32), () => Rnd.UInt, Rnd.NumberF.GetUInt32);
		}

		public static TheoryData<uint, uint> MinAndMax
		{
			get
			{
				var min = Rnd.UInt;
				var max = min + 1 + Rnd.UInt;
				return new() { { min, max } };
			}
		}

		[Theory]
		[MemberData(nameof(MinAndMax))]
		public void never_returns_out_of_bounds(uint min, uint max) =>
			Helpers.CheckBounds((min, max) => Rnd.NumberF.GetUInt32(min, max), min, max);
	}
}
