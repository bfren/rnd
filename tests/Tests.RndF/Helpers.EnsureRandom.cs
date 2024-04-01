// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF;

internal static partial class Helpers
{
	/// <summary>
	/// Allow a tiny amount of duplication (0.02%) to ensure the tests 'always' pass.
	/// </summary>
	internal const float AcceptableDuplicateRate = 0.0002f;

	internal static void EnsureRandom<T>(Func<T> get, int iterations = 100000)
	{
		// Arrange
		var numbers = new List<T>();
		var maximumDuplicates = Math.Ceiling(iterations * AcceptableDuplicateRate);

		// Act
		for (var i = 0; i < iterations; i++)
		{
			numbers.Add(get());
		}

		var result = iterations - numbers.Distinct().Count();

		// Assert
		Assert.True(result <= maximumDuplicates,
			$"Number of duplicate values ({result}) cannot be more than {maximumDuplicates}."
		);
	}
}
