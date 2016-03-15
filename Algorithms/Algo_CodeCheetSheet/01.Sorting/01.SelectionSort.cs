public void SelectionSort(T[] arr)
{
	for (int i = 0; i < arr.Length; i++)
	{
		int minIndex = i;
		for (int j = i + 1; j < arr.Length; j++)
		{
			if (arr[minIndex].CompareTo(arr[j]) > 0)
				minIndex = j;
		}

		Swap(ref arr[i], ref arr[minIndex]);
	}
}