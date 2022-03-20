// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System;
using System.Linq;

namespace RndF;

public static partial class Rnd
{
	public static partial class StringF
	{
		/// <summary>
		/// Retrieve EFF's short word list, with unique three-character prefixes
		/// See https://www.eff.org/deeplinks/2016/07/new-wordlists-random-passphrases
		/// </summary>
		internal static readonly Lazy<string[]> ShortWordList = new(
			() => GetWordList(Properties.Resources.eff_short_word_list)
		);

		/// <summary>
		/// Retrieve EFF's long word list, with higher entropy for use with fewer words
		/// See https://www.eff.org/deeplinks/2016/07/new-wordlists-random-passphrases
		/// </summary>
		internal static readonly Lazy<string[]> LongWordList = new(
			() => GetWordList(Properties.Resources.eff_long_word_list)
		);

		/// <summary>
		/// Convert a byte arry into a list of words
		/// </summary>
		/// <param name="input">Input byte array</param>
		internal static string[] GetWordList(string input)
		{
			// Return empty array
			if (input.Length == 0)
			{
				return Array.Empty<string>();
			}

			// Read the words into a list
			var list = from w in input.Split(Environment.NewLine)
					   where !string.IsNullOrEmpty(w)
					   select w;

			// Return as an array
			return list.ToArray();
		}
	}
}
