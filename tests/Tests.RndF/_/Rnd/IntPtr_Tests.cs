// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests;

public class IntPtr_Tests
{
	[Fact]
	public void Returns_Value_In_Range()
	{
		// Arrange
		var iterations = 1000;
		const nint min = 10000;
		const nint max = 19999;

		// Act
		var result = Rnd.For(iterations, () => Rnd.IntPtr);

		// Assert
		Assert.True(result.All(v => v is >= min and <= max));
	}
}
