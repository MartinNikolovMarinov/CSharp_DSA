using System;

public class Combination<T>
{
	// The count of all calculated combinations.
	private static int combinationCount;

	// The callback function that gets called on every combination.
	public Action<T[]> Callback { get; set; }

	// The set of all possible combinations.
	public T[] Set { get; set; }

	// The length of the set.
	private int N { get { return this.Set.Length; } }

	// The count of combinations to choose.
	private int K { get; set; }

	// The current combination.
	private T[] Combinations { get; set; }

	public Combination(T[] set, int k, Action<T[]> callback = null)
	{
		this.Set = set;
		this.K = k;
		this.Callback = callback;
		this.Combinations = new T[k];

		// Set the starting variation to the first element all the way.
		for (int i = 0; i < k; i++)
		{
			this.Combinations[i] = set[0];
		}
	}

	/// <summary>
	/// Algorithm for combinations WITHOUT repetition of the indexes.
	/// If some of the elements are the same there will be repetition !
	/// THIS ASSUMES THAT THE SET IS UNIQUE !
	/// </summary>
	/// <returns>The count of found variations.</returns> 
	public int CombinationWithNoRep()
	{
		combinationCount = 0;
		if (this.N >= this.K)
			CombinationWithNoRep(0, 0);
		return combinationCount;
	}

	private void CombinationWithNoRep(int counter, int curr)
	{
		if (curr >= this.K)
		{
			combinationCount++;
			if (this.Callback != null)
				this.Callback(this.Combinations);

			return;
		}

		for (int i = counter + 1; i <= this.N; i++)
		{
			this.Combinations[curr] = this.Set[i - 1];
			CombinationWithNoRep(i, curr + 1);
		}
	}

	/// <summary>
	/// Algorithm for combination WITH repetition.
	/// </summary>
	/// <returns>The count of found variations.</returns>
	public int CombinationWithRep()
	{
		combinationCount = 0;
		if (this.N >= this.K)
			CombinationWithRep(0, 0);
		return combinationCount;
	}

	private void CombinationWithRep(int counter, int curr)
	{
		if (curr >= this.K)
		{
			combinationCount++;
			if (this.Callback != null)
				this.Callback(this.Combinations);

			return;
		}

		for (int i = counter; i < this.N; i++)
		{
			this.Combinations[curr] = this.Set[i];
			CombinationWithRep(i, curr + 1);
		}
	}
}
