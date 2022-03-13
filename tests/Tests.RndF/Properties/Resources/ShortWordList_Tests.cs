// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Properties.Resources_Tests;

public class ShortWordList_Tests
{
	[Fact]
	public void Returns_Byte_Array()
	{
		// Arrange

		// Act
		var result = Resources.eff_short_word_list;

		// Assert
		Assert.IsType<byte[]>(result);
	}
}
