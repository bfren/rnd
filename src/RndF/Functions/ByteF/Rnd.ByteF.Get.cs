// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF;

public static partial class Rnd
{
	public static partial class ByteF
	{
		/// <summary>
		/// Return an array of random bytes from <see cref="Generator"/>.
		/// </summary>
		/// <param name="length">The length of the byte array.</param>
		/// <returns>Array of random bytes, or an empty array when <paramref name="length"/> is <c>0</c> or less.</returns>
		public static byte[] Get(int length)
		{
			// Return empty array
			if (length <= 0)
			{
				return [];
			}

			// Get random bytes
			return Generator.GetBytes(length);
		}
	}
}
