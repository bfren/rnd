// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System;
using System.Globalization;

namespace RndF.Exceptions;

/// <summary>
/// Used in random number functions when a minimum value of less than zero is used.
/// </summary>
/// <param name="message">See <see cref="Rnd.NumberF.MinimumMustBeAtLeastZero"/>.</param>
public sealed class MinimumLessThanZeroException(string message) : Exception(message)
{
	internal static MinimumLessThanZeroException Create<T>(string method, T min) =>
		new(string.Format(CultureInfo.InvariantCulture, Rnd.NumberF.MinimumMustBeAtLeastZero, method, min));
}
