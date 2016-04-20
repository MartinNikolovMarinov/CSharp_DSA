namespace _06.Snakes
{
    using System;

    public class Variation
    {
        public Action<int[]> Callback { get; set; }
        public int Offset { get; set; }

        private int N { get; set; }
        private int K { get; set; }
        private int[] Variations { get; set; }

        public Variation(int n, int k, Action<int[]> callback = null)
        {
            this.N = n;
            this.K = k;
            this.Callback = callback;
            this.Variations = new int[k];
            this.Offset = 0;
        }

        public void VariationWithRep()
        {
            VariationWithRep(0);
        }

        private void VariationWithRep(int curr)
        {
            if (curr >= this.K)
            {
                if (this.Callback != null)
                    this.Callback(this.Variations);

                return;
            }

            for (int i = 0 + this.Offset; i < this.N + this.Offset; i++)
            {
                this.Variations[curr] = i;
                VariationWithRep(curr + 1);
            }
        }
    }
}
