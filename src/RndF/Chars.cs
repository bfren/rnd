// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF;

/// <summary>
/// Character classes.
/// </summary>
public enum Chars
{
	/// <summary>
	/// No characters.
	/// </summary>
	None = 0,

	/// <summary>
	/// Numbers 0-9.
	/// </summary>
	Number = 1 << 0,

	/// <summary>
	/// Letters a-z.
	/// </summary>
	Lower = 1 << 1,

	/// <summary>
	/// Letters A-Z.
	/// </summary>
	Upper = 1 << 2,

	/// <summary>
	/// Special characters <c>! # @ + - * ^ = : ; $ ~ ` | % ?</c>.
	/// </summary>
	Special = 1 << 3,

	/// <summary>
	/// Hexadecimal digits 0-9 and A-F.
	/// </summary>
	Hexademical = 1 << 4,

	/// <summary>
	/// Numbers, letters and special characters (hexadecimal digits are already included).
	/// </summary>
	All = Number | Lower | Upper | Special,

	/// <summary>
	/// Letters a-z, A-Z.
	/// </summary>
	Letters = Lower | Upper
}
