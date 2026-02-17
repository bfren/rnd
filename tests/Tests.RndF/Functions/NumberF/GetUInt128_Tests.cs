// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.NumberF_Tests;

public class GetUInt128_Tests
{
	public class Without_Args
	{
		[Fact]
		public void Returns_Number_Between_Zero_And_MaxValue() =>
			Helpers.CheckBounds(() => Rnd.NumberF.GetUInt128(), 0UL, UInt128.MaxValue);
	}

	public class With_Max
	{
		public static TheoryData<UInt128> Max =>
			[Rnd.UInt128];

		[Theory]
		[MemberData(nameof(Max))]
		public void Returns_Number_Between_Zero_And_Max(UInt128 max) =>
			Helpers.CheckBounds(max => Rnd.NumberF.GetUInt128(max), 0UL, max);
	}

	public class With_Min_And_Max
	{
		public class When_Min_Is_More_Than_Max
		{
			[Fact]
			public void Throws_MaximumNotMoreThanMinimumException() =>
				Helpers.MaximumLessThanMinimum(nameof(Rnd.NumberF.GetUInt128), () => Rnd.UInt128, Rnd.NumberF.GetUInt128);
		}

		public static TheoryData<UInt128, UInt128> MinAndMax
		{
			get
			{
				var min = Rnd.UInt128;
				var max = min + 1 + Rnd.UInt128;
				return new() { { min, max } };
			}
		}

		[Theory]
		[MemberData(nameof(MinAndMax))]
		public void Returns_Number_Between_Min_And_Max(UInt128 min, UInt128 max) =>
			Helpers.CheckBounds((min, max) => Rnd.NumberF.GetUInt128(min, max), min, max);
	}
}
