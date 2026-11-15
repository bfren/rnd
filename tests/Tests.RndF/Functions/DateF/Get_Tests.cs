// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.DateF_Tests;

public class Get_Tests
{
	[Fact]
	public void Returns_Date_Between_Min_And_Max_Year() =>
		Helpers.CheckBounds(Rnd.DateF.Get, d => d.Year, 1, 10000);

	[Fact]
	public void Returns_Date_Between_Min_And_Max_Month() =>
		Helpers.CheckBounds(Rnd.DateF.Get, d => d.Month, 1, 13);

	[Fact]
	public void Returns_Date_Between_Min_And_Max_Day() =>
		Helpers.CheckBounds(Rnd.DateF.Get, d => d.Day, 1, 32);

	[Fact]
	public void Returns_The_31st_As_Often_As_The_Calendar()
	{
		// Arrange
		var iterations = 100000;

		// Act
		var result = Rnd.For(iterations, () => Rnd.DateF.Get().Day).Count(d => d == 31);

		// Assert - 7 days in every 365.2425 are the 31st, so expect about 1,917 (standard deviation about 44)
		Assert.InRange(result, 1500, 2300);
	}
}
