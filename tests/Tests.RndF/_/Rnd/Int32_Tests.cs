// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests;

public class Int32_Tests
{
	[Fact]
	public void Returns_Value_In_Range()
	{
		// Arrange
		var iterations = 1000;
		const int min = 10000;
		const int max = 19999;

		// Act
		var result = Rnd.For(iterations, () => Rnd.Int32);

		// Assert
		Assert.True(result.All(v => v is >= min and <= max));
	}

	[Fact]
	public void Int_Returns_Same_Range()
	{
		// Arrange
		var iterations = 1000;
		const int min = 10000;
		const int max = 19999;

		// Act
		var result = Rnd.For(iterations, () => Rnd.Int);

		// Assert
		Assert.True(result.All(v => v is >= min and <= max));
	}
}
