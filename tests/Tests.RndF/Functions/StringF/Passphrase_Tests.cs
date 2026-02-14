// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System.Globalization;
using RndF.Exceptions;

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
		var some = result.Split(Rnd.StringF.DefaultSeparator);
		Assert.Equal(8, some.Length);
	}

	[Fact]
	public void No_Options_Uses_Default_Separator()
	{
		// Arrange

		// Act
		var result = Rnd.StringF.Passphrase();

		// Assert
		Assert.Contains(Rnd.StringF.DefaultSeparator, result);
	}

	[Fact]
	public void No_Options_Makes_First_Letter_Uppercase()
	{
		// Arrange

		// Act
		var result = Rnd.StringF.Passphrase();

		// Assert
		Assert.NotEqual(result, result.ToLowerInvariant());
	}

	[Fact]
	public void No_Options_Includes_A_Number()
	{
		// Arrange

		// Act
		var result = Rnd.StringF.Passphrase();

		// Assert
		Assert.Contains(result, char.IsNumber);
	}

	[Fact]
	public void Null_Word_List_Returns_None_With_WordListCannotBeNullMsg()
	{
		// Arrange

		// Act
		static void act() => Rnd.StringF.Passphrase(null!, 3, '-', true, true);

		// Assert
		var ex = Assert.Throws<InvalidPassphraseException>(act);
		Assert.Equal(Rnd.StringF.WordListCannotBeNull, ex.Message);
	}

	[Fact]
	public void Empty_Word_List_Returns_None_With_WordListCannotBeEmptyMsg()
	{
		// Arrange
		var empty = Array.Empty<string>();

		// Act
		void act() => Rnd.StringF.Passphrase(empty, 3, '-', true, true);

		// Assert
		var ex = Assert.Throws<InvalidPassphraseException>(act);
		Assert.Equal(Rnd.StringF.WordListCannotBeEmpty, ex.Message);
	}

	[Theory]
	[InlineData(-1)]
	[InlineData(0)]
	[InlineData(1)]
	public void NumberOfWords_Less_Than_Two_Returns_None_With_NumberOfWordsMustBeAtLeastTwoMsg(int input)
	{
		// Arrange

		// Act
		void act() => Rnd.StringF.Passphrase(input);

		// Assert
		var ex = Assert.Throws<InvalidPassphraseException>(act);
		Assert.Equal(string.Format(CultureInfo.InvariantCulture, Rnd.StringF.PassphraseNotLongEnough, Rnd.StringF.MinimumPassphraseWords), ex.Message);
	}

	[Fact]
	public void NumberOfWords_Higher_Than_Word_List_Count_Returns_None_With_NumberOfWordsCannotBeMoreThanWordListMsg()
	{
		// Arrange
		var maximum = Rnd.StringF.LongWordList.Value.Length;
		const int tooMany = 7777;

		// Act
		static void act() => Rnd.StringF.Passphrase(tooMany);

		// Assert
		var ex = Assert.Throws<InvalidPassphraseException>(act);
		Assert.Equal(string.Format(CultureInfo.InvariantCulture, Rnd.StringF.PassphraseTooLong, maximum), ex.Message);
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
		var some = result.Split(sep);
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
		Assert.Contains(input, result);
	}

	[Fact]
	public void UpperFirst_True_Makes_First_Letter_Uppercase()
	{
		// Arrange
		var length = Rnd.NumberF.GetInt32(min: 3, max: 8);

		// Act
		var result = Rnd.StringF.Passphrase(length, '-', true, Rnd.Flip);

		// Assert
		Assert.NotEqual(result, result.ToLowerInvariant());
	}

	[Fact]
	public void UpperFirst_False_Does_Note_Make_First_Letter_Uppercase()
	{
		// Arrange
		var length = Rnd.NumberF.GetInt32(min: 3, max: 8);

		// Act
		var result = Rnd.StringF.Passphrase(length, '-', false, Rnd.Flip);

		// Assert
		Assert.Equal(result, result.ToLowerInvariant());
	}

	[Fact]
	public void IncludeNumber_True_Includes_A_Number()
	{
		// Arrange
		var length = Rnd.NumberF.GetInt32(min: 3, max: 8);

		// Act
		var result = Rnd.StringF.Passphrase(length, '-', Rnd.Flip, true);

		// Assert
		Assert.Contains(result, char.IsNumber);
	}

	[Fact]
	public void IncludeNumber_False_Does_Note_Include_A_Number()
	{
		// Arrange
		var length = Rnd.NumberF.GetInt32(min: 3, max: 8);

		// Act
		var result = Rnd.StringF.Passphrase(length, '-', Rnd.Flip, false);

		// Assert
		Assert.DoesNotContain(result, char.IsNumber);
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
		var some = result.Split(sep);
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
			phrases.Add(Rnd.StringF.Passphrase(length));
		}

		var result = phrases.Distinct().Count();

		// Assert
		Assert.InRange(result, phrases.Count - 1, phrases.Count);
	}

	[Fact]
	public void IncludeNumber_Adds_Number_To_Every_Fifth_Word()
	{
		// Arrange - use 10 words so indices 0 and 5 get numbers (i % 5 == 0)
		var wordList = new[] { "alpha", "bravo", "charlie", "delta", "echo", "foxtrot", "golf", "hotel", "india", "juliet" };

		// Act
		var result = Rnd.StringF.Passphrase(wordList, 10, '-', false, true);
		var words = result.Split('-');

		// Assert - exactly 2 words should contain a digit (indices 0 and 5 before shuffle)
		var wordsWithNumbers = words.Count(w => w.Any(char.IsDigit));
		Assert.Equal(2, wordsWithNumbers);
	}

	[Fact]
	public void IncludeNumber_With_Five_Words_Adds_Number_To_One_Word()
	{
		// Arrange - only index 0 gets a number (i % 5 == 0)
		var wordList = new[] { "alpha", "bravo", "charlie", "delta", "echo", "foxtrot", "golf", "hotel" };

		// Act
		var result = Rnd.StringF.Passphrase(wordList, 5, '-', false, true);
		var words = result.Split('-');

		// Assert - exactly 1 word should contain a digit
		var wordsWithNumbers = words.Count(w => w.Any(char.IsDigit));
		Assert.Equal(1, wordsWithNumbers);
	}

	[Fact]
	public void Custom_Word_List_Uses_Only_Provided_Words()
	{
		// Arrange
		var wordList = new[] { "cat", "dog", "fox", "bat", "owl" };

		// Act
		var result = Rnd.StringF.Passphrase(wordList, 5, '-', false, false);
		var words = result.Split('-');

		// Assert
		Assert.All(words, w => Assert.Contains(w, wordList));
	}

	[Fact]
	public void NumberOfWords_Equal_To_Word_List_Length_Uses_All_Words()
	{
		// Arrange
		var wordList = new[] { "cat", "dog", "fox", "bat", "owl" };

		// Act
		var result = Rnd.StringF.Passphrase(wordList, 5, '-', false, false);
		var words = result.Split('-');

		// Assert
		Assert.Equal(5, words.Length);
		Assert.Equal(5, words.Distinct().Count());
	}
}
