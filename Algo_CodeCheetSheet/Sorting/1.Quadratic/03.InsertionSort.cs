public void InsertionSort(T[] arr)
{
	for (int i = 1; i < arr.Count; i++)
	{
		int targetIndex = i;
		while (targetIndex > 0)
		{
			if (arr[targetIndex - 1].CompareTo(arr[targetIndex]) > 0)
				Swap(ref arr[targetIndex], ref arr[targetIndex - 1]);

			targetIndex--;
		}
	}
}