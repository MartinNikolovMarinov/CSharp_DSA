public void HeapSort(T[] arr)
{
	Heapify(arr);
	int end = arr.Length - 1;
	while (end > 0)
	{
		Swap(ref arr[end], ref arr[0]);
		end--;
		SiftDown(arr, 0, end);
	}
}

private void Heapify(T[] arr)
{
	int start = ((arr.Length - 2) / 2);
	while (start >= 0)
	{
		SiftDown(arr, start, arr.Length - 1);
		start--;
	}
}

private void SiftDown(T[] arr, int start, int end)
{
	int root = start;
	while (root * 2 + 1 <= end)
	{
		int child = root * 2 + 1;
		int swap_i = root;
		if (arr[swap_i].CompareTo(arr[child]) < 0)
			swap_i = child;
		if (child + 1 <= end && arr[swap_i].CompareTo(arr[child + 1]) < 0)
			swap_i = child + 1;
		if (swap_i == root)
			return;
		else
		{
			Swap(ref arr[root], ref arr[swap_i]);
			root = swap_i;
		}
	}
}