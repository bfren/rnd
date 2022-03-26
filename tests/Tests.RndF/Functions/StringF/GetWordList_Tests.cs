// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.StringF_Tests;

public class GetWordList_Tests
{
	[Fact]
	public void Empty_Input_Returns_Empty_Array()
	{
		// Arrange
		var input = string.Empty;

		// Act
		var result = Rnd.StringF.GetWordList(input);

		// Assert
		Assert.Empty(result);
		Assert.IsType<string[]>(result);
	}

	[Fact]
	public void Trims_Each_Word()
	{
		// Arrange
		var w0 = Rnd.Str + " ";
		var w1 = Rnd.Str + Environment.NewLine;
		var w2 = " " + Rnd.Str;
		var words = $"{w0},{w1},{w2}";

		// Act
		var result = Rnd.StringF.GetWordList(words);

		// Assert
		Assert.Collection(result,
			x => Assert.Equal(w0.Trim(), x),
			x => Assert.Equal(w1.Trim(), x),
			x => Assert.Equal(w2.Trim(), x)
		);
	}

	[Fact]
	public void Removes_Empty_Entries()
	{
		// Arrange
		var w0 = Rnd.Str;
		var w1 = Rnd.Str;
		var w2 = Rnd.Str;
		var words = $"{w0},,{w1}, ,{w2}";

		// Act
		var result = Rnd.StringF.GetWordList(words);

		// Assert
		Assert.Collection(result,
			x => Assert.Equal(w0.Trim(), x),
			x => Assert.Equal(w1.Trim(), x),
			x => Assert.Equal(w2.Trim(), x)
		);
	}

	[Fact]
	public void Returns_Array_Of_Words()
	{
		// Arrange
		var w0 = Rnd.Str;
		var w1 = Rnd.Str;
		var w2 = Rnd.Str;
		var words = $"{w0},{w1},{w2}";

		// Act
		var result = Rnd.StringF.GetWordList(words);

		// Assert
		Assert.Collection(result,
			x => Assert.Equal(w0, x),
			x => Assert.Equal(w1, x),
			x => Assert.Equal(w2, x)
		);
	}
}
