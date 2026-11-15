// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.TimeF_Tests;

public class Get_Tests
{
	[Fact]
	public void Returns_Number_Between_Min_And_Max_hour() =>
		Helpers.CheckBounds(Rnd.TimeF.Get, t => t.Hour, 0, 24);

	[Fact]
	public void Returns_Number_Between_Min_And_Max_minute() =>
		Helpers.CheckBounds(Rnd.TimeF.Get, t => t.Minute, 0, 60);

	[Fact]
	public void Returns_Number_Between_Min_And_Max_second() =>
		Helpers.CheckBounds(Rnd.TimeF.Get, t => t.Second, 0, 60);

	[Fact]
	public void Returns_Number_Between_Min_And_Max_millisecond() =>
		Helpers.CheckBounds(Rnd.TimeF.Get, t => t.Millisecond, 0, 1000);

	[Fact]
	public void Returns_Whole_Milliseconds()
	{
		// Arrange
		var iterations = 100000;

		// Act
		var result = Rnd.For(iterations, Rnd.TimeF.Get);

		// Assert
		Assert.All(result, x => Assert.Equal(0, x.Ticks % TimeSpan.TicksPerMillisecond));
	}
}
