// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System;

namespace RndF.Sodium;

/// <summary>
/// LibSodium Random Number Generator.
/// </summary>
public sealed class SodiumRng : IRng
{
	/// <inheritdoc/>
	public byte[] GetBytes(int length) =>
		global::Sodium.SodiumCore.GetRandomBytes(length);

	/// <inheritdoc/>
	// shortcut: allocates an array per call because Sodium.Core has no span API, switch to one if it adds it
	public void Fill(Span<byte> buffer) =>
		GetBytes(buffer.Length).CopyTo(buffer);
}
