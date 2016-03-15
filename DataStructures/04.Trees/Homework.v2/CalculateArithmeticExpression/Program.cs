namespace CalculateArithmeticExpression
{
    using System;
    using System.Globalization;
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            Console.Write("Expression = ");
            string input = Console.ReadLine();

            try
            {
                if (String.IsNullOrWhiteSpace(input)) 
                    throw new ArgumentException("Invalid expression.");

                Console.WriteLine(AritmeticExpressionEvaluator.Run(input));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
