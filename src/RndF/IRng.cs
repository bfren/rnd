// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System;

namespace RndF;

/// <summary>
/// Abstraction for Random Number Generators.
/// </summary>
public interface IRng
{
	/// <summary>
	/// Get random bytes.
	/// </summary>
	/// <param name="length">The length of the byte array.</param>
	/// <returns>Array of random bytes.</returns>
	byte[] GetBytes(int length);

	/// <summary>
	/// Fill <paramref name="buffer"/> with random bytes.
	/// </summary>
	/// <param name="buffer">The buffer to fill.</param>
	void Fill(Span<byte> buffer);
}
