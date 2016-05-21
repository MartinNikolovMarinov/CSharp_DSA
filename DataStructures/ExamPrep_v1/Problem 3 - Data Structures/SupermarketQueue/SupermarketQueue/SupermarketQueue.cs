namespace SupermarketQueue
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SupermarketQueue
    {
        LinkedList<string> people = new LinkedList<string>();
        Dictionary<string, int> nameOccurences = new Dictionary<string, int>();

        public SupermarketQueue() { }

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
                bool insertOk = this.Insert(name, possition);
                if(insertOk)
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
                string serveString = this.Serve(count);
                if (serveString != null)
                    Console.WriteLine(serveString);
                else
                    Console.WriteLine("Error");
            }
        }

        private string Serve(int count)
        {
            StringBuilder sb = new StringBuilder();
            if (this.people.Count < count || count < 0)
            {
                return "Error";                
            }

            var current = this.people.First;
            for (int i = 0;  i < count; i++)
            {
                if (this.nameOccurences[current.Value] == 1)
                    this.nameOccurences.Remove(current.Value);
                else
                    this.nameOccurences[current.Value]--;

                sb.AppendFormat("{0} ", current.Value);
                current = current.Next;
                this.people.RemoveFirst();
            }

            return sb.ToString();
        }

        private int Find(string name)
        {
            if (this.nameOccurences.ContainsKey(name))
                return this.nameOccurences[name];
            else
                return 0;
        }

        private bool Insert(string name, int possition)
        {
            if (possition > this.people.Count || possition < 0)
            {
                return false;
            }
            else if (possition == this.people.Count)
            {
                this.people.AddLast(name);
                this.AddNameOccurence(name);
                return true;
            }
            else if (this.people.Count == 0)
            {
                this.people.AddFirst(name);
                return true;
            }

            int counter = 0;
            var current = this.people.First;
            foreach (var item in this.people)
            {
                if (counter == possition)
                {
                    break;
                }

                counter++;
                current = current.Next;
            }
           
            this.people.AddBefore(current, name);
            this.AddNameOccurence(name);
            return true;
        }

        private void Append(string name)
        {
            this.people.AddLast(name);
            this.AddNameOccurence(name);
        }

        private void AddNameOccurence(string name)
        {
            if (this.nameOccurences.ContainsKey(name))
                this.nameOccurences[name]++;
            else 
                this.nameOccurences.Add(name, 1);
        }
    }
}
