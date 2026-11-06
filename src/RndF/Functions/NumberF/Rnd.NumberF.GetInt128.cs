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
		/// Returns a random positive integer between <see langword="0"/> and <see cref="Int128.MaxValue"/> inclusive.
		/// </summary>
		/// <returns>Random number.</returns>
		public static Int128 GetInt128() =>
			GetInt128(0, Int128.MaxValue);

		/// <summary>
		/// Returns a random positive integer between <see langword="0"/> and <paramref name="max"/> inclusive.
		/// </summary>
		/// <param name="max">Maximum acceptable value.</param>
		/// <returns>Random number.</returns>
		/// <exception cref="MaximumLessThanMinimumException"/>
		public static Int128 GetInt128(Int128 max) =>
			GetInt128(0, max);

		/// <summary>
		/// Returns a random positive integer between <paramref name="min"/> and <paramref name="max"/> inclusive.
		/// </summary>
		/// <param name="min">Minimum acceptable value (must be at least <see langword="0"/>).</param>
		/// <param name="max">Maximum acceptable value.</param>
		/// <returns>Random number.</returns>
		/// <exception cref="MaximumLessThanMinimumException"/>
		/// <exception cref="MinimumLessThanZeroException"/>
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
