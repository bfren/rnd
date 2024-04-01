// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.TimeF_Tests;

public class Get_Tests
{
	[Fact]
	public void never_returns_out_of_bounds_hour() =>
		Helpers.CheckBounds(Rnd.TimeF.Get, t => t.Hour, 0, Rnd.DateTimeF.HourMaxExclusive);

	[Fact]
	public void never_returns_out_of_bounds_minute() =>
		Helpers.CheckBounds(Rnd.TimeF.Get, t => t.Minute, 0, Rnd.DateTimeF.MinuteMaxExclusive);

	[Fact]
	public void never_returns_out_of_bounds_second() =>
		Helpers.CheckBounds(Rnd.TimeF.Get, t => t.Second, 0, Rnd.DateTimeF.SecondMaxExclusive);

	[Fact]
	public void never_returns_out_of_bounds_millisecond() =>
		Helpers.CheckBounds(Rnd.TimeF.Get, t => t.Millisecond, 0, Rnd.DateTimeF.MillisecondMaxExclusive);
}
