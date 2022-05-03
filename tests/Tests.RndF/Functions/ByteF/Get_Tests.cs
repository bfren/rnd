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
	public void Returns_Byte_Array_Of_Length(int length)
	{
		// Arrange

		// Act
		var result = Rnd.ByteF.Get(length);

		// Assert
		Assert.Equal(length, result.Length);
	}

	[Fact]
	public void Returns_Different_Bytes_Each_Time()
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
