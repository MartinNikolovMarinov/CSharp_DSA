using System;

public class Variation<T>
{
	// The count of all calculated variations.
	private static int variationsCount = 0;

	// The callback, that gets called on every variation.
	public Action<T[]> Callback { get; set; }

	// The set of possible objects.
	public T[] Set { get; set; }

	// The length of the set;
	private int N { get { return this.Set.Length; } }
	
	// The count of variations to choose.
	private int K { get; set; }

	// Current variation.
	private T[] Variations { get; set; }
	
	// Visited variations for the no repetition algorithm.
	private bool[] Visited { get; set; }

	public Variation(T[] set, int k, Action<T[]> callback = null)
	{
		this.Set = set;
		this.K = k;
		this.Callback = callback;
		this.Variations = new T[k];
		this.Visited = new bool[this.N];

		// Set the starting variation to the first element all the way.
		for (int i = 0; i < k; i++)
		{
			this.Variations[i] = set[0];
		}
	}

	/// <summary>
	/// Algorithm for Variation WITHOUT repetition of the indexes.
	/// If some of the elements are the same there will be repetition !
	/// THIS ASSUMES THAT THE SET IS UNIQUE !
	/// </summary>
	/// <returns>The count of found variations.</returns> 
	public int VariationWithoutRep()
	{
		variationsCount = 0;
		if (this.K <= this.N)
			VariationWithoutRep(0);
		return variationsCount;
	}

	private void VariationWithoutRep(int curr)
	{

		if (curr >= this.K)
		{
			variationsCount++;
			if (this.Callback != null)
				this.Callback(this.Variations);

			return;
		}

		for (int i = 0; i < this.N; i++)
		{
			if (!Visited[i])
			{
				Visited[i] = true;
				this.Variations[curr] = this.Set[i];
				VariationWithoutRep(curr + 1);
				Visited[i] = false;
			}
		}
	}

	/// <summary>
	/// Algorithm for Variation WITH repetition.
	/// </summary>
	/// <returns>The count of found variations.</returns> 
	public int VariationWithRep()
	{
		variationsCount = 0;
		VariationWithRep(0);
		return variationsCount;
	}

	private void VariationWithRep(int curr)
	{
		if (curr >= this.K)
		{
			variationsCount++;
			if (this.Callback != null)
				this.Callback(this.Variations);

			return;
		}

		for (int i = 0; i < this.N; i++)
		{
			this.Variations[curr] = this.Set[i];
			VariationWithRep(curr + 1);
		}
	}
}