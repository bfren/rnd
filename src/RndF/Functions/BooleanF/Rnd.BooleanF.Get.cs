// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF;

public static partial class Rnd
{
	public static partial class BooleanF
	{
		/// <summary>
		/// Return a random <see langword="true"/> or <see langword="false"/> value, using <see cref="Generator"/>.
		/// </summary>
		/// <returns><see langword="true"/> or <see langword="false"/>.</returns>
		public static bool Get() =>
			NumberF.GetInRange(0, 1) == 1;
	}
}
