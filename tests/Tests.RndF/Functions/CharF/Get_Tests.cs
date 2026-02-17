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
		public void Returns_Char_Between_Min_And_Max(ushort min, ushort max) =>
			Helpers.CheckBounds((x, y) => Rnd.CharF.Get(min: x, max: y), min, max);
	}
}
