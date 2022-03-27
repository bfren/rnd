// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.StringF_Tests;

public class Get_Tests
{
	[Fact]
	public void Valid_Length_Returns_String()
	{
		// Arrange
		var length = Rnd.NumberF.GetInt32(min: 20, max: 40);

		// Act
		var r0 = Rnd.StringF.Get(length);
		var r1 = Rnd.StringF.Get(length, chars: c => c with { Lower = true });
		var r2 = Rnd.StringF.Get(length, classes: Rnd.StringF.CharacterClasses.All);

		// Assert
		Assert.Equal(length, r0.Length);
		Assert.Equal(length, r1.Length);
		Assert.Equal(length, r2.Length);
	}

	[Fact]
	public void Invalid_Length_Throws_InvalidOperationException()
	{
		// Arrange
		var length = 3;

		// Act
		var a0 = void () => Rnd.StringF.Get(length, chars: _ => Rnd.StringF.CharacterClasses.All);
		var a1 = void () => Rnd.StringF.Get(length, Rnd.StringF.CharacterClasses.All);

		// Assert
		Assert.Throws<InvalidOperationException>(a0);
		Assert.Throws<InvalidOperationException>(a1);
	}

	[Fact]
	public void Invalid_Options_Throws_InvalidOperationException()
	{
		// Arrange
		var length = Rnd.NumberF.GetInt32(min: 20, max: 40);

		// Act
		var a0 = void () => Rnd.StringF.Get(length, chars: _ => Rnd.StringF.CharacterClasses.None);
		var a1 = void () => Rnd.StringF.Get(length, classes: Rnd.StringF.CharacterClasses.None);

		// Assert
		Assert.Throws<InvalidOperationException>(a0);
		Assert.Throws<InvalidOperationException>(a1);
	}

	[Fact]
	public void Without_Classes_Returns_Only_Lowercase_And_Uppercase()
	{
		// Arrange
		var length = Rnd.NumberF.GetInt32(min: 20, max: 40);

		// Act
		var result = Rnd.StringF.Get(length);

		// Assert
		Assert.True(result.All(c => Rnd.StringF.LowercaseChars.Contains(c) || Rnd.StringF.UppercaseChars.Contains(c)));
	}

	[Fact]
	public void With_Classes_Returns_Only_Lowercase_And_Uppercase()
	{
		// Arrange
		var length = Rnd.NumberF.GetInt32(min: 20, max: 40);

		// Act
		var r0 = Rnd.StringF.Get(length, chars: _ => Rnd.StringF.CharacterClasses.Default);
		var r1 = Rnd.StringF.Get(length, classes: Rnd.StringF.CharacterClasses.Default);

		// Assert
		Assert.True(r0.All(c => Rnd.StringF.LowercaseChars.Contains(c) || Rnd.StringF.UppercaseChars.Contains(c)));
		Assert.True(r1.All(c => Rnd.StringF.LowercaseChars.Contains(c) || Rnd.StringF.UppercaseChars.Contains(c)));
	}

	[Fact]
	public void With_Classes_Returns_Only_Lowercase_Characters()
	{
		// Arrange
		var length = Rnd.NumberF.GetInt32(min: 20, max: 40);

		// Act
		var r0 = Rnd.StringF.Get(length, chars: c => c with { Lower = true });
		var r1 = Rnd.StringF.Get(length, classes: new(true, false, false, false));

		// Assert
		Assert.True(r0.All(Rnd.StringF.LowercaseChars.Contains));
		Assert.True(r1.All(Rnd.StringF.LowercaseChars.Contains));
	}

	[Fact]
	public void With_Classes_Returns_Only_Uppercase_Characters()
	{
		// Arrange
		var length = Rnd.NumberF.GetInt32(min: 20, max: 40);

		// Act
		var r0 = Rnd.StringF.Get(length, chars: c => c with { Upper = true });
		var r1 = Rnd.StringF.Get(length, classes: new(false, true, false, false));

		// Assert
		Assert.True(r0.All(Rnd.StringF.UppercaseChars.Contains));
		Assert.True(r1.All(Rnd.StringF.UppercaseChars.Contains));
	}

	[Fact]
	public void With_Classes_Returns_Only_Numeric_Characters()
	{
		// Arrange
		var length = Rnd.NumberF.GetInt32(min: 20, max: 40);

		// Act
		var r0 = Rnd.StringF.Get(length, chars: c => c with { Numbers = true });
		var r1 = Rnd.StringF.Get(length, classes: new(false, false, true, false));

		// Assert
		Assert.True(r0.All(Rnd.StringF.NumberChars.Contains));
		Assert.True(r1.All(Rnd.StringF.NumberChars.Contains));
	}

	[Fact]
	public void With_Classes_Returns_Only_Special_Characters()
	{
		// Arrange
		var length = Rnd.NumberF.GetInt32(min: 20, max: 40);

		// Act
		var r0 = Rnd.StringF.Get(length, chars: c => c with { Special = true });
		var r1 = Rnd.StringF.Get(length, classes: new(false, false, false, true));

		// Assert
		Assert.True(r0.All(Rnd.StringF.SpecialChars.Contains));
		Assert.True(r1.All(Rnd.StringF.SpecialChars.Contains));
	}

	[Fact]
	public void With_Classes_Returns_String_With_All_Characters()
	{
		// Arrange
		var length = Rnd.NumberF.GetInt32(min: 20, max: 40);

		// Act
		var r0 = Rnd.StringF.Get(length, chars: _ => Rnd.StringF.CharacterClasses.All);
		var r1 = Rnd.StringF.Get(length, classes: Rnd.StringF.CharacterClasses.All);

		// Assert
		Assert.False(r0.All(Rnd.StringF.LowercaseChars.Contains));
		Assert.False(r0.All(Rnd.StringF.UppercaseChars.Contains));
		Assert.False(r0.All(Rnd.StringF.NumberChars.Contains));
		Assert.False(r0.All(Rnd.StringF.SpecialChars.Contains));
		Assert.True(r0.All(Rnd.StringF.AllChars.Contains));
		Assert.False(r1.All(Rnd.StringF.LowercaseChars.Contains));
		Assert.False(r1.All(Rnd.StringF.UppercaseChars.Contains));
		Assert.False(r1.All(Rnd.StringF.NumberChars.Contains));
		Assert.False(r1.All(Rnd.StringF.SpecialChars.Contains));
		Assert.True(r1.All(Rnd.StringF.AllChars.Contains));
	}
}
