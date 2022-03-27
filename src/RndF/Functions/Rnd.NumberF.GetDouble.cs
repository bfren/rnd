// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System;

namespace RndF;

public static partial class Rnd
{
	public static partial class NumberF
	{
		/// <summary>
		/// Returns a random positive double-precision floating number between <see langword="0"/> and
		/// <see cref="double.MaxValue"/> inclusive
		/// </summary>
		public static double GetDouble() =>
			GetDouble(0, double.MaxValue);

		/// <summary>
		/// Returns a random positive double-precision floating number between <see langword="0"/> and
		/// <paramref name="max"/> inclusive
		/// </summary>
		/// <param name="max">Maximum acceptable value</param>
		public static double GetDouble(double max) =>
			GetDouble(0, max);

		/// <summary>
		/// Returns a random positive double-precision floating number between <paramref name="min"/> and
		/// <paramref name="max"/> inclusive
		/// </summary>
		/// <param name="min">Minimum acceptable value</param>
		/// <param name="max">Maximum acceptable value</param>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		/// <exception cref="ArgumentException"></exception>
		public static double GetDouble(double min, double max)
		{
			// Check arguments
			if (min >= max)
			{
				throw new ArgumentOutOfRangeException(nameof(min), min, MinimumMustBeLessThanMaximum);
			}

			if (min < 0)
			{
				throw new ArgumentException(MinimumMustBeAtLeastZero, nameof(min));
			}

			// Get the range between the specified minimum and maximum values
			var range = max - min;

			// Now add a random amount of the range to the minimum value - it will never exceed maximum value
			var add = range * Get();
			return min + add;
		}
	}
}
