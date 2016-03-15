namespace CalculateArithmeticExpression
{
    using System;
    using System.Collections.Generic;

    public static class Evaluater
    {
        public static double RunEvaluater(Queue<Token> reversedExpression) 
        {
            return CalculateExpression(reversedExpression);
        }

        private static double CalculateExpression(Queue<Token> reversedExpression)
        {
            Tree evaluator = new Tree();
            Stack<double> numberBuffer = new Stack<double>();

            while (reversedExpression.Count > 0)
            {
                Token currentToken = reversedExpression.Peek();

                if (currentToken.Descriptor == "number")
                {
                    numberBuffer.Push((double)reversedExpression.Dequeue().Value);
                }
                else if (currentToken.Descriptor == "operator")
                {
                    evaluator.Value = currentToken;

                    if (numberBuffer.Count < 2)
                    {
                        throw new ArgumentException("Invalid Expression");
                    }

                    evaluator.RightNumber = numberBuffer.Pop();
                    evaluator.LeftNumber = numberBuffer.Pop();

                    double result = 0;

                    switch ((char)evaluator.Value.Value)
                    {
                        case '+':
                            result = (double)evaluator.LeftNumber.Value + (double)evaluator.RightNumber.Value;
                            break;
                        case '-':
                            result = (double)evaluator.LeftNumber.Value - (double)evaluator.RightNumber.Value;
                            break;
                        case '*':
                            result = (double)evaluator.LeftNumber.Value * (double)evaluator.RightNumber.Value;
                            break;
                        case '/':
                            result = (double)evaluator.LeftNumber.Value / (double)evaluator.RightNumber.Value;
                            break;
                        case '%':
                            result = (double)evaluator.LeftNumber.Value % (double)evaluator.RightNumber.Value;
                            break;
                        default:
                            throw new ArgumentException("Expression Error.");
                    }

                    numberBuffer.Push(result);
                    reversedExpression.Dequeue();
                }
            }

            return numberBuffer.Pop();
        }
    }
}
