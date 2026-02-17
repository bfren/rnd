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
		public static TheoryData<uint> Max =>
			[Rnd.UInt32];

		[Theory]
		[MemberData(nameof(Max))]
		public void Returns_Number_Between_Zero_And_Max(uint max) =>
			Helpers.CheckBounds(max => Rnd.NumberF.GetUInt32(max), 0u, max);
	}

	public class With_Min_And_Max
	{
		public class When_Min_Is_More_Than_Max
		{
			[Fact]
			public void Throws_MaximumNotMoreThanMinimumException() =>
				Helpers.MaximumLessThanMinimum(nameof(Rnd.NumberF.GetUInt32), () => Rnd.UInt32, Rnd.NumberF.GetUInt32);
		}

		public static TheoryData<uint, uint> MinAndMax
		{
			get
			{
				var min = Rnd.UInt32;
				var max = min + 1 + Rnd.UInt32;
				return new() { { min, max } };
			}
		}

		[Theory]
		[MemberData(nameof(MinAndMax))]
		public void Returns_Number_Between_Min_And_Max(uint min, uint max) =>
			Helpers.CheckBounds((min, max) => Rnd.NumberF.GetUInt32(min, max), min, max);
	}
}
