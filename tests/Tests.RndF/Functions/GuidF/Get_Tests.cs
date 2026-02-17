// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.GuidF_Tests;

public class get_Tests
{
	[Fact]
	public void returns_random_guid()
	{
		// Arrange
		var iterations = 10000;

		// Act
		var result = Rnd.For(iterations, Rnd.GuidF.Get)
			.Distinct().Count();

		// Assert
		Assert.Equal(iterations, result);
	}
}
