namespace Sorting
{
	using System;

	public enum PivotType
	{
		Rnd, Hi, Low
	}

	public class Sorter<T> where T : IComparable
	{
		private static void Swap(ref T a, ref T b)
		{
			T tmp = a;
			a = b;
			b = tmp;
		}

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

		#region Quick Sort

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

		#endregion

		#region Merge Sort

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
			Split(arr, low, mid);
			Split(arr, mid, hi);
			T[] merged = Merge(arr, low, mid, hi);
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
		
		#endregion

		#region Heap Sort
		
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
				{
					swap_i = child;
				}
				if (child + 1 <= end && arr[swap_i].CompareTo(arr[child + 1]) < 0)
				{
					swap_i = child + 1;
				}
				if (swap_i == root)
				{
					return;
				}
				else
				{
					Swap(ref arr[root], ref arr[swap_i]);
					root = swap_i;
				}
			}
		}

		#endregion
	}
}
