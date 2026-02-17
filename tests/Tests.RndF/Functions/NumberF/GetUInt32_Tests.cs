// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.NumberF_Tests;

public class GetUInt32_Tests
{
	public class Without_Args
	{
		[Fact]
		public void Returns_Number_Between_Zero_And_MaxValue() =>
			Helpers.CheckBounds(() => Rnd.NumberF.GetUInt32(), 0u, uint.MaxValue);
	}

	public class With_Max
	{
		[Fact]
		public void Returns_Number_Between_Zero_And_Max() =>
			Helpers.CheckBounds(Rnd.NumberF.GetUInt32, generateWithMax: Rnd.NumberF.GetUInt32);
	}

	public class With_Min_And_Max
	{
		public class When_Min_Is_More_Than_Max
		{
			[Fact]
			public void Throws_MaximumNotMoreThanMinimumException() =>
				Helpers.MaximumLessThanMinimum(nameof(Rnd.NumberF.GetUInt32), () => Rnd.UInt32, Rnd.NumberF.GetUInt32);
		}

		[Fact]
		public void Returns_Number_Between_Min_And_Max() =>
			Helpers.CheckBounds(Rnd.NumberF.GetUInt32, generateWithinBounds: Rnd.NumberF.GetUInt32);
	}
}
