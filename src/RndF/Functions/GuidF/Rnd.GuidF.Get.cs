// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System;

namespace RndF;

public static partial class Rnd
{
	public static partial class GuidF
	{
		/// <summary>
		/// Return a secure random (version 4) Guid compatible with RFC 4122.
		/// </summary>
		/// <returns>Random GUID.</returns>
		public static Guid Get() =>
			Guid.NewGuid();
	}
}
