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
	/// <inheritdoc/>
	public byte[] GetBytes(int length)
	{
		Span<byte> bytes = stackalloc byte[length];
		RandomNumberGenerator.Fill(bytes);
		return bytes.ToArray();
	}
}
