// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.NumberF_Tests;

public class GetInt32_Tests
{
	public class without_args
	{
		[Fact]
		public void never_returns_out_of_bounds() =>
			Helpers.CheckBounds(() => Rnd.NumberF.GetInt32(), 0, int.MaxValue);
	}

	public class with_max
	{
		public static TheoryData<int> Max =>
			[Rnd.Int32];

		[Theory]
		[MemberData(nameof(Max))]
		public void never_returns_out_of_bounds(int max) =>
			Helpers.CheckBounds(max => Rnd.NumberF.GetInt32(max), 0, max);
	}

	public class with_min_and_max
	{
		public class when_min_is_more_than_max
		{
			[Fact]
			public void throws_MaximumNotMoreThanMinimumException() =>
				Helpers.MaximumLessThanMinimum(nameof(Rnd.NumberF.GetInt32), () => Rnd.Int32, Rnd.NumberF.GetInt32);
		}

		public class when_min_is_less_than_zero
		{
			[Fact]
			public void throws_MinimumLessThanZeroException() =>
				Helpers.MinimumLessThanZero(nameof(Rnd.NumberF.GetInt32), () => Rnd.Int32 * -1, () => Rnd.Int32, Rnd.NumberF.GetInt32);
		}

		public static TheoryData<int, int> MinAndMax
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
		public void never_returns_out_of_bounds(int min, int max) =>
			Helpers.CheckBounds((min, max) => Rnd.NumberF.GetInt32(min, max), min, max);
	}
}
