// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System.Globalization;
using RndF.Exceptions;

namespace RndF.Exceptions_Tests;

public class MaximumLessThanMinimumException_Tests
{
	[Fact]
	public void create_returns_exception_with_correct_message()
	{
		// Arrange
		var method = "TestMethod";
		var min = 10;
		var max = 5;

		// Act
		var result = MaximumLessThanMinimumException.Create(method, min, max);

		// Assert
		Assert.IsType<MaximumLessThanMinimumException>(result);
		Assert.Equal(
			string.Format(CultureInfo.InvariantCulture, Rnd.NumberF.MaximumMustBeGreaterThanMinimum, method, max, min),
			result.Message
		);
	}

	[Fact]
	public void constructor_sets_message()
	{
		// Arrange
		var message = "Test message";

		// Act
		var result = new MaximumLessThanMinimumException(message);

		// Assert
		Assert.Equal(message, result.Message);
	}
}
