// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.NumberF_Tests;

public class Get_Tests
{
	/// <summary>
	/// Allow a tiny amount of duplication to ensure the tests always pass
	/// </summary>
	public const float FailureRate = 0.9998f;

	[Fact]
	public void Never_Returns_Number_Out_Of_Bounds()
	{
		// Arrange
		var iterations = 1000000;
		var numbers = new List<double>();

		// Act
		for (var i = 0; i < iterations; i++)
		{
			numbers.Add(Rnd.NumberF.Get());
		}

		// Assert
		Assert.True(numbers.Min() >= 0);
		Assert.True(numbers.Max() <= 1);
	}

	[Fact]
	public void Returns_Different_Number_Each_Time()
	{
		// Arrange
		var iterations = 10000;
		var numbers = new List<double>();

		// Act
		for (var i = 0; i < iterations; i++)
		{
			numbers.Add(Rnd.NumberF.Get());
		}

		var result = (double)numbers.Distinct().Count() / iterations;

		// Assert
		Assert.True(result > FailureRate);
		Assert.True(numbers.Min() >= 0);
		Assert.True(numbers.Max() <= 1);
	}
}
