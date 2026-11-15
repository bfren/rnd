// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System;

namespace RndF;

public static partial class Rnd
{
	public static partial class TimeF
	{
		/// <summary>
		/// Return a random time between 00:00:00.000 and 23:59:59.999.
		/// </summary>
		/// <remarks>
		/// Every millisecond in the range is equally likely, and the result is a whole number of milliseconds.
		/// </remarks>
		/// <returns>Random time.</returns>
		public static TimeOnly Get() =>
			new(NumberF.GetInRange(0L, TimeOnly.MaxValue.Ticks / TimeSpan.TicksPerMillisecond) * TimeSpan.TicksPerMillisecond);
	}
}
