// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.NumberF_Tests;

public class GetIntPtr_Tests
{
	public class without_args
	{
		[Fact]
		public void never_returns_out_of_bounds() =>
			Helpers.CheckBounds(() => Rnd.NumberF.GetIntPtr(), 0, nint.MaxValue);
	}

	public class with_max
	{
		public static TheoryData<nint> Max =>
			new() { { Rnd.Ptr } };

		[Theory]
#pragma warning disable xUnit1044 // Avoid using TheoryData type arguments that are not serializable
		[MemberData(nameof(Max))]
#pragma warning restore xUnit1044 // Avoid using TheoryData type arguments that are not serializable
		public void never_returns_out_of_bounds(nint max) =>
			Helpers.CheckBounds(max => Rnd.NumberF.GetIntPtr(max), 0, max);
	}

	public class with_min_and_max
	{
		public class when_min_is_more_than_max
		{
			[Fact]
			public void throws_MaximumNotMoreThanMinimumException() =>
				Helpers.MaximumLessThanMinimum(nameof(Rnd.NumberF.GetIntPtr), () => Rnd.Ptr, Rnd.NumberF.GetIntPtr);
		}

		public class when_min_is_less_than_zero
		{
			[Fact]
			public void throws_MinimumLessThanZeroException() =>
				Helpers.MinimumLessThanZero(nameof(Rnd.NumberF.GetIntPtr), () => Rnd.Ptr * -1, () => Rnd.Ptr, Rnd.NumberF.GetIntPtr);
		}

		public static TheoryData<nint, nint> MinAndMax
		{
			get
			{
				var min = Rnd.Ptr;
				var max = min + 1 + Rnd.Ptr;
				return new() { { min, max } };
			}
		}

		[Theory]
#pragma warning disable xUnit1044 // Avoid using TheoryData type arguments that are not serializable
		[MemberData(nameof(MinAndMax))]
#pragma warning restore xUnit1044 // Avoid using TheoryData type arguments that are not serializable
		public void never_returns_out_of_bounds(nint min, nint max) =>
			Helpers.CheckBounds((min, max) => Rnd.NumberF.GetIntPtr(min, max), min, max);
	}
}
