// Rnd Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace Rnd.Properties.Resources_Tests;

public class WordList_Tests
{
	[Fact]
	public void Returns_Byte_Array()
	{
		// Arrange

		// Act
		var result = Resources.eff_long_word_list;

		// Assert
		Assert.IsType<byte[]>(result);
	}
}
