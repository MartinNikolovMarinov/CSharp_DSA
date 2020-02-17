namespace _06.Snakes
{
    using System;
    using System.Linq;

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

        public void PermuteWithoutRep()
        {
            PermuteWithoutRep(0);
        }

        private void PermuteWithoutRep(int curr)
        {
            if (curr >= this.N)
            {
                if (this.Callback != null)
                    this.Callback(this.Permutations);

                return;
            }

            PermuteWithoutRep(curr + 1);
            for (int i = curr + 1; i < this.N; i++)
            {
                Swap(ref this.Permutations[curr], ref this.Permutations[i]);
                PermuteWithoutRep(curr + 1);
                Swap(ref this.Permutations[curr], ref this.Permutations[i]);
            }
        }

        public void PermuteWithRep()
        {
            PermuteWithRep(0, this.Permutations.Length);
        }

        public void PermuteWithRep(int curr, int n)
        {
            if (this.Callback != null)
                this.Callback(this.Permutations);

            if (curr < n)
            {
                for (int i = n - 2; i >= curr; i--)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        if (this.Permutations[i] != this.Permutations[j])
                        {
                            Swap(ref this.Permutations[i], ref this.Permutations[j]);
                            PermuteWithRep(i + 1, n);
                        }
                    }

                    // Undo all modifications done by
                    // recursive calls and swapping.
                    int tmp = this.Permutations[i];
                    for (int j = i; j < n - 1; j++)
                    {
                        this.Permutations[j] = this.Permutations[j + 1];
                    }

                    this.Permutations[n - 1] = tmp;
                }
            }
        }
    }
}
