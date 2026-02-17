// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Functions.CharF;

internal sealed class Get_Tests
{
	public sealed class Without_Args
	{
		[Fact]
		public void Returns_Number_Between_Min_And_Max() =>
			Helpers.CheckBounds(() => (ushort)Rnd.CharF.Get(), char.MinValue, char.MaxValue);
	}

	public sealed class With_Min_And_Max
	{
		public sealed class When_Min_Is_More_Than_Max
		{
			[Fact]
			public void Throws_MaximumNotMoreThanMinimumException() =>
				Helpers.MaximumLessThanMinimum(nameof(Rnd.CharF.Get), () => (char)Rnd.UInt16, (min, max) => Rnd.CharF.Get(min, max));
		}

		[Fact]
		public void Returns_Number_Between_Min_And_Max() =>
			Helpers.CheckBounds(Rnd.NumberF.GetUInt16, (min, max) => Rnd.CharF.Get(min, max));
	}
}
