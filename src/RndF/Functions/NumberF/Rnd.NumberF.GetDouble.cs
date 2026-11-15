// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System;
using RndF.Exceptions;

namespace RndF;

public static partial class Rnd
{
	public static partial class NumberF
	{
		/// <summary>
		/// Return a random non-negative double-precision floating-point number between <c>0</c> and
		/// <see cref="double.MaxValue"/> inclusive.
		/// </summary>
		/// <returns>Random number.</returns>
		public static double GetDouble() =>
			GetDouble(0, double.MaxValue);

		/// <summary>
		/// Return a random non-negative double-precision floating-point number between <c>0</c> and
		/// <paramref name="max"/> inclusive.
		/// </summary>
		/// <param name="max">Maximum acceptable value.</param>
		/// <returns>Random number.</returns>
		/// <exception cref="MaximumLessThanMinimumException"><paramref name="max"/> is not greater than <c>0</c>.</exception>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="max"/> is not a finite number.</exception>
		public static double GetDouble(double max) =>
			GetDouble(0, max);

		/// <summary>
		/// Return a random non-negative double-precision floating-point number between <paramref name="min"/> and
		/// <paramref name="max"/> inclusive.
		/// </summary>
		/// <param name="min">Minimum acceptable value (must be at least <c>0</c>).</param>
		/// <param name="max">Maximum acceptable value.</param>
		/// <returns>Random number.</returns>
		/// <exception cref="MaximumLessThanMinimumException"><paramref name="max"/> is not greater than <paramref name="min"/>.</exception>
		/// <exception cref="MinimumLessThanZeroException"><paramref name="min"/> is less than <c>0</c>.</exception>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="min"/> or <paramref name="max"/> is not a finite number.</exception>
		public static double GetDouble(double min, double max)
		{
			// Check arguments (NaN fails every comparison, so check it first)
			if (!double.IsFinite(min) || !double.IsFinite(max))
			{
				throw new ArgumentOutOfRangeException(double.IsFinite(min) ? nameof(max) : nameof(min), "Value must be a finite number.");
			}

			if (min >= max)
			{
				throw MaximumLessThanMinimumException.Create(nameof(GetDouble), min, max);
			}

			if (min < 0)
			{
				throw MinimumLessThanZeroException.Create(nameof(GetDouble), min);
			}

			// Get the range between the specified minimum and maximum values
			var range = max - min;

			// Now add a random amount of the range to the minimum value - it will never exceed maximum value
			var add = range * Get();
			return min + add;
		}
	}
}
