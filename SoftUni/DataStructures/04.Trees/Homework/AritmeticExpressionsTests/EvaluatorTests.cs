using CalculateArithmeticExpression;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AritmeticExpressionsTests
{
    [TestClass]
    public class EvaluatorTests
    {
        [TestMethod]
        public void SoftUniTests()
        {
            string input = "2+3*4";
            double result = AritmeticExpressionEvaluator.Run(input);
            Assert.AreEqual(14d, result);

            input = "5 + 6";
            result = AritmeticExpressionEvaluator.Run(input);
            Assert.AreEqual(11d, result);

            input = "(2 + 3) * 4.5";
            result = AritmeticExpressionEvaluator.Run(input);
            Assert.AreEqual(22.5d, result);

            input = "2 + 3 * 1.5 - 1";
            result = AritmeticExpressionEvaluator.Run(input);
            Assert.AreEqual(5.5d, result);

            input = "-2 - -1";
            result = AritmeticExpressionEvaluator.Run(input);
            Assert.AreEqual(-1d, result); // This one is wrong in the example -2 - -1 = -2 + 1 = -1 !!
            
            input = "1.5 - 2.5 * 2 * (-3)";
            result = AritmeticExpressionEvaluator.Run(input);
            Assert.AreEqual(16.5d, result);

            input = "1/2";
            result = AritmeticExpressionEvaluator.Run(input);
            Assert.AreEqual(0.5d, result);
        }

         [TestMethod]
         [ExpectedException(typeof(ArgumentException), "Invalid Expression")]
         public void SoftUniExceptionTest() 
         {
             string input = "3 ++ 4";
             double result = AritmeticExpressionEvaluator.Run(input);
             Assert.AreEqual(14d, result);
         }
    }
}
