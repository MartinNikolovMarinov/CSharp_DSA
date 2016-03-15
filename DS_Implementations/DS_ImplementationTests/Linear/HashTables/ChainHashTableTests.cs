namespace DS_ImplementationTests.Linear.HashTables
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using DS_Implementations.Linear.HashTables;

    [TestClass]
    public class ChainHashTableTests
    {
        private static Random rnd = new Random();

        [TestMethod]
        public void AddingRandomElements()
        {
            ChainHashTable<int, List<string>> test = new ChainHashTable<int, List<string>>(2);
            test.Add(0, new List<string>() { 
                "apple",
                "orange"
            });
            test.Add(1, new List<string>() { 
                "banana",
                "pudding"
            });
            test.Add(2, new List<string>() { 
                "yogurt",
                "biscuit"
            });

            CollectionAssert.AreEqual(new List<string>() { "apple", "orange" }, test[0]);
            CollectionAssert.AreEqual(new List<string>() { "banana", "pudding" }, test[1]);
            CollectionAssert.AreEqual(new List<string>() { "yogurt", "biscuit" }, test[2]);

            test.AddOrReplace(2, new List<string>() { 
                "replaced",
                "replaced"
            });

            CollectionAssert.AreEqual(new List<string>() { "apple", "orange" }, test[0]);
            CollectionAssert.AreEqual(new List<string>() { "banana", "pudding" }, test[1]);
            CollectionAssert.AreEqual(new List<string>() { "replaced", "replaced" }, test[2]);
        }

        [TestMethod]
        public void RemoveAndCopyTo()
        {
            ChainHashTable<string, string> test = new ChainHashTable<string, string>();
            test.Add("Pesho", "student");
            test.Add("Paco", "teacher");
            test.Add("Gaco", "student");

            Assert.AreEqual("student", test["Pesho"]);
            Assert.AreEqual("teacher", test.Get("Paco"));
            Assert.AreEqual("student", test["Gaco"]);
            Assert.AreEqual(3, test.Count);

            test.Remove("Gaco");
            KeyValue<string, string>[] expected = 
            { 
                new KeyValue<string, string>("Pesho", "student"),
                new KeyValue<string, string>("Paco", "teacher")
            };
            KeyValue<string, string>[] result = new KeyValue<string, string>[2];
            test.CopyTo(result, 0);

            CollectionAssert.AreEqual(expected, result);
            Assert.AreEqual(2, test.Count);
        }

        [TestMethod]
        public void AddManyElements()
        {
            ChainHashTable<int, int> test = new ChainHashTable<int, int>();
            const int testLen = 100000;
            int[] expected = new int[testLen];

            for (int i = 0; i < testLen ; i++)
            {
                int currRndInt = rnd.Next(-1000, 1000);
                test.AddOrReplace(i, currRndInt);
                expected[i] = currRndInt;
            }

            for (int i = 0; i < testLen; i++)
            {
                Assert.AreEqual(expected[i], test[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ExistingElement()
        {
            ChainHashTable<int, int> test = new ChainHashTable<int, int>();
            test.Add(1, 1);
            test.Add(1, 5);
        }
    }
}
