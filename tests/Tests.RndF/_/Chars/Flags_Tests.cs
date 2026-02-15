// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Chars_Tests;

public class Flags_Tests
{
	[Fact]
	public void none_has_value_zero()
	{
		// Arrange

		// Act
		var result = (int)Chars.None;

		// Assert
		Assert.Equal(0, result);
	}

	[Fact]
	public void all_is_combination_of_number_lower_upper_special()
	{
		// Arrange
		var expected = Chars.Number | Chars.Lower | Chars.Upper | Chars.Special;

		// Act
		var result = Chars.All;

		// Assert
		Assert.Equal(expected, result);
	}

	[Fact]
	public void letters_is_combination_of_lower_and_upper()
	{
		// Arrange
		var expected = Chars.Lower | Chars.Upper;

		// Act
		var result = Chars.Letters;

		// Assert
		Assert.Equal(expected, result);
	}

	[Fact]
	public void all_does_not_include_hexademical()
	{
		// Arrange

		// Act
		var result = Chars.All & Chars.Hexademical;

		// Assert
		Assert.NotEqual(Chars.Hexademical, result);
	}

	[Fact]
	public void all_includes_number()
	{
		// Arrange

		// Act
		var result = Chars.All & Chars.Number;

		// Assert
		Assert.Equal(Chars.Number, result);
	}

	[Fact]
	public void all_includes_lower()
	{
		// Arrange

		// Act
		var result = Chars.All & Chars.Lower;

		// Assert
		Assert.Equal(Chars.Lower, result);
	}

	[Fact]
	public void all_includes_upper()
	{
		// Arrange

		// Act
		var result = Chars.All & Chars.Upper;

		// Assert
		Assert.Equal(Chars.Upper, result);
	}

	[Fact]
	public void all_includes_special()
	{
		// Arrange

		// Act
		var result = Chars.All & Chars.Special;

		// Assert
		Assert.Equal(Chars.Special, result);
	}

	[Fact]
	public void letters_includes_lower()
	{
		// Arrange

		// Act
		var result = Chars.Letters & Chars.Lower;

		// Assert
		Assert.Equal(Chars.Lower, result);
	}

	[Fact]
	public void letters_includes_upper()
	{
		// Arrange

		// Act
		var result = Chars.Letters & Chars.Upper;

		// Assert
		Assert.Equal(Chars.Upper, result);
	}

	[Fact]
	public void letters_does_not_include_number()
	{
		// Arrange

		// Act
		var result = Chars.Letters & Chars.Number;

		// Assert
		Assert.NotEqual(Chars.Number, result);
	}

	[Fact]
	public void letters_does_not_include_special()
	{
		// Arrange

		// Act
		var result = Chars.Letters & Chars.Special;

		// Assert
		Assert.NotEqual(Chars.Special, result);
	}

	[Theory]
	[InlineData(Chars.Number)]
	[InlineData(Chars.Lower)]
	[InlineData(Chars.Upper)]
	[InlineData(Chars.Special)]
	[InlineData(Chars.Hexademical)]
	public void individual_flags_are_distinct_powers_of_two(Chars flag)
	{
		// Arrange
		var value = (int)flag;

		// Act
		var isPowerOfTwo = value != 0 && (value & (value - 1)) == 0;

		// Assert
		Assert.True(isPowerOfTwo);
	}

	[Fact]
	public void combined_flags_produce_strings_with_correct_characters()
	{
		// Arrange
		var length = 200;
		var classes = Chars.Number | Chars.Lower;
		var allowed = new List<char>();
		allowed.AddRange(Helpers.Chars.Numbers);
		allowed.AddRange(Helpers.Chars.Lowercase);

		// Act
		var result = Rnd.StringF.Get(length, classes);

		// Assert
		Assert.All(result, c => Assert.Contains(c, allowed));
	}

	[Fact]
	public void upper_and_special_flags_produce_strings_with_correct_characters()
	{
		// Arrange
		var length = 200;
		var classes = Chars.Upper | Chars.Special;
		var allowed = new List<char>();
		allowed.AddRange(Helpers.Chars.Uppercase);
		allowed.AddRange(Helpers.Chars.Special);

		// Act
		var result = Rnd.StringF.Get(length, classes);

		// Assert
		Assert.All(result, c => Assert.Contains(c, allowed));
	}
}
