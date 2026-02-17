// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System;

namespace RndF;

public static partial class Rnd
{
#pragma warning disable CA1720 // Identifier contains type name

	/// <inheritdoc cref="NumberF.GetSingle()"/>
	public static float Single =>
		NumberF.GetSingle(min: 10000f, max: 19999f);

	/// <inheritdoc cref="Single"/>
	public static float Flt =>
		Single;

	/// <inheritdoc cref="NumberF.GetDouble()"/>
	public static double Double =>
		NumberF.GetDouble(min: 10000d, max: 19999d);

	/// <inheritdoc cref="NumberF.GetInt16()"/>
	public static short Int16 =>
		NumberF.GetInt16(min: 10000, max: 19999);

	/// <inheritdoc cref="NumberF.GetInt32()"/>
	public static int Int32 =>
		NumberF.GetInt32(min: 10000, max: 19999);

	/// <inheritdoc cref="Int32"/>
	public static int Int =>
		Int32;

	/// <inheritdoc cref="NumberF.GetInt64()"/>
	public static long Int64 =>
		NumberF.GetInt64(min: 10000L, max: 19999L);

	/// <inheritdoc cref="Int64"/>
	public static long Lng =>
		Int64;

	/// <inheritdoc cref="NumberF.GetInt128()"/>
	public static Int128 Int128 =>
		NumberF.GetInt128(min: 10000L, max: 19999L);

	/// <inheritdoc cref="NumberF.GetUIntPtr()"/>
	public static nint IntPtr =>
		NumberF.GetIntPtr(min: 10000, max: 19999);

	/// <inheritdoc cref="NumberF.GetUInt16()"/>
	public static ushort UInt16 =>
		NumberF.GetUInt16(min: 10000, max: 19999);

	/// <inheritdoc cref="NumberF.GetUInt32()"/>
	public static uint UInt32 =>
		NumberF.GetUInt32(min: 10000u, max: 19999u);

	/// <inheritdoc cref="NumberF.GetUInt64()"/>
	public static ulong UInt64 =>
		NumberF.GetUInt64(min: 10000UL, max: 19999UL);

	/// <inheritdoc cref="NumberF.GetUInt128()"/>
	public static UInt128 UInt128 =>
		NumberF.GetUInt128(min: 10000, max: 19999);

	/// <inheritdoc cref="NumberF.GetUIntPtr()"/>
	public static nuint UIntPtr =>
		NumberF.GetUIntPtr(min: 10000, max: 19999);

#pragma warning restore CA1720 // Identifier contains type name
}
