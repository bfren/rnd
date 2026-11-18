// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System;
using System.Buffers.Binary;
using System.Numerics;
using RndF.Exceptions;

namespace RndF;

public static partial class Rnd
{
	public static partial class NumberF
	{
		/// <summary>
		/// Check the arguments of a public <c>Get*</c> integer method and return a random integer between
		/// <paramref name="min"/> and <paramref name="max"/> inclusive.
		/// </summary>
		/// <typeparam name="T">Integer type.</typeparam>
		/// <param name="method">Name of the calling method, used in exception messages.</param>
		/// <param name="min">Minimum acceptable value (must be at least <c>0</c>).</param>
		/// <param name="max">Maximum acceptable value.</param>
		/// <returns>Random number.</returns>
		/// <exception cref="MaximumLessThanMinimumException"><paramref name="max"/> is not greater than <paramref name="min"/>.</exception>
		/// <exception cref="MinimumLessThanZeroException"><paramref name="min"/> is less than <c>0</c>.</exception>
		internal static T GetChecked<T>(string method, T min, T max)
			where T : IBinaryInteger<T>, IMinMaxValue<T>
		{
			if (min >= max)
			{
				throw MaximumLessThanMinimumException.Create(method, min, max);
			}

			// Always false for unsigned types
			if (T.IsNegative(min))
			{
				throw MinimumLessThanZeroException.Create(method, min);
			}

			return GetInRange(min, max);
		}

		/// <summary>
		/// Returns a uniformly distributed random integer between <paramref name="min"/> and <paramref name="max"/>
		/// inclusive, using bytes from <see cref="Generator"/>.
		/// </summary>
		/// <remarks>
		/// Callers must check that 0 &lt;= <paramref name="min"/> &lt; <paramref name="max"/>.
		/// </remarks>
		/// <typeparam name="T">Integer type.</typeparam>
		/// <param name="min">Minimum acceptable value.</param>
		/// <param name="max">Maximum acceptable value.</param>
		/// <returns>Random number.</returns>
		internal static T GetInRange<T>(T min, T max)
			where T : IBinaryInteger<T>, IMinMaxValue<T>
		{
			var rng = Generator;
			var range = max - min;
			Span<byte> buffer = stackalloc byte[16];

			if (range.GetByteCount() <= 8)
			{
				// Draw 64 bits and reject the few values below 2^64 mod n, so every remainder is equally likely
				var n = ulong.CreateTruncating(range) + 1;
				var bytes = buffer[..8];
				ulong r;
				if (n == 0)
				{
					// Full ulong range: every value is acceptable
					rng.Fill(bytes);
					return min + T.CreateTruncating(BinaryPrimitives.ReadUInt64LittleEndian(bytes));
				}

				var threshold = unchecked(0UL - n) % n;
				do
				{
					rng.Fill(bytes);
					r = BinaryPrimitives.ReadUInt64LittleEndian(bytes);
				}
				while (r < threshold);

				return min + T.CreateTruncating(r % n);
			}

			// 128-bit: keep only the bits the range needs and retry if the value is too big
			var width = range.GetByteCount() * 8;
			var bits = width - int.CreateTruncating(T.LeadingZeroCount(range));
			var mask = bits == width ? T.AllBitsSet : (T.One << bits) - T.One;
			var isUnsigned = !T.IsNegative(T.MinValue);
			T value;
			do
			{
				rng.Fill(buffer);
				value = T.ReadLittleEndian(buffer, isUnsigned) & mask;
			}
			while (value > range);

			return min + value;
		}
	}
}
