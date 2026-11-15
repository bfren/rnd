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
		/// Return a random non-negative integer between <c>0</c> and <see cref="Int128.MaxValue"/> inclusive.
		/// </summary>
		/// <returns>Random number.</returns>
		public static Int128 GetInt128() =>
			GetInt128(0, Int128.MaxValue);

		/// <summary>
		/// Return a random non-negative integer between <c>0</c> and <paramref name="max"/> inclusive.
		/// </summary>
		/// <param name="max">Maximum acceptable value.</param>
		/// <returns>Random number.</returns>
		/// <exception cref="MaximumLessThanMinimumException"><paramref name="max"/> is not greater than <c>0</c>.</exception>
		public static Int128 GetInt128(Int128 max) =>
			GetInt128(0, max);

		/// <summary>
		/// Return a random non-negative integer between <paramref name="min"/> and <paramref name="max"/> inclusive.
		/// </summary>
		/// <param name="min">Minimum acceptable value (must be at least <c>0</c>).</param>
		/// <param name="max">Maximum acceptable value.</param>
		/// <returns>Random number.</returns>
		/// <exception cref="MaximumLessThanMinimumException"><paramref name="max"/> is not greater than <paramref name="min"/>.</exception>
		/// <exception cref="MinimumLessThanZeroException"><paramref name="min"/> is less than <c>0</c>.</exception>
		public static Int128 GetInt128(Int128 min, Int128 max)
		{
			// Check arguments
			if (min >= max)
			{
				throw MaximumLessThanMinimumException.Create(nameof(GetInt128), min, max);
			}

			if (min < 0)
			{
				throw MinimumLessThanZeroException.Create(nameof(GetInt128), min);
			}

			return GetInRange(min, max);
		}
	}
}
