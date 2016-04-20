public void BubbleSort(T[] arr)
{
	for (int i = 0; i < arr.Length; i++)
	{
		for (int j = 1; j < arr.Length - i; j++)
		{
			if (arr[j - 1].CompareTo(arr[j]) > 0)
				Swap(ref arr[j - 1], ref arr[j]);
		}
	}
}