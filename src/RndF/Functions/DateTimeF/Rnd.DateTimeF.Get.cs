// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System;

namespace RndF;

public static partial class Rnd
{
	public static partial class DateTimeF
	{
		/// <summary>
		/// Return a random DateTime between 0001-01-01 00:00:00.000 and 9999-12-31 23:59:59.999.
		/// </summary>
		/// <returns>Random date/time.</returns>
		public static DateTime Get() =>
			new DateTime(
				year: NumberF.GetInRange(1, YearMaxExclusive - 1),
				month: NumberF.GetInRange(1, MonthMaxExclusive - 1),
				day: NumberF.GetInRange(1, DayMaxExclusive - 1),
				hour: NumberF.GetInRange(0, HourMaxExclusive - 1),
				minute: NumberF.GetInRange(0, MinuteMaxExclusive - 1),
				second: NumberF.GetInRange(0, SecondMaxExclusive - 1),
				millisecond: NumberF.GetInRange(0, MillisecondMaxExclusive - 1),
				kind: DateTimeKind.Utc
			).AddDays(NumberF.GetInRange(0, 3));
	}
}
