// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

#if NET8_0_OR_GREATER
using System.Text;
#endif

namespace RndF;

public static partial class Rnd
{
	/// <summary>Random string functions.</summary>
	public static partial class StringF
	{
		internal const string NotEnoughClasses =
			"You must include at least one character class.";

#if NET8_0_OR_GREATER
		internal static CompositeFormat PassphraseNotLongEnough =>
			CompositeFormat.Parse("Passphrases must contain at least {0} words.");

		internal static CompositeFormat PassphraseTooLong =>
			CompositeFormat.Parse("You cannot request more words than the word list contains ({0}).");
#else
		internal const string PassphraseNotLongEnough =
			"Passphrases must contain at least {0} words.";

		internal const string PassphraseTooLong =
			"You cannot request more words than the word list contains ({0}).";
#endif

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
