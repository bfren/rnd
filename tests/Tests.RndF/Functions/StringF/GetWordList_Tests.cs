// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.StringF_Tests;

public class GetWordList_Tests
{
	public class input_is_null_or_empty
	{
		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData(" ")]
		public void returns_empty_array(string? input)
		{
			// Arrange

			// Act
			var result = Rnd.StringF.GetWordList(input!);

			// Assert
			Assert.Empty(result);
		}
	}

	[Fact]
	public void splits_words_by_comma()
	{
		// Arrange
		var w0 = Rnd.Str;
		var w1 = Rnd.Str;
		var w2 = Rnd.Str;
		var input = $"{w0},{w1},{w2}";

		// Act
		var result = Rnd.StringF.GetWordList(input);

		// Assert
		Assert.Collection(result,
			w => Assert.Equal(w0, w),
			w => Assert.Equal(w1, w),
			w => Assert.Equal(w2, w)
		);
	}

	[Fact]
	public void removes_empty_entries()
	{
		// Arrange
		var w0 = Rnd.Str;
		var w1 = Rnd.Str;
		var w2 = Rnd.Str;
		var input = $",{w0},,{w1},,,{w2},";

		// Act
		var result = Rnd.StringF.GetWordList(input);

		// Assert
		Assert.Collection(result,
			w => Assert.Equal(w0, w),
			w => Assert.Equal(w1, w),
			w => Assert.Equal(w2, w)
		);
	}

	[Fact]
	public void trims_each_word()
	{
		// Arrange
		var w0 = Rnd.Str;
		var w1 = Rnd.Str;
		var w2 = Rnd.Str;
		var input = $"  {w0} ,{w1}{Environment.NewLine}, {w2} ";

		// Act
		var result = Rnd.StringF.GetWordList(input);

		// Assert
		Assert.Collection(result,
			w => Assert.Equal(w0, w),
			w => Assert.Equal(w1, w),
			w => Assert.Equal(w2, w)
		);
	}
}
