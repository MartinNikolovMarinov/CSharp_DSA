using System.Collections.Generic;

namespace CalculateArithmeticExpression
{
    public static class AritmeticExpressionEvaluator
    {
        public static double Run(string input) 
        {
            List<Token> tokens = Lexer.RunLexer(input);
            Queue<Token> reversedExpression = Parser.RunParser(tokens);
            double result = Evaluater.RunEvaluater(reversedExpression);
            return result;
        }
    }
}
