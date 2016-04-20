namespace Sortable_Collection
{
    using System;
    using System.Collections.Generic;

    public class Util
    {
        public static Random rnd = new Random();

        public static void Swap<T>(IList<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }

        public static void CopyArrToList<T>(T[] source, int sourceStart, List<T> dest, int destStart, int count)
        {
            if (sourceStart + count > source.Length || sourceStart < 0 ||
                destStart + count > dest.Count || destStart < 0)
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = 0; i < count; i++)
            {
                dest[i + destStart] = source[i + sourceStart];
            }
        }
    }
}
