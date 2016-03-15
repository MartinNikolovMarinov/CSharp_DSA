namespace _09.SequenceNtoM
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;

    class Program
    {
        public class Item<T>
        {
            public T value;
            public Item<T> prev;
        }

        static public Item<int> FindSequence(int n, int m)
        {
            if (n > m)
                return null;

            Item<int> currItem = null;
            Queue<Item<int>> q = new Queue<Item<int>>();
            q.Enqueue(new Item<int>() { value = n, prev = null });
            
            while (q.Count > 0)
            {
                currItem = q.Dequeue();
                if (currItem.value == m)
                    break;

                if (currItem.value < m)
                {
                    q.Enqueue(new Item<int>()
                    {
                        value = currItem.value * 2,
                        prev = currItem
                    });
                    q.Enqueue(new Item<int>()
                    {
                        value = currItem.value + 2,
                        prev = currItem
                    });
                    q.Enqueue(new Item<int>()
                    {
                        value = currItem.value + 1,
                        prev = currItem
                    });
                }
            }

            return currItem;
        }

        static void Main(string[] args)
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("m = ");
            int m = int.Parse(Console.ReadLine());
            Stack<int> result = new Stack<int>();
            Item<int> seq = FindSequence(n, m);
            if (seq == null) 
            {
                Console.WriteLine("(no solution)");
                return;
            }

            while (seq != null)
            {
                result.Push(seq.value);
                seq = seq.prev;
            }

            int i = 0;
            result.ToList().ForEach(x =>
            {
                if (++i < result.Count)
                    Console.Write("{0} -> ", x);
                else
                    Console.Write("{0}", x);
            });

            Console.WriteLine();
        }
    }
}
