// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Functions.CharF;

internal sealed class Get_Tests
{
	public sealed class without_args
	{
		[Fact]
		public void never_returns_out_of_bounds() =>
			Helpers.CheckBounds(() => (ushort)Rnd.CharF.Get(), char.MinValue, char.MaxValue);
	}

	public sealed class with_min_and_max
	{
		public sealed class when_min_is_more_than_max
		{
			[Fact]
			public void throws_MaximumNotMoreThanMinimumException() =>
				Helpers.MaximumLessThanMinimum(nameof(Rnd.CharF.Get), () => (char)Rnd.UInt16, (min, max) => Rnd.CharF.Get(min, max));
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
