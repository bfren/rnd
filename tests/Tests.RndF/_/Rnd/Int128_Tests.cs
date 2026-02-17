// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests;

public class Int128_Tests
{
	[Fact]
	public void Returns_Value_In_Range()
	{
		// Arrange
		var iterations = 1000;
		Int128 min = 10000;
		Int128 max = 19999;

		// Act
		var result = Rnd.For(iterations, () => Rnd.Int128);

		// Assert
		Assert.True(result.All(v => v >= min && v <= max));
	}
}
