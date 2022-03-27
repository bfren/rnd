// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.NumberF_Tests;

public class Get_Tests
{
	/// <summary>
	/// Allow a tiny amount of duplication to ensure the tests 'always' pass
	/// </summary>
	public static float AcceptableDuplicateRate { get; } = 0.9998f;

	[Fact]
	public void Never_Returns_Number_Out_Of_Bounds()
	{
		// Arrange
		var iterations = 1000000;
		var numbers = new List<double>();

		// Act
		for (var i = 0; i < iterations; i++)
		{
			numbers.Add(Rnd.NumberF.Get());
		}

		// Assert
		Assert.True(numbers.Min() >= 0);
		Assert.True(numbers.Max() <= 1);
	}

	[Fact]
	public void Returns_Different_Number_Each_Time() =>
		Returns_Different_Number_With_Acceptable_Duplicate_Rate(Rnd.NumberF.Get);

	internal static void Returns_Different_Number_With_Acceptable_Duplicate_Rate<T>(Func<T> get, float acceptableDuplicateRate = AcceptableDuplicateRate)
	{
		// Arrange
		var iterations = 10000;
		var numbers = new List<T>();

		// Act
		for (var i = 0; i < iterations; i++)
		{
			numbers.Add(get());
		}

		var result = (double)numbers.Distinct().Count() / iterations;

		// Assert
		Assert.True(
			result > acceptableDuplicateRate,
			$"Rate of unique values ({result:0.0000}) cannot be less than {acceptableDuplicateRate}. " +
			$"Duplicates: {string.Join(',', GetDuplicates(numbers))}."
		);
	}

	internal static List<T> GetDuplicates<T>(List<T> list)
	{
		var distinct = list.Distinct().ToList();
		var duplicates = new List<T>();
		foreach (var item in list)
		{
			if (distinct.Contains(item))
			{
				distinct.Remove(item);
			}
			else
			{
				duplicates.Add(item);
			}
		}
		return duplicates;
	}
}
