namespace Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using _04.StringEditor;

    [TestClass]
    public class StringEditorTests
    {
        [TestMethod]
        public void StringEditorWithBigInputTest()
        {
            StringEditor se = new StringEditor();
            int testVar = 10000;

            // append 10000 elements
            for (int i = 0; i < testVar; i++)
            {
                se.Append("*");
            }

            // insert 10000 elements
            for (int i = 0; i < testVar; i++)
            {
                se.Insert("+", i);
            }

            // replace 20000 elements one by one
            for (int i = 0; i < testVar * 2; i++)
            {
                se.Replace(i, 1, "-");
            }

            // delete 20000 elements one by one
            for (int i = 0; i < testVar * 2; i++)
            {
                se.Delete(0, 1);
            }

            Assert.AreEqual("", se.ToString());
        }

        [TestMethod]
        public void BigDataAppendTest() 
        {
            StringEditor se = new StringEditor();
            int testVar = 1000000;
            string testStr = "not that simple of a string!";
            for (int i = 0; i < testVar; i++)
            {
                se.Append(testStr);
            }

            Assert.AreEqual(testVar * testStr.Length, se.Count);

            // Insertion in big data.
            testStr = "PESHOINSERTEDINTOTHEMATRIX";
            se.Insert(testStr, 200);
            CollectionAssert.AreEqual(new char[] {'P','E','S','H','O','I','N','S','E','R','T',
                    'E','D','I','N','T','O','T','H','E','M','A','T','R','I','X'}, se.GetRange(200, testStr.Length));

            // Deletion in big data.
            se.Delete(200, testStr.Length - 5);
            CollectionAssert.AreEqual(new char[] {'A','T','R','I','X'}, se.GetRange(200, 5));

            // Replacing in big data.
            se.Replace(200, 4, "PESHO");
            CollectionAssert.AreEqual(new char[] { 'P', 'E', 'S', 'H', 'O' }, se.GetRange(200, 5));
        }
    }
}
