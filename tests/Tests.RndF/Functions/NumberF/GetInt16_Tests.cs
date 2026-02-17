// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.NumberF_Tests;

public class GetInt16_Tests
{
	public class Without_Args
	{
		[Fact]
		public void Returns_Number_Between_Zero_And_MaxValue() =>
			Helpers.CheckBounds(() => Rnd.NumberF.GetInt16(), (short)0, short.MaxValue);
	}

	public class With_Max
	{
		[Fact]
		public void Returns_Number_Between_Zero_And_Max() =>
			Helpers.CheckBounds(Rnd.NumberF.GetInt16, generateWithMax: Rnd.NumberF.GetInt16);
	}

	public class With_Min_And_Max
	{
		public class When_Min_Is_More_Than_Max
		{
			[Fact]
			public void Throws_MaximumNotMoreThanMinimumException() =>
				Helpers.MaximumLessThanMinimum(nameof(Rnd.NumberF.GetInt16), () => Rnd.Int16, Rnd.NumberF.GetInt16);
		}

		public class When_Min_Is_Less_Than_Zero
		{
			[Fact]
			public void Throws_MinimumLessThanZeroException() =>
				Helpers.MinimumLessThanZero(nameof(Rnd.NumberF.GetInt16), () => (short)(Rnd.Int16 * -1), () => Rnd.Int16, Rnd.NumberF.GetInt16);
		}

		[Fact]
		public void Returns_Number_Between_Min_And_Max() =>
			Helpers.CheckBounds(Rnd.NumberF.GetInt16, generateWithinBounds: Rnd.NumberF.GetInt16);
	}
}
