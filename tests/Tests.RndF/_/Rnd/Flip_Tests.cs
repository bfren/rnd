// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests;

public class Flip_Tests
{
	[Fact]
	public void Returns_Boolean()
	{
		// Arrange
		var iterations = 100;

		// Act
		var result = Rnd.For(iterations, () => Rnd.Flip);

		// Assert
		Assert.All(result, x => Assert.IsType<bool>(x));
	}
}
