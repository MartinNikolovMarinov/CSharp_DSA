using System;
using LinearDataStructures;
using LinearDataStructures.DistanceInLabyrinth;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinearDataStructuresTests
{
    [TestClass]
    public class DistanceInLabyrinth
    {
        [TestMethod]
        public void DistanceInLabyrinthTest() 
        {
            LabCell[,] labirint = new LabCell[6, 6] 
            {
                {
                    new LabCell("0"),
                    new LabCell("0"),
                    new LabCell("0"),
                    new LabCell("0"),
                    new LabCell("0"),
                    new LabCell("0"),
                },                
                {                 
                    new LabCell("0"),
                    new LabCell("x"),
                    new LabCell("*"),
                    new LabCell("x"),
                    new LabCell("0"),
                    new LabCell("0"),
                },                
                {                 
                    new LabCell("0"),
                    new LabCell("0"),
                    new LabCell("x"),
                    new LabCell("0"),
                    new LabCell("0"),
                    new LabCell("0"),
                },                
                {                 
                    new LabCell("x"),
                    new LabCell("x"),
                    new LabCell("0"),
                    new LabCell("0"),
                    new LabCell("x"),
                    new LabCell("x"),
                },                
                {                 
                    new LabCell("0"),
                    new LabCell("0"),
                    new LabCell("x"),
                    new LabCell("0"),
                    new LabCell("x"),
                    new LabCell("0"),
                },
                {
                    new LabCell("x"),
                    new LabCell("x"),
                    new LabCell("0"),
                    new LabCell("0"),
                    new LabCell("0"),
                    new LabCell("x"),
                }
            };

            LabCell[,] result = LabTraversal.FindPathsInLabirint(labirint, 1, 2);

            // row 1
            Assert.AreEqual("3", result[0, 0].Value);
            Assert.AreEqual("2", result[0, 1].Value);
            Assert.AreEqual("1", result[0, 2].Value);
            Assert.AreEqual("2", result[0, 3].Value);
            Assert.AreEqual("3", result[0, 4].Value);
            Assert.AreEqual("4", result[0, 5].Value);

            // row 2
            Assert.AreEqual("4", result[1, 0].Value);
            Assert.AreEqual("x", result[1, 1].Value);
            Assert.AreEqual("*", result[1, 2].Value);
            Assert.AreEqual("x", result[1, 3].Value);
            Assert.AreEqual("4", result[1, 4].Value);
            Assert.AreEqual("5", result[1, 5].Value);

            // row 3
            Assert.AreEqual("5", result[2, 0].Value);
            Assert.AreEqual("6", result[2, 1].Value);
            Assert.AreEqual("x", result[2, 2].Value);
            Assert.AreEqual("6", result[2, 3].Value);
            Assert.AreEqual("5", result[2, 4].Value);
            Assert.AreEqual("6", result[2, 5].Value);

            // row 4
            Assert.AreEqual("x", result[3, 0].Value);
            Assert.AreEqual("x", result[3, 1].Value);
            Assert.AreEqual("8", result[3, 2].Value);
            Assert.AreEqual("7", result[3, 3].Value);
            Assert.AreEqual("x", result[3, 4].Value);
            Assert.AreEqual("x", result[3, 5].Value);

            // row 5
            Assert.AreEqual("u", result[4, 0].Value);
            Assert.AreEqual("u", result[4, 1].Value);
            Assert.AreEqual("x", result[4, 2].Value);
            Assert.AreEqual("8", result[4, 3].Value);
            Assert.AreEqual("x", result[4, 4].Value);
            Assert.AreEqual("u", result[4, 5].Value);

            // row 6
            Assert.AreEqual("x", result[5, 0].Value);
            Assert.AreEqual("x", result[5, 1].Value);
            Assert.AreEqual("10", result[5, 2].Value);
            Assert.AreEqual("9", result[5, 3].Value);
            Assert.AreEqual("10", result[5, 4].Value);
            Assert.AreEqual("x", result[5, 5].Value);   
        }
    }
}
