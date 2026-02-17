// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System;
using System.Security.Cryptography;

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
				year: RandomNumberGenerator.GetInt32(1, DateTimeF.YearMaxExclusive),
				month: RandomNumberGenerator.GetInt32(1, DateTimeF.MonthMaxExclusive),
				day: RandomNumberGenerator.GetInt32(1, DateTimeF.DayMaxExclusive)
			).AddDays(RandomNumberGenerator.GetInt32(0, 4));
	}
}
