// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.NumberF_Tests;

public class GetInt64_Tests
{
	public class Without_Args
	{
		[Fact]
		public void Returns_Number_Between_Zero_And_MaxValue() =>
			Helpers.CheckBounds(() => Rnd.NumberF.GetInt64(), 0, long.MaxValue);
	}

	public class With_Max
	{
		public static TheoryData<long> Max =>
			[Rnd.Int64];

		[Theory]
		[MemberData(nameof(Max))]
		public void Returns_Number_Between_Zero_And_Max(long max) =>
			Helpers.CheckBounds(max => Rnd.NumberF.GetInt64(max), 0, max);
	}

	public class With_Min_And_Max
	{
		public class When_Min_Is_More_Than_Max
		{
			[Fact]
			public void Throws_MaximumNotMoreThanMinimumException() =>
				Helpers.MaximumLessThanMinimum(nameof(Rnd.NumberF.GetInt64), () => Rnd.Int64, Rnd.NumberF.GetInt64);
		}

		public class When_Min_Is_Less_Than_Zero
		{
			[Fact]
			public void Throws_MinimumLessThanZeroException() =>
				Helpers.MinimumLessThanZero(nameof(Rnd.NumberF.GetInt64), () => Rnd.Int64 * -1, () => Rnd.Int64, Rnd.NumberF.GetInt64);
		}

		public static TheoryData<long, long> MinAndMax
		{
			get
			{
				var min = Rnd.Int64;
				var max = min + 1 + Rnd.Int64;
				return new() { { min, max } };
			}
		}

		[Theory]
		[MemberData(nameof(MinAndMax))]
		public void Returns_Number_Between_Min_And_Max(long min, long max) =>
			Helpers.CheckBounds((min, max) => Rnd.NumberF.GetInt64(min, max), min, max);
	}
}
