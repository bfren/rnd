// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System;

namespace RndF;

public static partial class Rnd
{
	public static partial class DateF
	{
		/// <summary>
		/// Return a random Date between 0001-01-01 and 9999-12-31.
		/// </summary>
		/// <returns>Random date.</returns>
		public static DateOnly Get() =>
			new DateOnly(
				year: NumberF.GetInRange(1, DateTimeF.YearMaxExclusive - 1),
				month: NumberF.GetInRange(1, DateTimeF.MonthMaxExclusive - 1),
				day: NumberF.GetInRange(1, DateTimeF.DayMaxExclusive - 1)
			).AddDays(NumberF.GetInRange(0, 3));
	}
}
