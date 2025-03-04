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
		/// Returns a random positive integer between <see langword="0"/> and <see cref="ulong.MaxValue"/> inclusive.
		/// </summary>
		/// <remarks>
		/// Don't share code with other GetUIntxx() methods for memory allocation reasons.
		/// </remarks>
		/// <returns>Random number.</returns>
		public static ulong GetUInt64() =>
			GetUInt64(0, ulong.MaxValue);

		/// <summary>
		/// Returns a random positive integer between <see langword="0"/> and <paramref name="max"/> inclusive.
		/// </summary>
		/// <remarks>
		/// Don't share code with other GetUIntxx() methods for memory allocation reasons.
		/// </remarks>
		/// <param name="max">Maximum acceptable value</param>
		/// <returns>Random number.</returns>
		/// <exception cref="MaximumLessThanMinimumException"/>
		public static ulong GetUInt64(ulong max) =>
			GetUInt64(0, max);

		/// <summary>
		/// Returns a random positive integer between <paramref name="min"/> and <paramref name="max"/> inclusive.
		/// </summary>
		/// <remarks>
		/// Don't share code with other GetUIntxx() methods for memory allocation reasons.
		/// </remarks>
		/// <param name="min">Minimum acceptable value.</param>
		/// <param name="max">Maximum acceptable value.</param>
		/// <returns>Random number.</returns>
		/// <exception cref="MaximumLessThanMinimumException"/>
		public static ulong GetUInt64(ulong min, ulong max)
		{
			// Check arguments
			if (min >= max)
			{
				throw MaximumLessThanMinimumException.Create(nameof(GetUInt64), min, max);
			}

			// Get the range between the specified minimum and maximum values
			var range = max - min;

			// Now add a random amount of the range to the minimum value - it will never exceed maximum value
			var add = Math.Round(range * Get());
			return (ulong)(min + add);
		}
	}
}
