public class Permutation
{
	public Action<int[]> Callback { get; set; }
	private int N { get; set; }
	private int[] Permutations { get; set; }

	public Permutation(int n, Action<int[]> callback = null)
	{
		this.N = n;
		this.Callback = callback;
		this.Permutations = Enumerable.Range(0, n).ToArray();
	}

	private static void Swap(ref int a, ref int b)
	{
		a ^= b;
		b ^= a;
		a ^= b;
	}

	public void Permute()
	{
		Permute(0);
	}

	private void Permute(int curr)
	{
		if (curr >= this.N)
		{
			if (this.Callback != null)
				this.Callback(this.Permutations);

			return;
		}

		Permute(curr + 1);
		for (int i = curr + 1; i < this.N; i++)
		{
			Swap(ref this.Permutations[curr], ref this.Permutations[i]);
			Permute(curr + 1);
			Swap(ref this.Permutations[curr], ref this.Permutations[i]);
		}
	}
} 