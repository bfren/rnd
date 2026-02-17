// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System;
using System.Security.Cryptography;

namespace RndF;

public static partial class Rnd
{
	public static partial class TimeF
	{
		/// <summary>
		/// Return a random Time
		/// </summary>
		public static TimeOnly Get() =>
			new(
				hour: RandomNumberGenerator.GetInt32(0, DateTimeF.HourMaxExclusive),
				minute: RandomNumberGenerator.GetInt32(0, DateTimeF.MinuteMaxExclusive),
				second: RandomNumberGenerator.GetInt32(0, DateTimeF.SecondMaxExclusive),
				millisecond: RandomNumberGenerator.GetInt32(0, DateTimeF.MillisecondMaxExclusive)
			);
	}
}
