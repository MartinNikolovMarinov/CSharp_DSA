namespace _03.ArrayStack
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayStack<int> s = new ArrayStack<int>(1);
            s.Push(10);
            s.Push(8);
            int n = s.Pop();
        }
    }
}
