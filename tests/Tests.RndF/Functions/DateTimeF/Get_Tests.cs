// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.DateTimeF_Tests;

public class Get_Tests
{
	[Fact]
	public void never_returns_out_of_bounds_year() =>
		Helpers.CheckBounds(Rnd.DateTimeF.Get, dt => dt.Year, 1, Rnd.DateTimeF.YearMaxExclusive);

	[Fact]
	public void never_returns_out_of_bounds_month() =>
		Helpers.CheckBounds(Rnd.DateTimeF.Get, dt => dt.Month, 1, Rnd.DateTimeF.MonthMaxExclusive);

	[Fact]
	public void never_returns_out_of_bounds_day() =>
		Helpers.CheckBounds(Rnd.DateTimeF.Get, dt => dt.Day, 1, Rnd.DateTimeF.DayMaxExclusive + 3);

	[Fact]
	public void never_returns_out_of_bounds_hour() =>
		Helpers.CheckBounds(Rnd.DateTimeF.Get, dt => dt.Hour, 0, Rnd.DateTimeF.HourMaxExclusive);

	[Fact]
	public void never_returns_out_of_bounds_minute() =>
		Helpers.CheckBounds(Rnd.DateTimeF.Get, dt => dt.Minute, 0, Rnd.DateTimeF.MinuteMaxExclusive);

	[Fact]
	public void never_returns_out_of_bounds_second() =>
		Helpers.CheckBounds(Rnd.DateTimeF.Get, dt => dt.Second, 0, Rnd.DateTimeF.SecondMaxExclusive);

	[Fact]
	public void never_returns_out_of_bounds_millisecond() =>
		Helpers.CheckBounds(Rnd.DateTimeF.Get, dt => dt.Millisecond, 0, Rnd.DateTimeF.MillisecondMaxExclusive);

	[Fact]
	public void returns_utc()
	{
		// Arrange

		// Act
		var result = Rnd.DateTimeF.Get();

		// Assert
		Assert.Equal(DateTimeKind.Utc, result.Kind);
	}

	[Fact]
	public void never_exceeds_datetime_max_value()
	{
		// Arrange
		var iterations = 100000;

		// Act & Assert
		for (var i = 0; i < iterations; i++)
		{
			var result = Rnd.DateTimeF.Get();
			Assert.True(result >= DateTime.MinValue);
			Assert.True(result <= DateTime.MaxValue);
		}
	}

	[Fact]
	public void never_generates_days_above_twenty_eight()
	{
		// Arrange
		var iterations = 100000;
		var values = new List<int>();

		// Act
		var result = Rnd.For(iterations, () => Rnd.DateTimeF.Get().Day);

		// Assert
		Assert.All(values, d => Assert.True(d <= 28));
	}

	[Fact]
	public void generates_variety_of_months()
	{
		// Arrange
		var iterations = 100000;
		var months = new HashSet<int>();

		// Act
		for (var i = 0; i < iterations; i++)
		{
			months.Add(Rnd.DateTimeF.Get().Month);
		}

		// Assert - should cover all 12 months
		Assert.Equal(12, months.Count);
	}
}
