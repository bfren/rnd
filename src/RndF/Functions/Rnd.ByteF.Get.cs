// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System;
using System.Security.Cryptography;

namespace RndF;

public static partial class Rnd
{
	public static partial class ByteF
	{
		/// <summary>
		/// Return an array of cryptographically secure random bytes.
		/// </summary>
		/// <param name="length">The length of the byte array.</param>
		/// <returns>Array of random bytes.</returns>
		public static byte[] Get(int length)
		{
			// Return empty array
			if (length == 0)
			{
				return [];
			}

			// Get random bytes
			Span<byte> bytes = stackalloc byte[length];
			RandomNumberGenerator.Fill(bytes);
			return bytes.ToArray();
		}
	}
}
