// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

namespace RndF.Rnd_Tests.NumberF_Tests;

public class GetUIntPtr_Tests
{
	public class Without_Args
	{
		[Fact]
		public void Returns_Number_Between_Zero_And_MaxValue() =>
			Helpers.CheckBounds(() => Rnd.NumberF.GetUIntPtr(), (nuint)0, nuint.MaxValue);
	}

	public class With_Max
	{
		public static TheoryData<nuint> Max =>
			[Rnd.UIntPtr];

		[Theory]
		[MemberData(nameof(Max))]
		public void Returns_Number_Between_Zero_And_Max(nuint max) =>
			Helpers.CheckBounds(max => Rnd.NumberF.GetUIntPtr(max), (nuint)0, max);
	}

	public class With_Min_And_Max
	{
		public class When_Min_Is_More_Than_Max
		{
			[Fact]
			public void Throws_MaximumNotMoreThanMinimumException() =>
				Helpers.MaximumLessThanMinimum(nameof(Rnd.NumberF.GetUIntPtr), () => Rnd.UIntPtr, Rnd.NumberF.GetUIntPtr);
		}

		public static TheoryData<nuint, nuint> MinAndMax
		{
			get
			{
				var min = Rnd.UIntPtr;
				var max = min + 1 + Rnd.UIntPtr;
				return new() { { min, max } };
			}
		}

		[Theory]
#pragma warning disable xUnit1044 // Avoid using TheoryData type arguments that are not serializable
		[MemberData(nameof(MinAndMax))]
#pragma warning restore xUnit1044 // Avoid using TheoryData type arguments that are not serializable
		public void Returns_Number_Between_Min_And_Max(nuint min, nuint max) =>
			Helpers.CheckBounds((min, max) => Rnd.NumberF.GetUIntPtr(min, max), min, max);
	}
}
