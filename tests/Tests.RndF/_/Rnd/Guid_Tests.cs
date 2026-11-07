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

	[Fact]
	public void Returns_Random_Version_4_Guids()
	{
		// Act
		var result = Rnd.For(100, () => Rnd.Guid);

		// Assert: the version is the first character of the third group (time-based version 7 GUIDs fail this)
		Assert.All(result, g => Assert.Equal('4', g.ToString()[14]));
	}
}
