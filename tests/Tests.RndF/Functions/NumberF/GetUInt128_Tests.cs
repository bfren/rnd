// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.NumberF_Tests;

public class GetUInt128_Tests
{
	public class without_args
	{
		[Fact]
		public void never_returns_out_of_bounds() =>
			Helpers.CheckBounds(() => Rnd.NumberF.GetUInt128(), 0UL, UInt128.MaxValue);
	}

	public class with_max
	{
		public static TheoryData<UInt128> Max =>
			new() { { Rnd.UInt64 } };

		[Theory]
		[MemberData(nameof(Max))]
		public void never_returns_out_of_bounds(UInt128 max) =>
			Helpers.CheckBounds(max => Rnd.NumberF.GetUInt128(max), 0UL, max);
	}

	public class with_min_and_max
	{
		public class when_min_is_more_than_max
		{
			[Fact]
			public void throws_MaximumNotMoreThanMinimumException() =>
				Helpers.MaximumLessThanMinimum(nameof(Rnd.NumberF.GetUInt128), () => Rnd.UInt128, Rnd.NumberF.GetUInt128);
		}

		public static TheoryData<UInt128, UInt128> MinAndMax
		{
			get
			{
				var min = Rnd.UInt64;
				var max = min + 1 + Rnd.UInt64;
				return new() { { min, max } };
			}
		}

		[Theory]
		[MemberData(nameof(MinAndMax))]
		public void never_returns_out_of_bounds(UInt128 min, UInt128 max) =>
			Helpers.CheckBounds((min, max) => Rnd.NumberF.GetUInt128(min, max), min, max);
	}
}
