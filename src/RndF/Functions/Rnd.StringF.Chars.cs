// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF;

public static partial class Rnd
{
	public static partial class StringF
	{
		/// <summary>
		/// Array of all characters.
		/// </summary>
		internal static char[] AllChars { get; }

		/// <summary>
		/// Array of lowercase characters.
		/// </summary>
		internal static char[] LowercaseChars =>
			['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'];

		/// <summary>
		/// Array of uppercase characters.
		/// </summary>
		internal static char[] UppercaseChars =>
			['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'];

		/// <summary>
		/// Array of numeric characters.
		/// </summary>
		internal static char[] NumberChars =>
			['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];

		/// <summary>
		/// Array of special characters.
		/// </summary>
		internal static char[] SpecialChars =>
			['!', '#', '@', '+', '-', '*', '^', '=', ':', ';', '£', '$', '~', '`', '¬', '|'];

		/// <summary>
		/// Array of hexademical characters.
		/// </summary>
		internal static char[] HexadecimalChars =>
			['0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'];

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
			/// Various special characters (excluding %).
			/// </summary>
			Special = 1 << 3,

			/// <summary>
			/// Hexademical 0-9, A-F.
			/// </summary>
			Hexademical = 1 << 4,

			/// <summary>
			/// All characters.
			/// </summary>
			All = Number | Lower | Upper | Special,

			/// <summary>
			/// Letters a-z, A-Z.
			/// </summary>
			Letters = Lower | Upper
		}
	}
}
