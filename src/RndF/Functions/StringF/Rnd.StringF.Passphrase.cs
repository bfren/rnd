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
		/// Default passphrase separator character.
		/// </summary>
		internal const char DefaultSeparator = '-';

		/// <summary>
		/// Generate a random passphrase using a modified (i.e. with British spellings) form of EFF's Short Word List,
		/// with unique three-character prefixes.
		/// </summary>
		/// <remarks>
		/// See https://www.eff.org/deeplinks/2016/07/new-wordlists-random-passphrases.
		/// </remarks>
		/// <inheritdoc cref="Passphrase(int, char, bool, bool)"/>
		public static string Passphrase() =>
			Passphrase(ShortWordList.Value, 8, DefaultSeparator, true, true);

		/// <inheritdoc cref="Passphrase(int, char, bool, bool)"/>
		public static string Passphrase(int numberOfWords) =>
			Passphrase(numberOfWords, DefaultSeparator, true, true);

		/// <summary>
		/// Generate a random passphrase using a modified (i.e. with British spellings) form of EFF's Long Word List,
		/// with unique three-character prefixes.
		/// </summary>
		/// <remarks>
		/// See https://www.eff.org/deeplinks/2016/07/new-wordlists-random-passphrases.
		/// </remarks>
		/// <inheritdoc cref="Passphrase(string[], int, char, bool, bool)"/>
		public static string Passphrase(int numberOfWords, char separator, bool upperFirst, bool includeNumber) =>
			Passphrase(LongWordList.Value, numberOfWords, separator, upperFirst, includeNumber);

		/// <summary>
		/// Generate a random passphrase using the specified <paramref name="wordList"/>.
		/// </summary>
		/// <param name="wordList">List of words to use for the passphrase.</param>
		/// <param name="numberOfWords">The number of words in the passphrase (see <see cref="MinimumPassphraseWords"/>).</param>
		/// <param name="separator">Word separator.</param>
		/// <param name="upperFirst">Whether or not to make the first letter of each word upper case.</param>
		/// <param name="includeNumber">Whether or not to include a number with one of the words.</param>
		/// <returns>Random passphrase.</returns>
		/// <exception cref="InvalidPassphraseException"/>
		public static string Passphrase(
			string[] wordList,
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
			if (wordList.Length == 0)
			{
				throw InvalidPassphraseException.WordListCannotBeEmpty();
			}

			// Check for minimum number of words
			if (numberOfWords < MinimumPassphraseWords)
			{
				throw InvalidPassphraseException.PassphraseNotLongEnough(MinimumPassphraseWords);
			}

			// Number of words cannot be higher than the word list
			if (numberOfWords > wordList.Length)
			{
				throw InvalidPassphraseException.PassphraseTooLong(wordList.Length);
			}

			// Get the right number of words
			var used = new List<int>();
			var words = new List<string>();
			for (var i = 0; i < numberOfWords; i++)
			{
				// Get the index of a word that hasn't been used yet
				var index = getUniqueIndex();
				used.Add(index);

				var word = wordList[index];

				// Make the first letter uppercase
				if (upperFirst)
				{
					word = word[0].ToString().ToUpperInvariant() + word[1..];
				}

				// Add a number to the first word and every fifth word after that
				// (the list will be shuffled later)
				if (includeNumber && (i % 5 == 0))
				{
					// We can use Unsafe().Unwrap() because the arguments 0 and 9 will not cause a Fail
					var num = NumberF.GetInt64(0, 9);
					word = Flip switch
					{
						true =>
							$"{word}{num}",

						false =>
							$"{num}{word}"
					};
				}

				// Add the word to the list
				words.Add(word);
			}

			// Shuffle the words
			var shuffled = words.ToArray().Shuffle();

			// Return joined
			return string.Join(separator, shuffled);

			// Get a random array index that hasn't been used before
			int getUniqueIndex()
			{
				int index;
				do
				{
					// We can use Unsafe().Unwrap() because the wordList length has already been checked
					index = NumberF.GetInt32(0, wordList.Length - 1);
				}
				while (used.Contains(index));

				return index;
			}
		}
	}
}
