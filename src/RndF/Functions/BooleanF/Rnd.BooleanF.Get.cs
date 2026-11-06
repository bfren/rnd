// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF;

public static partial class Rnd
{
	public static partial class BooleanF
	{
		/// <summary>
		/// Returns a cryptographically-secure random true or false value.
		/// </summary>
		/// <returns>True or false.</returns>
		public static bool Get() =>
			NumberF.GetInRange(0, 1) == 1;
	}
}
