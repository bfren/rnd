// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.DateF_Tests;

public class Get_Tests
{
	private static void Never_Returns_Number_Out_Of_Bounds(Func<DateOnly, int> value, int min, int max)
	{
		// Arrange
		var iterations = 100000;
		var values = new List<int>();

		// Act
		for (var i = 0; i < iterations; i++)
		{
			var d = Rnd.DateF.Get();
			values.Add(value(d));
		}

		// Assert
		Assert.True(values.Min() >= min);
		Assert.True(values.Max() <= max);
	}

	[Fact]
	public void Never_Returns_Year_Out_Of_Bounds() =>
		Never_Returns_Number_Out_Of_Bounds(dt => dt.Year, 1, 9999);

	[Fact]
	public void Never_Returns_Month_Out_Of_Bounds() =>
		Never_Returns_Number_Out_Of_Bounds(dt => dt.Month, 1, 12);

	[Fact]
	public void Never_Returns_Day_Out_Of_Bounds() =>
		Never_Returns_Number_Out_Of_Bounds(dt => dt.Day, 1, 28);
}
