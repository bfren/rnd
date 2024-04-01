// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System;

namespace RndF;

public static partial class Rnd
{
	public static partial class NumberF
	{
		/// <summary>
		/// Returns a random double-precision floating point number between 0 and 1.
		/// </summary>
		/// <remarks>
		/// Thanks to https://stackoverflow.com/users/11178549/theodor-zoulias for comments and suggested improvements
		/// - see https://stackoverflow.com/a/64264895/8199362.
		/// </remarks>
		/// <returns>Random number.</returns>
		public static double Get()
		{
			// Get 8 random bytes to convert into a 64-bit integer
			var lng = BitConverter.ToInt64(ByteF.Get(8), 0);
			var dbl = (double)(lng < 0 ? ~lng : lng);

			// Convert to a random number between 0 and 1
			return dbl / long.MaxValue;
		}
	}
}
