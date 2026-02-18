// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System;
using System.Security.Cryptography;

namespace RndF;

/// <summary>
/// Default Random Number Generator.
/// </summary>
public sealed class DefaultRng : IRng
{
	private const int StackAllocThreshold = 256;

	/// <inheritdoc/>
	public byte[] GetBytes(int length)
	{
		// Check threshold to avoid stack overflow
		if (length <= StackAllocThreshold)
		{
			Span<byte> byteSpan = stackalloc byte[length];
			RandomNumberGenerator.Fill(byteSpan);
			return byteSpan.ToArray();
		}

		// Safely get more bytes than StackAllocThreshold
		var byteArray = new byte[length];
		RandomNumberGenerator.Fill(byteArray);
		return byteArray;
	}
}
