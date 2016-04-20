using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test;

[TestClass]
public class CombinationTest
{
	[TestMethod]
	public void Combinations_NO_REP_TestWithInt()
	{
		int[] set = { 0, 1, 2, 3 };
		List<int[]> result = new List<int[]>();
		List<int[]> expectedResult = new List<int[]>() 
		{
			new int[] { 0, 1 },
			new int[] { 0, 2 },
			new int[] { 0, 3 },
			new int[] { 1, 2 },
			new int[] { 1, 3 },
			new int[] { 2, 3 }
		};
		Combination<int> c = new Combination<int>(set, 2, perm =>
		{
			int[] copy = new int[perm.Length];
			perm.CopyTo(copy, 0);
			result.Add(copy);
		});
		int permutationsCount = c.CombinationWithNoRep();

		CompareCombinatorics(expectedResult, result, permutationsCount);
	}

	[TestMethod]
	public void Combinations_WITH_REP_TestWithInt()
	{
		int[] set = { 0, 1, 2, 3 };
		List<int[]> result = new List<int[]>();
		List<int[]> expectedResult = new List<int[]>() 
		{
			new int[] { 0, 0 },
			new int[] { 0, 1 },
			new int[] { 0, 2 },
			new int[] { 0, 3 },
			new int[] { 1, 1 },
			new int[] { 1, 2 },
			new int[] { 1, 3 },
			new int[] { 2, 2 },
			new int[] { 2, 3 },
			new int[] { 3, 3 },
		};
		Combination<int> c = new Combination<int>(set, 2, perm =>
		{
			int[] copy = new int[perm.Length];
			perm.CopyTo(copy, 0);
			result.Add(copy);
			Console.WriteLine(String.Join(", ", perm));
		});
		int permutationsCount = c.CombinationWithRep();

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