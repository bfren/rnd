// Rnd: Random value generators.
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

#if NET8_0_OR_GREATER
using System.Text;
#endif

namespace RndF;

public static partial class Rnd
{
	/// <summary>Random number functions</summary>
	public static partial class NumberF
	{
#if NET8_0_OR_GREATER
		internal static CompositeFormat MaximumMustBeGreaterThanMinimum =>
			CompositeFormat.Parse("{0}(): Maximum value '{1}' must be more than minimum value '{2}'.");

		internal static CompositeFormat MinimumMustBeAtLeastZero =>
			CompositeFormat.Parse("{0}(): Minimum value '{1}' must be at least 0.");
#else
		internal const string MaximumMustBeGreaterThanMinimum =
			"{0}(): Maximum value '{1}' must be more than minimum value '{2}'.";

		internal const string MinimumMustBeAtLeastZero =
			"{0}(): Minimum value '{1}' must be at least 0.";
#endif
	}
}
