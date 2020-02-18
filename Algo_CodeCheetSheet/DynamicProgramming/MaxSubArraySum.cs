int MaxSubArraySumNo(int[] arr)
{
    int maxEndingHere = 0;
    int maxSum = int.MinValue;

    foreach (int x in arr)
    {
        int a = x;
        int b = maxEndingHere + x;
        maxEndingHere = Math.Max(a, b);
        maxSum = Math.Max(maxSum, maxEndingHere);
    }

    return maxSum;
}