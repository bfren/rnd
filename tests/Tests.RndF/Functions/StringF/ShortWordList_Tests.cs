// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.StringF_Tests;

public class ShortWordList_Tests
{
	[Fact]
	public void returns_correct_list()
	{
		// Arrange
		var shortList = Properties.Resources.eff_short_word_list;
		var list = from w in shortList.Split(',')
				   select w.Trim();

		// Act
		var result = Rnd.StringF.ShortWordList.Value;

		// Assert
		Assert.Equal(list, result);
	}
}
