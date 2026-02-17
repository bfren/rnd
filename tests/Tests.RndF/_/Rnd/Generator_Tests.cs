// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests;

public class Generator_Tests
{
	[Fact]
	public void Returns_DefaultRng()
	{
		// Arrange

		// Act
		var result = Rnd.Generator;

		// Assert
		Assert.IsType<DefaultRng>(result);
	}
}
