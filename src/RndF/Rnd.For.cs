// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System;
using System.Linq;

namespace RndF;

public static partial class Rnd
{
	/// <inheritdoc cref="For{T}(int, Func{int, T})"/>
	public static T[] For<T>(int count, Func<T> action) =>
		For(count, _ => action());

	/// <summary>
	/// Used in testing or to generate a number of Random elements in one call.
	/// </summary>
	/// <remarks>
	/// Use instead of a <c>for</c> loop to generate random values, e.g.
	/// <c>var values = Rnd.For(10, () => Rnd.Int);</c>
	/// </remarks>
	/// <typeparam name="T">Return type.</typeparam>
	/// <param name="count">The number of elements to return.</param>
	/// <param name="action">Action to generate a random value.</param>
	/// <returns>Array of random elements.</returns>
	public static T[] For<T>(int count, Func<int, T> action) =>
		[.. Enumerable.Range(0, count).Select(x => action(x))];
}
