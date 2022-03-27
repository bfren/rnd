// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.DateTimeF_Tests;

public class Get_Tests
{
	private static void Never_Returns_Number_Out_Of_Bounds(Func<DateTime, int> value, int min, int max)
	{
		// Arrange
		var iterations = 100000;
		var values = new List<int>();

		// Act
		for (var i = 0; i < iterations; i++)
		{
			var dt = Rnd.DateTimeF.Get();
			values.Add(value(dt));
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

	[Fact]
	public void Never_Returns_Hour_Out_Of_Bounds() =>
		Never_Returns_Number_Out_Of_Bounds(dt => dt.Hour, 0, 23);

	[Fact]
	public void Never_Returns_Minute_Out_Of_Bounds() =>
		Never_Returns_Number_Out_Of_Bounds(dt => dt.Minute, 0, 59);

	[Fact]
	public void Never_Returns_Second_Out_Of_Bounds() =>
		Never_Returns_Number_Out_Of_Bounds(dt => dt.Second, 0, 59);

	[Fact]
	public void Returns_UTC_DateTime()
	{
		// Arrange

		// Act
		var result = Rnd.DateTimeF.Get();

		// Assert
		Assert.Equal(DateTimeKind.Utc, result.Kind);
	}
}
