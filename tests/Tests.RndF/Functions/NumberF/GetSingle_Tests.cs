// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.NumberF_Tests;

public class GetSingle_Tests
{
	public class Without_Args
	{
		[Fact]
		public void Returns_Number_Between_Zero_And_MaxValue() =>
			Helpers.CheckBounds(() => Rnd.NumberF.GetSingle(), 0, float.MaxValue);
	}

	public class With_Max
	{
		public static TheoryData<float> Max =>
			[Rnd.Flt];

		[Theory]
		[MemberData(nameof(Max))]
		public void Returns_Number_Between_Zero_And_Max(float max) =>
			Helpers.CheckBounds(max => Rnd.NumberF.GetSingle(max), 0, max);
	}

	public class With_Min_And_Max
	{
		public class When_Min_Is_More_Than_Max
		{
			[Fact]
			public void Throws_MaximumNotMoreThanMinimumException() =>
				Helpers.MaximumLessThanMinimum(nameof(Rnd.NumberF.GetSingle), () => Rnd.Flt, Rnd.NumberF.GetSingle);
		}

		public class When_Min_Is_Less_Than_Zero
		{
			[Fact]
			public void Throws_MinimumLessThanZeroException() =>
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
		public void Returns_Number_Between_Min_And_Max(float min, float max) =>
			Helpers.CheckBounds((min, max) => Rnd.NumberF.GetSingle(min, max), min, max);
	}
}
