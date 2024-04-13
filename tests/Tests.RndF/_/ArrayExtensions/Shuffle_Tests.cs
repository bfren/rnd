// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.ArrayExtensions_Tests;

public class Shuffle_Tests
{
	public class when_input_is_null
	{
		[Fact]
		public void returns_empty_array()
		{
			// Arrange

			// Act
			var result = ArrayExtensions.Shuffle<int>(null!);

			// Assert
			Assert.Empty(result);
		}
	}

	public class when_input_is_array
	{
		public class and_contains_fewer_than_two_elements
		{
			public static TheoryData<int, int> Data =>
				new()
				{
				{ Rnd.Int, 0 },
				{ Rnd.Int, 1 }
				};

			[Theory]
			[MemberData(nameof(Data))]
			public void returns_original_array(int start, int count)
			{
				// Arrange
				var array = Enumerable.Range(start, count).ToArray();

				// Act
				var result = array.Shuffle();

				// Assert
				Assert.Same(array, result);
			}
		}

		[Fact]
		public void returns_shuffled_array()
		{
			// Arrange
			var array = Enumerable.Range(Rnd.Int, 100).ToArray();

			// Act
			var result = array.Shuffle();

			// Assert
			Assert.NotEqual(array, result);
		}
	}
}
