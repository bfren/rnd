// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests;

public class UInt128_Tests
{
	[Fact]
	public void Returns_Value_In_Range()
	{
		// Arrange
		var iterations = 1000;
		UInt128 min = 10000;
		UInt128 max = 19999;

		// Act
		var result = Rnd.For(iterations, () => Rnd.UInt128);

		// Assert
		Assert.True(result.All(v => v >= min && v <= max));
	}
}
