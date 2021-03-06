// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using RndF.Exceptions;

namespace RndF.Rnd_Tests.NumberF_Tests;

public class GetUInt32_Tests
{
	[Fact]
	public void Min_GreaterThan_Max_Throws_ArgumentOutOfRangeException()
	{
		// Arrange
		var min = 3u;
		var max = 2u;

		// Act
		var action = void () => Rnd.NumberF.GetUInt32(min, max);

		// Assert
		var ex = Assert.Throws<MinimumMoreThanMaximumException>(action);
		Assert.Equal("GetDouble(): Minimium value '3' must be less than maximum value '2'.", ex.Message);
	}

	[Fact]
	public void Never_Returns_Number_Out_Of_Bounds()
	{
		// Arrange
		var iterations = 1000000;
		var min = 1u;
		var max = 10u;
		var numbers = new List<uint>();

		// Act
		for (var i = 0; i < iterations; i++)
		{
			numbers.Add(Rnd.NumberF.GetUInt32(min, max));
		}

		// Assert
		Assert.True(numbers.Min() >= min);
		Assert.True(numbers.Max() <= max);
	}

	[Fact]
	public void Returns_Different_Number_Each_Time() =>
		Get_Tests.Returns_Different_Number_With_Acceptable_Duplicate_Rate(Rnd.NumberF.GetUInt32);
}
