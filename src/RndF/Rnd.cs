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
	/// Gets or sets the random number generator that supplies the random bytes for every function except
	/// <see cref="GuidF.Get"/>.
	/// </summary>
	/// <remarks>
	/// Defaults to <see cref="DefaultRng"/>, which is cryptographically secure.
	/// </remarks>
	public static IRng Generator { get; set; } =
		new DefaultRng();

	/// <summary>
	/// Gets a random <see langword="true"/> or <see langword="false"/> value.
	/// </summary>
	public static bool Flip =>
		BooleanF.Get();

	/// <summary>
	/// Gets a random character between <c>'0'</c> (U+0030) and <c>'z'</c> (U+007A) inclusive.
	/// </summary>
	/// <remarks>
	/// As well as digits and letters, the range includes <c>: ; &lt; = &gt; ? @ [ \ ] ^ _ `</c>.
	/// </remarks>
	public static char Char =>
		CharF.Get(48, 122);

	/// <inheritdoc cref="GuidF.Get"/>
	public static Guid Guid =>
		GuidF.Get();

	/// <summary>
	/// Gets a random passphrase of eight words from <see cref="StringF.ShortWordList"/>.
	/// </summary>
	/// <remarks>
	/// See <see cref="StringF.Passphrase()"/> for the format.
	/// </remarks>
	public static string Pass =>
		StringF.Passphrase();

	/// <summary>
	/// Gets a random string of six letters (a-z and A-Z), with at least one of each case.
	/// </summary>
	public static string Str =>
		StringF.Get(6);

#pragma warning restore CA1720 // Identifier contains type name
}
