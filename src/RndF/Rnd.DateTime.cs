// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System;

namespace RndF;

public static partial class Rnd
{
	/// <inheritdoc cref="DateF.Get"/>
	public static DateOnly Date =>
		DateF.Get();

	/// <inheritdoc cref="DateTimeF.Get"/>
	public static DateTime DateTime =>
		DateTimeF.Get();

	/// <inheritdoc cref="TimeF.Get"/>
	public static TimeOnly Time =>
		TimeF.Get();
}
