// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System.Text;

namespace RndF.Rnd_Tests.StringF_Tests;

public class LongWordList_Tests
{
	[Fact]
	public void Returns_Long_List()
	{
		// Arrange
		var longList = Properties.Resources.eff_long_word_list;
		var words = Encoding.ASCII.GetString(longList);
		var list = from w in words.Split(Environment.NewLine)
				   where !string.IsNullOrEmpty(w)
				   select w;

		// Act
		var result = Rnd.StringF.LongWordList.Value;

		// Assert
		Assert.Equal(list, result);
	}
}
