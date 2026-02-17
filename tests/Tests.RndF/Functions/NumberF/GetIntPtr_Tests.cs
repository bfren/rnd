// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.NumberF_Tests;

public class GetIntPtr_Tests
{
	public class Without_Args
	{
		[Fact]
		public void Returns_Number_Between_Zero_And_MaxValue() =>
			Helpers.CheckBounds(() => Rnd.NumberF.GetIntPtr(), 0, nint.MaxValue);
	}

	public class With_Max
	{
		[Fact]
		public void Returns_Number_Between_Zero_And_Max() =>
			Helpers.CheckBounds(Rnd.NumberF.GetIntPtr, generateWithMax: Rnd.NumberF.GetIntPtr);
	}

	public class With_Min_And_Max
	{
		public class When_Min_Is_More_Than_Max
		{
			[Fact]
			public void Throws_MaximumNotMoreThanMinimumException() =>
				Helpers.MaximumLessThanMinimum(nameof(Rnd.NumberF.GetIntPtr), () => Rnd.IntPtr, Rnd.NumberF.GetIntPtr);
		}

		public class When_Min_Is_Less_Than_Zero
		{
			[Fact]
			public void Throws_MinimumLessThanZeroException() =>
				Helpers.MinimumLessThanZero(nameof(Rnd.NumberF.GetIntPtr), () => Rnd.IntPtr * -1, () => Rnd.IntPtr, Rnd.NumberF.GetIntPtr);
		}

		[Fact]
		public void Returns_Number_Between_Min_And_Max() =>
			Helpers.CheckBounds(Rnd.NumberF.GetIntPtr, generateWithinBounds: Rnd.NumberF.GetIntPtr);
	}
}
