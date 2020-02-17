namespace _01.StudentsAndCourses
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    class Program
    {
        private static readonly string PathToData = @"../../Data/input.txt";

        private static SortedDictionary<string, SortedSet<Person>> MapData(string[] input) 
        {
            var peopleCourses = new SortedDictionary<string, SortedSet<Person>>();
            foreach (var line in input)
            {
                string[] splitLine = line.Split('|');
                string firstName = splitLine[0].Trim();
                string lastName = splitLine[1].Trim();
                string courseName = splitLine[2].Trim();

                if (peopleCourses.ContainsKey(courseName))
                {
                    peopleCourses[courseName].Add(new Person(firstName, lastName));
                }
                else
                {
                    var newSet = new SortedSet<Person>()
                    {
                        new Person(firstName, lastName)
                    };
                    peopleCourses.Add(courseName, newSet);
                }
            }

            return peopleCourses;
        }

        private static void PrintPeopleCourses(SortedDictionary<string, SortedSet<Person>> peopleCourses) 
        {
            foreach (var peopleSet in peopleCourses)
            {
                Console.Write("{0}: ", peopleSet.Key);
                int i = 0;
                int peopleInSetCount = peopleSet.Value.Count;
                foreach (var person in peopleSet.Value)
                {
                    i++;
                    Console.Write("{0} {1}", person.FirstName, person.LastName);
                    if (i <= peopleInSetCount - 1)
                    {
                        Console.Write(", ");
                    }
                }

                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(PathToData);
            var peopleCourses = MapData(input);
            PrintPeopleCourses(peopleCourses);
        }
    }
}
