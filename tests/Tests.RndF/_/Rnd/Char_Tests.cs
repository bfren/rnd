// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests;

public class Char_Tests
{
	[Fact]
	public void char_returns_char_in_valid_range()
	{
		// Arrange
		var iterations = 1000;
		const char min = (char)48;
		const char max = (char)122;

		// Act
		var result = Rnd.For(iterations, () => Rnd.Char);

		// Assert
		Assert.True(result.All(c => c is >= min and <= max));
	}
}
