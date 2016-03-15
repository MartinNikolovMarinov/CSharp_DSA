public void CountingSort(int[] arr, int min, int max)
{
	int[] count = new int[max - min + 1];
	int z = 0;

	for (int i = 0; i < arr.Length; i++) 
	{ 
		count[arr[i] - min]++;
	}

	for (int i = min; i <= max; i++)
	{
		while (count[i - min]-- > 0)
		{
			arr[z] = i;
			z++;
		}
	}
}