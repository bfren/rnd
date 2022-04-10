// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System;
using System.Collections.Generic;

namespace RndF;

public static partial class Rnd
{
	public static partial class StringF
	{
		/// <summary>
		/// List of all characters
		/// </summary>
		public static List<char> AllChars { get; }

		/// <summary>
		/// List of lowercase characters
		/// </summary>
		public static List<char> LowercaseChars { get; }

		/// <summary>
		/// List of uppercase characters
		/// </summary>
		public static List<char> UppercaseChars { get; }

		/// <summary>
		/// List of numeric characters
		/// </summary>
		public static List<char> NumberChars { get; }

		/// <summary>
		/// List of special characters
		/// </summary>
		public static List<char> SpecialChars { get; }

		/// <summary>
		/// Fill character lists
		/// </summary>
		static StringF()
		{
			LowercaseChars = new List<char>();
			for (var i = 97; i <= 122; i++)
			{
				LowercaseChars.Add(Convert.ToChar(i));
			}

			UppercaseChars = new List<char>();
			for (var i = 65; i <= 90; i++)
			{
				UppercaseChars.Add(Convert.ToChar(i));
			}

			NumberChars = new List<char>();
			for (var i = 48; i <= 57; i++)
			{
				NumberChars.Add(Convert.ToChar(i));
			}

			// Don't include % so we don't confuse SQL databases
			SpecialChars = new List<char>(new[] { '!', '#', '@', '+', '-', '*', '^', '=', ':', ';', '£', '$', '~', '`', '¬', '|' });

			AllChars = new List<char>();
			AllChars.AddRange(LowercaseChars);
			AllChars.AddRange(UppercaseChars);
			AllChars.AddRange(NumberChars);
			AllChars.AddRange(SpecialChars);
		}

		/// <summary>
		/// Create a random string using default character groups - see <see cref="CharacterClasses.DefaultClasses"/>
		/// </summary>
		/// <param name="length">The length of the new random string</param>
		public static string Get(int length) =>
			Get(length, CharacterClasses.DefaultClasses);

		/// <summary>
		/// Create a random string using specified character groups (none are enabled by default)
		/// </summary>
		/// <remarks>
		/// If you don't enable any character classes, you will get an exception
		/// </remarks>
		/// <param name="length">The length of the new random string</param>
		/// <param name="chars">The character classes to include</param>
		public static string Get(int length, SelectCharacterClasses chars) =>
			Get(length, chars(CharacterClasses.NoClasses));

		/// <summary>
		/// Create a random string using specified character groups
		/// Lowercase letters will always be used
		/// </summary>
		/// <param name="length">The length of the new random string</param>
		/// <param name="classes">The character classes to include</param>
		/// <exception cref="InvalidOperationException"></exception>
		internal static string Get(int length, CharacterClasses classes)
		{
			// Setup
			var random = new List<char>();

			if (!classes.IsValid)
			{
				throw new InvalidOperationException("You must include at least one character class.");
			}

			// Array of characters to use
			var useChars = new List<char>();

			// Add lowercase characters
			if (classes.Lower)
			{
				useChars.AddRange(LowercaseChars);
				appendOneOf(LowercaseChars);
			}

			// Add uppercase characters
			if (classes.Upper)
			{
				useChars.AddRange(UppercaseChars);
				appendOneOf(UppercaseChars);
			}

			// Add numbers
			if (classes.Numbers)
			{
				useChars.AddRange(NumberChars);
				appendOneOf(NumberChars);
			}

			// Add special characters
			if (classes.Special)
			{
				useChars.AddRange(SpecialChars);
				appendOneOf(SpecialChars);
			}

			// If the array is now bigger than the requested length, throw an exception
			if (random.Count > length)
			{
				throw new InvalidOperationException("Using requested character groups results in a string longer than the one requested.");
			}

			// Generate the rest of the random characters
			while (random.Count < length)
			{
				appendOneOf(useChars);
			}

			// Return random string
			return new(random.ToArray().Shuffle());

			// Append one of the characters in list to the random string
			void appendOneOf(List<char> list)
			{
				var index = NumberF.GetInt32(max: list.Count - 1);
				random.Add(list[index]);
			}
		}

		/// <summary>
		/// Return the character classes to use for a random string - see <see cref="Get(int, SelectCharacterClasses)"/>
		/// </summary>
		/// <param name="chars"></param>
		public delegate CharacterClasses SelectCharacterClasses(CharacterClasses chars);

		/// <summary>
		/// Character classes - at least one character class must be included
		/// </summary>
		/// <param name="Lower">If true (default) lowercase letters will be included</param>
		/// <param name="Upper">If true (default) uppercase letters will be included</param>
		/// <param name="Numbers">If true numbers will be included</param>
		/// <param name="Special">If true special characters will be included</param>
		public sealed record class CharacterClasses(
			bool Lower,
			bool Upper,
			bool Numbers,
			bool Special
		)
		{
			/// <inheritdoc cref="AllClasses"/>
			public CharacterClasses All =>
				AllClasses;

			/// <summary>
			/// Returns all character classes
			/// </summary>
			internal static CharacterClasses AllClasses =>
				new(true, true, true, true);

			/// <summary>
			/// Returns no character classes
			/// </summary>
			internal static CharacterClasses NoClasses =>
				new(false, false, false, false);

			/// <summary>
			/// Returns default character classes:
			///		<see cref="Lower"/> = true
			///		<see cref="Upper"/> = true
			///		<see cref="Numbers"/> = false
			///		<see cref="Special"/> = false
			/// </summary>
			internal static CharacterClasses DefaultClasses =>
				new(true, true, false, false);

			/// <summary>
			/// Returns true if at least one character class is enabled
			/// </summary>
			internal bool IsValid =>
				Lower || Upper || Numbers || Special;
		}
	}
}
