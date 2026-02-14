// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.NumberF_Tests;

public class Get_Tests
{
	[Fact]
	public void never_returns_out_of_bounds() =>
		Helpers.CheckBounds(Rnd.NumberF.Get, 0, 1);

	[Fact]
	public void all_zero_bytes_returns_zero()
	{
		// Arrange
		var original = Rnd.Generator;

		try
		{
			Rnd.Generator = new ZeroBytesRng();

			// Act
			var result = Rnd.NumberF.Get();

			// Assert
			Assert.Equal(0d, result);
		}
		finally
		{
			Rnd.Generator = original;
		}
	}

	[Fact]
	public void all_max_bytes_returns_one()
	{
		// Arrange
		var original = Rnd.Generator;

		try
		{
			Rnd.Generator = new MaxBytesRng();

			// Act
			var result = Rnd.NumberF.Get();

			// Assert
			Assert.Equal(1d, result);
		}
		finally
		{
			Rnd.Generator = original;
		}
	}

	[Fact]
	public void handles_negative_int64_from_bytes()
	{
		// Arrange
		// 0x80 in the high byte produces a negative Int64 via BitConverter
		var original = Rnd.Generator;

		try
		{
			Rnd.Generator = new NegativeInt64Rng();

			// Act
			var result = Rnd.NumberF.Get();

			// Assert
			Assert.InRange(result, 0d, 1d);
		}
		finally
		{
			Rnd.Generator = original;
		}
	}

	private sealed class ZeroBytesRng : IRng
	{
		public byte[] GetBytes(int length) => new byte[length];
	}

	private sealed class MaxBytesRng : IRng
	{
		public byte[] GetBytes(int length)
		{
			var bytes = new byte[length];
			Array.Fill(bytes, byte.MaxValue);
			return bytes;
		}
	}

	private sealed class NegativeInt64Rng : IRng
	{
		public byte[] GetBytes(int length)
		{
			var bytes = new byte[length];
			// Set only the high byte to 0x80 so BitConverter.ToInt64 returns a negative value
			if (length >= 8)
			{
				bytes[7] = 0x80;
			}

			return bytes;
		}
	}
}
