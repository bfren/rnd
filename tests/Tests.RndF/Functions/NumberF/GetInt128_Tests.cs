// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.NumberF_Tests;

public class GetInt128_Tests
{
	public class Without_Args
	{
		[Fact]
		public void Returns_Number_Between_Zero_And_MaxValue() =>
			Helpers.CheckBounds(() => Rnd.NumberF.GetInt128(), (Int128)0, Int128.MaxValue);
	}

	public class With_Max
	{
		public static TheoryData<Int128> Max =>
			[Rnd.Int128];

		[Theory]
		[MemberData(nameof(Max))]
		public void Returns_Number_Between_Zero_And_Max(Int128 max) =>
			Helpers.CheckBounds(max => Rnd.NumberF.GetInt128(max), 0, max);
	}

	public class With_Min_And_Max
	{
		public class When_Min_Is_More_Than_Max
		{
			[Fact]
			public void Throws_MaximumNotMoreThanMinimumException() =>
				Helpers.MaximumLessThanMinimum(nameof(Rnd.NumberF.GetInt128), () => Rnd.Int128, Rnd.NumberF.GetInt128);
		}

		public class When_Min_Is_Less_Than_Zero
		{
			[Fact]
			public void Throws_MinimumLessThanZeroException() =>
				Helpers.MinimumLessThanZero(nameof(Rnd.NumberF.GetInt128), () => Rnd.Int128 * -1, () => Rnd.Int128, Rnd.NumberF.GetInt128);
		}

		public static TheoryData<Int128, Int128> MinAndMax
		{
			get
			{
				var min = Rnd.Int128;
				var max = min + 1 + Rnd.Int128;
				return new() { { min, max } };
			}
		}

		[Theory]
		[MemberData(nameof(MinAndMax))]
		public void Returns_Number_Between_Min_And_Max(Int128 min, Int128 max) =>
			Helpers.CheckBounds((min, max) => Rnd.NumberF.GetInt128(min, max), min, max);
	}
}
