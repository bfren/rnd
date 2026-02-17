// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using RndF.Exceptions;

namespace RndF.Exceptions_Tests;

public class InvalidCharsException_Tests
{
	[Fact]
	public void not_enough_classes_returns_exception_with_correct_message()
	{
		// Arrange

		// Act
		var result = InvalidCharsException.NotEnoughClasses();

		// Assert
		Assert.IsType<InvalidCharsException>(result);
		Assert.Equal(Rnd.StringF.NotEnoughClasses, result.Message);
	}

	[Fact]
	public void too_many_classes_returns_exception_with_correct_message()
	{
		// Arrange

		// Act
		var result = InvalidCharsException.TooManyClasses();

		// Assert
		Assert.IsType<InvalidCharsException>(result);
		Assert.Equal(Rnd.StringF.TooManyClasses, result.Message);
	}

	[Fact]
	public void constructor_sets_message()
	{
		// Arrange
		var message = "Test message";

		// Act
		var result = new InvalidCharsException(message);

		// Assert
		Assert.Equal(message, result.Message);
	}
}
