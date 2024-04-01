// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System;
using System.Globalization;

namespace RndF.Exceptions;

/// <summary>
/// Used when something goes wrong while generating a Passphrase.
/// </summary>
/// <param name="message">Exception message.</param>
public sealed class InvalidPassphraseException(string message) : Exception(message)
{
	internal static InvalidPassphraseException PassphraseNotLongEnough(int minimum) =>
		new(string.Format(CultureInfo.InvariantCulture, Rnd.StringF.PassphraseNotLongEnough, minimum));

	internal static InvalidPassphraseException PassphraseTooLong(int maximum) =>
		new(string.Format(CultureInfo.InvariantCulture, Rnd.StringF.PassphraseTooLong, maximum));

	internal static InvalidPassphraseException WordListCannotBeEmpty() =>
		new(Rnd.StringF.WordListCannotBeEmpty);

	internal static InvalidPassphraseException WordListCannotBeNull() =>
		new(Rnd.StringF.WordListCannotBeNull);
}
