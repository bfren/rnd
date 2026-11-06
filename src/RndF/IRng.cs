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
	/// <remarks>
	/// The default body only exists so implementations written before this method keep working;
	/// implement it to avoid the array allocation.
	/// </remarks>
	/// <param name="buffer">The buffer to fill.</param>
	void Fill(Span<byte> buffer) =>
		GetBytes(buffer.Length).CopyTo(buffer);
}
