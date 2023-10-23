// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using static RndF.Rnd.StringF.M;

namespace RndF.Rnd_Tests.StringF_Tests;

public class Passphrase_Tests
{
	[Fact]
	public void No_Options_Returns_Eight_Words()
	{
		// Arrange

		// Act
		var result = Rnd.StringF.Passphrase();

		// Assert
		var some = result.AssertSome().Split(Rnd.StringF.DefaultSeparator);
		Assert.Equal(8, some.Length);
	}

	[Fact]
	public void No_Options_Uses_Default_Separator()
	{
		// Arrange

		// Act
		var result = Rnd.StringF.Passphrase();

		// Assert
		var some = result.AssertSome();
		Assert.Contains(Rnd.StringF.DefaultSeparator, some);
	}

	[Fact]
	public void No_Options_Makes_First_Letter_Uppercase()
	{
		// Arrange

		// Act
		var result = Rnd.StringF.Passphrase();

		// Assert
		var some = result.AssertSome();
		Assert.NotEqual(some, some.ToLowerInvariant());
	}

	[Fact]
	public void No_Options_Includes_A_Number()
	{
		// Arrange

		// Act
		var result = Rnd.StringF.Passphrase();

		// Assert
		var some = result.AssertSome();
		Assert.Contains(some, char.IsNumber);
	}

	[Fact]
	public void Null_Word_List_Returns_None_With_WordListCannotBeNullMsg()
	{
		// Arrange

		// Act
		var result = Rnd.StringF.Passphrase(null!, 3, '-', true, true);

		// Assert
		var none = result.AssertNone();
		Assert.IsType<WordListCannotBeNullMsg>(none);
	}

	[Fact]
	public void Empty_Word_List_Returns_None_With_WordListCannotBeEmptyMsg()
	{
		// Arrange
		var empty = Array.Empty<string>();

		// Act
		var result = Rnd.StringF.Passphrase(empty, 3, '-', true, true);

		// Assert
		var none = result.AssertNone();
		Assert.IsType<WordListCannotBeEmptyMsg>(none);
	}

	[Theory]
	[InlineData(-1)]
	[InlineData(0)]
	[InlineData(1)]
	public void NumberOfWords_Less_Than_Two_Returns_None_With_NumberOfWordsMustBeAtLeastTwoMsg(int input)
	{
		// Arrange

		// Act
		var result = Rnd.StringF.Passphrase(input);

		// Assert
		var none = result.AssertNone();
		Assert.IsType<NumberOfWordsMustBeAtLeastTwoMsg>(none);
	}

	[Fact]
	public void NumberOfWords_Higher_Than_Word_List_Count_Returns_None_With_NumberOfWordsCannotBeMoreThanWordListMsg()
	{
		// Arrange

		// Act
		var result = Rnd.StringF.Passphrase(7777);

		// Assert
		var none = result.AssertNone();
		Assert.IsType<NumberOfWordsCannotBeMoreThanWordListMsg>(none);
	}

	[Theory]
	[InlineData(2)]
	[InlineData(4)]
	[InlineData(8)]
	public void Uses_Correct_Number_Of_Words(int input)
	{
		// Arrange
		const char sep = '|';

		// Act
		var result = Rnd.StringF.Passphrase(input, sep, Rnd.Flip, Rnd.Flip);

		// Assert
		var some = result.AssertSome().Split(sep);
		Assert.Equal(input, some.Length);
	}

	[Theory]
	[InlineData('|')]
	[InlineData('^')]
	[InlineData('+')]
	public void Joins_Words_Using_Separator(char input)
	{
		// Arrange
		var length = Rnd.NumberF.GetInt32(min: 3, max: 8);

		// Act
		var result = Rnd.StringF.Passphrase(length, input, Rnd.Flip, Rnd.Flip);

		// Assert
		var some = result.AssertSome();
		Assert.Contains(input, some);
	}

	[Fact]
	public void UpperFirst_True_Makes_First_Letter_Uppercase()
	{
		// Arrange
		var length = Rnd.NumberF.GetInt32(min: 3, max: 8);

		// Act
		var result = Rnd.StringF.Passphrase(length, '-', true, Rnd.Flip);

		// Assert
		var some = result.AssertSome();
		Assert.NotEqual(some, some.ToLowerInvariant());
	}

	[Fact]
	public void UpperFirst_False_Does_Note_Make_First_Letter_Uppercase()
	{
		// Arrange
		var length = Rnd.NumberF.GetInt32(min: 3, max: 8);

		// Act
		var result = Rnd.StringF.Passphrase(length, '-', false, Rnd.Flip);

		// Assert
		var some = result.AssertSome();
		Assert.Equal(some, some.ToLowerInvariant());
	}

	[Fact]
	public void IncludeNumber_True_Includes_A_Number()
	{
		// Arrange
		var length = Rnd.NumberF.GetInt32(min: 3, max: 8);

		// Act
		var result = Rnd.StringF.Passphrase(length, '-', Rnd.Flip, true);

		// Assert
		var some = result.AssertSome();
		Assert.Contains(some, char.IsNumber);
	}

	[Fact]
	public void IncludeNumber_False_Does_Note_Include_A_Number()
	{
		// Arrange
		var length = Rnd.NumberF.GetInt32(min: 3, max: 8);

		// Act
		var result = Rnd.StringF.Passphrase(length, '-', Rnd.Flip, false);

		// Assert
		var some = result.AssertSome();
		Assert.DoesNotContain(some, char.IsNumber);
	}

	[Fact]
	public void Does_Not_Repeat_Words()
	{
		// Arrange
		var length = 7774;
		var sep = '|';

		// Act
		var result = Rnd.StringF.Passphrase(length, sep, false, false);

		// Assert
		var some = result.AssertSome().Split(sep);
		Assert.Equal(length, some.Distinct().Count());
	}

	[Fact]
	public void Returns_Different_Phrase_Each_Time()
	{
		// Arrange
		var iterations = 10000;
		var length = 2;
		var phrases = new List<string>();

		// Act
		for (var i = 0; i < iterations; i++)
		{
			phrases.Add(Rnd.StringF.Passphrase(length).UnsafeUnwrap());
		}

		var result = phrases.Distinct().Count();

		// Assert
		Assert.InRange(result, phrases.Count - 1, phrases.Count);
	}
}
