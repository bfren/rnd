// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.NumberF_Tests;

public class GetInt16_Tests
{
	public class without_args
	{
		[Fact]
		public void never_returns_out_of_bounds() =>
			Helpers.CheckBounds(() => Rnd.NumberF.GetInt16(), short.MinValue, short.MaxValue);
	}

	public class with_max
	{
		public static TheoryData<short> Max =>
			[Rnd.Int16];

		[Theory]
		[MemberData(nameof(Max))]
		public void never_returns_out_of_bounds(short max) =>
			Helpers.CheckBounds(max => Rnd.NumberF.GetInt16(max), short.MinValue, max);
	}

	public class with_min_and_max
	{
		public class when_min_is_more_than_max
		{
			[Fact]
			public void throws_MaximumNotMoreThanMinimumException() =>
				Helpers.MaximumLessThanMinimum(nameof(Rnd.NumberF.GetInt16), () => Rnd.Int16, Rnd.NumberF.GetInt16);
		}

		public class when_min_is_less_than_zero
		{
			[Fact]
			public void throws_MinimumLessThanZeroException() =>
				Helpers.MinimumLessThanZero(nameof(Rnd.NumberF.GetInt16), () => (short)(Rnd.Int16 * -1), () => Rnd.Int16, Rnd.NumberF.GetInt16);
		}

		public static TheoryData<short, short> MinAndMax
		{
			get
			{
				var min = Rnd.Int16;
				var max = (short)(min + 1 + Rnd.Int16);
				return new() { { min, max } };
			}
		}

		[Theory]
		[MemberData(nameof(MinAndMax))]
		public void never_returns_out_of_bounds(short min, short max) =>
			Helpers.CheckBounds((min, max) => Rnd.NumberF.GetInt16(min, max), min, max);
	}
}
