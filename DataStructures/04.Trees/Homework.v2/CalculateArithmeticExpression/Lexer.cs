namespace CalculateArithmeticExpression
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class Lexer
    {
        public static readonly char[] operatorList = { '/', '*', '-', '+', ')', '(', '%'};

        private static bool IsOperator(char symbol)
        {
            return operatorList.Contains(symbol);
        }

        public static List<Token> RunLexer(string expression)
        {
            List<Token> tokens = new List<Token>();
            int inputLenght = expression.Length;

            for (int i = 0; i < inputLenght; i++)
            {
                if (char.IsWhiteSpace(expression[i]))
                {
                    // Ignore white spaces.
                    continue;
                }
                else if (char.IsNumber(expression[i]))
                {
                    Token numberToken = ExtractNumberAsToken(expression, ref i, inputLenght);
                    tokens.Add(numberToken);
                }
                else if (IsOperator(expression[i]))
                {
                    Token operatorToken = new Token("operator", expression[i]);
                    tokens.Add(operatorToken);
                }
                else
                {
                    throw new ArgumentException("Unrecognized token!");
                }
            }

            return tokens;
        }

        private static Token ExtractNumberAsToken(string input, ref int inputIndx, int inputLenght)
        {
            StringBuilder numBuffer = new StringBuilder();
            int dotCounter = 0;
            numBuffer.Append(input[inputIndx]);

            if (inputIndx < inputLenght - 1)
            {
                while (char.IsNumber(input[inputIndx + 1]) || input[inputIndx + 1] == '.')
                {
                    // Checking how many dots there are in a sequence considered to be a number.
                    if (input[inputIndx + 1] == '.')
                    {
                        dotCounter++;
                    }

                    // If there are more than one explode.
                    if (dotCounter > 1)
                    {
                        throw new ArgumentException("There are to many dots in a number in the expression.");
                    }

                    numBuffer.Append(input[inputIndx + 1]);
                    inputIndx++;
                    if (inputIndx == inputLenght - 1)
                    {
                        break;
                    }
                }
            }

            
            double number;
            if (!double.TryParse(numBuffer.ToString(), out number))
            {
                // Should never happen.
                throw new InvalidCastException("Casting failed.");
            }

            return new Token("number", number);
        }
    }
}
