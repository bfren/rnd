// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.NumberF_Tests;

public class GetInt64_Tests
{
	public class without_args
	{
		[Fact]
		public void never_returns_out_of_bounds() =>
			Helpers.CheckBounds(() => Rnd.NumberF.GetInt64(), 0L, long.MaxValue);
	}

	public class with_max
	{
		public static TheoryData<long> Max =>
			new() { { Rnd.Int32 } };

		[Theory]
		[MemberData(nameof(Max))]
		public void never_returns_out_of_bounds(long max) =>
			Helpers.CheckBounds(max => Rnd.NumberF.GetInt64(max), 0L, max);
	}

	public class with_min_and_max
	{
		public class when_min_is_more_than_max
		{
			[Fact]
			public void throws_MaximumNotMoreThanMinimumException() =>
				Helpers.MaximumLessThanMinimum(nameof(Rnd.NumberF.GetInt64), () => Rnd.Int64, Rnd.NumberF.GetInt64);
		}

		public class when_min_is_less_than_zero
		{
			[Fact]
			public void throws_MinimumLessThanZeroException() =>
				Helpers.MinimumLessThanZero(nameof(Rnd.NumberF.GetInt64), () => Rnd.Int64 * -1, () => Rnd.Int64, Rnd.NumberF.GetInt64);
		}

		public static TheoryData<long, long> MinAndMax
		{
			get
			{
				var min = Rnd.Int32;
				var max = min + 1 + Rnd.Int32;
				return new() { { min, max } };
			}
		}

		[Theory]
		[MemberData(nameof(MinAndMax))]
		public void never_returns_out_of_bounds(long min, long max) =>
			Helpers.CheckBounds((min, max) => Rnd.NumberF.GetInt64(min, max), min, max);
	}
}
