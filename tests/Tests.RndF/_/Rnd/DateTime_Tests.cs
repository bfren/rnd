// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests;

public class DateTime_Tests
{
	[Fact]
	public void Returns_Valid_DateTime()
	{
		// Arrange

		// Act
		var result = Rnd.DateTime;

		// Assert
		Assert.True(result >= DateTime.MinValue);
		Assert.True(result <= DateTime.MaxValue);
	}
}
