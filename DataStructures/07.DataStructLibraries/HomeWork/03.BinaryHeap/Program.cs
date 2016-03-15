namespace _03.BinaryHeap
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue<int> q = new PriorityQueue<int>();

            q.Enqueue(15);
            q.Enqueue(2);
            q.Enqueue(4);

            Console.WriteLine(q.Dequeue());
            Console.WriteLine(q.Dequeue());
            Console.WriteLine(q.Dequeue());
        }
    }
}
