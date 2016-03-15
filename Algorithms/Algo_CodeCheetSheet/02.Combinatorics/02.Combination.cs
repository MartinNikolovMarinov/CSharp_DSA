using System;

public class Combination
{
    public Action<int[]> Callback { get; set; }
    public int Offset { get; set; }

    private int N { get; set; }
    private int K { get; set; }
    private int[] Combinations { get; set; }

    public Combination(int n, int k, Action<int[]> callback = null)
    {
        this.N = n;
        this.K = k;
        this.Callback = callback;
        this.Combinations = new int[k];
        this.Offset = 0;
    }

    public void CombinationWithRep()
    {
        if (this.N < this.K)
            return;
        else
            CombinationWithRep(0, 0);
    }

    private void CombinationWithRep(int counter, int curr)
    {
        if (curr >= this.K)
        {
            if (this.Callback != null)
                this.Callback(this.Combinations);

            return;
        }

        for (int i = counter + this.Offset; i < this.N + this.Offset; i++)
        {
            this.Combinations[curr] = i;
            CombinationWithRep(i - this.Offset, curr + 1);
        }
    }

    public void CombinationWithNoRep()
    {
        if (this.N < this.K)
            return;
        else
            CombinationWithNoRep(0, 0);
    }

    private void CombinationWithNoRep(int counter, int curr)
    {
        if (curr >= this.K)
        {
            if (this.Callback != null)
                this.Callback(this.Combinations);

            return;
        }

        for (int i = counter + 1 + this.Offset; i <= this.N + this.Offset; i++)
        {
            this.Combinations[curr] = i - 1;
            CombinationWithNoRep(i - this.Offset, curr + 1);
        }
    }
}
