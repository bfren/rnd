// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using RndF.Exceptions;

namespace RndF;

public static partial class Rnd
{
	public static partial class NumberF
	{
		/// <summary>
		/// Returns a random positive double-precision floating number between <see langword="0"/> and
		/// <see cref="double.MaxValue"/> inclusive.
		/// </summary>
		/// <returns>Random number.</returns>
		public static double GetDouble() =>
			GetDouble(0, double.MaxValue);

		/// <summary>
		/// Returns a random positive double-precision floating number between <see langword="0"/> and
		/// <paramref name="max"/> inclusive.
		/// </summary>
		/// <param name="max">Maximum acceptable value.</param>
		/// <returns>Random number.</returns>
		/// <exception cref="MaximumLessThanMinimumException"/>
		public static double GetDouble(double max) =>
			GetDouble(0, max);

		/// <summary>
		/// Returns a random positive double-precision floating number between <paramref name="min"/> and
		/// <paramref name="max"/> inclusive.
		/// </summary>
		/// <param name="min">Minimum acceptable value.</param>
		/// <param name="max">Maximum acceptable value.</param>
		/// <returns>Random number.</returns>
		/// <exception cref="MaximumLessThanMinimumException"/>
		/// <exception cref="MinimumLessThanZeroException"/>
		public static double GetDouble(double min, double max)
		{
			// Check arguments
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
