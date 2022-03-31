// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using RndF.Exceptions;

namespace RndF;

public static partial class Rnd
{
	public static partial class NumberF
	{
		/// <summary>
		/// Returns a random positive single-precision floating number between <see langword="0"/> and
		/// <see cref="float.MaxValue"/> inclusive
		/// </summary>
		public static float GetSingle() =>
			GetSingle(0, float.MaxValue);

		/// <summary>
		/// Returns a random positive single-precision floating number between <see langword="0"/> and
		/// <paramref name="max"/> inclusive
		/// </summary>
		/// <param name="max">Maximum acceptable value</param>
		public static float GetSingle(float max) =>
			GetSingle(0, max);

		/// <summary>
		/// Returns a random positive single-precision floating number between <paramref name="min"/> and
		/// <paramref name="max"/> inclusive
		/// </summary>
		/// <param name="min">Minimum acceptable value</param>
		/// <param name="max">Maximum acceptable value</param>
		/// <exception cref="MinimumMoreThanMaximumException"></exception>
		/// <exception cref="MinimumLessThanZeroException"></exception>
		public static float GetSingle(float min, float max)
		{
			// Check arguments
			if (min >= max)
			{
				throw MinimumMoreThanMaximumException.Create(nameof(GetSingle), min, max);
			}

			if (min < 0)
			{
				throw MinimumLessThanZeroException.Create(nameof(GetSingle), min);
			}

			// Get the range between the specified minimum and maximum values
			var range = max - min;

			// Now add a random amount of the range to the minimum value - it will never exceed maximum value
			var add = range * Get();
			return (float)(min + add);
		}
	}
}
