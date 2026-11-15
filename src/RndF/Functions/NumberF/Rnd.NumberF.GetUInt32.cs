// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using RndF.Exceptions;

namespace RndF;

public static partial class Rnd
{
	public static partial class NumberF
	{
		/// <summary>
		/// Return a random non-negative integer between <c>0</c> and <see cref="uint.MaxValue"/> inclusive.
		/// </summary>
		/// <returns>Random number.</returns>
		public static uint GetUInt32() =>
			GetUInt32(0, uint.MaxValue);

		/// <summary>
		/// Return a random non-negative integer between <c>0</c> and <paramref name="max"/> inclusive.
		/// </summary>
		/// <param name="max">Maximum acceptable value.</param>
		/// <returns>Random number.</returns>
		/// <exception cref="MaximumLessThanMinimumException"><paramref name="max"/> is not greater than <c>0</c>.</exception>
		public static uint GetUInt32(uint max) =>
			GetUInt32(0, max);

		/// <summary>
		/// Return a random non-negative integer between <paramref name="min"/> and <paramref name="max"/> inclusive.
		/// </summary>
		/// <param name="min">Minimum acceptable value.</param>
		/// <param name="max">Maximum acceptable value.</param>
		/// <returns>Random number.</returns>
		/// <exception cref="MaximumLessThanMinimumException"><paramref name="max"/> is not greater than <paramref name="min"/>.</exception>
		public static uint GetUInt32(uint min, uint max)
		{
			// Check arguments
			if (min >= max)
			{
				throw MaximumLessThanMinimumException.Create(nameof(GetUInt32), min, max);
			}

			return GetInRange(min, max);
		}
	}
}
