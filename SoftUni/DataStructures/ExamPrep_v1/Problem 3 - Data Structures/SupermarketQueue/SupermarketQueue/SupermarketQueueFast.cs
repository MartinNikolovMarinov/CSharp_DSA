namespace SupermarketQueue
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class SupermarketQueueFast
    {
        BigList<string> repository = new BigList<string>();
        Bag<string> names = new Bag<string>();

        private void Append(string name)
        {
            this.repository.Add(name);
            this.names.Add(name);
        }

        private bool Insert(int position, string name)
        {
            if (this.names.Count < position || position < 0)
            {
                return false;
            }
            
            this.repository.Insert(position, name);
            this.names.Add(name);
            return true;
        }

        private int Find(string name)
        {
            int occurences = this.names.NumberOfCopies(name);
            return occurences;
        }

        private IEnumerable<string> Serve(int count)
        {
            if (count > this.names.Count || count < 0)
            {
                return null;
            }

            var servedNames = this.repository.Range(0, count).ToList();
            this.repository.RemoveRange(0, count);
            this.names.RemoveMany(servedNames);
            return servedNames;
        }

        public void ExecuteCommand(string commandStr)
        {
            string[] commands = commandStr.Split();

            if (commands[0] == "Append")
            {
                string name = commands[1];
                this.Append(name);
                Console.WriteLine("OK");
            }
            else if (commands[0] == "Insert")
            {
                int possition = int.Parse(commands[1]);
                string name = commands[2];
                bool insertOk = this.Insert(possition, name);
                if (insertOk)
                    Console.WriteLine("OK");
                else
                    Console.WriteLine("Error");
            }
            else if (commands[0] == "Find")
            {
                string name = commands[1];
                int occurences = this.Find(name);
                Console.WriteLine(occurences);
            }
            else if (commands[0] == "Serve")
            {
                int count = int.Parse(commands[1]);
                var serveString = this.Serve(count);
                if (serveString != null)
                    serveString.FirstOrDefault(x => { Console.WriteLine(x); return false; });
                else
                    Console.WriteLine("Error");
            }
        }
    }
}
