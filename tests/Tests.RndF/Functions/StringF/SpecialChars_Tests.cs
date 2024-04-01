// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.StringF_Tests;

public class SpecialChars_Tests
{
	[Fact]
	public void returns_correct_chars()
	{
		// Arrange
		var expected = Helpers.Chars.Special;

		// Act
		var result = Rnd.StringF.SpecialChars;

		// Assert
		Assert.Equal(expected, result);
	}
}
