// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.DateF_Tests;

public class Get_Tests
{
	[Fact]
	public void never_returns_out_of_bounds_year() =>
		Helpers.CheckBounds(Rnd.DateF.Get, d => d.Year, 1, Rnd.DateTimeF.YearMaxExclusive);

	[Fact]
	public void never_returns_out_of_bounds_month() =>
		Helpers.CheckBounds(Rnd.DateF.Get, d => d.Month, 1, Rnd.DateTimeF.MonthMaxExclusive);

	[Fact]
	public void never_returns_out_of_bounds_day() =>
		Helpers.CheckBounds(Rnd.DateF.Get, d => d.Day, 1, Rnd.DateTimeF.DayMaxExclusive + 3);
}
