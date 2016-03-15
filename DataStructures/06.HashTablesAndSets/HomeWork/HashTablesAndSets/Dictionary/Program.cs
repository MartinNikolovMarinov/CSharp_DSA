namespace Dictionary
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var table = new HashTable<string, string>();
            table.Add("example_one", "aaa");
            table["example_two"] = "bbb";
            table["example_three"] = "ccc";
            table.Remove("example_three");

            Array.ForEach(table.ToArray(), 
                item => Console.WriteLine("{0} - {1}", item.Key, item.Value));
        }
    }
}
