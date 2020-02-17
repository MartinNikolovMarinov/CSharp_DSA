namespace AATree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            AATree<int> tree = new AATree<int>();
            tree.Add(15);
            tree.Add(20);
            tree.Add(25);
            tree.Add(16);
            tree.Add(10);
            tree.Add(11);
            tree.Add(5);

            Console.WriteLine(tree);
            bool r1 = tree.Remove(5);
            bool r2 = tree.Remove(10);
            bool r3 = tree.Remove(11);
            bool r4 = tree.Remove(16);
            Console.WriteLine(tree);
            bool r5 = tree.Remove(25);
            bool r6 = tree.Remove(15);
            bool r7 = tree.Remove(2000); // expect false.
            bool r8 = tree.Remove(20);
            Console.WriteLine(tree);
        }
    }
}
