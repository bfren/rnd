// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests;

public class Date_Tests
{
	[Fact]
	public void Returns_Valid_Date()
	{
		// Arrange

		// Act
		var result = Rnd.Date;

		// Assert
		Assert.True(result >= DateOnly.MinValue);
		Assert.True(result <= DateOnly.MaxValue);
	}
}
