// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System;

namespace RndF;

public static partial class Rnd
{
	public static partial class TimeF
	{
		/// <summary>
		/// Return a random Time.
		/// </summary>
		/// <returns>Random time.</returns>
		public static TimeOnly Get() =>
			new(
				hour: NumberF.GetInRange(0, DateTimeF.HourMaxExclusive - 1),
				minute: NumberF.GetInRange(0, DateTimeF.MinuteMaxExclusive - 1),
				second: NumberF.GetInRange(0, DateTimeF.SecondMaxExclusive - 1),
				millisecond: NumberF.GetInRange(0, DateTimeF.MillisecondMaxExclusive - 1)
			);
	}
}
