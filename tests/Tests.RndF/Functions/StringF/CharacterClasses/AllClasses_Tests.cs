// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Functions.StringF_Tests.CharacterClasses_Tests;

public class AllClasses_Tests
{
	[Fact]
	public void All_Classes_Enabled()
	{
		// Arrange

		// Act
		var result = Rnd.StringF.CharacterClasses.AllClasses;

		// Assert
		Assert.True(result.Lower);
		Assert.True(result.Upper);
		Assert.True(result.Numbers);
		Assert.True(result.Special);
	}
}
