// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.BooleanF_Tests;

public class Get_Tests
{
	[Fact]
	public void returns_only_true_or_false()
	{
		// Arrange
		var iterations = 100;

		// Act
		var result = Rnd.For(iterations, Rnd.BooleanF.Get)
			.Distinct().Count();

		// Assert
		Assert.Equal(2, result);
	}
}
