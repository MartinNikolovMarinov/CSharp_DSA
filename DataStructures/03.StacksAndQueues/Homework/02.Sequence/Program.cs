namespace _02.Sequence
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Program
    {
        public static int[] Sequence(int start, int n)
        {
            Queue<int> q = new Queue<int>();
            int[] ret = new int[n];
            ret[0] = start;
            int currSum = start;
            int i;

            for (i = 0; i < n - 1; i++)
            {
                switch (i % 3)
                {
                    case 0 :
                        q.Enqueue(currSum + 1);
                        ret[i + 1] = currSum + 1;
                        break;
                    case 1:
                        q.Enqueue(2 * currSum + 1);
                        ret[i + 1] = 2 * currSum + 1;
                        break;
                    case 2:
                        q.Enqueue(currSum + 2);
                        ret[i + 1] = currSum + 2;
                        currSum = q.Dequeue();
                        break;
                }
            }

            return ret;
        }

        static void Main(string[] args)
        {
            int startingNum = 1000;
            int[] result = Sequence(startingNum, 50);
            Array.ForEach(result, x => Console.Write("{0} ", x));
            Console.WriteLine();
        }
    }
}
