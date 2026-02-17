// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System.Globalization;
using RndF.Exceptions;

namespace RndF.Rnd_Tests.StringF_Tests;

public class Passphrase_Tests
{
	public class Without_Args
	{
		[Fact]
		public void Returns_Eight_Words()
		{
			// Arrange

			// Act
			var result = Rnd.StringF.Passphrase();

			// Assert
			var some = result.Split(Rnd.StringF.DefaultSeparator);
			Assert.Equal(8, some.Length);
		}

		[Fact]
		public void Uses_Default_Separator()
		{
			// Arrange

			// Act
			var result = Rnd.StringF.Passphrase();

			// Assert
			Assert.Contains(Rnd.StringF.DefaultSeparator, result);
		}

		[Fact]
		public void Makes_First_Letter_Uppercase()
		{
			// Arrange

			// Act
			var result = Rnd.StringF.Passphrase();

			// Assert
			Assert.NotEqual(result, result.ToLowerInvariant());
		}

		[Fact]
		public void Includes_A_Number()
		{
			// Arrange

			// Act
			var result = Rnd.StringF.Passphrase();

			// Assert
			Assert.Contains(result, char.IsNumber);
		}
	}

	public class With_NumberOfWords_Only
	{
		[Fact]
		public void Returns_Correct_Number_Of_Words()
		{
			// Arrange
			var numberOfWords = Rnd.NumberF.GetInt32(10, 20);

			// Act
			var result = Rnd.StringF.Passphrase(numberOfWords);

			// Assert
			var some = result.Split(Rnd.StringF.DefaultSeparator);
			Assert.Equal(numberOfWords, some.Length);
		}

		[Fact]
		public void Uses_Default_Separator()
		{
			// Arrange
			var numberOfWords = Rnd.NumberF.GetInt32(10, 20);

			// Act
			var result = Rnd.StringF.Passphrase(numberOfWords);

			// Assert
			Assert.Contains(Rnd.StringF.DefaultSeparator, result);
		}

		[Fact]
		public void Makes_First_Letter_Uppercase()
		{
			// Arrange
			var numberOfWords = Rnd.NumberF.GetInt32(10, 20);

			// Act
			var result = Rnd.StringF.Passphrase(numberOfWords);

			// Assert
			Assert.NotEqual(result, result.ToLowerInvariant());
		}

		[Fact]
		public void Includes_A_Number()
		{
			// Arrange
			var numberOfWords = Rnd.NumberF.GetInt32(10, 20);

			// Act
			var result = Rnd.StringF.Passphrase(numberOfWords);

			// Assert
			Assert.Contains(result, char.IsNumber);
		}

		[Fact]
		public void Returns_Different_Phrase_Each_Time()
		{
			// Arrange
			var iterations = 10000;
			var numberOfWords = 2;
			var phrases = new List<string>();

			// Act
			var result = Rnd.For(iterations, () => Rnd.StringF.Passphrase(numberOfWords))
				.Distinct().Count();

			// Assert
			Assert.InRange(result, iterations - 1, iterations);
		}

		[Theory]
		[InlineData(-1)]
		[InlineData(0)]
		[InlineData(1)]
		public void Less_Than_Two_Returns_None_With_NumberOfWordsMustBeAtLeastTwoMsg(int input)
		{
			// Arrange

			// Act
			var result = Record.Exception(() => Rnd.StringF.Passphrase(input));

			// Assert
			var ex = Assert.IsType<InvalidPassphraseException>(result);
			Assert.Equal(string.Format(CultureInfo.InvariantCulture, Rnd.StringF.PassphraseNotLongEnough, Rnd.StringF.MinimumPassphraseWords), ex.Message);
		}

		[Fact]
		public void Higher_Than_Word_List_Count_Returns_None_With_NumberOfWordsCannotBeMoreThanWordListMsg()
		{
			// Arrange
			var maximum = Rnd.StringF.LongWordList.Value.Length;
			const int tooMany = 7777;

			// Act
			var result = Record.Exception(() => Rnd.StringF.Passphrase(tooMany));

			// Assert
			var ex = Assert.IsType<InvalidPassphraseException>(result);
			Assert.Equal(string.Format(CultureInfo.InvariantCulture, Rnd.StringF.PassphraseTooLong, maximum), ex.Message);
		}
	}
	public class With_Word_List
	{
		[Fact]
		public void Null_Returns_None_With_WordListCannotBeNullMsg()
		{
			// Arrange

			// Act
			var result = Record.Exception(() => Rnd.StringF.Passphrase(null!, 3, '-', Rnd.Flip, Rnd.Flip));

			// Assert
			var ex = Assert.IsType<InvalidPassphraseException>(result);
			Assert.Equal(Rnd.StringF.WordListCannotBeNull, ex.Message);
		}

		[Fact]
		public void Empty_Returns_None_With_WordListCannotBeEmptyMsg()
		{
			// Arrange
			var empty = Array.Empty<string>();

			// Act
			var result = Record.Exception(() => Rnd.StringF.Passphrase(empty, 3, '-', Rnd.Flip, Rnd.Flip));

			// Assert
			var ex = Assert.IsType<InvalidPassphraseException>(result);
			Assert.Equal(Rnd.StringF.WordListCannotBeEmpty, ex.Message);
		}

		[Fact]
		public void IncludeNumber_Adds_Number_To_Every_Fifth_Word()
		{
			// Arrange - use 10 words so indices 0 and 5 get numbers (i % 5 == 0)
			var wordList = Rnd.For(10, () => Rnd.Str);

			// Act
			var result = Rnd.StringF.Passphrase(wordList, 10, '-', Rnd.Flip, true).Split('-');

			// Assert - exactly 2 words should contain a digit (indices 0 and 5 before shuffle)
			var wordsWithNumbers = result.Count(w => w.Any(char.IsDigit));
			Assert.Equal(2, wordsWithNumbers);
		}

		[Fact]
		public void IncludeNumber_With_Five_Words_Adds_Number_To_One_Word()
		{
			// Arrange - only index 0 gets a number (i % 5 == 0)
			var index0 = Rnd.Str;
			var wordList = Rnd.For(5, () => Rnd.Str).Prepend(index0).ToArray();

			// Act
			var result = Rnd.StringF.Passphrase(wordList, 5, '-', Rnd.Flip, true).Split('-');

			// Assert - exactly 1 word should contain a digit
			var wordsWithNumbers = result.Count(w => w.Any(char.IsDigit));
			Assert.Equal(1, wordsWithNumbers);
		}

		[Fact]
		public void Custom_Word_List_Uses_Only_Provided_Words()
		{
			// Arrange
			var wordList = Rnd.For(10, () => Rnd.Str);

			// Act
			var result = Rnd.StringF.Passphrase(wordList, 5, '-', false, false).Split('-');

			// Assert
			Assert.All(result, w => Assert.Contains(w, wordList));
		}

		[Fact]
		public void NumberOfWords_Equal_To_Word_List_Length_Uses_All_Words()
		{
			// Arrange
			var numberOfWords = Rnd.NumberF.GetInt32(5, 10);
			var wordList = Rnd.For(numberOfWords, () => Rnd.Str);

			// Act
			var result = Rnd.StringF.Passphrase(wordList, numberOfWords, '-', Rnd.Flip, Rnd.Flip).Split('-');

			// Assert
			Assert.Equal(numberOfWords, result.Length);
			Assert.Equal(numberOfWords, result.Distinct().Count());
		}
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
}
