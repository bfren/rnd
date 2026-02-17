// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests;

public class Time_Tests
{
	[Fact]
	public void Returns_Valid_Time()
	{
		// Arrange

		// Act
		var result = Rnd.Time;

		// Assert
		Assert.True(result >= TimeOnly.MinValue);
		Assert.True(result <= TimeOnly.MaxValue);
	}
}
