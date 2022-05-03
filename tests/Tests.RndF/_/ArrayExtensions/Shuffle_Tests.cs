// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.ArrayExtensions_Tests;

public class Shuffle_Tests
{
	[Fact]
	public void Array_ReturnsShuffledArray()
	{
		// Arrange
		var array = Enumerable.Range(0, 100).ToArray();

		// Act
		var result = array.Shuffle();

		// Assert
		Assert.NotEqual(array, result);
	}

	[Fact]
	public void Null_Input__Returns_Empty_Array()
	{
		// Arrange

		// Act
		var result = ArrayExtensions.Shuffle<int>(null!);

		// Assert
		Assert.Empty(result);
	}
}
