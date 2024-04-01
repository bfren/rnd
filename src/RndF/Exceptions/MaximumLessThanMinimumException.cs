// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System;
using System.Globalization;

namespace RndF.Exceptions;

/// <summary>
/// Used in random number functions when a maximum value is not greater than minimum.
/// </summary>
/// <param name="message">See <see cref="Rnd.NumberF.MaximumMustBeGreaterThanMinimum"/>.</param>
public sealed class MaximumLessThanMinimumException(string message) : Exception(message)
{
	internal static MaximumLessThanMinimumException Create<T>(string method, T min, T max) =>
		new(string.Format(CultureInfo.InvariantCulture, Rnd.NumberF.MaximumMustBeGreaterThanMinimum, method, max, min));
}
