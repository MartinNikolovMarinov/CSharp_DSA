namespace CountSymbols
{
    using System;
    using System.Linq;
    using Dictionary;

    class Program
    {
        static HashTable<char, int> CountSymbols(string input) 
        {
            HashTable<char, int> dict = new HashTable<char, int>(input.Length);

            for (int i = 0; i < input.Length; i++)
            {
                var currentSymbol = dict.Find(input[i]);

                if (currentSymbol != null)
                {
                    dict.AddOrReplace(input[i], currentSymbol.Value + 1);
                }
                else 
                {
                    dict.Add(input[i], 1);
                }
            }

            return dict;
        }

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var dict = CountSymbols(input).OrderBy(e => e.Key);
            foreach (var symbol in dict)
            {
                Console.WriteLine("{0} : {1} time/s", symbol.Key, symbol.Value);
            }
        }
    }
}
