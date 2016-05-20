using CalculateArithmeticExpression;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AritmeticExpressionsTests
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public void StandartInputTest1() 
        {
            string input = "2+3*5-1+4";
            List<Token> tokens = Lexer.RunLexer(input);
            Queue<Token> reversedExpression = Parser.RunParser(tokens);
            
            Assert.AreEqual(2d, reversedExpression.Dequeue().Value);
            Assert.AreEqual(3d, reversedExpression.Dequeue().Value);
            Assert.AreEqual(5d, reversedExpression.Dequeue().Value);
            Assert.AreEqual('*', reversedExpression.Dequeue().Value);
            Assert.AreEqual('+', reversedExpression.Dequeue().Value);
            Assert.AreEqual(1d, reversedExpression.Dequeue().Value);
            Assert.AreEqual('-', reversedExpression.Dequeue().Value);
            Assert.AreEqual(4d, reversedExpression.Dequeue().Value);
            Assert.AreEqual('+', reversedExpression.Dequeue().Value);
        }

        [TestMethod]
        public void StandartInputTest2()
        {
            string input = " 1.5 - 2.5  *2 *  (-  3) ";
            List<Token> tokens = Lexer.RunLexer(input);
            Queue<Token> reversedExpression = Parser.RunParser(tokens);
            
            Assert.AreEqual(1.5d, reversedExpression.Dequeue().Value);
            Assert.AreEqual(2.5d, reversedExpression.Dequeue().Value);
            Assert.AreEqual(2d, reversedExpression.Dequeue().Value);
            Assert.AreEqual('*', reversedExpression.Dequeue().Value);
            Assert.AreEqual(-3d, reversedExpression.Dequeue().Value);
            Assert.AreEqual('*', reversedExpression.Dequeue().Value);
            Assert.AreEqual('-', reversedExpression.Dequeue().Value);
        }

        [TestMethod]
        public void StandartInputTest3()
        {
            string input = " 12+3/2*5-3*2-4/2 ";
            List<Token> tokens = Lexer.RunLexer(input);
            Queue<Token> reversedExpression = Parser.RunParser(tokens);
            
            Assert.AreEqual(12d, reversedExpression.Dequeue().Value);
            Assert.AreEqual(3d, reversedExpression.Dequeue().Value);
            Assert.AreEqual(2d, reversedExpression.Dequeue().Value);
            Assert.AreEqual('/', reversedExpression.Dequeue().Value);
            Assert.AreEqual(5d, reversedExpression.Dequeue().Value);
            Assert.AreEqual('*', reversedExpression.Dequeue().Value);
            Assert.AreEqual('+', reversedExpression.Dequeue().Value);
            Assert.AreEqual(3d, reversedExpression.Dequeue().Value);
            Assert.AreEqual(2d, reversedExpression.Dequeue().Value);
            Assert.AreEqual('*', reversedExpression.Dequeue().Value);
            Assert.AreEqual('-', reversedExpression.Dequeue().Value);
            Assert.AreEqual(4d, reversedExpression.Dequeue().Value);
            Assert.AreEqual(2d, reversedExpression.Dequeue().Value);
            Assert.AreEqual('/', reversedExpression.Dequeue().Value);
            Assert.AreEqual('-', reversedExpression.Dequeue().Value);
        }

        [TestMethod]
        public void NestedBraketTest1()
        {
            string input = "2*(2+(3*2))";
            List<Token> tokens = Lexer.RunLexer(input);
            Queue<Token> reversedExpression = Parser.RunParser(tokens);
            
            Assert.AreEqual(2d, reversedExpression.Dequeue().Value);
            Assert.AreEqual(2d, reversedExpression.Dequeue().Value);
            Assert.AreEqual(3d, reversedExpression.Dequeue().Value);
            Assert.AreEqual(2d, reversedExpression.Dequeue().Value);
            Assert.AreEqual('*', reversedExpression.Dequeue().Value);
            Assert.AreEqual('+', reversedExpression.Dequeue().Value);
            Assert.AreEqual('*', reversedExpression.Dequeue().Value);
        }

        [TestMethod]
        public void NestedBraketTest2()
        {
            string input = "-((2*3))(*(4-5)*1)()";

            List<Token> tokens = Lexer.RunLexer(input);
            Queue<Token> reversedExpression = Parser.RunParser(tokens);

            Assert.AreEqual(2d, reversedExpression.Dequeue().Value);
            Assert.AreEqual(3d, reversedExpression.Dequeue().Value);
            Assert.AreEqual('*', reversedExpression.Dequeue().Value);
            Assert.AreEqual(4d, reversedExpression.Dequeue().Value);
            Assert.AreEqual(5d, reversedExpression.Dequeue().Value);
            Assert.AreEqual('-', reversedExpression.Dequeue().Value);
            Assert.AreEqual('*', reversedExpression.Dequeue().Value);
            Assert.AreEqual(1d, reversedExpression.Dequeue().Value);
            Assert.AreEqual('*', reversedExpression.Dequeue().Value);
            Assert.AreEqual('-', reversedExpression.Dequeue().Value);
        }

        [TestMethod]
        public void EmptyBrackets()
        {
            string input = "((()))";
            List<Token> tokens = Lexer.RunLexer(input);
            Queue<Token> reversedExpression = Parser.RunParser(tokens);

            Assert.AreEqual(0, reversedExpression.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "A bracket was not closed.")]
        public void NoClosingBracket()
        {
            string input = "((()";
            List<Token> tokens = Lexer.RunLexer(input);
            Queue<Token> reversedExpression = Parser.RunParser(tokens);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "A closing bracket doesn't have an opening friend.")]
        public void NoOpeningBracket()
        {
            string input = "(2+3)*5)";
            List<Token> tokens = Lexer.RunLexer(input);
            Queue<Token> reversedExpression = Parser.RunParser(tokens);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid expression.")]
        public void InvalidExpression()
        {
            string input = "~~~@#!~~1123";
            List<Token> tokens = Lexer.RunLexer(input);
            Queue<Token> reversedExpression = Parser.RunParser(tokens);
        }
    }
}
