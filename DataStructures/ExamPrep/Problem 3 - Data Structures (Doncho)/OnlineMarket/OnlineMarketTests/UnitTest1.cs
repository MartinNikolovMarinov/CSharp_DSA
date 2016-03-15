namespace OnlineMarketTests
{
    using System;
    using System.IO;
    using System.Text;
    using OnlineMarket;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    [TestClass]
    public class UnitTest1
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

        [TestMethod]
        public void Test1()
        {
            string testIn = ReadTest("test.001.in.txt");
            string testOut = ReadTest("test.001.out.txt");
            market = new OnlineMarket();
            CommandController.ExecuteCommand(testIn, market);
        }
    }
}
