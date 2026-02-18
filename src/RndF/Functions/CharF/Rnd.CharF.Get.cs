// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using RndF.Exceptions;

namespace RndF;

public static partial class Rnd
{
	public static partial class CharF
	{
		/// <summary>
		/// Return a random character.
		/// </summary>
		/// <returns>Random character.</returns>
		public static char Get() =>
			Get(char.MinValue, char.MaxValue);

		/// <summary>
		/// Return a random character.
		/// </summary>
		/// <returns>Random character.</returns>
		public static char Get(ushort min, ushort max)
		{
			if (min >= max)
			{
				throw MaximumLessThanMinimumException.Create(nameof(CharF), min, max);
			}

			return (char)NumberF.GetUInt16(min, max);
		}
	}
}
