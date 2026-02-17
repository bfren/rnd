// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.NumberF_Tests;

public class GetInt32_Tests
{
	public class Without_Args
	{
		[Fact]
		public void Returns_Number_Between_Zero_And_MaxValue() =>
			Helpers.CheckBounds(() => Rnd.NumberF.GetInt32(), 0, int.MaxValue);
	}

	public class With_Max
	{
		public static TheoryData<int> Max =>
			[Rnd.Int32];

		[Theory]
		[MemberData(nameof(Max))]
		public void Returns_Number_Between_Zero_And_Max(int max) =>
			Helpers.CheckBounds(max => Rnd.NumberF.GetInt32(max), 0, max);
	}

	public class With_Min_And_Max
	{
		public class When_Min_Is_More_Than_Max
		{
			[Fact]
			public void Throws_MaximumNotMoreThanMinimumException() =>
				Helpers.MaximumLessThanMinimum(nameof(Rnd.NumberF.GetInt32), () => Rnd.Int32, Rnd.NumberF.GetInt32);
		}

		public class When_Min_Is_Less_Than_Zero
		{
			[Fact]
			public void Throws_MinimumLessThanZeroException() =>
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
		public void Returns_Number_Between_Min_And_Max(int min, int max) =>
			Helpers.CheckBounds((min, max) => Rnd.NumberF.GetInt32(min, max), min, max);
	}
}
