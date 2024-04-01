// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System;

namespace RndF.Exceptions;

/// <summary>
/// Used when something goes wrong while generating a random string.
/// </summary>
/// <param name="message">Exception message.</param>
public sealed class InvalidCharsException(string message) : Exception(message)
{
	internal static InvalidCharsException NotEnoughClasses() =>
		new(Rnd.StringF.NotEnoughClasses);

	internal static InvalidCharsException TooManyClasses() =>
		new(Rnd.StringF.TooManyClasses);
}
