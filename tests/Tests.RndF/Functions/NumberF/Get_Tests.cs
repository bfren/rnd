// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.NumberF_Tests;

public class Get_Tests
{
	[Fact]
	public void never_returns_out_of_bounds() =>
		Helpers.CheckBounds(Rnd.NumberF.Get, 0, 1);

	[Fact]
	public void returns_random_number() =>
		Helpers.EnsureRandom(Rnd.NumberF.Get);
}
