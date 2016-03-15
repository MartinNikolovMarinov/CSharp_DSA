namespace DS_Implementations
{
    using System;
    using System.Text;

    public static class Global
    {
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        public static string ElementsToString<T>(this T[] arr, string delimiter = ", ")
        {
            StringBuilder elementsToString = new StringBuilder();

            elementsToString.Append("[ ");
            for (int i = 0; i < arr.Length; i++)
            {
                elementsToString.Append(arr[i]);

                if (i != arr.Length - 1)
                {
                    elementsToString.Append(delimiter);
                }
            }

            elementsToString.Append(" ]");
            return elementsToString.ToString();
        }
    }
}
