// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Functions.StringF_Tests.CharacterClasses_Tests;

public class IsValid_Tests
{
	[Fact]
	public void With_No_Character_Classes_Returns_False()
	{
		// Arrange
		var options = new Rnd.StringF.CharacterClasses(false, false, false, false, false);

		// Act
		var result = options.IsValid;

		// Assert
		Assert.False(result);
	}

	[Theory]
	[InlineData(true, false, false, false, false)]
	[InlineData(false, true, false, false, false)]
	[InlineData(false, false, true, false, false)]
	[InlineData(false, false, false, true, false)]
	[InlineData(false, false, false, false, true)]
	public void With_At_Least_One_Character_Class_Returns_True(bool lower, bool upper, bool numbers, bool hexadecimal, bool special)
	{
		// Arrange
		var options = new Rnd.StringF.CharacterClasses(lower, upper, numbers, hexadecimal, special);

		// Act
		var result = options.IsValid;

		// Assert
		Assert.True(result);
	}
}
