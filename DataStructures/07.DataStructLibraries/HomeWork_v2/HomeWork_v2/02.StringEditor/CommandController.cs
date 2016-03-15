namespace _02.StringEditor
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public static class CommandController
    {
        private static List<string> commands = new List<string>();

        public static void ReadCommands()
        {
            string curr;
            while((curr = Console.ReadLine()) != null)
            {
                if (curr == "END")
                    break;
                else
                    commands.Add(curr);
            }
        }

        public static void RunCommands()
        {
            StringEditor se = new StringEditor();

            foreach (var command in commands)
            {
                string[] cmdSplit;
                int firstWhiteSpaceIndex = command.IndexOf(' ') > 0 ? command.IndexOf(' ') : command.Length;
                string commandName = command.Substring(0, firstWhiteSpaceIndex);

                if (commandName == "APPEND")
                {
                    cmdSplit = SplitNTimes(command, ' ', 1);
                    TryCommand(() => 
                    {
                        se.Append(cmdSplit[1]);    
                    });
                }
                else if (commandName == "INSERT")
                {
                    cmdSplit = SplitNTimes(command, ' ', 2);
                    TryCommand(() =>
                    {
                        int i = int.Parse(cmdSplit[1]); // example switches places !
                        se.Insert(cmdSplit[2], i);
                    });
                }
                else if (commandName == "DELETE")
                {
                    cmdSplit = SplitNTimes(command, ' ', 3);
                    TryCommand(() =>
                    {
                        int i = int.Parse(cmdSplit[1]);
                        int count = int.Parse(cmdSplit[2]);
                        se.Delete(i, count);
                    });
                }
                else if (commandName == "REPLACE")
                {
                    cmdSplit = SplitNTimes(command, ' ', 3);
                    TryCommand(() =>
                    {
                        int i = int.Parse(cmdSplit[1]);
                        int count = int.Parse(cmdSplit[2]);
                        se.Replace(i, count, cmdSplit[3]);
                    });
                }
                else if (commandName == "PRINT")
                {
                    Console.WriteLine(se.ToString());
                }
                else
                {
                    throw new ArgumentException("Unsupported command.");
                }
            }
        }

        private static void TryCommand(Action fn)
        {
            try
            {
                fn();
                Console.WriteLine("OK");
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR");
            }
        }

        private static string[] SplitNTimes(string input, char delim, int n)
        {
            if (n <= 0)
                throw new ArgumentException("Invalid argument n.");

            List<string> ret = new List<string>();
            int count = 0;
            int start = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == delim)
                {
                    if (count++ == n)
                        break;

                    ret.Add(input.Substring(start, i - start).Trim());
                    start = i;
                }
            }

            ret.Add(input.Substring(start + 1, input.Length - start - 1));
            return ret.ToArray();
        }
    }
}
