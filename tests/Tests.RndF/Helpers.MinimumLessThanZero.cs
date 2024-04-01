// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System.Globalization;
using RndF.Exceptions;

namespace RndF;

internal static partial class Helpers
{
	public static void MinimumLessThanZero<T>(string method, Func<T> fMin, Func<T> fMax, Func<T, T, T> g)
		where T : IComparable<T>
	{
		// Arrange
		var (min, max) = (fMin(), fMax());

		// Act
		void act() => g(min, max);

		// Assert
		var ex = Assert.Throws<MinimumLessThanZeroException>(act);
		Assert.Equal(
			string.Format(CultureInfo.InvariantCulture, Rnd.NumberF.MinimumMustBeAtLeastZero, method, min),
			ex.Message
		);
	}
}
