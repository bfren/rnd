// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System;
using System.Linq;
using System.Text;

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
		/// Retrieve EFF's long word list
		/// https://www.eff.org/deeplinks/2016/07/new-wordlists-random-passphrases
		/// </summary>
		internal static readonly Lazy<string[]> LongWordList = new(
			() => GetWordList(Properties.Resources.eff_long_word_list)
		);

		/// <summary>
		/// Convert a byte arry into a list of words
		/// </summary>
		/// <param name="bytes">Input byte array</param>
		internal static string[] GetWordList(byte[] bytes)
		{
			// Return empty array
			if (bytes.Length == 0)
			{
				return Array.Empty<string>();
			}

			// Read the words into a list
			var words = Encoding.ASCII.GetString(bytes);
			var list = from w in words.Split(Environment.NewLine)
					   where !string.IsNullOrEmpty(w)
					   select w;

			// Return as an array
			return list.ToArray();
		}
	}
}
