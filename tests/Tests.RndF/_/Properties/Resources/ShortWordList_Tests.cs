// Rnd: Unit Tests
// Copyright (c) bfren - licensed under https://mit.bfren.dev/2021

using System.Security.Cryptography;
using System.Text;

namespace RndF.Properties.Resources_Tests;

public class ShortWordList_Tests
{
	public const string ShortWordListHash = "1yAGynx4Rpdz6lMZO05O5bj0WZ46w0ESxZ1fsSs+DFg=";

	[Fact]
	public void Returns_Correct_Values()
	{
		// Arrange
		var list = Resources.eff_short_word_list;
		var bytes = Encoding.UTF8.GetBytes(list);
		var expected = Convert.FromBase64String(ShortWordListHash);

		// Act
		var result = SHA256.HashData(bytes);

		// Assert
		Assert.Equal(expected, result);
	}
}
