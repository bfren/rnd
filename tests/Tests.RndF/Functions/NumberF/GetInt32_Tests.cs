// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using RndF.Exceptions;

namespace RndF.Rnd_Tests.NumberF_Tests;

public class GetInt32_Tests
{
	[Fact]
	public void Min_GreaterThan_Max_Throws_ArgumentOutOfRangeException()
	{
		// Arrange
		var min = 3;
		var max = 2;

		// Act
		var action = void () => Rnd.NumberF.GetInt32(min, max);

		// Assert
		var ex = Assert.Throws<MinimumMoreThanMaximumException>(action);
		Assert.Equal("GetInt32(): Minimium value '3' must be less than maximum value '2'.", ex.Message);
	}

	[Fact]
	public void Min_LessThan_Zero_Throws_ArgumentException()
	{
		// Arrange
		var min = int.MinValue;

		// Act
		var action = void () => Rnd.NumberF.GetInt32(min: min, max: Rnd.Int);

		// Assert
		var ex = Assert.Throws<MinimumLessThanZeroException>(action);
		Assert.Equal($"GetInt32(): Minimum value '{min}' must be at least 0.", ex.Message);
	}

	[Fact]
	public void Never_Returns_Number_Out_Of_Bounds()
	{
		// Arrange
		var iterations = 1000000;
		var min = 1;
		var max = 10;
		var numbers = new List<int>();

		// Act
		for (var i = 0; i < iterations; i++)
		{
			numbers.Add(Rnd.NumberF.GetInt32(min, max));
		}

		// Assert
		Assert.True(numbers.Min() >= min);
		Assert.True(numbers.Max() <= max);
	}

	[Fact]
	public void Returns_Different_Number_Each_Time() =>
		Get_Tests.Returns_Different_Number_With_Acceptable_Duplicate_Rate(Rnd.NumberF.GetInt32);
}
