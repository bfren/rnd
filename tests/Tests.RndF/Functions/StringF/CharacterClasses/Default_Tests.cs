// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Functions.StringF_Tests.CharacterClasses_Tests;

public class Default_Tests
{
	[Fact]
	public void Upper_And_Lower_Classes_Enabled()
	{
		// Arrange

		// Act
		var result = Rnd.StringF.CharacterClasses.Default;

		// Assert
		Assert.True(result.Lower);
		Assert.True(result.Upper);
		Assert.False(result.Numbers);
		Assert.False(result.Special);
	}
}
