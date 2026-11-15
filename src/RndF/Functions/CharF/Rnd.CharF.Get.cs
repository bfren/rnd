// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using RndF.Exceptions;

namespace RndF;

public static partial class Rnd
{
	public static partial class CharF
	{
		/// <summary>
		/// Return a random character between U+0000 and U+FFFF inclusive.
		/// </summary>
		/// <remarks>
		/// The result can be a control character, an unassigned code point or half of a surrogate pair.
		/// </remarks>
		/// <returns>Random character.</returns>
		public static char Get() =>
			Get(char.MinValue, char.MaxValue);

		/// <summary>
		/// Return a random character between <paramref name="min"/> and <paramref name="max"/> inclusive.
		/// </summary>
		/// <param name="min">Lowest acceptable UTF-16 code unit.</param>
		/// <param name="max">Highest acceptable UTF-16 code unit.</param>
		/// <returns>Random character.</returns>
		/// <exception cref="MaximumLessThanMinimumException"><paramref name="max"/> is not greater than <paramref name="min"/>.</exception>
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
