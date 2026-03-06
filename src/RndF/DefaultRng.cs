// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

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
		var byteArray = new byte[length];
		RandomNumberGenerator.Fill(byteArray);
		return byteArray;
	}
}
