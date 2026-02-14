// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System.Globalization;
using RndF.Exceptions;

namespace RndF.Exceptions_Tests;

public class InvalidPassphraseException_Tests
{
	[Fact]
	public void passphrase_not_long_enough_returns_exception_with_correct_message()
	{
		// Arrange
		var minimum = 3;

		// Act
		var result = InvalidPassphraseException.PassphraseNotLongEnough(minimum);

		// Assert
		Assert.IsType<InvalidPassphraseException>(result);
		Assert.Equal(
			string.Format(CultureInfo.InvariantCulture, Rnd.StringF.PassphraseNotLongEnough, minimum),
			result.Message
		);
	}

	[Fact]
	public void passphrase_too_long_returns_exception_with_correct_message()
	{
		// Arrange
		var maximum = 10;

		// Act
		var result = InvalidPassphraseException.PassphraseTooLong(maximum);

		// Assert
		Assert.IsType<InvalidPassphraseException>(result);
		Assert.Equal(
			string.Format(CultureInfo.InvariantCulture, Rnd.StringF.PassphraseTooLong, maximum),
			result.Message
		);
	}

	[Fact]
	public void word_list_cannot_be_empty_returns_exception_with_correct_message()
	{
		// Arrange

		// Act
		var result = InvalidPassphraseException.WordListCannotBeEmpty();

		// Assert
		Assert.IsType<InvalidPassphraseException>(result);
		Assert.Equal(Rnd.StringF.WordListCannotBeEmpty, result.Message);
	}

	[Fact]
	public void word_list_cannot_be_null_returns_exception_with_correct_message()
	{
		// Arrange

		// Act
		var result = InvalidPassphraseException.WordListCannotBeNull();

		// Assert
		Assert.IsType<InvalidPassphraseException>(result);
		Assert.Equal(Rnd.StringF.WordListCannotBeNull, result.Message);
	}

	[Fact]
	public void constructor_sets_message()
	{
		// Arrange
		var message = "Test message";

		// Act
		var result = new InvalidPassphraseException(message);

		// Assert
		Assert.Equal(message, result.Message);
	}
}
