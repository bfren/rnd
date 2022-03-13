// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System;

namespace RndF;

public static partial class Rnd
{
	public static partial class GuidF
	{
		/// <summary>
		/// Return a secure random Guid
		/// </summary>
		public static Guid Get() =>
			new(ByteF.Get(16));
	}
}
