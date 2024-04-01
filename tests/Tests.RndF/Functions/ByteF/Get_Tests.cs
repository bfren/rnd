// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.ByteF_Tests;

public class Get_Tests
{
	[Theory]
	[InlineData(0)]
	[InlineData(2)]
	[InlineData(4)]
	[InlineData(8)]
	[InlineData(16)]
	[InlineData(32)]
	[InlineData(64)]
	public void returns_byte_array_of_correct_length(int length)
	{
		// Arrange

		// Act
		var result = Rnd.ByteF.Get(length);

		// Assert
		Assert.Equal(length, result.Length);
	}

	[Fact]
	public void returns_random_bytes()
	{
		// Arrange
		var iterations = 10000;
		var bytes = new List<byte[]>();

		// Act
		for (var i = 0; i < iterations; i++)
		{
			bytes.Add(Rnd.ByteF.Get(4));
		}

		var result = bytes.Distinct().Count();

		// Assert
		Assert.Equal(bytes.Count, result);
	}
}
