namespace _01.FindWordsInFile
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, int>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                string[] splitWords = line.Split();

                foreach (var word  in splitWords)
                {
                    if (dict.ContainsKey(word))
                    {
                        dict[word]++;
                    }
                    else 
                    {
                        dict.Add(word, 1);
                    }
                }
            }

            int k = int.Parse(Console.ReadLine());
            string[] words = new string[k];
            for (int i = 0; i < k; i++)
            {
                words[i] = Console.ReadLine();
            }

            for (int i = 0; i < k; i++)
            {
                string word = words[i];
                if (dict.ContainsKey(word))
                {
                    Console.WriteLine("{0} -> {1}", word, dict[word]);
                }
            }
        }
    }
}
