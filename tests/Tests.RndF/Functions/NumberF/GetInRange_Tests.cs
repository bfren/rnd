// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.NumberF_Tests;

public class GetInRange_Tests
{
	[Theory]
	[InlineData("Int32")] // 64-bit threshold path
	[InlineData("Int128")] // 128-bit mask path
	[InlineData("UInt128")]
	public void Every_Value_Is_Equally_Likely(string type)
	{
		// Arrange
		var counts = new int[10];
		Func<int> draw = type switch
		{
			"Int32" =>
				() => Rnd.NumberF.GetInt32(0, 9),

			"Int128" =>
				() => (int)Rnd.NumberF.GetInt128(0, 9),

			_ =>
				() => (int)Rnd.NumberF.GetUInt128(0, 9)
		};

		// Act
		for (var i = 0; i < 200_000; i++)
		{
			counts[draw()]++;
		}

		// Assert: expect ~20,000 each (standard deviation ~134); the old rounding code gave ~11,000 for 0 and 9
		Assert.All(counts, c => Assert.InRange(c, 19_000, 21_000));
	}

	[Fact]
	public void UInt64_Uses_All_Bits()
	{
		// Act
		var result = Rnd.For(10_000, Rnd.NumberF.GetUInt64);

		// Assert: expect ~10 multiples of 1024; the old double-based code gave ~8,300
		Assert.InRange(result.Count(v => v % 1024 == 0), 0, 100);
	}

	[Fact]
	public void Int128_Uses_All_Bits()
	{
		// Act
		var result = Rnd.For(10_000, () => Rnd.NumberF.GetInt128());

		// Assert: the old double-based code only returned multiples of 2^60
		Assert.InRange(result.Count(v => v % ((Int128)1 << 60) == 0), 0, 1);
	}

	[Fact]
	public void Full_UInt64_Range_Can_Return_Both_Halves()
	{
		// Act
		var result = Rnd.For(1_000, () => Rnd.NumberF.GetUInt64(0, ulong.MaxValue));

		// Assert
		Assert.Contains(result, v => v > long.MaxValue);
		Assert.Contains(result, v => v <= long.MaxValue);
	}
}
