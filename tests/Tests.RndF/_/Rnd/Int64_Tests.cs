// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests;

public class Int64_Tests
{
	[Fact]
	public void Returns_Value_In_Range()
	{
		// Arrange
		var iterations = 1000;
		const long min = 10000;
		const long max = 19999;

		// Act
		var result = Rnd.For(iterations, () => Rnd.Int64);

		// Assert
		Assert.True(result.All(v => v is >= min and <= max));
	}

	[Fact]
	public void Lng_Returns_Same_Range()
	{
		// Arrange
		var iterations = 1000;
		const long min = 10000;
		const long max = 19999;

		// Act
		var result = Rnd.For(iterations, () => Rnd.Lng);

		// Assert
		Assert.True(result.All(v => v is >= min and <= max));
	}
}
