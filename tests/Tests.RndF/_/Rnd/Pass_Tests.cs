// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests;

public class Pass_Tests
{
	[Fact]
	public void Returns_String()
	{
		// Arrange

		// Act
		var result = Rnd.Pass;

		// Assert
		Assert.NotNull(result);
		Assert.NotEmpty(result);
	}
}
