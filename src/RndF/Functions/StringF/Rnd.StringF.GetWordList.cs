// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System;
using System.Collections.Immutable;

namespace RndF;

public static partial class Rnd
{
	public static partial class StringF
	{
		/// <summary>
		/// Modified (i.e. with British spellings) form of EFF's Short Word List,
		/// with unique three-character prefixes.
		/// </summary>
		/// <remarks>
		/// See https://www.eff.org/deeplinks/2016/07/new-wordlists-random-passphrases.
		/// </remarks>
		public static readonly Lazy<ImmutableArray<string>> ShortWordList = new(
			() => GetWordList(Properties.Resources.eff_short_word_list)
		);

		/// <summary>
		/// Modified (i.e. with British spellings) form of EFF's Long Word List,
		/// with higher entropy for use with fewer words.
		/// </summary>
		/// <remarks>
		/// See https://www.eff.org/deeplinks/2016/07/new-wordlists-random-passphrases.
		/// </remarks>
		public static readonly Lazy<ImmutableArray<string>> LongWordList = new(
			() => GetWordList(Properties.Resources.eff_long_word_list)
		);

		/// <summary>
		/// Split a comma-separated string into an array of trimmed, non-empty words.
		/// </summary>
		/// <param name="input">Comma-separated words.</param>
		/// <returns>Array of words, or an empty array when <paramref name="input"/> is <see langword="null"/> or white space.</returns>
		internal static ImmutableArray<string> GetWordList(string input)
		{
			// Return empty array
			if (string.IsNullOrWhiteSpace(input))
			{
				return ImmutableArray<string>.Empty;
			}

			// Split the input string into a list of words
			return [.. input.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)];
		}
	}
}
