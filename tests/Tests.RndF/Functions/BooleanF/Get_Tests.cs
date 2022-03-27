// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.BooleanF_Tests;

public class Get_Tests
{
	[Fact]
	public void Returns_True_Or_False()
	{
		// Arrange
		var iterations = 100;
		var results = new List<bool>();

		// Act
		for (var i = 0; i < iterations; i++)
		{
			results.Add(Rnd.BooleanF.Get());
		}

		// Assert
		Assert.Equal(2, results.Distinct().Count());
	}
}
