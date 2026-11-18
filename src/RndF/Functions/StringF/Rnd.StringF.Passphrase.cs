// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using RndF.Exceptions;

namespace RndF;

public static partial class Rnd
{
	public static partial class StringF
	{
		/// <summary>
		/// Default passphrase separator character.
		/// </summary>
		internal const char DefaultSeparator = '-';

		/// <summary>
		/// Generate a random passphrase of eight words from <see cref="ShortWordList"/>, a modified (i.e. with British
		/// spellings) form of EFF's Short Word List, with unique three-character prefixes.
		/// </summary>
		/// <remarks>
		/// Words are separated by <c>-</c>, start with an upper-case letter, and two of them have a random digit added
		/// at the start or end - see <see cref="Passphrase(IReadOnlyList{string}, int, char, bool, bool)"/>.
		/// See https://www.eff.org/deeplinks/2016/07/new-wordlists-random-passphrases.
		/// </remarks>
		/// <returns>Random passphrase.</returns>
		public static string Passphrase() =>
			Passphrase(ShortWordList.Value, 8, DefaultSeparator, true, true);

		/// <summary>
		/// Generate a random passphrase from <see cref="LongWordList"/>, a modified (i.e. with British spellings) form of
		/// EFF's Long Word List, with higher entropy for use with fewer words.
		/// </summary>
		/// <remarks>
		/// Words are separated by <c>-</c>, start with an upper-case letter, and one word in every five has a random
		/// digit added at the start or end - see <see cref="Passphrase(IReadOnlyList{string}, int, char, bool, bool)"/>.
		/// See https://www.eff.org/deeplinks/2016/07/new-wordlists-random-passphrases.
		/// </remarks>
		/// <param name="numberOfWords">The number of words in the passphrase, at least <c>2</c>.</param>
		/// <returns>Random passphrase.</returns>
		/// <exception cref="InvalidPassphraseException">
		/// <paramref name="numberOfWords"/> is less than <c>2</c> or more than the number of words in the list.
		/// </exception>
		public static string Passphrase(int numberOfWords) =>
			Passphrase(numberOfWords, DefaultSeparator, true, true);

		/// <summary>
		/// Generate a random passphrase from <see cref="LongWordList"/>, a modified (i.e. with British spellings) form of
		/// EFF's Long Word List, with higher entropy for use with fewer words.
		/// </summary>
		/// <remarks>
		/// See <see cref="Passphrase(IReadOnlyList{string}, int, char, bool, bool)"/> for how the options are applied.
		/// See https://www.eff.org/deeplinks/2016/07/new-wordlists-random-passphrases.
		/// </remarks>
		/// <param name="numberOfWords">The number of words in the passphrase, at least <c>2</c>.</param>
		/// <param name="separator">Word separator.</param>
		/// <param name="upperFirst">Whether to make the first letter of each word upper case.</param>
		/// <param name="includeNumber">
		/// Whether to add a random digit (0-9) to the start or end of the first word and every fifth word after it.
		/// </param>
		/// <returns>Random passphrase.</returns>
		/// <exception cref="InvalidPassphraseException">
		/// <paramref name="numberOfWords"/> is less than <c>2</c> or more than the number of words in the list.
		/// </exception>
		public static string Passphrase(int numberOfWords, char separator, bool upperFirst, bool includeNumber) =>
			Passphrase(LongWordList.Value, numberOfWords, separator, upperFirst, includeNumber);

		/// <summary>
		/// Generate a random passphrase from the specified <paramref name="wordList"/>.
		/// </summary>
		/// <remarks>
		/// Each word is used at most once. Words are numbered before the list is shuffled, so the words with a digit
		/// can appear anywhere in the passphrase.
		/// </remarks>
		/// <param name="wordList">List of words to use for the passphrase.</param>
		/// <param name="numberOfWords">
		/// The number of words in the passphrase, from <c>2</c> to the number of words in <paramref name="wordList"/>.
		/// </param>
		/// <param name="separator">Word separator.</param>
		/// <param name="upperFirst">Whether to make the first letter of each word upper case.</param>
		/// <param name="includeNumber">
		/// Whether to add a random digit (0-9) to the start or end of the first word and every fifth word after it.
		/// </param>
		/// <returns>Random passphrase.</returns>
		/// <exception cref="InvalidPassphraseException">
		/// <paramref name="wordList"/> is <see langword="null"/>, empty or contains a <see langword="null"/> or empty
		/// word, or <paramref name="numberOfWords"/> is out of range.
		/// </exception>
		public static string Passphrase(
			IReadOnlyList<string> wordList,
			int numberOfWords,
			char separator,
			bool upperFirst,
			bool includeNumber
		)
		{
			// Word list cannot be null
			if (wordList is null)
			{
				throw InvalidPassphraseException.WordListCannotBeNull();
			}

			// Check word list length
			if (wordList.Count == 0)
			{
				throw InvalidPassphraseException.WordListCannotBeEmpty();
			}

			// Every word must have at least one character (GetWordList already drops empty words from the built-in lists)
			var isBuiltIn = wordList is ImmutableArray<string> list && (list == ShortWordList.Value || list == LongWordList.Value);
			if (!isBuiltIn && wordList.Any(string.IsNullOrEmpty))
			{
				throw InvalidPassphraseException.WordListCannotContainEmptyWords();
			}

			// Check for minimum number of words
			if (numberOfWords < MinimumPassphraseWords)
			{
				throw InvalidPassphraseException.PassphraseNotLongEnough(MinimumPassphraseWords);
			}

			// Number of words cannot be higher than the word list
			if (numberOfWords > wordList.Count)
			{
				throw InvalidPassphraseException.PassphraseTooLong(wordList.Count);
			}

			// Pre-allocated arrays for the correct number of words
			var used = new HashSet<int>(numberOfWords);
			var words = new string[numberOfWords];
			for (var i = 0; i < numberOfWords; i++)
			{
				// Get the index of a word that hasn't been used yet
				var unique = getUniqueIndex();

				var word = wordList[unique];

				// Make the first letter uppercase
				if (upperFirst)
				{
					word = char.ToUpperInvariant(word[0]) + word[1..];
				}

				// Add a number to the first word and every fifth word after that
				// (the list will be shuffled later)
				if (includeNumber && (i % 5 == 0))
				{
					var num = NumberF.GetIntPtr(0, 9);
					word = Flip switch
					{
						true =>
							$"{word}{num}",

						false =>
							$"{num}{word}"
					};
				}

				// Add the word to the list
				words[i] = word;
			}

			// Shuffle the words
			ArrayExtensions.ShuffleInPlace(words);

			// Return passphrase joined by separator
			return string.Join(separator, words);

			// Get a random array index that hasn't been used before
			int getUniqueIndex()
			{
				int index;
				do
				{
					index = NumberF.GetInt32(0, wordList.Count - 1);
				}
				while (!used.Add(index));

				return index;
			}
		}
	}
}
