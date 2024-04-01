// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

#if NET7_0_OR_GREATER
using System.Numerics;
#endif

namespace RndF;

internal static partial class Helpers
{
#if NET7_0_OR_GREATER
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
		var values = new List<TValue>();

		// Act
		for (var i = 0; i < iterations; i++)
		{
			var x = generate();
			values.Add(getValue(x));
		}

		// Assert
		Assert.True(values.Min()! >= minimumInclusive);
		Assert.True(values.Max()! < maximumExclusive);
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
		var values = new List<T>();

		// Act
		for (var i = 0; i < iterations; i++)
		{
			var x = generate(minimumInclusive, maximumInclusive);
			values.Add(x);
		}

		// Assert
		Assert.True(values.Min()! >= minimumInclusive);
		Assert.True(values.Max()! <= maximumInclusive);
	}
#else

	internal static void CheckBounds<TObject, TValue>(
		Func<TObject> generate,
		Func<TObject, TValue> getValue,
		TValue minimumInclusive,
		TValue maximumExclusive,
		int iterations = 100000
	)
		where TValue : IComparable<TValue>
	{
		// Arrange
		var values = new List<TValue>();

		// Act
		for (var i = 0; i < iterations; i++)
		{
			var x = generate();
			values.Add(getValue(x));
		}

		// Assert
		Assert.True(values.Min()!.CompareTo(minimumInclusive) >= 0);
		Assert.True(values.Max()!.CompareTo(maximumExclusive) < 0);
	}

	internal static void CheckBounds<T>(
		Func<T> generate,
		T minimumInclusive,
		T maximumInclusive,
		int iterations = 100000
	)
		where T : IComparable<T> =>
		CheckBounds((_, _) => generate(), minimumInclusive, maximumInclusive, iterations);

	internal static void CheckBounds<T>(
		Func<T, T> generate,
		T minimumInclusive,
		T maximumInclusive,
		int iterations = 100000
	)
		where T : IComparable<T> =>
		CheckBounds((_, max) => generate(max), minimumInclusive, maximumInclusive, iterations);

	internal static void CheckBounds<T>(
		Func<T, T, T> generate,
		T minimumInclusive,
		T maximumInclusive,
		int iterations = 100000
	)
		where T : IComparable<T>
	{
		// Arrange
		var values = new List<T>();

		// Act
		for (var i = 0; i < iterations; i++)
		{
			var x = generate(minimumInclusive, maximumInclusive);
			values.Add(x);
		}

		// Assert
		Assert.True(values.Min()!.CompareTo(minimumInclusive) >= 0);
		Assert.True(values.Max()!.CompareTo(maximumInclusive) <= 0);
	}
#endif
}
