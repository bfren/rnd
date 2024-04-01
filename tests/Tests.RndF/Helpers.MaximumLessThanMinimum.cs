// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System.Globalization;
#if NET7_0_OR_GREATER
using System.Numerics;
#endif
using RndF.Exceptions;

namespace RndF;

internal static partial class Helpers
{
#if NET7_0_OR_GREATER
	public static void MaximumLessThanMinimum<T>(string method, Func<T> f, Func<T, T, T> g)
		where T : INumber<T>
	{
		// Arrange
		var (n0, n1) = (f(), f());
		var (min, max) = (n0 > n1) switch
		{
			false =>
				(n1, n0),

			true =>
				(n0, n1)
		};

		// Act
		void act() => g(min, max);

		// Assert
		var ex = Assert.Throws<MaximumLessThanMinimumException>(act);
		Assert.Equal(
			string.Format(CultureInfo.InvariantCulture, Rnd.NumberF.MaximumMustBeGreaterThanMinimum, method, max, min),
			ex.Message
		);
	}
#else
	public static void MaximumLessThanMinimum<T>(string method, Func<T> f, Func<T, T, T> g)
		where T : IComparable<T>
	{
		// Arrange
		var (n0, n1) = (f(), f());
		var (min, max) = n0.CompareTo(n1) switch
		{
			<= 0 =>
				(n1, n0),

			> 0 =>
				(n0, n1)
		};

		// Act
		void act() => g(min, max);

		// Assert
		var ex = Assert.Throws<MaximumLessThanMinimumException>(act);
		Assert.Equal(
			string.Format(CultureInfo.InvariantCulture, Rnd.NumberF.MaximumMustBeGreaterThanMinimum, method, max, min),
			ex.Message
		);
	}
#endif
}
