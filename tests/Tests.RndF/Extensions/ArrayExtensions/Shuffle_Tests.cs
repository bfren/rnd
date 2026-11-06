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
			[Theory]
			[InlineData(0)]
			[InlineData(1)]
			public void returns_original_array(int count)
			{
				// Arrange
				var array = Rnd.For(count, () => Rnd.Int);

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
		public void returns_every_order_equally_often()
		{
			// Arrange
			int[] array = [1, 2, 3];
			var counts = new Dictionary<string, int>();

			// Act
			for (var i = 0; i < 60_000; i++)
			{
				var order = string.Join(',', array.Shuffle());
				counts[order] = counts.GetValueOrDefault(order) + 1;
			}

			// Assert: expect ~10,000 for each of the 6 orders (standard deviation ~91);
			// Sattolo's variant never returns 4 of them, and the naive 'any index' shuffle favours some
			Assert.Equal(6, counts.Count);
			Assert.All(counts.Values, n => Assert.InRange(n, 9_000, 11_000));
		}

		[Fact]
		public void does_not_modify_original_array()
		{
			// Arrange
			var array = Enumerable.Range(Rnd.Int32, 100).ToArray();
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
			var array = Rnd.For(50, () => Rnd.Str);

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
			var array = Rnd.For(50, x => new { Id = x, Name = $"item-{x}" });

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
