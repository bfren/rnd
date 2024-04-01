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
}
