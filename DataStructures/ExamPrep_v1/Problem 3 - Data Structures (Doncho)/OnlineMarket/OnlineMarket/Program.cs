namespace OnlineMarket
{
    using System;
    using System.Globalization;
    using System.Threading;

    using System.IO;
    using System.Text;
    using System.Collections.Generic;

    class Program
    {
        static readonly string basePath = @"../../../../Tests/";
        static OnlineMarket market;

        static string ReadTest(string fileName)
        {
            StringBuilder sb = new StringBuilder();
            using (StreamReader sr = new StreamReader(basePath + fileName))
            {
                while (sr.Peek() >= 0)
                {
                    sb.AppendLine(sr.ReadLine());
                }
            }

            return sb.ToString();
        }

        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            /*bool over = false;
            OnlineMarket market = new OnlineMarket();

            while (!over)
            {
                string line = Console.ReadLine();
                over = CommandController.ExecuteCommand(line, market);
            }*/

            var originalConsoleOut = Console.Out; // preserve the original stream
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);

                market = new OnlineMarket();
                string[] testIn = ReadTest("test.001.in.txt").Split(new string[] { "\r\n" }, StringSplitOptions.None);
                string[] testOut = ReadTest("test.001.out.txt").Split(new string[] { "\r\n" }, StringSplitOptions.None);

                for (int i = 0; i < testIn.Length; i++)
                {
                    CommandController.ExecuteCommand(testIn[i], market);
                }

                string[] results = writer.GetStringBuilder().ToString().Split(new string[] { "\r\n" }, StringSplitOptions.None);

                for (int i = 0; i < testOut.Length; i++)
                {
                    if (results[i] != testOut[i])
                    {
                        Console.WriteLine();
                    }
                }
            }

            Console.SetOut(originalConsoleOut); // restore Console.Out

        }
    }
}
