// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System.Text;

namespace RndF.Rnd_Tests.StringF_Tests;

public class GetWordList_Tests
{
	[Fact]
	public void Empty_Input_Returns_Empty_Array()
	{
		// Arrange
		var input = Array.Empty<byte>();

		// Act
		var result = Rnd.StringF.GetWordList(input);

		// Assert
		Assert.Empty(result);
		Assert.IsType<string[]>(result);
	}

	[Fact]
	public void Returns_Array_Of_Words()
	{
		// Arrange
		var w0 = Rnd.Str;
		var w1 = Rnd.Str;
		var w2 = Rnd.Str;
		var words = w0 + Environment.NewLine + w1 + Environment.NewLine + w2;
		var bytes = Encoding.ASCII.GetBytes(words);

		// Act
		var result = Rnd.StringF.GetWordList(bytes);

		// Assert
		Assert.Collection(result,
			x => Assert.Equal(w0, x),
			x => Assert.Equal(w1, x),
			x => Assert.Equal(w2, x)
		);
	}
}
