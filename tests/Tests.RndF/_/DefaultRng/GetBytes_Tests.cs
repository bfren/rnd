// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.DefaultRng_Tests;

public class GetBytes_Tests
{
	[Fact]
	public void returns_byte_array_of_requested_length()
	{
		// Arrange
		var rng = new DefaultRng();
		var length = 16;

		// Act
		var result = rng.GetBytes(length);

		// Assert
		Assert.Equal(length, result.Length);
	}

	[Theory]
	[InlineData(1)]
	[InlineData(4)]
	[InlineData(8)]
	[InlineData(32)]
	[InlineData(64)]
	public void returns_byte_array_of_correct_length_for_various_sizes(int length)
	{
		// Arrange
		var rng = new DefaultRng();

		// Act
		var result = rng.GetBytes(length);

		// Assert
		Assert.Equal(length, result.Length);
	}

	[Fact]
	public void returns_different_bytes_each_time()
	{
		// Arrange
		var rng = new DefaultRng();
		var iterations = 100;
		var results = new List<byte[]>();

		// Act
		var result = Enumerable.Range(0, iterations).Select(_ => rng.GetBytes(8)).Distinct().Count();

		// Assert
		Assert.Equal(iterations, result);
	}
}
