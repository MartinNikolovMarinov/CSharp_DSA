using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinearDataStructures;

namespace LinearDataStructuresTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SumAndAverageTest()
        {
            // test 1
            List<double> list = new List<double>() {4, 5, 6};
            double sum = SumAndAverage.Sum(list);
            double average = SumAndAverage.Average(list);

            Assert.AreEqual(15, sum);
            Assert.AreEqual(5, average);

            // test 2
            list = new List<double>() { 1, 1 };
            sum = SumAndAverage.Sum(list);
            average = SumAndAverage.Average(list);

            Assert.AreEqual(2, sum); // this one is wrong in the problem example ! 1 + 1 = 2
            Assert.AreEqual(1, average);

            // test 3
            list = new List<double>() { };
            sum = SumAndAverage.Sum(list);
            average = SumAndAverage.Average(list);

            Assert.AreEqual(0, sum);
            Assert.AreEqual(0, average);

            // test 4
            list = new List<double>() { 10 };
            sum = SumAndAverage.Sum(list);
            average = SumAndAverage.Average(list);

            Assert.AreEqual(10, sum);
            Assert.AreEqual(10, average);

            // test 5
            list = new List<double>() { 2, 2, 1 };
            sum = SumAndAverage.Sum(list);
            average = SumAndAverage.Average(list);

            Assert.AreEqual(5, sum);
            Assert.AreEqual(1.6666666666666667, average);

        }  
    }
}
