static (int Low, int Hight, int CrossSum) MaxCrossingSum(int[] a, int low, int mid, int high)
{
    int sum = 0;
    int leftSum = int.MinValue;
    int maxLeft = 0;
    for (int i = mid; i >= low; i--)
    {
        sum += a[i];
        if (sum > leftSum)
        {
            leftSum = sum;
            maxLeft = i;
        }
    }

    sum = 0;
    int rightSum = int.MinValue;
    int maxRight = 0;
    for (int i = mid + 1; i <= high; i++)
    {
        sum += a[i];
        if (sum > rightSum)
        {
            rightSum = sum;
            maxRight = i;
        }
    }

    return (maxLeft, maxRight, leftSum + rightSum);
}

static (int Low, int High, int Sum) MaxSubArraySum(int[] arr, int low, int high)
{
    if (low == high)
    {
        return (low, high, arr[low]);
    }

    int mid = (low + high) / 2;

    var (leftLow, leftHigh, leftSum) = MaxSubArraySum(arr, low, mid);
    var (rightLow, rightHigh, rightSum) = MaxSubArraySum(arr, mid + 1, high);
    var (crossLow, crossHigh, crossSum) = MaxCrossingSum(arr, low, mid, high);

    if (leftSum >= rightSum && leftSum >= crossSum)
    {
        return (leftLow, leftHigh, leftSum);
    }
    else if (crossSum >= leftSum && crossSum >= rightSum)
    {
        return (crossLow, crossHigh, crossSum);
    }
    else if (rightSum >= leftSum && rightSum >= crossSum)
    {
        return (rightLow, rightHigh, rightSum);
    }
    else
    {
        throw new Exception("Should not happen");
    }
}