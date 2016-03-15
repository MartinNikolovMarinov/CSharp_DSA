namespace _04.StringEditor
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        public static void ReadBigFile(StringEditor se) 
        {
            string path = @"../../test.txt";
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            using (StreamReader reader = new StreamReader(fs))
            {
                se.Append(reader.ReadToEnd());
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Start work on big data...");

            StringEditor se = new StringEditor();
            ReadBigFile(se);
            Console.WriteLine(se.Count);

            Console.WriteLine("Done");

            /*
            se.Append("Pesho");
            se.Insert(" Goshev", se.Count);
            se.Print();

            Console.WriteLine();
            se.Replace(0, se.Count, "Changed Name");
            se.Print();

            Console.WriteLine();
            se.Delete(0, 8);
            se.Print();

            Console.WriteLine();
            */
        }
    }
}
