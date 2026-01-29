// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System.Text;

namespace RndF;

public static partial class Rnd
{
	/// <summary>Random string functions.</summary>
	public static partial class StringF
	{
		internal const string NotEnoughClasses =
			"You must include at least one character class.";

		internal static CompositeFormat PassphraseNotLongEnough =>
			CompositeFormat.Parse("Passphrases must contain at least {0} words.");

		internal static CompositeFormat PassphraseTooLong =>
			CompositeFormat.Parse("You cannot request more words than the word list contains ({0}).");

		internal const string TooManyClasses =
			"Using requested character groups results in a string longer than the one requested.";

		internal const string WordListCannotBeEmpty =
			"The word list cannot be empty.";

		internal const string WordListCannotBeNull =
			"The word list cannot be null.";

		/// <summary>
		/// Passphrases must contain at least this many words.
		/// </summary>
		internal const int MinimumPassphraseWords = 2;

		/// <summary>
		/// Combine character classes.
		/// </summary>
		static StringF() =>
			AllChars = [.. NumberChars, .. LowercaseChars, .. UppercaseChars, .. SpecialChars];
	}
}
