namespace _03.FastSearchForStringsInFile
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            DateTime startTime = DateTime.Now;

            // Read the input list of words
            string[] wordsOriginal = File.ReadAllLines("../../words.txt");
            string[] wordsLowercase =
                wordsOriginal.Select(w => w.ToLower()).ToArray();

            // Read the text
            string text = File.ReadAllText("../../big_file.txt").ToLower();

            // Find all word matches and count them
            var search = new AhoCorasickSearch();
            var matches = search.SearchAll(text, wordsLowercase);
            Dictionary<string, int> occurrences =
                new Dictionary<string, int>();
            foreach (string word in wordsLowercase)
            {
                occurrences[word] = 0;
            }
            foreach (var match in matches)
            {
                string word = match.Match;
                occurrences[word]++;
            }

            // Print the result
            using (StreamWriter result = File.CreateText("../../result.txt"))
            {
                foreach (string word in wordsOriginal)
                {
                    result.WriteLine("{0} --> {1}", word,
                        occurrences[word.ToLower()]);
                }
            }

            Console.WriteLine(DateTime.Now - startTime);
        }
    }
}
