// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.TimeF_Tests;

public class Get_Tests
{
	private static void Never_Returns_Number_Out_Of_Bounds(Func<TimeOnly, int> value, int min, int max)
	{
		// Arrange
		var iterations = 100000;
		var values = new List<int>();

		// Act
		for (var i = 0; i < iterations; i++)
		{
			var t = Rnd.TimeF.Get();
			values.Add(value(t));
		}

		// Assert
		Assert.True(values.Min() >= min);
		Assert.True(values.Max() <= max);
	}

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
	public void Never_Returns_Millisecond_Out_Of_Bounds() =>
		Never_Returns_Number_Out_Of_Bounds(dt => dt.Millisecond, 0, 999);
}
