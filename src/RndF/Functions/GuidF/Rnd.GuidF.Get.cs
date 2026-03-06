// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System;

namespace RndF;

public static partial class Rnd
{
	public static partial class GuidF
	{
		/// <summary>
		/// Return a secure random Guid compatible with RFC 4122.
		/// </summary>
		/// <remarks>
		/// On .NET 9 and above, will also be compatible with RFC 9562.
		/// </remarks>
		/// <returns>Random GUID.</returns>
		public static Guid Get() =>
#if NET9_0_OR_GREATER
			Guid.CreateVersion7();
#else
			Guid.NewGuid();
#endif
	}
}
