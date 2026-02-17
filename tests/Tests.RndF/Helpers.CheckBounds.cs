// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System.Numerics;

namespace RndF;

internal static partial class Helpers
{
	internal static void CheckBounds<TObject, TValue>(
		Func<TObject> generate,
		Func<TObject, TValue> getValue,
		TValue minimumInclusive,
		TValue maximumExclusive,
		int iterations = 100000
	)
		where TValue : INumber<TValue>
	{
		// Arrange

		// Act
		var result = Rnd.For(iterations, () => getValue(generate()));

		// Assert
		Assert.True(result.Min()! >= minimumInclusive);
		Assert.True(result.Max()! < maximumExclusive);
	}

	internal static void CheckBounds<T>(
		Func<T> generate,
		T minimumInclusive,
		T maximumInclusive,
		int iterations = 100000
	)
		where T : INumber<T> =>
		CheckBounds((_, _) => generate(), minimumInclusive, maximumInclusive, iterations);

	internal static void CheckBounds<T>(
		Func<T, T> generate,
		T minimumInclusive,
		T maximumInclusive,
		int iterations = 100000
	)
		where T : INumber<T> =>
		CheckBounds((_, max) => generate(max), minimumInclusive, maximumInclusive, iterations);

	internal static void CheckBounds<T>(
		Func<T, T, T> generate,
		T minimumInclusive,
		T maximumInclusive,
		int iterations = 100000
	)
		where T : INumber<T>
	{
		// Arrange

		// Act
		var result = Rnd.For(iterations, () => generate(minimumInclusive, maximumInclusive));

		// Assert
		Assert.True(result.Min()! >= minimumInclusive);
		Assert.True(result.Max()! <= maximumInclusive);
	}
}
