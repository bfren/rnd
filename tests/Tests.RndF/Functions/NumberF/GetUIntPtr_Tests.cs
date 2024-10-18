// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.NumberF_Tests;

public class GetUIntPtr_Tests
{
	public class without_args
	{
		[Fact]
		public void never_returns_out_of_bounds() =>
			Helpers.CheckBounds(() => Rnd.NumberF.GetUIntPtr(), (nuint)0, nuint.MaxValue);
	}

	public class with_max
	{
		public static TheoryData<nuint> Max =>
			new() { { Rnd.UPtr } };

		[Theory]
#pragma warning disable xUnit1044 // Avoid using TheoryData type arguments that are not serializable
		[MemberData(nameof(Max))]
#pragma warning restore xUnit1044 // Avoid using TheoryData type arguments that are not serializable
		public void never_returns_out_of_bounds(nuint max) =>
			Helpers.CheckBounds(max => Rnd.NumberF.GetUIntPtr(max), (nuint)0, max);
	}

	public class with_min_and_max
	{
		public class when_min_is_more_than_max
		{
			[Fact]
			public void throws_MaximumNotMoreThanMinimumException() =>
				Helpers.MaximumLessThanMinimum(nameof(Rnd.NumberF.GetUIntPtr), () => Rnd.UPtr, Rnd.NumberF.GetUIntPtr);
		}

		public static TheoryData<nuint, nuint> MinAndMax
		{
			get
			{
				var min = Rnd.UPtr;
				var max = min + 1 + Rnd.UPtr;
				return new() { { min, max } };
			}
		}

		[Theory]
#pragma warning disable xUnit1044 // Avoid using TheoryData type arguments that are not serializable
		[MemberData(nameof(MinAndMax))]
#pragma warning restore xUnit1044 // Avoid using TheoryData type arguments that are not serializable
		public void never_returns_out_of_bounds(nuint min, nuint max) =>
			Helpers.CheckBounds((min, max) => Rnd.NumberF.GetUIntPtr(min, max), min, max);
	}
}
