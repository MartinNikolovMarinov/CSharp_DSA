using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test;

[TestClass]
public class PermutationTest
{
	[TestMethod]
	public void Permute_NO_REP_TestWithInt()
	{
		int[] set = { 1, 2, 3 };
		List<int[]> result = new List<int[]>();
		List<int[]> expectedResult = new List<int[]>() 
		{
			new int[] { 1, 2, 3 }, 
			new int[] { 1, 3, 2 }, 
			new int[] { 2, 1, 3 }, 
			new int[] { 2, 3, 1 }, 
			new int[] { 3, 2, 1 }, 
			new int[] { 3, 1, 2 }
		};
		Permutation<int> p = new Permutation<int>(set, perm =>
		{
			int[] copy = new int[perm.Length];
			perm.CopyTo(copy, 0);
			result.Add(copy);
		});
		int permutationsCount = p.PermuteWithoutRep();

		CompareCombinatorics(expectedResult, result, permutationsCount);
	}

	[TestMethod]
	public void Permute_NO_REP_TestWithString()
	{
		string[] set = { "a", "b", "c", "d" };
		List<string[]> result = new List<string[]>();
		List<string[]> expectedResult = new List<string[]>()
		{
			new string[] { "a", "b", "c", "d" },
			new string[] { "a", "b", "d", "c" },
			new string[] { "a", "c", "b", "d" },
			new string[] { "a", "c", "d", "b" },
			new string[] { "a", "d", "c", "b" },
			new string[] { "a", "d", "b", "c" },
			new string[] { "b", "a", "c", "d" },
			new string[] { "b", "a", "d", "c" },
			new string[] { "b", "c", "a", "d" },
			new string[] { "b", "c", "d", "a" },
			new string[] { "b", "d", "c", "a" },
			new string[] { "b", "d", "a", "c" },
			new string[] { "c", "b", "a", "d" },
			new string[] { "c", "b", "d", "a" },
			new string[] { "c", "a", "b", "d" },
			new string[] { "c", "a", "d", "b" },
			new string[] { "c", "d", "a", "b" },
			new string[] { "c", "d", "b", "a" },
			new string[] { "d", "b", "c", "a" },
			new string[] { "d", "b", "a", "c" },
			new string[] { "d", "c", "b", "a" },
			new string[] { "d", "c", "a", "b" },
			new string[] { "d", "a", "c", "b" },
			new string[] { "d", "a", "b", "c" }
		};
		Permutation<string> p = new Permutation<string>(set, perm =>
		{
			string[] copy = new string[perm.Length];
			perm.CopyTo(copy, 0);
			result.Add(copy);
		});
		int permutationsCount = p.PermuteWithoutRep();

		CompareCombinatorics(expectedResult, result, permutationsCount);
	}

	[TestMethod]
	public void Permute_WITH_REP_TestWithInt()
	{
		int[] set = { 6, 1, 1, 1, 1, 1, 1, 1, 1 };
		var result = new List<int[]>();
		var expectedResult = new List<int[]>() 
		{
			new int[] { 6, 1, 1, 1, 1, 1, 1, 1, 1 },
			new int[] { 1, 6, 1, 1, 1, 1, 1, 1, 1 },
			new int[] { 1, 1, 6, 1, 1, 1, 1, 1, 1 },
			new int[] { 1, 1, 1, 6, 1, 1, 1, 1, 1 },
			new int[] { 1, 1, 1, 1, 6, 1, 1, 1, 1 },
			new int[] { 1, 1, 1, 1, 1, 6, 1, 1, 1 },
			new int[] { 1, 1, 1, 1, 1, 1, 6, 1, 1 },
			new int[] { 1, 1, 1, 1, 1, 1, 1, 6, 1 },
			new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 6 }
		};
		Permutation<int> p = new Permutation<int>(set, perm =>
		{
			var copy = new int[perm.Length];
			perm.CopyTo(copy, 0);
			result.Add(copy);
		});
		int permutationsCount = p.PermuteWithRep();

		CompareCombinatorics(expectedResult, result, permutationsCount);
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