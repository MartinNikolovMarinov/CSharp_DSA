namespace _05.LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedStack<int> l = new LinkedStack<int>();
            l.Push(5);
            l.Push(2);
            l.Push(3);
            int n = l.Pop();
        }
    }
}
