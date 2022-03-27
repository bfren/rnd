// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Properties.Resources_Tests;

public class LongWordList_Tests
{
	[Fact]
	public void Returns_String()
	{
		// Arrange

		// Act
		var result = Resources.eff_long_word_list;

		// Assert
		Assert.IsType<string>(result);
	}
}
