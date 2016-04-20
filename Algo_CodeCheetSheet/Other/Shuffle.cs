public static Random rnd = new Random();

public void Shuffle(T[] arr)
{
	for (int i = 0; i < arr.Length; i++)
	{
		int rndIndex = i + rnd.Next(0, arr.Length - i);
		T tmp = arr[i];
		arr[i] = arr[rndIndex];
		arr[rndIndex] = tmp;
	}
}