// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System;
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
		public static char Get(ushort min = char.MinValue, ushort max = char.MaxValue)
		{
			if (min > char.MaxValue)
			{
				throw new ArgumentOutOfRangeException(nameof(min), $"Value must be between {char.MinValue} and {char.MaxValue}.");
			}
			if (max > char.MaxValue)
			{
				throw new ArgumentOutOfRangeException(nameof(max), $"Value must be between {char.MinValue} and {char.MaxValue}.");
			}
			if (min >= max)
			{
				throw MaximumLessThanMinimumException.Create(nameof(CharF), min, max);
			}

			return (char)NumberF.GetUInt16(min, max);
		}
	}
}
