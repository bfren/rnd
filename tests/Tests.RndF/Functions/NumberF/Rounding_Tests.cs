// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.NumberF_Tests;

[Collection(nameof(Rnd.Generator))] // swaps the generator
public class Rounding_Tests
{
	// These pairs round min + (max - min) up past max
	[Fact]
	public void GetSingle_Never_Exceeds_Max() =>
		Assert.True(WithTopFraction(() => Rnd.NumberF.GetSingle(2.5605469f, 57807.24f)) <= 57807.24f);

	[Fact]
	public void GetDouble_Never_Exceeds_Max() =>
		Assert.True(WithTopFraction(() => Rnd.NumberF.GetDouble(0.3785265406493687, 0.9929587808404857)) <= 0.9929587808404857);

	private static T WithTopFraction<T>(Func<T> act)
	{
		var original = Rnd.Generator;
		Rnd.Generator = new TopRng();
		TopRng.Active = true;
		try
		{
			return act();
		}
		finally
		{
			TopRng.Active = false;
			Rnd.Generator = original;
		}
	}

	// Makes NumberF.Get() return 1.0 on this thread only, so tests on other threads still get real random bytes
	private sealed class TopRng : IRng
	{
		[field: ThreadStatic]
		public static bool Active { get; set; }

		private readonly DefaultRng inner = new();

		public byte[] GetBytes(int length)
		{
			var bytes = new byte[length];
			Fill(bytes);
			return bytes;
		}

		public void Fill(Span<byte> buffer)
		{
			if (!Active)
			{
				inner.Fill(buffer);
				return;
			}

			// long.MaxValue in little-endian
			buffer.Fill(0xFF);
			buffer[^1] = 0x7F;
		}
	}
}
