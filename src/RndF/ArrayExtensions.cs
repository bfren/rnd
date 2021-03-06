// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System;
using System.Linq;

namespace RndF;

/// <summary>
/// Array Extensions
/// </summary>
public static class ArrayExtensions
{
	/// <summary>
	/// Create a copy of an array and shuffle the elements using a Fisher-Yates Shuffle
	/// </summary>
	/// <typeparam name="T">Object type</typeparam>
	/// <param name="this">Array to shuffle</param>
	public static T[] Shuffle<T>(this T[] @this)
	{
		// Return empty list for null
		if (@this is null)
		{
			return Array.Empty<T>();
		}

		// Don't alter the original array
		var shuffled = @this.ToArray();

		for (var i = shuffled.Length; i > 1; i--)
		{
			var j = Rnd.NumberF.GetInt32(max: i - 1);
			(shuffled[i - 1], shuffled[j]) = (shuffled[j], shuffled[i - 1]);
		}

		return shuffled;
	}
}
