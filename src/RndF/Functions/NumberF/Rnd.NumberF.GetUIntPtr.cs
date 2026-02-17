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
		/// Returns a random positive integer between <see langword="0"/> and <see cref="nuint.MaxValue"/> inclusive.
		/// </summary>
		/// <remarks>
		/// Don't share code with other GetUIntxx() methods for memory allocation reasons.
		/// </remarks>
		/// <returns>Random number.</returns>
		public static nuint GetUIntPtr() =>
			GetUIntPtr(0, nuint.MaxValue);

		/// <summary>
		/// Returns a random positive integer between <see langword="0"/> and <paramref name="max"/> inclusive.
		/// </summary>
		/// <remarks>
		/// Don't share code with other GetUIntxx() methods for memory allocation reasons.
		/// </remarks>
		/// <param name="max">Maximum acceptable value</param>
		/// <returns>Random number.</returns>
		/// <exception cref="MaximumLessThanMinimumException"/>
		public static nuint GetUIntPtr(nuint max) =>
			GetUIntPtr(0, max);

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
		public static nuint GetUIntPtr(nuint min, nuint max)
		{
			// Check arguments
			if (min >= max)
			{
				throw MaximumLessThanMinimumException.Create(nameof(GetUIntPtr), min, max);
			}

			// Get the range between the specified minimum and maximum values
			var range = max - min;

			// Now add a random amount of the range to the minimum value - it will never exceed maximum value
			var add = Math.Round(range * Get());
			return (nuint)(min + add);
		}
	}
}
