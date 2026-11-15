// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System;

namespace RndF;

public static partial class Rnd
{
	/// <summary>
	/// Gets a random date between 0001-01-01 and 9999-12-31.
	/// </summary>
	public static DateOnly Date =>
		DateF.Get();

	/// <summary>
	/// Gets a random UTC date and time between 0001-01-01 00:00:00.000 and 9999-12-31 23:59:59.999.
	/// </summary>
	public static DateTime DateTime =>
		DateTimeF.Get();

	/// <summary>
	/// Gets a random time between 00:00:00.000 and 23:59:59.999.
	/// </summary>
	public static TimeOnly Time =>
		TimeF.Get();
}
