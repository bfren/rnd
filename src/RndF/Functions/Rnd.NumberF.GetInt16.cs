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
		/// Returns a random positive integer between <see langword="0"/> and <see cref="short.MaxValue"/> inclusive.
		/// </summary>
		/// <remarks>
		/// Don't share code with other GetIntxx() methods for memory allocation reasons.
		/// </remarks>
		/// <returns>Random number.</returns>
		public static short GetInt16() =>
			GetInt16(0, short.MaxValue);

		/// <summary>
		/// Returns a random positive integer between <see langword="0"/> and <paramref name="max"/> inclusive.
		/// </summary>
		/// <remarks>
		/// Don't share code with other GetIntxx() methods for memory allocation reasons.
		/// </remarks>
		/// <param name="max">Maximum acceptable value.</param>
		/// <returns>Random number.</returns>
		/// <exception cref="MaximumLessThanMinimumException"/>
		public static short GetInt16(short max) =>
			GetInt16(0, max);

		/// <summary>
		/// Returns a random positive integer between <paramref name="min"/> and <paramref name="max"/> inclusive.
		/// </summary>
		/// <remarks>
		/// Don't share code with other GetIntxx() methods for memory allocation reasons.
		/// </remarks>
		/// <param name="min">Minimum acceptable value (must be at least <see langword="0"/>).</param>
		/// <param name="max">Maximum acceptable value.</param>
		/// <returns>Random number.</returns>
		/// <exception cref="MaximumLessThanMinimumException"/>
		/// <exception cref="MinimumLessThanZeroException"/>
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

			// Get the range between the specified minimum and maximum values
			var range = max - min;

			// Now add a random amount of the range to the minimum value - it will never exceed maximum value
			var add = Math.Round(range * Get());
			return (short)(min + add);
		}
	}
}
