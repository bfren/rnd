// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.NumberF_Tests;

public class GetUInt64_Tests
{
	public class Without_Args
	{
		[Fact]
		public void Returns_Number_Between_Zero_And_MaxValue() =>
			Helpers.CheckBounds(() => Rnd.NumberF.GetUInt64(), 0UL, ulong.MaxValue);
	}

	public class With_Max
	{
		public static TheoryData<ulong> Max =>
			[Rnd.UInt64];

		[Theory]
		[MemberData(nameof(Max))]
		public void Returns_Number_Between_Zero_And_Max(ulong max) =>
			Helpers.CheckBounds(max => Rnd.NumberF.GetUInt64(max), 0UL, max);
	}

	public class With_Min_And_Max
	{
		public class When_Min_Is_More_Than_Max
		{
			[Fact]
			public void Throws_MaximumNotMoreThanMinimumException() =>
				Helpers.MaximumLessThanMinimum(nameof(Rnd.NumberF.GetUInt64), () => Rnd.UInt64, Rnd.NumberF.GetUInt64);
		}

		public static TheoryData<ulong, ulong> MinAndMax
		{
			get
			{
				var min = Rnd.UInt64;
				var max = min + 1 + Rnd.UInt64;
				return new() { { min, max } };
			}
		}

		[Theory]
		[MemberData(nameof(MinAndMax))]
		public void Returns_Number_Between_Min_And_Max(ulong min, ulong max) =>
			Helpers.CheckBounds((min, max) => Rnd.NumberF.GetUInt64(min, max), min, max);
	}
}
