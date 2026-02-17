// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System;
using System.Security.Cryptography;

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
				year: RandomNumberGenerator.GetInt32(1, YearMaxExclusive),
				month: RandomNumberGenerator.GetInt32(1, MonthMaxExclusive),
				day: RandomNumberGenerator.GetInt32(1, DayMaxExclusive),
				hour: RandomNumberGenerator.GetInt32(0, HourMaxExclusive),
				minute: RandomNumberGenerator.GetInt32(0, MinuteMaxExclusive),
				second: RandomNumberGenerator.GetInt32(0, SecondMaxExclusive),
				millisecond: RandomNumberGenerator.GetInt32(0, MillisecondMaxExclusive),
				kind: DateTimeKind.Utc
			).AddDays(RandomNumberGenerator.GetInt32(0, 4));
	}
}
