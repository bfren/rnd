// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System.Text;

namespace RndF.Rnd_Tests.StringF_Tests;

public class ShortWordList_Tests
{
	[Fact]
	public void Returns_Short_List()
	{
		// Arrange
		var shortList = Properties.Resources.eff_short_word_list;
		var words = Encoding.ASCII.GetString(shortList);
		var list = from w in words.Split(Environment.NewLine)
				   where !string.IsNullOrEmpty(w)
				   select w;

		// Act
		var result = Rnd.StringF.ShortWordList.Value;

		// Assert
		Assert.Equal(list, result);
	}
}
