namespace _02.StringEditor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            CommandController.ReadCommands();
            Console.WriteLine();
            CommandController.RunCommands();
        }
    }
}
