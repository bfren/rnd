// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System;

namespace RndF;

public static partial class Rnd
{
	public static partial class DateTimeF
	{
		/// <summary>
		/// Return a random UTC date and time between 0001-01-01 00:00:00.000 and 9999-12-31 23:59:59.999.
		/// </summary>
		/// <remarks>
		/// Every millisecond in the range is equally likely, and the result is a whole number of milliseconds.
		/// </remarks>
		/// <returns>Random date/time.</returns>
		public static DateTime Get() =>
			DateF.Get().ToDateTime(TimeF.Get(), DateTimeKind.Utc);
	}
}
