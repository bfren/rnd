// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.GuidF_Tests;

public class Get_Tests
{
	[Fact]
	public void Returns_Different_Bytes_Each_Time()
	{
		// Arrange
		var iterations = 10000;
		var values = new List<Guid>();

		// Act
		for (var i = 0; i < iterations; i++)
		{
			values.Add(Rnd.GuidF.Get());
		}

		var result = values.Distinct().Count();

		// Assert
		Assert.Equal(values.Count, result);
	}
}
