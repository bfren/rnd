// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using RndF.Exceptions;

namespace RndF.Rnd_Tests.NumberF_Tests;

public class GetDouble_Tests
{
	[Fact]
	public void Min_GreaterThan_Max_Throws_MinimumMoreThanMaximumException()
	{
		// Arrange
		var min = 3d;
		var max = 2d;

		// Act
		var action = void () => Rnd.NumberF.GetDouble(min, max);

		// Assert
		var ex = Assert.Throws<MinimumMoreThanMaximumException>(action);
		Assert.Equal("GetDouble(): Minimium value '3' must be less than maximum value '2'.", ex.Message);
	}

	[Fact]
	public void Min_LessThan_Zero_Throws_MinimumLessThanZeroException()
	{
		// Arrange
		var min = double.MinValue;

		// Act
		var action = void () => Rnd.NumberF.GetDouble(min: min, max: Rnd.Int);

		// Assert
		var ex = Assert.Throws<MinimumLessThanZeroException>(action);
		Assert.Equal($"GetDouble(): Minimum value '{min}' must be at least 0.", ex.Message);
	}

	[Fact]
	public void Never_Returns_Number_Out_Of_Bounds()
	{
		// Arrange
		var iterations = 1000000;
		var min = 0.5697d;
		var max = 9.1357d;
		var numbers = new List<double>();

		// Act
		for (var i = 0; i < iterations; i++)
		{
			numbers.Add(Rnd.NumberF.GetDouble(min, max));
		}

		// Assert
		Assert.True(numbers.Min() >= min);
		Assert.True(numbers.Max() <= max);
	}

	[Fact]
	public void Returns_Different_Number_Each_Time() =>
		Get_Tests.Returns_Different_Number_With_Acceptable_Duplicate_Rate(Rnd.NumberF.GetDouble);
}
