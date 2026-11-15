// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using RndF.Exceptions;

namespace RndF;

public static partial class Rnd
{
	public static partial class NumberF
	{
		/// <summary>
		/// Return a random non-negative integer between <c>0</c> and <see cref="short.MaxValue"/> inclusive.
		/// </summary>
		/// <returns>Random number.</returns>
		public static short GetInt16() =>
			GetInt16(0, short.MaxValue);

		/// <summary>
		/// Return a random non-negative integer between <c>0</c> and <paramref name="max"/> inclusive.
		/// </summary>
		/// <param name="max">Maximum acceptable value.</param>
		/// <returns>Random number.</returns>
		/// <exception cref="MaximumLessThanMinimumException"><paramref name="max"/> is not greater than <c>0</c>.</exception>
		public static short GetInt16(short max) =>
			GetInt16(0, max);

		/// <summary>
		/// Return a random non-negative integer between <paramref name="min"/> and <paramref name="max"/> inclusive.
		/// </summary>
		/// <param name="min">Minimum acceptable value (must be at least <c>0</c>).</param>
		/// <param name="max">Maximum acceptable value.</param>
		/// <returns>Random number.</returns>
		/// <exception cref="MaximumLessThanMinimumException"><paramref name="max"/> is not greater than <paramref name="min"/>.</exception>
		/// <exception cref="MinimumLessThanZeroException"><paramref name="min"/> is less than <c>0</c>.</exception>
		public static short GetInt16(short min, short max)
		{
			// Check arguments
			if (min >= max)
			{
				throw MaximumLessThanMinimumException.Create(nameof(GetInt16), min, max);
			}

			if (min < 0)
			{
				throw MinimumLessThanZeroException.Create(nameof(GetInt16), min);
			}

			return GetInRange(min, max);
		}
	}
}
