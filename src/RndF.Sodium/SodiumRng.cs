// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Sodium;

/// <summary>
/// LibSodium Random Number Generator.
/// </summary>
public sealed class SodiumRng : IRng
{
	/// <inheritdoc/>
	public byte[] GetBytes(int length) =>
		global::Sodium.SodiumCore.GetRandomBytes(length);
}
