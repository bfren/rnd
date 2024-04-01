// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.StringF_Tests;

public class LongWordList_Tests
{
	[Fact]
	public void returns_correct_list()
	{
		// Arrange
		var longList = Properties.Resources.eff_long_word_list;
		var list = from w in longList.Split(',')
				   select w.Trim();

		// Act
		var result = Rnd.StringF.LongWordList.Value;

		// Assert
		Assert.Equal(list.ToArray(), result);
	}
}
