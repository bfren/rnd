// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System;
using RndF.Exceptions;

namespace RndF;

/// <summary>
/// Random generator functions - very useful for testing
/// </summary>
public static partial class Rnd
{
	/// <summary>
	/// 'Flip a coin' - generate a random true / false
	/// </summary>
	public static bool Flip =>
		BooleanF.Get();

	/// <summary>
	/// Generate a random Guid
	/// </summary>
#pragma warning disable CA1720 // Identifier contains type name
	public static Guid Guid =>
		GuidF.Get();
#pragma warning restore CA1720 // Identifier contains type name

	/// <summary>
	/// Generate a random passphrase with eight dictionary words all starting with an uppercase
	/// letter, and one number
	/// </summary>
	public static string Pass =>
		StringF.Passphrase().Unwrap(r => throw new InvalidPassphraseException(r));

	/// <summary>
	/// Generate a random string 6 characters long, containing uppercase and lowercase letters,
	/// but no numbers or special characters
	/// </summary>
	public static string Str =>
		StringF.Get(6);

	#region DateTime

	/// <summary>
	/// Generate a random Date between the year 1 and the year 9999
	/// </summary>
	public static DateOnly Date =>
		DateF.Get();

	/// <summary>
	/// Generate a random DateTime (UTC) between the year 1 and the year 9999
	/// </summary>
	public static DateTime DateTime =>
		DateTimeF.Get();

	/// <summary>
	/// Generate a random Time between 00:00 and 23:59
	/// </summary>
	public static TimeOnly Time =>
		TimeF.Get();

	#endregion DateTime

	#region Numbers

	/// <summary>
	/// Generate a random double-precision floating-point number between 0 and 10000
	/// </summary>
	public static double Dbl =>
		NumberF.GetDouble(max: 10000d);

	/// <summary>
	/// Generate a random single-precision floating-point number between 0 and 10000
	/// </summary>
	public static float Flt =>
		NumberF.GetSingle(max: 10000f);

	/// <summary>
	/// Generate a random 32-bit integer between 0 and 10000
	/// </summary>
#pragma warning disable CA1720 // Identifier contains type name
	public static int Int =>
		NumberF.GetInt32(max: 10000);
#pragma warning restore CA1720 // Identifier contains type name

	/// <summary>
	/// Generate a random 64-bit integer between 0 and 10000
	/// </summary>
	public static long Lng =>
		NumberF.GetInt64(max: 10000L);

	/// <summary>
	/// Generate a random 32-bit unsigned integer between 0 and 10000
	/// </summary>
#pragma warning disable CA1720 // Identifier contains type name
	public static uint UInt =>
		NumberF.GetUInt32(max: 10000u);
#pragma warning restore CA1720 // Identifier contains type name

	/// <summary>
	/// Generate a random 64-bit unsigned integer between 0 and 10000
	/// </summary>
	public static ulong ULng =>
		NumberF.GetUInt64(max: 10000UL);

	#endregion Numbers

	#region Classes

	/// <summary>Random boolean functions</summary>
	public static partial class BooleanF { }

	/// <summary>Random Byte functions</summary>
	public static partial class ByteF { }

	/// <summary>Random Date functions</summary>
	public static partial class DateF { }

	/// <summary>Random DateTime functions</summary>
	public static partial class DateTimeF { }

	/// <summary>Random Guid functions</summary>
	public static partial class GuidF { }

	/// <summary>Random number functions</summary>
	public static partial class NumberF
	{
		internal static string MinimumMustBeLessThanMaximum { get; } = "{0}(): Minimium value '{1}' must be less than maximum value '{2}'.";

		internal static string MinimumMustBeAtLeastZero { get; } = "{0}(): Minimum value '{1}' must be at least 0.";
	}

	/// <summary>Random string functions</summary>
	public static partial class StringF { }

	/// <summary>Random Time functions</summary>
	public static partial class TimeF { }

	#endregion Classes
}
