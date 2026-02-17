// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests;

public class Str_Tests
{
	[Fact]
	public void Returns_String_Of_Length_Six()
	{
		// Arrange

		// Act
		var result = Rnd.Str;

		// Assert
		Assert.Equal(6, result.Length);
	}
}
