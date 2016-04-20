public enum PivotType { Rnd, Hi, Low }
public PivotType QuickSortPivotType = PivotType.Hi;
private static Random rnd = new Random();

public void QuickSort(T[] arr)
{
	QuickSort(arr, 0, arr.Length - 1);
}

private void QuickSort(T[] arr, int low, int hi)
{
	if (low < hi)
	{
		int pivot = ChoosePivot(low, hi);
		pivot = Partition(arr, low, hi, pivot);
		QuickSort(arr, low, pivot);
		QuickSort(arr, pivot + 1, hi);
	}
}

private int ChoosePivot(int low, int hi)
{
	switch (QuickSortPivotType)
	{
		case PivotType.Rnd:
			return rnd.Next(low, hi - 1);
		case PivotType.Hi: 
			return hi - 1;
		case PivotType.Low: 
			return low;
		default:
			return hi - 1;
	}
}

private int Partition(T[] arr, int low, int hi, int pivot)
{
	T elemAtPivot = arr[pivot];
	int i = low - 1;
	int j = hi + 1;

	while (true)
	{
		do
		{
			j--;
		} while (arr[j].CompareTo(elemAtPivot) > 0);

		do
		{
			i++;
		} while (arr[i].CompareTo(elemAtPivot) < 0);

		if (i < j)
			Swap(ref arr[i], ref arr[j]);
		else
			return j;
	}
}