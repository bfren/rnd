// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.GuidF_Tests;

public class Get_Tests
{
	[Fact]
	public void Returns_Different_Bytes_Each_Time()
	{
		// Arrange
		const int iterations = 10000;
		var numbers = new List<Guid>();

		// Act
		for (var i = 0; i < iterations; i++)
		{
			numbers.Add(Rnd.GuidF.Get());
		}

		var unique = numbers.Distinct();

		// Assert
		Assert.Equal(unique.Count(), numbers.Count);
	}
}
