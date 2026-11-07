// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using RndF.Exceptions;
using static RndF.Rnd.StringF;

namespace RndF.Rnd_Tests.StringF_Tests;

public class Get_Tests
{
	public class with_length
	{
		public class length_less_than_one
		{
			public static TheoryData<int> Length =>
				[-1, 0];

			[Theory]
			[MemberData(nameof(Length))]
			public void throws_InvalidCharsException(int length)
			{
				// Arrange

				// Act
				var result = Record.Exception(() => Get(length));

				// Assert
				var ex = Assert.IsType<InvalidCharsException>(result);
				Assert.Equal(LengthMustBePositive, ex.Message);
			}
		}

		public class length_one
		{
			[Fact]
			public void throws_InvalidCharsException()
			{
				// Arrange

				// Act
				var result = Record.Exception(() => Get(1));

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

		public class hexadecimal_with_number
		{
			[Fact]
			public void does_not_favour_overlapping_characters()
			{
				// Arrange: Number adds 0-9 and Hexademical adds 0-9 again, plus A-F
				var counts = new Dictionary<char, int>();

				// Act
				for (var i = 0; i < 16; i++)
				{
					foreach (var c in Get(10_000, Chars.Number | Chars.Hexademical))
					{
						counts[c] = counts.GetValueOrDefault(c) + 1;
					}
				}

				// Assert: expect ~10,000 each; counting 0-9 twice gave ~12,300 for digits and ~6,150 for A-F
				Assert.Equal(16, counts.Count);
				Assert.All(counts.Values, n => Assert.InRange(n, 9_000, 11_000));
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
