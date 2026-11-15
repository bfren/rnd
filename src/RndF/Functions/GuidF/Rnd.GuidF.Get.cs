// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System;

namespace RndF;

public static partial class Rnd
{
	public static partial class GuidF
	{
		/// <summary>
		/// Return a random version 4 GUID compatible with RFC 4122.
		/// </summary>
		/// <remarks>
		/// This calls <see cref="Guid.NewGuid"/>, so it does not use <see cref="Generator"/>.
		/// </remarks>
		/// <returns>Random GUID.</returns>
		public static Guid Get() =>
			Guid.NewGuid();
	}
}
