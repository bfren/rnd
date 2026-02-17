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
		where T : INumber<T>
	{
		// Arrange

		// Act
		var result = Rnd.For(iterations, () => generate());

		// Assert
		Assert.True(result.Min()! >= minimumInclusive);
		Assert.True(result.Max()! <= maximumInclusive);
	}

	internal static void CheckBounds<T>(
		Func<T> generate,
		Func<T, T> generateWithMax,
		int iterations = 100000
	)
		where T : INumber<T>
	{
		// Arrange
		var max = generate();

		// Act
		var result = Rnd.For(iterations, () => generateWithMax(max));

		// Assert
		Assert.True(result.Min()! >= T.Zero);
		Assert.True(result.Max()! <= max);
	}

	internal static void CheckBounds<T>(
		Func<T> generate,
		Func<T, T, T> generateWithinBounds,
		int iterations = 100000
	)
		where T : INumber<T>
	{
		// Arrange
		var (v0, v1) = (generate(), generate());
		var (min, max) = (v0 < v1) switch
		{
			true =>
				(v0, v1),

			false =>
				(v1, v0)
		};

		// Act
		var result = Rnd.For(iterations, () => generateWithinBounds(min, max));

		// Assert
		Assert.True(result.Min()! >= min);
		Assert.True(result.Max()! <= max);
	}
}
