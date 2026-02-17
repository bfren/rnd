// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests;

public class Guid_Tests
{
	[Fact]
	public void Returns_Unique_Guids()
	{
		// Arrange
		var iterations = 100;

		// Act
		var result = Rnd.For(iterations, () => Rnd.Guid)
			.Distinct().Count();

		// Assert
		Assert.Equal(iterations, result);
	}
}
