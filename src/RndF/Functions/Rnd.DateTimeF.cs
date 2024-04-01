// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF;

public static partial class Rnd
{
	/// <summary>
	/// Random DateTime functions.
	/// </summary>
	public static partial class DateTimeF
	{
		/// <summary>
		/// Maximum bound (exclusive) for years.
		/// </summary>

		internal const int YearMaxExclusive = 10000;

		/// <summary>
		/// Maximum bound (exclusive) for months.
		/// </summary>

		internal const int MonthMaxExclusive = 13;

		/// <summary>
		/// Maximum bound (exclusive) for days.
		/// </summary>
		/// <remarks>
		/// This is 29 because there are at least 28 days in every month.
		/// Random functions then add 0-3 days to each date so days up to 31 are possible.
		/// </remarks>

		internal const int DayMaxExclusive = 29;

		/// <summary>
		/// Maximum bound (exclusive) for hours.
		/// </summary>

		internal const int HourMaxExclusive = 24;

		/// <summary>
		/// Maximum bound (exclusive) for minutes.
		/// </summary>

		internal const int MinuteMaxExclusive = 60;

		/// <summary>
		/// Maximum bound (exclusive) for seconds.
		/// </summary>

		internal const int SecondMaxExclusive = 60;

		/// <summary>
		/// Maximum bound (exclusive) for milliseconds.
		/// </summary>

		internal const int MillisecondMaxExclusive = 1000;
	}
}
