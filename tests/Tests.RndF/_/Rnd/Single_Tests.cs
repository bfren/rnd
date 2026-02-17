// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests;

public class Single_Tests
{
	[Fact]
	public void Returns_Value_In_Range()
	{
		// Arrange
		var iterations = 1000;
		const float min = 10000;
		const float max = 19999;

		// Act
		var result = Rnd.For(iterations, () => Rnd.Single);

		// Assert
		Assert.True(result.All(v => v is >= min and <= max));
	}

	[Fact]
	public void Flt_Returns_Same_Range()
	{
		// Arrange
		var iterations = 1000;
		const float min = 10000;
		const float max = 19999;

		// Act
		var result = Rnd.For(iterations, () => Rnd.Flt);

		// Assert
		Assert.True(result.All(v => v is >= min and <= max));
	}
}
