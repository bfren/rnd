// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System;
using System.Globalization;

namespace RndF.Exceptions;

/// <summary>
/// Used in random number functions, e.g. <see cref="Rnd.NumberF.GetDouble(double, double)"/>
/// </summary>
public sealed class MinimumMoreThanMaximumException : Exception
{
	/// <summary>
	/// Create exception
	/// </summary>
	public MinimumMoreThanMaximumException() { }

	/// <summary>
	/// Create exception with message
	/// </summary>
	/// <param name="message"></param>
	public MinimumMoreThanMaximumException(string message) : base(message) { }

	/// <summary>
	/// Create exception with message and inner exception
	/// </summary>
	/// <param name="message"></param>
	/// <param name="inner"></param>
	public MinimumMoreThanMaximumException(string message, Exception inner) : base(message, inner) { }

	/// <summary>
	/// Create exception with formatted string
	/// </summary>
	/// <typeparam name="T">Number type</typeparam>
	/// <param name="method">Method name</param>
	/// <param name="min">Requested minimum value</param>
	/// <param name="max">Requested maximum value</param>
	public static MinimumMoreThanMaximumException Create<T>(string method, T min, T max) =>
		new(string.Format(CultureInfo.InvariantCulture, Rnd.NumberF.MinimumMustBeLessThanMaximum, method, min, max));
}
