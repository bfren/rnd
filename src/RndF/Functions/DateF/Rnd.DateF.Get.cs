// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System;

namespace RndF;

public static partial class Rnd
{
	public static partial class DateF
	{
		/// <summary>
		/// Return a random date between 0001-01-01 and 9999-12-31.
		/// </summary>
		/// <remarks>
		/// Every date in the range is equally likely.
		/// </remarks>
		/// <returns>Random date.</returns>
		public static DateOnly Get() =>
			DateOnly.FromDayNumber(NumberF.GetInRange(0, DateOnly.MaxValue.DayNumber));
	}
}
