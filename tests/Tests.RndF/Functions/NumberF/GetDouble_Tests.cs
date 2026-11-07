// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.NumberF_Tests;

public class GetDouble_Tests
{
	public class Without_Args
	{
		[Fact]
		public void Returns_Number_Between_Zero_And_MaxValue() =>
			Helpers.CheckBounds(() => Rnd.NumberF.GetDouble(), 0, double.MaxValue);
	}

	public class With_Max
	{
		[Fact]
		public void Returns_Number_Between_Zero_And_Max() =>
			Helpers.CheckBounds(Rnd.NumberF.GetDouble, generateWithMax: Rnd.NumberF.GetDouble);
	}

	public class With_Min_And_Max
	{
		public class When_Min_Is_More_Than_Max
		{
			[Fact]
			public void Throws_MaximumNotMoreThanMinimumException() =>
				Helpers.MaximumLessThanMinimum(nameof(Rnd.NumberF.GetDouble), () => Rnd.Double, Rnd.NumberF.GetDouble);
		}

		public class When_Min_Is_Less_Than_Zero
		{
			[Fact]
			public void Throws_MinimumLessThanZeroException() =>
				Helpers.MinimumLessThanZero(nameof(Rnd.NumberF.GetDouble), () => Rnd.Double * -1, () => Rnd.Double, Rnd.NumberF.GetDouble);
		}

		[Fact]
		public void Returns_Number_Between_Min_And_Max() =>
			Helpers.CheckBounds(Rnd.NumberF.GetDouble, generateWithinBounds: Rnd.NumberF.GetDouble);

		[Theory]
		[InlineData(double.NaN, 1d)]
		[InlineData(0d, double.NaN)]
		[InlineData(0d, double.PositiveInfinity)]
		[InlineData(double.NegativeInfinity, 1d)]
		public void Not_Finite_Throws_ArgumentOutOfRangeException(double min, double max) =>
			Assert.Throws<ArgumentOutOfRangeException>(() => Rnd.NumberF.GetDouble(min, max));

		[Theory]
		[InlineData(float.NaN, 1f)]
		[InlineData(0f, float.PositiveInfinity)]
		public void Single_Not_Finite_Throws_ArgumentOutOfRangeException(float min, float max) =>
			Assert.Throws<ArgumentOutOfRangeException>(() => Rnd.NumberF.GetSingle(min, max));
	}
}
