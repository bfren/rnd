// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Functions.StringF_Tests.CharacterClasses_Tests;

public class NoClasses_Tests
{
	[Fact]
	public void No_Classes_Enabled()
	{
		// Arrange

		// Act
		var result = Rnd.StringF.CharacterClasses.NoClasses;

		// Assert
		Assert.False(result.Lower);
		Assert.False(result.Upper);
		Assert.False(result.Numbers);
		Assert.False(result.Special);
	}
}
