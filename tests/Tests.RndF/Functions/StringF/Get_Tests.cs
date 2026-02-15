// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using RndF.Exceptions;
using static RndF.Rnd.StringF;

namespace RndF.Rnd_Tests.StringF_Tests;

public class Get_Tests
{
	public class with_length
	{
		public class length_less_than_two
		{
			public static TheoryData<int> Length =>
				[-1, 0, 1];

			[Theory]
			[MemberData(nameof(Length))]
			public void throws_InvalidCharsException(int length)
			{
				// Arrange

				// Act
				var result = Record.Exception(() => Get(length));

				// Assert
				var ex = Assert.IsType<InvalidCharsException>(result);
				Assert.Equal(TooManyClasses, ex.Message);
			}
		}

		[Fact]
		public void returns_string_of_correct_length()
		{
			// Arrange
			var length = Rnd.NumberF.GetInt32(min: 2, max: 40);

			// Act
			var result = Get(length);

			// Assert
			Assert.Equal(length, result.Length);
		}

		[Fact]
		public void returns_string_containing_only_letters()
		{
			// Arrange
			var length = Rnd.NumberF.GetInt32(min: 200, max: 400);

			// Act
			var result = Get(length);

			// Assert
			Assert.All(result,
				c => Assert.True(LowercaseChars.Contains(c) || UppercaseChars.Contains(c))
			);
		}
	}

	public class with_length_and_classes
	{
		public class length_less_than_classes_length
		{
			public static TheoryData<int, Chars> LengthAndClasses =>
				[
					(1, Chars.Letters),
					(2, Chars.Number | Chars.Special | Chars.Hexademical),
					(3, Chars.All)
				];

			[Theory]
			[MemberData(nameof(LengthAndClasses))]
			public void throws_InvalidCharsException(int length, Chars classes)
			{
				// Arrange

				// Act
				var result = Record.Exception(() => Get(length, classes));

				// Assert
				var ex = Assert.IsType<InvalidCharsException>(result);
				Assert.Equal(TooManyClasses, ex.Message);
			}
		}

		public class classes_none
		{
			[Fact]
			public void throws_InvalidCharsException()
			{
				// Arrange
				var length = Rnd.NumberF.GetInt32(min: 2, max: 40);

				// Act
				var result = Record.Exception(() => Get(length, Chars.None));

				// Assert
				var ex = Assert.IsType<InvalidCharsException>(result);
				Assert.Equal(NotEnoughClasses, ex.Message);
			}
		}

		[Fact]
		public void returns_string_of_correct_length()
		{
			// Arrange
			var length = Rnd.NumberF.GetInt32(min: 2, max: 40);

			// Act
			var result = Get(length);

			// Assert
			Assert.Equal(length, result.Length);
		}

		public static TheoryData<Chars, char[]> ClassesAndChars =>
			[
				(Chars.Number, Helpers.Chars.Numbers),
				(Chars.Lower, Helpers.Chars.Lowercase),
				(Chars.Upper, Helpers.Chars.Uppercase),
				(Chars.Special, Helpers.Chars.Special),
				(Chars.Hexademical, Helpers.Chars.Hexadecimal),
				(Chars.Letters, Helpers.Chars.Letters),
				(Chars.All, Helpers.Chars.All)
			];

		[Theory]
		[MemberData(nameof(ClassesAndChars))]
		public void returns_string_containing_correct_classes(Chars classes, char[] allowed)
		{
			// Arrange
			var length = Rnd.NumberF.GetInt32(min: 200, max: 400);

			// Act
			var result = Get(length, classes);

			// Assert
			Assert.All(result, c => Assert.Contains(c, allowed));
		}
	}
}
