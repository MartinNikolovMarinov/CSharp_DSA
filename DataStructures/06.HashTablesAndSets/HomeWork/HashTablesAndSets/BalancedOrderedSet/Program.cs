namespace BalancedOrderedSet
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var set = new BalancedOrderedSet<int>();
            set.Add(17);
            set.Add(9);
            set.Add(12);
            set.Add(19);
            set.Add(6);
            set.Add(25);

            int[] expectedResult = { 6, 9, 12, 17, 19, 25 };
            string ret = set.ToString();
        }
    }
}
