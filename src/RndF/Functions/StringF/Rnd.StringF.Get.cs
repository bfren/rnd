// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System.Collections.Generic;
using System.Numerics;
using RndF.Exceptions;

namespace RndF;

public static partial class Rnd
{
	public static partial class StringF
	{
		/// <summary>
		/// Create a random string of letters (a-z and A-Z) - see <see cref="Chars.Letters"/>.
		/// </summary>
		/// <param name="length">The length of the new random string.</param>
		/// <remarks>
		/// The string contains at least one character from each class in <see cref="Chars.Letters"/>.
		/// </remarks>
		/// <returns>Random string.</returns>
		/// <exception cref="InvalidCharsException">
		/// <paramref name="length"/> is less than <c>2</c>, so there is no room for both cases.
		/// </exception>
		public static string Get(int length) =>
			Get(length, Chars.Letters);

		/// <summary>
		/// Create a random string from the specified character classes.
		/// </summary>
		/// <param name="length">The length of the new random string.</param>
		/// <param name="classes">The character classes to include.</param>
		/// <remarks>
		/// The string contains at least one character from each class in <paramref name="classes"/>.
		/// </remarks>
		/// <returns>Random string.</returns>
		/// <exception cref="InvalidCharsException">
		/// <paramref name="length"/> is less than <c>1</c>, <paramref name="classes"/> is <see cref="Chars.None"/>,
		/// or <paramref name="length"/> is less than the number of classes in <paramref name="classes"/>.
		/// </exception>
		public static string Get(int length, Chars classes)
		{
			if (length < 1)
			{
				throw InvalidCharsException.LengthMustBePositive();
			}

			// Ignore undefined flags
			classes &= Chars.All | Chars.Hexademical;
			if (classes == Chars.None)
			{
				throw InvalidCharsException.NotEnoughClasses();
			}

			// There must be room for one character from each class
			if (BitOperations.PopCount((uint)classes) > length)
			{
				throw InvalidCharsException.TooManyClasses();
			}

			// Add one character from each class, so every class appears at least once
			var result = new char[length];
			var count = 0;
			foreach (var c in CharClasses)
			{
				if ((classes & c) == c)
				{
					result[count++] = GetOneOf(GetClassChars(c));
				}
			}

			// Fill the rest from all the classes - if two threads build the same pool at once, both build the same array
			var pool = Pools[(int)classes] ??= BuildPool(classes);
			while (count < length)
			{
				result[count++] = GetOneOf(pool);
			}

			// Return random string
			ArrayExtensions.ShuffleInPlace(result);
			return new(result);
		}

		/// <summary>
		/// Each character class, in the order one character from each is added.
		/// </summary>
		private static readonly Chars[] CharClasses =
			[Chars.Number, Chars.Lower, Chars.Upper, Chars.Special, Chars.Hexademical];

		/// <summary>
		/// Characters to choose from for each combination of classes, indexed by the <see cref="Chars"/> value and
		/// built on first use.
		/// </summary>
		private static readonly char[]?[] Pools =
			new char[(int)(Chars.All | Chars.Hexademical) + 1][];

		/// <summary>
		/// Build the characters to choose from for <paramref name="classes"/>.
		/// </summary>
		/// <param name="classes">Character classes.</param>
		/// <returns>Every character in <paramref name="classes"/> once (a set, because Hexademical overlaps Number and Upper).</returns>
		private static char[] BuildPool(Chars classes)
		{
			var chars = new HashSet<char>();
			foreach (var c in CharClasses)
			{
				if ((classes & c) == c)
				{
					chars.UnionWith(GetClassChars(c));
				}
			}

			return [.. chars];
		}

		/// <summary>
		/// Get the characters in a single class.
		/// </summary>
		/// <param name="c">Character class.</param>
		/// <returns>Characters in <paramref name="c"/>.</returns>
		private static char[] GetClassChars(Chars c) =>
			c switch
			{
				Chars.Number =>
					NumberChars,
				Chars.Lower =>
					LowercaseChars,
				Chars.Upper =>
					UppercaseChars,
				Chars.Special =>
					SpecialChars,
				_ =>
					HexadecimalChars
			};

		/// <summary>
		/// Return a random character from <paramref name="list"/>.
		/// </summary>
		/// <param name="list">Characters to choose from.</param>
		/// <returns>Random character.</returns>
		private static char GetOneOf(char[] list) =>
			list[NumberF.GetInRange(0, list.Length - 1)];
	}
}
