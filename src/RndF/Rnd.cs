// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System;

namespace RndF;

/// <summary>
/// Random generator functions - very useful for testing.
/// </summary>
public static partial class Rnd
{
#pragma warning disable CA1720 // Identifier contains type name

	/// <summary>
	/// Random Number Generator
	/// </summary>
	public static IRng Generator { get; set; } =
		new DefaultRng();

	/// <inheritdoc cref="BooleanF.Get()"/>
	public static bool Flip =>
		BooleanF.Get();

	/// <inheritdoc cref="CharF.Get(ushort, ushort)"/>
	public static char Char =>
		CharF.Get(48, 122);

	/// <inheritdoc cref="GuidF.Get"/>
	public static Guid Guid =>
		GuidF.Get();

	/// <inheritdoc cref="StringF.Passphrase()"/>
	public static string Pass =>
		StringF.Passphrase();

	/// <inheritdoc cref="StringF.Get(int)"/>
	public static string Str =>
		StringF.Get(6);

#pragma warning restore CA1720 // Identifier contains type name
}
