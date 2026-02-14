// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests;

public class Properties_Tests
{
	[Fact]
	public void generator_returns_default_rng_by_default()
	{
		// Arrange

		// Act
		var result = Rnd.Generator;

		// Assert
		Assert.IsType<DefaultRng>(result);
	}

	[Fact]
	public void generator_can_be_set_to_custom_rng()
	{
		// Arrange
		var original = Rnd.Generator;
		var custom = new TestRng();

		try
		{
			// Act
			Rnd.Generator = custom;

			// Assert
			Assert.Same(custom, Rnd.Generator);
		}
		finally
		{
			Rnd.Generator = original;
		}
	}

	[Fact]
	public void custom_rng_is_used_by_byte_generation()
	{
		// Arrange
		var original = Rnd.Generator;
		var custom = new TestRng();

		try
		{
			Rnd.Generator = custom;

			// Act
			var result = Rnd.ByteF.Get(4);

			// Assert
			Assert.Equal([0xAB, 0xAB, 0xAB, 0xAB], result);
		}
		finally
		{
			Rnd.Generator = original;
		}
	}

	private sealed class TestRng : IRng
	{
		public byte[] GetBytes(int length)
		{
			var bytes = new byte[length];
			Array.Fill(bytes, (byte)0xAB);
			return bytes;
		}
	}

	[Fact]
	public void flip_returns_boolean()
	{
		// Arrange
		var iterations = 100;
		var values = new List<bool>();

		// Act
		for (var i = 0; i < iterations; i++)
		{
			values.Add(Rnd.Flip);
		}

		// Assert
		Assert.Equal(2, values.Distinct().Count());
	}

	[Fact]
	public void char_returns_char_in_valid_range()
	{
		// Arrange
		var iterations = 1000;
		var values = new List<char>();

		// Act
		for (var i = 0; i < iterations; i++)
		{
			values.Add(Rnd.Char);
		}

		// Assert
		Assert.True(values.All(c => c >= (char)48 && c <= (char)122));
	}

	[Fact]
	public void guid_returns_unique_guids()
	{
		// Arrange
		var iterations = 100;
		var values = new List<Guid>();

		// Act
		for (var i = 0; i < iterations; i++)
		{
			values.Add(Rnd.Guid);
		}

		// Assert
		Assert.Equal(iterations, values.Distinct().Count());
	}

	[Fact]
	public void pass_returns_non_empty_string()
	{
		// Arrange

		// Act
		var result = Rnd.Pass;

		// Assert
		Assert.NotNull(result);
		Assert.NotEmpty(result);
	}

	[Fact]
	public void str_returns_string_of_length_six()
	{
		// Arrange

		// Act
		var result = Rnd.Str;

		// Assert
		Assert.Equal(6, result.Length);
	}

	[Fact]
	public void date_returns_valid_date()
	{
		// Arrange

		// Act
		var result = Rnd.Date;

		// Assert
		Assert.True(result >= DateOnly.MinValue);
		Assert.True(result <= DateOnly.MaxValue);
	}

	[Fact]
	public void datetime_returns_valid_datetime()
	{
		// Arrange

		// Act
		var result = Rnd.DateTime;

		// Assert
		Assert.True(result >= System.DateTime.MinValue);
		Assert.True(result <= System.DateTime.MaxValue);
	}

	[Fact]
	public void time_returns_valid_time()
	{
		// Arrange

		// Act
		var result = Rnd.Time;

		// Assert
		Assert.True(result >= TimeOnly.MinValue);
		Assert.True(result <= TimeOnly.MaxValue);
	}

	[Fact]
	public void int32_returns_value_in_range()
	{
		// Arrange
		var iterations = 1000;
		var values = new List<int>();

		// Act
		for (var i = 0; i < iterations; i++)
		{
			values.Add(Rnd.Int32);
		}

		// Assert
		Assert.True(values.All(v => v >= 0 && v <= 10000));
	}

	[Fact]
	public void int_returns_same_range_as_int32()
	{
		// Arrange
		var iterations = 1000;
		var values = new List<int>();

		// Act
		for (var i = 0; i < iterations; i++)
		{
			values.Add(Rnd.Int);
		}

		// Assert
		Assert.True(values.All(v => v >= 0 && v <= 10000));
	}

	[Fact]
	public void int64_returns_value_in_range()
	{
		// Arrange
		var iterations = 1000;
		var values = new List<long>();

		// Act
		for (var i = 0; i < iterations; i++)
		{
			values.Add(Rnd.Int64);
		}

		// Assert
		Assert.True(values.All(v => v >= 0 && v <= 10000L));
	}

	[Fact]
	public void lng_returns_same_range_as_int64()
	{
		// Arrange
		var iterations = 1000;
		var values = new List<long>();

		// Act
		for (var i = 0; i < iterations; i++)
		{
			values.Add(Rnd.Lng);
		}

		// Assert
		Assert.True(values.All(v => v >= 0 && v <= 10000L));
	}

	[Fact]
	public void single_returns_value_in_range()
	{
		// Arrange
		var iterations = 1000;
		var values = new List<float>();

		// Act
		for (var i = 0; i < iterations; i++)
		{
			values.Add(Rnd.Single);
		}

		// Assert
		Assert.True(values.All(v => v >= 0f && v <= 10000f));
	}

	[Fact]
	public void flt_returns_same_range_as_single()
	{
		// Arrange
		var iterations = 1000;
		var values = new List<float>();

		// Act
		for (var i = 0; i < iterations; i++)
		{
			values.Add(Rnd.Flt);
		}

		// Assert
		Assert.True(values.All(v => v >= 0f && v <= 10000f));
	}

	[Fact]
	public void double_returns_value_in_range()
	{
		// Arrange
		var iterations = 1000;
		var values = new List<double>();

		// Act
		for (var i = 0; i < iterations; i++)
		{
			values.Add(Rnd.Double);
		}

		// Assert
		Assert.True(values.All(v => v >= 0d && v <= 10000d));
	}

	[Fact]
	public void uint32_returns_value_in_range()
	{
		// Arrange
		var iterations = 1000;
		var values = new List<uint>();

		// Act
		for (var i = 0; i < iterations; i++)
		{
			values.Add(Rnd.UInt32);
		}

		// Assert
		Assert.True(values.All(v => v <= 10000u));
	}

	[Fact]
	public void uint64_returns_value_in_range()
	{
		// Arrange
		var iterations = 1000;
		var values = new List<ulong>();

		// Act
		for (var i = 0; i < iterations; i++)
		{
			values.Add(Rnd.UInt64);
		}

		// Assert
		Assert.True(values.All(v => v <= 10000UL));
	}

	[Fact]
	public void int16_returns_value_in_range()
	{
		// Arrange
		var iterations = 1000;
		var values = new List<short>();

		// Act
		for (var i = 0; i < iterations; i++)
		{
			values.Add(Rnd.Int16);
		}

		// Assert
		Assert.True(values.All(v => v >= 0 && v <= 10000));
	}

	[Fact]
	public void uint16_returns_value_in_range()
	{
		// Arrange
		var iterations = 1000;
		var values = new List<ushort>();

		// Act
		for (var i = 0; i < iterations; i++)
		{
			values.Add(Rnd.UInt16);
		}

		// Assert
		Assert.True(values.All(v => v <= 10000));
	}

	[Fact]
	public void int128_returns_value_in_range()
	{
		// Arrange
		var iterations = 1000;
		var values = new List<Int128>();

		// Act
		for (var i = 0; i < iterations; i++)
		{
			values.Add(Rnd.Int128);
		}

		// Assert
		Assert.True(values.All(v => v >= 0 && v <= 10000));
	}

	[Fact]
	public void uint128_returns_value_in_range()
	{
		// Arrange
		var iterations = 1000;
		var values = new List<UInt128>();

		// Act
		for (var i = 0; i < iterations; i++)
		{
			values.Add(Rnd.UInt128);
		}

		// Assert
		Assert.True(values.All(v => v <= 10000));
	}

	[Fact]
	public void intptr_returns_value_in_range()
	{
		// Arrange
		var iterations = 1000;
		var values = new List<nint>();

		// Act
		for (var i = 0; i < iterations; i++)
		{
			values.Add(Rnd.IntPtr);
		}

		// Assert
		Assert.True(values.All(v => v >= 0 && v <= 10000));
	}

	[Fact]
	public void uintptr_returns_value_in_range()
	{
		// Arrange
		var iterations = 1000;
		var values = new List<nuint>();

		// Act
		for (var i = 0; i < iterations; i++)
		{
			values.Add(Rnd.UIntPtr);
		}

		// Assert
		Assert.True(values.All(v => v <= 10000));
	}
}
