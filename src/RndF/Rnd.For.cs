// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System;

namespace RndF;

public static partial class Rnd
{
	/// <summary>
	/// Call <paramref name="action"/> <paramref name="count"/> times and return the results in an array.
	/// </summary>
	/// <remarks>
	/// Use instead of a <c>for</c> loop to generate random values, e.g.
	/// <c>var values = Rnd.For(10, () => Rnd.Int);</c>
	/// </remarks>
	/// <typeparam name="T">Element type.</typeparam>
	/// <param name="count">The number of elements to return.</param>
	/// <param name="action">Function that generates each value.</param>
	/// <returns>Array of <paramref name="count"/> values, empty when <paramref name="count"/> is <c>0</c>.</returns>
	/// <exception cref="OverflowException"><paramref name="count"/> is negative.</exception>
	public static T[] For<T>(int count, Func<T> action) =>
		For(count, _ => action());

	/// <summary>
	/// Call <paramref name="action"/> with each index from <c>0</c> to <paramref name="count"/> - 1 and return the
	/// results in an array.
	/// </summary>
	/// <remarks>
	/// Use instead of a <c>for</c> loop to generate random values, e.g.
	/// <c>var values = Rnd.For(10, i => $"{i}: {Rnd.Str}");</c>
	/// </remarks>
	/// <typeparam name="T">Element type.</typeparam>
	/// <param name="count">The number of elements to return.</param>
	/// <param name="action">Function that receives the index and generates the value for it.</param>
	/// <returns>Array of <paramref name="count"/> values, empty when <paramref name="count"/> is <c>0</c>.</returns>
	/// <exception cref="OverflowException"><paramref name="count"/> is negative.</exception>
	public static T[] For<T>(int count, Func<int, T> action)
	{
		// Use pre-sized array
		var result = new T[count];
		for (var i = 0; i < count; i++)
		{
			result[i] = action(i);
		}
		return result;
	}
}
