public void MergeSort(T[] arr)
{
	Split(arr, 0, arr.Length);
}

private void Split(T[] arr, int low, int hi)
{
	if (hi - low <= 1)
	{
		return;
	}

	int mid = (hi + low) / 2;
	Split(arr, low, mid); // split step
	Split(arr, mid, hi);
	T[] merged = Merge(arr, low, mid, hi); // merge step
	Array.Copy(merged, 0, arr, low, merged.Length);
}

private T[] Merge(T[] arr, int low, int mid, int hi)
{
	T[] result = new T[hi - low];
	int low_i = 0;
	int hi_i = 0;

	for (int i = 0; i < result.Length; i++)
	{
		T first, second;

		if (mid + hi_i >= hi)
		{
			// done with the right part.
			first = arr[low + low_i];
			result[i] = first;
			low_i++;
			continue;
		}
		else
		{
			second = arr[mid + hi_i];
		}

		if (low + low_i >= mid)
		{
			// done with the left part.
			second = arr[mid + hi_i];
			result[i] = second;
			hi_i++;
			continue;
		}
		else 
		{
			first = arr[low + low_i];
		}
		
	   
		if (first.CompareTo(second) <= 0)
		{
			result[i] = first;
			low_i++;
		}
		else
		{
			result[i] = second;
			hi_i++;
		}
	}

	return result;
}