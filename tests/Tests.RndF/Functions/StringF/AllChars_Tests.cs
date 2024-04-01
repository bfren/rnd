// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.StringF_Tests;

public class AllChars_Tests
{
	[Fact]
	public void returns_correct_chars()
	{
		// Arrange
		char[] expected = [
			.. Helpers.Chars.Numbers,
			.. Helpers.Chars.Lowercase,
			.. Helpers.Chars.Uppercase,
			.. Helpers.Chars.Special
		];

		// Act
		var result = Rnd.StringF.AllChars;

		// Assert
		Assert.Equal(expected, result);
	}
}
