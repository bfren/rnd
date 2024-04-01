// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

#if NET8_0_OR_GREATER
using System;
using System.Security.Cryptography;
#endif

namespace RndF;

public static partial class ArrayExtensions
{
	/// <summary>
	/// Create a copy of an array and shuffle the elements.
	/// </summary>
	/// <typeparam name="T">Object type.</typeparam>
	/// <param name="this">Array to shuffle.</param>
	/// <returns>Shuffled array.</returns>
	public static T[] Shuffle<T>(this T[] @this)
	{
		// Return empty list for null
		if (@this is null)
		{
			return [];
		}

		// If the array contains fewer than two elements, return the original
		if (@this.Length < 2)
		{
			return @this;
		}

		// Copy to new array so the original is not affected
		T[] shuffled = [.. @this];
#if NET8_0_OR_GREATER
		RandomNumberGenerator.Shuffle(shuffled.AsSpan());
#else
		for (var i = shuffled.Length; i > 1; i--)
		{
			var j = Rnd.NumberF.GetInt32(max: i - 1);
			(shuffled[i - 1], shuffled[j]) = (shuffled[j], shuffled[i - 1]);
		}
#endif

		// Original array remains the same
		return shuffled;
	}
}
