// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.DateTimeF_Tests;

public class Get_Tests
{
	[Fact]
	public void Returns_DateTime_Between_Min_And_Max_Year() =>
		Helpers.CheckBounds(Rnd.DateTimeF.Get, dt => dt.Year, 1, Rnd.DateTimeF.YearMaxExclusive);

	[Fact]
	public void Returns_DateTime_Between_Min_And_Max_Month() =>
		Helpers.CheckBounds(Rnd.DateTimeF.Get, dt => dt.Month, 1, Rnd.DateTimeF.MonthMaxExclusive);

	[Fact]
	public void Returns_DateTime_Between_Min_And_Max_Day() =>
		Helpers.CheckBounds(Rnd.DateTimeF.Get, dt => dt.Day, 1, Rnd.DateTimeF.DayMaxExclusive + 3);

	[Fact]
	public void Returns_DateTime_Between_Min_And_Max_Hour() =>
		Helpers.CheckBounds(Rnd.DateTimeF.Get, dt => dt.Hour, 0, Rnd.DateTimeF.HourMaxExclusive);

	[Fact]
	public void Returns_DateTime_Between_Min_And_Max_Minute() =>
		Helpers.CheckBounds(Rnd.DateTimeF.Get, dt => dt.Minute, 0, Rnd.DateTimeF.MinuteMaxExclusive);

	[Fact]
	public void Returns_DateTime_Between_Min_And_Max_Second() =>
		Helpers.CheckBounds(Rnd.DateTimeF.Get, dt => dt.Second, 0, Rnd.DateTimeF.SecondMaxExclusive);

	[Fact]
	public void Returns_DateTime_Between_Min_And_Max_Millisecond() =>
		Helpers.CheckBounds(Rnd.DateTimeF.Get, dt => dt.Millisecond, 0, Rnd.DateTimeF.MillisecondMaxExclusive);

	[Fact]
	public void Returns_UTC()
	{
		// Arrange

		// Act
		var result = Rnd.DateTimeF.Get();

		// Assert
		Assert.Equal(DateTimeKind.Utc, result.Kind);
	}

	[Fact]
	public void Never_Exceeds_DateTime_MaxValue()
	{
		// Arrange
		var iterations = 100000;

		// Act
		var result = Rnd.For(iterations, Rnd.DateTimeF.Get);

		// Assert
		Assert.All(result, x => Assert.True(x >= DateTime.MinValue));
		Assert.All(result, x => Assert.True(x <= DateTime.MaxValue));
	}

	[Fact]
	public void never_generates_days_above_thirty_one()
	{
		// Arrange
		var iterations = 100000;

		// Act
		var result = Rnd.For(iterations, () => Rnd.DateTimeF.Get().Day);

		// Assert
		Assert.All(result, d => Assert.True(d <= 31));
	}

	[Fact]
	public void generates_variety_of_months()
	{
		// Arrange
		var iterations = 100000;

		// Act
		var result = Rnd.For(iterations, () => Rnd.DateTimeF.Get().Month)
			.Distinct();

		// Assert - should cover all 12 months
		Assert.Equal(12, result.Count());
	}
}
