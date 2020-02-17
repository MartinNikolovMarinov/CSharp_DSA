namespace CalculateArithmeticExpression
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public static class Parser
    {
        public static Queue<Token> RunParser(List<Token> tokens)
        {
            Queue<Token> reversedExpression = RevereseNotation(tokens);
            return reversedExpression;
        }

        private static int currOperatorPriority = 0;
        private static int topOperotorPriority = 0;

        private static Queue<Token> RevereseNotation(List<Token> tokens)
        {
            Queue<Token> reversedExpression = new Queue<Token>();
            Stack<Token> operatorBuffer = new Stack<Token>();

            for (int i = 0; i < tokens.Count; i++)
            {
                var currentToken = tokens[i];

                if (currentToken.Descriptor == "number")
                {
                    reversedExpression.Enqueue(currentToken);
                }
                else if (currentToken.Descriptor == "operator" &&
                        currentToken.Value.Equals('-') &&
                        i + 1 < tokens.Count &&
                        IsUnaryMinus(tokens, i, tokens.Count))
                {
                    // The minus is part of the number.
                    tokens[i + 1].Value = 0 - (double)tokens[i + 1].Value;
                    reversedExpression.Enqueue(tokens[i + 1]);
                    i++;
                }
                else if (currentToken.Descriptor == "operator")
                {
                    if (operatorBuffer.Count == 0)
                    {
                        operatorBuffer.Push(currentToken);
                        continue;
                    }

                    currOperatorPriority = GetPriority(currentToken);
                    topOperotorPriority = GetPriority(operatorBuffer.Peek());

                    if (currentToken.Value.Equals(')'))
                    {
                        HandleCloseingBracket(reversedExpression, operatorBuffer, currentToken);
                    }
                    else if (currOperatorPriority < topOperotorPriority)
                    {
                        operatorBuffer.Push(currentToken);
                    }
                    else
                    {
                        SaveTokensWithHigherPriority(reversedExpression, operatorBuffer, currentToken);
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid expression.");
                }
            }

            while (operatorBuffer.Count > 0)
            {
                if (operatorBuffer.Peek().Value.Equals('('))
                {
                    throw new ArgumentException("A bracket was not closed.");
                }

                reversedExpression.Enqueue(operatorBuffer.Pop());
            }

            return reversedExpression;
        }

        private static void SaveTokensWithHigherPriority(Queue<Token> reversedExpression, Stack<Token> operatorBuffer, Token currentToken)
        {
            while (operatorBuffer.Count > 0)
            {
                Token topOperator = operatorBuffer.Peek();
                topOperotorPriority = GetPriority(topOperator);

                if (topOperator.Value.Equals('('))
                {
                    break;
                }

                if (currOperatorPriority < topOperotorPriority || operatorBuffer.Count == 0)
                {
                    break;
                }

                reversedExpression.Enqueue(operatorBuffer.Pop());
            }

            operatorBuffer.Push(currentToken);
        }

        private static void HandleCloseingBracket(Queue<Token> reversedExpression, Stack<Token> operatorBuffer, Token currentToken)
        {
            bool foundOpeningBracket = false;

            while (operatorBuffer.Count > 0)
            {
                Token topOperator = operatorBuffer.Peek();
                topOperotorPriority = GetPriority(topOperator);

                if (topOperator.Value.Equals('(') && currentToken.Value.Equals(')'))
                {
                    foundOpeningBracket = true;
                    operatorBuffer.Pop();
                    break;
                }

                reversedExpression.Enqueue(operatorBuffer.Pop());
            }

            if (foundOpeningBracket == false)
            {
                throw new ArgumentException("A closing bracket doesn't have an opening friend.");
            }
        }

        private static bool IsUnaryMinus(List<Token> tokens, int index, int len)
        {
            if (index == 0)
            {
                // minus in front of the expression
                return tokens[index + 1].Descriptor == "number";
            }

            if (index + 1 < len)
            {
                return tokens[index - 1].Descriptor == "operator" &&
                        tokens[index + 1].Descriptor == "number";
            }

            return false;
        }
            
        private static int GetPriority(Token token)
        {
            if (token.Value.Equals('(') || token.Value.Equals(')'))
            {
                return 1;
            }

            if (token.Value.Equals('*') || token.Value.Equals('/') || 
                token.Value.Equals('%'))
            {
                return 2;
            }

            if (token.Value.Equals('-') || token.Value.Equals('+'))
            {
                return 3;
            }

            throw new ArgumentException("Invalid token.");
        }
    }
}
