// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.NumberF_Tests;

public class GetDouble_Tests
{
	public class without_args
	{
		[Fact]
		public void never_returns_out_of_bounds() =>
			Helpers.CheckBounds(() => Rnd.NumberF.GetDouble(), 0d, double.MaxValue);
	}

	public class with_max
	{
		public static TheoryData<double> Max =>
			new() { { Rnd.Dbl } };

		[Theory]
		[MemberData(nameof(Max))]
		public void never_returns_out_of_bounds(double max) =>
			Helpers.CheckBounds(max => Rnd.NumberF.GetDouble(max), 0d, max);
	}

	public class with_min_and_max
	{
		public class when_min_is_more_than_max
		{
			[Fact]
			public void throws_MaximumNotMoreThanMinimumException() =>
				Helpers.MaximumLessThanMinimum(nameof(Rnd.NumberF.GetDouble), () => Rnd.Dbl, Rnd.NumberF.GetDouble);
		}

		public class when_min_is_less_than_zero
		{
			[Fact]
			public void throws_MinimumLessThanZeroException() =>
				Helpers.MinimumLessThanZero(nameof(Rnd.NumberF.GetDouble), () => Rnd.Dbl * -1, () => Rnd.Dbl, Rnd.NumberF.GetDouble);
		}

		public static TheoryData<double, double> MinAndMax
		{
			get
			{
				var min = Rnd.Dbl;
				var max = min + 1 + Rnd.Dbl;
				return new() { { min, max } };
			}
		}

		[Theory]
		[MemberData(nameof(MinAndMax))]
		public void never_returns_out_of_bounds(double min, double max) =>
			Helpers.CheckBounds((min, max) => Rnd.NumberF.GetDouble(min, max), min, max);

	}
}
