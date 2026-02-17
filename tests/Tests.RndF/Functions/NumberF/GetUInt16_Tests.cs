// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.NumberF_Tests;

public class GetUInt16_Tests
{
	public class Without_Args
	{
		[Fact]
		public void Returns_Number_Between_Zero_And_MaxValue() =>
			Helpers.CheckBounds(() => Rnd.NumberF.GetUInt16(), (ushort)0, ushort.MaxValue);
	}

	public class With_Max
	{
		[Fact]
		public void Returns_Number_Between_Zero_And_Max() =>
			Helpers.CheckBounds(Rnd.NumberF.GetUInt16, generateWithMax: Rnd.NumberF.GetUInt16);
	}

	public class With_Min_And_Max
	{
		public class When_Min_Is_More_Than_Max
		{
			[Fact]
			public void Throws_MaximumNotMoreThanMinimumException() =>
				Helpers.MaximumLessThanMinimum(nameof(Rnd.NumberF.GetUInt16), () => Rnd.UInt16, Rnd.NumberF.GetUInt16);
		}

		[Fact]
		public void Returns_Number_Between_Min_And_Max() =>
			Helpers.CheckBounds(Rnd.NumberF.GetUInt16, generateWithinBounds: Rnd.NumberF.GetUInt16);
	}
}
