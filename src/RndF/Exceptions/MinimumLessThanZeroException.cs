// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System;
using System.Globalization;

namespace RndF.Exceptions;

/// <summary>
/// Used in random number functions, e.g. <see cref="Rnd.NumberF.GetDouble(double, double)"/>
/// </summary>
public sealed class MinimumLessThanZeroException : Exception
{
	/// <summary>
	/// Create exception
	/// </summary>
	public MinimumLessThanZeroException() { }

	/// <summary>
	/// Create exception with message
	/// </summary>
	/// <param name="message"></param>
	public MinimumLessThanZeroException(string message) : base(message) { }

	/// <summary>
	/// Create exception with message and inner exception
	/// </summary>
	/// <param name="message"></param>
	/// <param name="inner"></param>
	public MinimumLessThanZeroException(string message, Exception inner) : base(message, inner) { }

	/// <summary>
	/// Create exception with formatted string
	/// </summary>
	/// <typeparam name="T">Number type</typeparam>
	/// <param name="method">Method name</param>
	/// <param name="min">Requested minimum value</param>
	public static MinimumLessThanZeroException Create<T>(string method, T min) =>
		new(string.Format(CultureInfo.InvariantCulture, Rnd.NumberF.MinimumMustBeAtLeastZero, method, min));
}
