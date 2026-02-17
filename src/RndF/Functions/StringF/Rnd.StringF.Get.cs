// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System.Collections.Generic;
using RndF.Exceptions;

namespace RndF;

public static partial class Rnd
{
	public static partial class StringF
	{
		/// <summary>
		/// Create a random string using default character groups - see <see cref="Chars.Letters"/>.
		/// </summary>
		/// <param name="length">The length of the new random string.</param>
		/// <returns>Random string.</returns>
		/// <exception cref="InvalidCharsException"/>
		public static string Get(int length) =>
			Get(length, Chars.Letters);

		/// <summary>
		/// Create a random string using specified character groups.
		/// </summary>
		/// <remarks>
		/// Lowercase letters will always be used.
		/// </remarks>
		/// <param name="length">The length of the new random string.</param>
		/// <param name="classes">The character classes to include.</param>
		/// <returns>Random string.</returns>
		/// <exception cref="InvalidCharsException"/>
		public static string Get(int length, Chars classes)
		{
			// Setup
			var random = new List<char>();

			void appendOneOf(char[] list) =>
				random.Add(list[NumberF.GetInt32(max: list.Length - 1)]);

			// Check whether or not we have a valid selection of character classes
			if (classes == Chars.None)
			{
				throw InvalidCharsException.NotEnoughClasses();
			}

			// Array of characters to use
			var useChars = new List<char>();

			// Add numbers
			if ((classes & Chars.Number) == Chars.Number)
			{
				useChars.AddRange(NumberChars);
				appendOneOf(NumberChars);
			}

			// Add lowercase letters
			if ((classes & Chars.Lower) == Chars.Lower)
			{
				useChars.AddRange(LowercaseChars);
				appendOneOf(LowercaseChars);
			}

			// Add uppercase letters
			if ((classes & Chars.Upper) == Chars.Upper)
			{
				useChars.AddRange(UppercaseChars);
				appendOneOf(UppercaseChars);
			}

			// Add special characters
			if ((classes & Chars.Special) == Chars.Special)
			{
				useChars.AddRange(SpecialChars);
				appendOneOf(SpecialChars);
			}

			// Add hexadecimal characters
			if ((classes & Chars.Hexademical) == Chars.Hexademical)
			{
				useChars.AddRange(HexadecimalChars);
				appendOneOf(HexadecimalChars);
			}

			// If the array is now bigger than the requested length, throw an exception
			if (random.Count > length)
			{
				throw InvalidCharsException.TooManyClasses();
			}

			// Generate the rest of the random characters
			while (random.Count < length)
			{
				appendOneOf([.. useChars]);
			}

			// Return random string
			return new(random.ToArray().Shuffle());
		}
	}
}
