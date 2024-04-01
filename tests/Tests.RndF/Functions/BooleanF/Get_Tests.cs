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
		var values = new List<bool>();

		// Act
		for (var i = 0; i < iterations; i++)
		{
			values.Add(Rnd.BooleanF.Get());
		}

		var result = values.Distinct().Count();

		// Assert
		Assert.Equal(2, result);
	}
}
