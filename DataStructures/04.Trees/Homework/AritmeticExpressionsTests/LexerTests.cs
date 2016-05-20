using CalculateArithmeticExpression;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace AritmeticExpressionsTests
{
    [TestClass]
    public class LexerTests
    {
        [TestMethod]
        public void StandartInput()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            string input = "1.5-2.5*2*(-3)";
            List<Token> tokens = new List<Token>();
            tokens = Lexer.RunLexer(input);

            Assert.AreEqual(new Token("number", 1.5d), tokens[0]);
            Assert.AreEqual(new Token("operator", '-'), tokens[1]);
            Assert.AreEqual(new Token("number", 2.5d), tokens[2]);
            Assert.AreEqual(new Token("operator", '*'), tokens[3]);
            Assert.AreEqual(new Token("number", 2d), tokens[4]);
            Assert.AreEqual(new Token("operator", '*'), tokens[5]);
            Assert.AreEqual(new Token("operator", '('), tokens[6]);
            Assert.AreEqual(new Token("operator", '-'), tokens[7]);
            Assert.AreEqual(new Token("number", 3d), tokens[8]);
            Assert.AreEqual(new Token("operator", ')'), tokens[9]);

            input = "2 + 3 * 1.5    - 1";
            tokens = new List<Token>();
            tokens = Lexer.RunLexer(input);

            Assert.AreEqual(new Token("number", 2d), tokens[0]);
            Assert.AreEqual(new Token("operator", '+'), tokens[1]);
            Assert.AreEqual(new Token("number", 3d), tokens[2]);
            Assert.AreEqual(new Token("operator", '*'), tokens[3]);
            Assert.AreEqual(new Token("number", 1.5d), tokens[4]);
            Assert.AreEqual(new Token("operator", '-'), tokens[5]);
            Assert.AreEqual(new Token("number", 1d), tokens[6]);

            input = "       (2 + 3) * 4.5           ";
            tokens = new List<Token>();
            tokens = Lexer.RunLexer(input);

            Assert.AreEqual(new Token("operator", '('), tokens[0]);
            Assert.AreEqual(new Token("number", 2d), tokens[1]);
            Assert.AreEqual(new Token("operator", '+'), tokens[2]);
            Assert.AreEqual(new Token("number", 3d), tokens[3]);
            Assert.AreEqual(new Token("operator", ')'), tokens[4]);
            Assert.AreEqual(new Token("operator", '*'), tokens[5]);
            Assert.AreEqual(new Token("number", 4.5d), tokens[6]);

            input = "       5          +        6           ";
            tokens = new List<Token>();
            tokens = Lexer.RunLexer(input);

            Assert.AreEqual(new Token("number", 5d), tokens[0]);
            Assert.AreEqual(new Token("operator", '+'), tokens[1]);
            Assert.AreEqual(new Token("number", 6d), tokens[2]);

            input = "    ";
            tokens = new List<Token>();
            tokens = Lexer.RunLexer(input);

            Assert.AreEqual(0, tokens.Count);
        }
    }
}
