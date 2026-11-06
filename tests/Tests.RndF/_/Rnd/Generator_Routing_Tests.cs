// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests;

[Collection(nameof(Rnd.Generator))] // don't run alongside Generator_Tests, which expects DefaultRng
public class Generator_Routing_Tests
{
	public static TheoryData<string> Functions =>
		["Flip", "Date", "DateTime", "Time", "Shuffle", "Double"];

	[Theory]
	[MemberData(nameof(Functions))]
	public void Uses_Generator(string function)
	{
		// Arrange
		Action act = function switch
		{
			"Flip" =>
				() => _ = Rnd.Flip,

			"Date" =>
				() => _ = Rnd.Date,

			"DateTime" =>
				() => _ = Rnd.DateTime,

			"Time" =>
				() => _ = Rnd.Time,

			"Shuffle" =>
				() => _ = Rnd.For(3, i => i).Shuffle(),

			_ =>
				() => _ = Rnd.Double
		};
		var original = Rnd.Generator;
		Rnd.Generator = new CountingRng();

		try
		{
			// Act
			var before = CountingRng.Calls;
			act();

			// Assert
			Assert.True(CountingRng.Calls > before);
		}
		finally
		{
			Rnd.Generator = original;
		}
	}

	private sealed class CountingRng : IRng
	{
		// Count per thread, so tests running on other threads at the same time don't affect the result
		[ThreadStatic]
		private static int calls;

		public static int Calls =>
			calls;

		private readonly DefaultRng inner = new();

		public byte[] GetBytes(int length)
		{
			calls++;
			return inner.GetBytes(length);
		}

		public void Fill(Span<byte> buffer)
		{
			calls++;
			inner.Fill(buffer);
		}
	}
}
