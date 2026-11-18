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
		/// Return a random non-negative single-precision floating-point number between <c>0</c> and
		/// <see cref="float.MaxValue"/> inclusive.
		/// </summary>
		/// <returns>Random number.</returns>
		public static float GetSingle() =>
			GetSingle(0, float.MaxValue);

		/// <summary>
		/// Return a random non-negative single-precision floating-point number between <c>0</c> and
		/// <paramref name="max"/> inclusive.
		/// </summary>
		/// <param name="max">Maximum acceptable value.</param>
		/// <returns>Random number.</returns>
		/// <exception cref="MaximumLessThanMinimumException"><paramref name="max"/> is not greater than <c>0</c>.</exception>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="max"/> is not a finite number.</exception>
		public static float GetSingle(float max) =>
			GetSingle(0, max);

		/// <summary>
		/// Return a random non-negative single-precision floating-point number between <paramref name="min"/> and
		/// <paramref name="max"/> inclusive.
		/// </summary>
		/// <param name="min">Minimum acceptable value (must be at least <c>0</c>).</param>
		/// <param name="max">Maximum acceptable value.</param>
		/// <returns>Random number.</returns>
		/// <exception cref="MaximumLessThanMinimumException"><paramref name="max"/> is not greater than <paramref name="min"/>.</exception>
		/// <exception cref="MinimumLessThanZeroException"><paramref name="min"/> is less than <c>0</c>.</exception>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="min"/> or <paramref name="max"/> is not a finite number.</exception>
		public static float GetSingle(float min, float max)
		{
			// Check arguments (NaN fails every comparison, so check it first)
			if (!float.IsFinite(min) || !float.IsFinite(max))
			{
				throw new ArgumentOutOfRangeException(float.IsFinite(min) ? nameof(max) : nameof(min), "Value must be a finite number.");
			}

			if (min >= max)
			{
				throw MaximumLessThanMinimumException.Create(nameof(GetSingle), min, max);
			}

			if (min < 0)
			{
				throw MinimumLessThanZeroException.Create(nameof(GetSingle), min);
			}

			// Get the range between the specified minimum and maximum values
			var range = max - min;

			// Now add a random amount of the range to the minimum value - rounding can push it just past the maximum, so clamp
			var add = range * Get();
			return Math.Min((float)(min + add), max);
		}
	}
}
