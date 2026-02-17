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
		public static TheoryData<ushort> Max =>
			[Rnd.UInt16];

		[Theory]
		[MemberData(nameof(Max))]
		public void Returns_Number_Between_Zero_And_Max(ushort max) =>
			Helpers.CheckBounds(max => Rnd.NumberF.GetUInt16(min: 0, max), (ushort)0, max);
	}

	public class With_Min_And_Max
	{
		public class When_Min_Is_More_Than_Max
		{
			[Fact]
			public void Throws_MaximumNotMoreThanMinimumException() =>
				Helpers.MaximumLessThanMinimum(nameof(Rnd.NumberF.GetUInt16), () => Rnd.UInt16, Rnd.NumberF.GetUInt16);
		}

		public static TheoryData<ushort, ushort> MinAndMax
		{
			get
			{
				var min = Rnd.UInt16;
				var max = (ushort)(min + 1 + Rnd.UInt16);
				return new() { { min, max } };
			}
		}

		[Theory]
		[MemberData(nameof(MinAndMax))]
		public void Returns_Number_Between_Min_And_Max(ushort min, ushort max) =>
			Helpers.CheckBounds((min, max) => Rnd.NumberF.GetUInt16(min, max), min, max);
	}
}
