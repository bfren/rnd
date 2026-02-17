// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System.Globalization;
using System.Numerics;
using RndF.Exceptions;

namespace RndF;

internal static partial class Helpers
{
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
		var result = Record.Exception(() => g(min, max));

		// Assert
		var ex = Assert.IsType<MaximumLessThanMinimumException>(result);
		Assert.Equal(
			string.Format(CultureInfo.InvariantCulture, Rnd.NumberF.MaximumMustBeGreaterThanMinimum, method, max, min),
			ex.Message
		);
	}
}
