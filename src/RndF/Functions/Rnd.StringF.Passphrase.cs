// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System.Collections.Generic;
using MaybeF;

namespace RndF;

public static partial class Rnd
{
	public static partial class StringF
	{
		/// <summary>
		/// Default passphrase separator character
		/// </summary>
		internal const char DefaultSeparator = '-';

		/// <summary>
		/// Generate a random passphrase using the EFF short word list<br/>
		/// See https://www.eff.org/deeplinks/2016/07/new-wordlists-random-passphrases
		/// </summary>
		public static Maybe<string> Passphrase() =>
			Passphrase(ShortWordList.Value, 8, DefaultSeparator, true, true);

		/// <inheritdoc cref="Passphrase(int, char, bool, bool)"/>
		public static Maybe<string> Passphrase(int numberOfWords) =>
			Passphrase(numberOfWords, DefaultSeparator, true, true);

		/// <summary>
		/// Generate a random passphrase using the EFF long word list<br/>
		/// See https://www.eff.org/deeplinks/2016/07/new-wordlists-random-passphrases
		/// </summary>
		/// <inheritdoc cref="Passphrase(string[], int, char, bool, bool)"/>
		public static Maybe<string> Passphrase(int numberOfWords, char separator, bool upperFirst, bool includeNumber) =>
			Passphrase(LongWordList.Value, numberOfWords, separator, upperFirst, includeNumber);

		/// <summary>
		/// Generate a random passphrase
		/// </summary>
		/// <param name="wordList">List of words to use for the passphrase</param>
		/// <param name="numberOfWords">The number of words in the passphrase (minimum: 2)</param>
		/// <param name="separator">Word separator</param>
		/// <param name="upperFirst">Whether or not to make the first letter of each word upper case</param>
		/// <param name="includeNumber">Whether or not to include a number with one of the words</param>
		public static Maybe<string> Passphrase(
			string[] wordList,
			int numberOfWords,
			char separator,
			bool upperFirst,
			bool includeNumber
		)
		{
			// Number of words must be at least 2
			if (numberOfWords < 2)
			{
				return F.None<string, M.NumberOfWordsMustBeAtLeastTwoMsg>();
			}

			// Get word list
			if (wordList.Length == 0)
			{
				return F.None<string, M.EmptyWordListMsg>();
			}

			// Number of words cannot be higher than the word list
			if (numberOfWords > wordList.Length)
			{
				return F.None<string>(new M.NumberOfWordsCannotBeMoreThanWordListMsg(wordList.Length));
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

				// Add a number to the first word (the list will be shuffled later)
				if (includeNumber && i == 0)
				{
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
					index = NumberF.GetInt32(0, wordList.Length - 1);
				}
				while (used.Contains(index));

				return index;
			}
		}

		/// <summary>Messages</summary>
		public static class M
		{
			/// <summary>Number of words must be at least 2</summary>
			public sealed record class NumberOfWordsMustBeAtLeastTwoMsg : IMsg;

			/// <summary>Number of words must be less than length of word list</summary>
			/// <param name="Maximum">The maximum number of words</param>
			public sealed record class NumberOfWordsCannotBeMoreThanWordListMsg(int Maximum) : IMsg;

			/// <summary>The word list was empty</summary>
			public sealed record class EmptyWordListMsg : IMsg;
		}
	}
}
