namespace Phonebook
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Dictionary;

    class Program
    {
        static List<string> ReadInput() 
        {
            string currentLine = Console.ReadLine();
            List<string> inputList = new List<string>();
            while (currentLine != "")
            {
                inputList.Add(currentLine);
                currentLine = Console.ReadLine();
            }

            return inputList;
        }

        static HashTable<string, string> CreatePhonebook(List<string> inputList, int indexOfSearchCommand)
        {
            var phonebook = new HashTable<string, string>();
            for (int i = 0; i < indexOfSearchCommand; i++)
            {
                string[] splitLine = inputList[i].Split('-');
                string name = splitLine[0];
                string phone = splitLine[1];
                phonebook.Add(name, phone);
            }

            return phonebook;
        }
        private static List<string> CreateSearchTermList(List<string> inputList, int indexOfSearchCommand)
        {
            var searchTerms = new List<string>();
            for (int i = indexOfSearchCommand + 1; i < inputList.Count; i++)
            {
                searchTerms.Add(inputList[i]);
            }

            return searchTerms;
        }

        private static void PrintPhonebookSearchResults(HashTable<string, string> phonebook, List<string> searchTerms)
        {
            foreach (var personName in searchTerms)
            {
                var person = phonebook.Find(personName);

                if (person != null)
                {
                    string phoneNumber = person.Value;
                    Console.WriteLine("{0} -> {1}", personName, phoneNumber);
                }
                else 
                {
                    Console.WriteLine("Contact {0} does not exist.", personName);
                }
            }
        }

        static void Main(string[] args)
        {
            List<string> inputList = ReadInput();
            int indexOfSearchCommand = inputList.IndexOf("search");
            HashTable<string, string> phonebook = CreatePhonebook(inputList, indexOfSearchCommand);
            List<string> searchTerms = CreateSearchTermList(inputList, indexOfSearchCommand);
            PrintPhonebookSearchResults(phonebook, searchTerms);
        }
      
    }
}
