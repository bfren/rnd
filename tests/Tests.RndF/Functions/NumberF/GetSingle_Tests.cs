// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.NumberF_Tests;

public class GetSingle_Tests
{
	public class without_args
	{
		[Fact]
		public void never_returns_out_of_bounds() =>
			Helpers.CheckBounds(() => Rnd.NumberF.GetSingle(), 0f, float.MaxValue);

		[Fact]
		public void returns_random_number() =>
			Helpers.EnsureRandom(Rnd.NumberF.GetSingle, iterations: 1000);
	}

	public class with_max
	{
		public static TheoryData<float> Max =>
			new() { { Rnd.Flt } };

		[Theory]
		[MemberData(nameof(Max))]
		public void never_returns_out_of_bounds(float max) =>
			Helpers.CheckBounds(max => Rnd.NumberF.GetSingle(max), 0f, max);

		[Theory]
		[MemberData(nameof(Max))]
		public void returns_random_number(float max) =>
			Helpers.EnsureRandom(() => Rnd.NumberF.GetSingle(max), iterations: 1000);
	}

	public class with_min_and_max
	{
		public class when_min_is_more_than_max
		{
			[Fact]
			public void throws_MaximumNotMoreThanMinimumException() =>
				Helpers.MaximumLessThanMinimum(nameof(Rnd.NumberF.GetSingle), () => Rnd.Flt, Rnd.NumberF.GetSingle);
		}

		public class when_min_is_less_than_zero
		{
			[Fact]
			public void throws_MinimumLessThanZeroException() =>
				Helpers.MinimumLessThanZero(nameof(Rnd.NumberF.GetSingle), () => Rnd.Flt * -1, () => Rnd.Flt, Rnd.NumberF.GetSingle);
		}

		public static TheoryData<float, float> MinAndMax
		{
			get
			{
				var min = Rnd.Flt;
				var max = min + 1 + Rnd.Flt;
				return new() { { min, max } };
			}
		}

		[Theory]
		[MemberData(nameof(MinAndMax))]
		public void never_returns_out_of_bounds(float min, float max) =>
			Helpers.CheckBounds((min, max) => Rnd.NumberF.GetSingle(min, max), min, max);

		[Theory]
		[MemberData(nameof(MinAndMax))]
		public void returns_random_number(float min, float max) =>
			Helpers.EnsureRandom(() => Rnd.NumberF.GetSingle(min, max), iterations: 1000);
	}
}
