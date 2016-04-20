using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test;

[TestClass]
public class VariationTests
{
	[TestMethod]
	public void Variation_NO_REP_TestWithInt()
	{
		int[] set = { 9, 2, 6, 4 };
		int k = 2;
		var result = new List<int[]>();
		var expectedResult = new List<int[]>() 
		{
			new int[] { 9, 2 },
			new int[] { 9, 6 },
			new int[] { 9, 4 },
			new int[] { 2, 9 },
			new int[] { 2, 6 },
			new int[] { 2, 4 },
			new int[] { 6, 9 },
			new int[] { 6, 2 },
			new int[] { 6, 4 },
			new int[] { 4, 9 },
			new int[] { 4, 2 },
			new int[] { 4, 6 }
		};
		Variation<int> v = new Variation<int>(set, k, variation =>
		{
			var copy = new int[variation.Length];
			variation.CopyTo(copy, 0);
			result.Add(copy);
		});
		int variationCount = v.VariationWithoutRep();

		CompareCombinatorics(expectedResult, result, variationCount);
	}

	[TestMethod]
	public void Variation_NO_REP_TestWithString()
	{
		string[] set = { "aa", "bb", "cc" };
		int k = 3;
		var result = new List<string[]>();
		var expectedResult = new List<string[]>()
		{
			new string[] { "aa", "bb", "cc" },
			new string[] { "aa", "cc", "bb" },
			new string[] { "bb", "aa", "cc" },
			new string[] { "bb", "cc", "aa" },
			new string[] { "cc", "aa", "bb" },
			new string[] { "cc", "bb", "aa" }
		};
		Variation<string> v = new Variation<string>(set, k, variation =>
		{
			var copy = new string[variation.Length];
			variation.CopyTo(copy, 0);
			result.Add(copy);
		});
		int variationCount = v.VariationWithoutRep();

		CompareCombinatorics(expectedResult, result, variationCount);
	}

	[TestMethod]
	public void Variation_WITH_REP_TestWithInt()
	{
		int[] set = { 1, 2, 3 };
		int k = 2;
		var result = new List<int[]>();
		var expectedResult = new List<int[]>()
		{
			new int[] { 1, 1 },
			new int[] { 1, 2 },
			new int[] { 1, 3 },
			new int[] { 2, 1 },
			new int[] { 2, 2 },
			new int[] { 2, 3 },
			new int[] { 3, 1 },
			new int[] { 3, 2 },
			new int[] { 3, 3 },
		};
		var v = new Variation<int>(set, k, variation =>
		{
			var copy = new int[variation.Length];
			variation.CopyTo(copy, 0);
			result.Add(copy);
		});
		int variationCount = v.VariationWithRep();

		CompareCombinatorics(expectedResult, result, variationCount);
	}

	[TestMethod]
	public void Variation_WITH_REP_TestWithInt_2()
	{
		int[] set = { 1, 2 };
		int k = 3;
		var result = new List<int[]>();
		var expectedResult = new List<int[]>()
		{
			new int[] { 1, 1, 1 },
			new int[] { 1, 1, 2 },
			new int[] { 1, 2, 1 },
			new int[] { 1, 2, 2 },
			new int[] { 2, 1, 1 },
			new int[] { 2, 1, 2 },
			new int[] { 2, 2, 1 },
			new int[] { 2, 2, 2 }
		};
		var v = new Variation<int>(set, k, variation =>
		{
			var copy = new int[variation.Length];
			variation.CopyTo(copy, 0);
			result.Add(copy);
			Console.WriteLine(string.Join(", ", copy));
		});
		int variationCount = v.VariationWithRep();

		CompareCombinatorics(expectedResult, result, variationCount);
	}

	// Utility :
	private static void CompareCombinatorics<T>(List<T[]> expectedResult, List<T[]> result, int count)
	{
		Assert.AreEqual(expectedResult.Count, count);
		Assert.AreEqual(expectedResult.Count, result.Count);
		for (int i = 0; i < expectedResult.Count; i++)
		{
			CollectionAssert.AreEqual(expectedResult[i], result[i]);
		}
	}
}