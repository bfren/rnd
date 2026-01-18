// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System;

namespace RndF;

/// <summary>
/// Random generator functions - very useful for testing.
/// </summary>
public static partial class Rnd
{
	/// <summary>
	/// Random Number Generator
	/// </summary>
	public static IRng Generator { get; set; } = new DefaultRng();

	/// <inheritdoc cref="BooleanF.Get()"/>
	public static bool Flip =>
		BooleanF.Get();

	/// <inheritdoc cref="CharF.Get(ushort, ushort)"/>
#pragma warning disable CA1720 // Identifier contains type name
	public static char Char =>
		CharF.Get(48, 122);
#pragma warning restore CA1720 // Identifier contains type name

	/// <inheritdoc cref="GuidF.Get"/>
#pragma warning disable CA1720 // Identifier contains type name
	public static Guid Guid =>
		GuidF.Get();
#pragma warning restore CA1720 // Identifier contains type name

	/// <inheritdoc cref="StringF.Passphrase()"/>
	public static string Pass =>
		StringF.Passphrase();

	/// <inheritdoc cref="StringF.Get(int)"/>
	public static string Str =>
		StringF.Get(6);

	#region DateTime

	/// <inheritdoc cref="DateF.Get"/>
	public static DateOnly Date =>
		DateF.Get();

	/// <inheritdoc cref="DateTimeF.Get"/>
	public static DateTime DateTime =>
		DateTimeF.Get();

	/// <inheritdoc cref="TimeF.Get"/>
	public static TimeOnly Time =>
		TimeF.Get();

	#endregion DateTime

	#region Numbers

	/// <inheritdoc cref="NumberF.GetDouble()"/>
	public static double Dbl =>
		NumberF.GetDouble(max: 10000d);

	/// <inheritdoc cref="NumberF.GetSingle()"/>
	public static float Flt =>
		NumberF.GetSingle(max: 10000f);

	/// <inheritdoc cref="NumberF.GetInt16()"/>
	public static short Sht =>
		NumberF.GetInt16(max: 10000);

	/// <inheritdoc cref="NumberF.GetInt32()"/>
#pragma warning disable CA1720 // Identifier contains type name
	public static int Int =>
		NumberF.GetInt32(max: 10000);
#pragma warning restore CA1720 // Identifier contains type name

	/// <inheritdoc cref="NumberF.GetInt64()"/>
	public static long Lng =>
		NumberF.GetInt64(max: 10000L);

	/// <inheritdoc cref="NumberF.GetUIntPtr()"/>
#pragma warning disable CA1720 // Identifier contains type name
	public static nint Ptr =>
		NumberF.GetIntPtr(max: 10000);
#pragma warning restore CA1720 // Identifier contains type name

	/// <inheritdoc cref="NumberF.GetUInt16()"/>
	public static ushort USht =>
		NumberF.GetUInt16(max: 10000);

	/// <inheritdoc cref="NumberF.GetUInt32()"/>
#pragma warning disable CA1720 // Identifier contains type name
	public static uint UInt =>
		NumberF.GetUInt32(max: 10000u);
#pragma warning restore CA1720 // Identifier contains type name

	/// <inheritdoc cref="NumberF.GetUInt64()"/>
	public static ulong ULng =>
		NumberF.GetUInt64(max: 10000UL);

	/// <inheritdoc cref="NumberF.GetUIntPtr()"/>
#pragma warning disable CA1720 // Identifier contains type name
	public static nuint UPtr =>
		NumberF.GetUIntPtr(max: 10000);
#pragma warning restore CA1720 // Identifier contains type name

	#endregion Numbers
}
