namespace SupermarketQueue
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            bool over = false;
            var sQueue = new SupermarketQueueFast();
            while (!over)
            {
                string line = Console.ReadLine();
                if (line == "End")
                    break;
                else
                    sQueue.ExecuteCommand(line);
            }
        }
    }
}
