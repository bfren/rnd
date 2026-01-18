// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Functions.CharF;

internal class Get_Tests
{
	public class without_args
	{
		[Fact]
		public void never_returns_out_of_bounds() =>
			Helpers.CheckBounds(() => (ushort)Rnd.CharF.Get(), char.MinValue, char.MaxValue);
	}

	public class with_min
	{
		public static TheoryData<ushort> Min =>
			new() { { Rnd.CharF.Get() } };

		[Theory]
		[MemberData(nameof(Min))]
		public void never_returns_out_of_bounds(ushort min) =>
			Helpers.CheckBounds(x => Rnd.CharF.Get(min: x), min, char.MaxValue);
	}

	public class with_max
	{
		public static TheoryData<ushort> Max =>
			new() { { Rnd.CharF.Get() } };

		[Theory]
		[MemberData(nameof(Max))]
		public void never_returns_out_of_bounds(ushort max) =>
			Helpers.CheckBounds(x => Rnd.CharF.Get(max: x), char.MinValue, max);
	}

	public class with_min_and_max
	{
		public class when_min_is_more_than_max
		{
			[Fact]
			public void throws_MaximumNotMoreThanMinimumException() =>
				Helpers.MaximumLessThanMinimum(nameof(Rnd.CharF.Get), () => (char)Rnd.USht, (min, max) => Rnd.CharF.Get(min, max));
		}

		public static TheoryData<ushort, ushort> MinAndMax
		{
			get
			{
				var v0 = Rnd.CharF.Get();
				var v1 = Rnd.CharF.Get();
				return (v0, v1) switch
				{
					_ when v0 < v1 =>
						new() { { v0, v1 } },
					_ =>
						new() { { v1, v0 } }
				};
			}
		}

		[Theory]
		[MemberData(nameof(MinAndMax))]
		public void never_returns_out_of_bounds(ushort min, ushort max) =>
			Helpers.CheckBounds((x, y) => Rnd.CharF.Get(min: x, max: y), min, max);
	}
}
