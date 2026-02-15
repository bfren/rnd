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
			[Fact]
			public void returns_original_array()
			{
				// Arrange
				var array = new[] { Rnd.Int };

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
			var array = Enumerable.Range(Rnd.Int32, 100).ToArray();

			// Act
			var result = array.Shuffle();

			// Assert
			Assert.NotEqual(array, result);
		}

		[Fact]
		public void does_not_modify_original_array()
		{
			// Arrange
			var array = Enumerable.Range(0, 100).ToArray();
			var original = array.ToArray();

			// Act
			_ = array.Shuffle();

			// Assert
			Assert.Equal(original, array);
		}

		[Fact]
		public void shuffles_string_array()
		{
			// Arrange
			var array = Enumerable.Range(0, 50).Select(_ => Rnd.Str).ToArray();

			// Act
			var result = array.Shuffle();

			// Assert
			Assert.NotEqual(array, result);
			Assert.Equal(array.Length, result.Length);
		}

		[Fact]
		public void shuffles_object_array()
		{
			// Arrange
			var array = Enumerable.Range(0, 50).Select(i => new { Id = i, Name = $"item-{i}" }).ToArray();

			// Act
			var result = array.Shuffle();

			// Assert
			Assert.NotEqual(array, result);
			Assert.Equal(array.Length, result.Length);
		}

		[Fact]
		public void preserves_all_elements()
		{
			// Arrange
			var array = Enumerable.Range(0, 1000).ToArray();

			// Act
			var result = array.Shuffle();

			// Assert
			Assert.All(result, item => Assert.Contains(item, array));
		}

		[Fact]
		public void returns_null_string_input_as_empty_array()
		{
			// Arrange

			// Act
			var result = ArrayExtensions.Shuffle<string>(null!);

			// Assert
			Assert.Empty(result);
		}
	}
}
