// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System;
using MaybeF;

namespace RndF.Exceptions;

/// <summary>
/// See <see cref="Rnd.Pass"/>
/// </summary>
public sealed class InvalidPassphraseException : Exception
{
	/// <summary>
	/// Create exception
	/// </summary>
	public InvalidPassphraseException() { }

	/// <summary>
	/// Create exception with reason
	/// </summary>
	/// <param name="reason"></param>
	public InvalidPassphraseException(IMsg reason) : this(reason.ToString() ?? string.Empty) { }

	/// <summary>
	/// Create exception with message
	/// </summary>
	/// <param name="message"></param>
	public InvalidPassphraseException(string message) : base(message) { }

	/// <summary>
	/// Create exception with message and inner exception
	/// </summary>
	/// <param name="message"></param>
	/// <param name="inner"></param>
	public InvalidPassphraseException(string message, Exception inner) : base(message, inner) { }
}
