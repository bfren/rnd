// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System.Globalization;
using RndF.Exceptions;

namespace RndF.Exceptions_Tests;

public class MinimumLessThanZeroException_Tests
{
	[Fact]
	public void create_returns_exception_with_correct_message()
	{
		// Arrange
		var method = "TestMethod";
		var min = -5;

		// Act
		var result = MinimumLessThanZeroException.Create(method, min);

		// Assert
		Assert.IsType<MinimumLessThanZeroException>(result);
		Assert.Equal(
			string.Format(CultureInfo.InvariantCulture, Rnd.NumberF.MinimumMustBeAtLeastZero, method, min),
			result.Message
		);
	}

	[Fact]
	public void constructor_sets_message()
	{
		// Arrange
		var message = "Test message";

		// Act
		var result = new MinimumLessThanZeroException(message);

		// Assert
		Assert.Equal(message, result.Message);
	}
}
