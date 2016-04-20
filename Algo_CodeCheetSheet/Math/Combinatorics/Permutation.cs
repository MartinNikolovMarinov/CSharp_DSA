using System;
using System.Linq;

public class Permutation<T>
{
	// The Number of total calculated permutations.
	private static int countOfPermutations = 0;

	// The callback function, that gets called on every found permutation.
	public Action<T[]> Callback { get; set; }

	// The length of the set.
	public int N { get { return this.Set.Length; } }
	
	// The set of all possible object to permute.
	public T[] Set { get; set; }

	// The current variant of the permutation.
	private T[] Permutations { get; set; }

	public Permutation(T[] set, Action<T[]> callback = null)
	{
		this.Set = set;
		this.Callback = callback;
		this.Permutations = new T[set.Length];

		// Start off the permutations with the initial given set :
		set.CopyTo(this.Permutations, 0);
	}

	/// <summary>
	/// Algorithm for Permutation WITHOUT repetition for the indexes.
	/// If some of the elements are the same there will be repetition !
	/// THIS ASSUMES THAT THE SET IS UNIQUE !
	/// </summary>
	/// <returns>The count of found permutations.</returns>
	public int PermuteWithoutRep()
	{
		countOfPermutations = 0;
		PermuteWithoutRep(0);
		return countOfPermutations;
	}

	private void PermuteWithoutRep(int curr)
	{
		if (curr >= this.N)
		{
			countOfPermutations++;
			if (this.Callback != null)
				this.Callback(this.Permutations);

			return;
		}

		PermuteWithoutRep(curr + 1);
		for (int i = curr + 1; i < this.N; i++)
		{
			Swap<T>(ref this.Permutations[curr], ref this.Permutations[i]);
			PermuteWithoutRep(curr + 1);
			Swap<T>(ref this.Permutations[curr], ref this.Permutations[i]);
		}
	}

	/// <summary>
	/// Algorithm for Permutation WITH repetition.
	/// </summary>
	/// <returns>The count of found permutations.</returns>
	public int PermuteWithRep()
	{
		countOfPermutations = 0;
		PermuteWithRep(0);
		return countOfPermutations;
	}

	public void PermuteWithRep(int start)
	{
		countOfPermutations++;
		if (this.Callback != null)
			this.Callback(this.Permutations);

		if (start < this.N)
		{
			for (int i = this.N - 2; i >= start; i--)
			{
				for (int j = i + 1; j < this.N; j++)
				{
					if (this.Permutations[i].Equals(this.Permutations[j]) == false)
					{
						Swap<T>(ref this.Permutations[i], ref this.Permutations[j]);
						PermuteWithRep(i + 1);
					}
				}

				// Undo all modifications done by recursive calls and swaps.
				T firstElem = this.Permutations[i];
				for (int j = i; j < this.N - 1; j++)
				{
					this.Permutations[j] = this.Permutations[j + 1];
				}

				this.Permutations[this.N - 1] = firstElem;
			}
		}
	}

	private static void Swap<K>(ref T a, ref T b)
	{
		T tmp = a;
		a = b;
		b = tmp;
	}
}