namespace StackCalculator;

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("This is stack calculator that works with an expression in a postfix form.");
        Console.Write("Enter your expression in posfix form: ");
        string? expression = Console.ReadLine();

        if (expression == null)
        {
            throw new ArgumentNullException("Expression can't be null!");
        }

        double result = 0;

        try
        {
            var dynamicArrayStack = new DynamicArrayStack();
            var stackCalculator = new StackCalculator(dynamicArrayStack);

            result = stackCalculator.EvaluateExpression(expression);
            Console.WriteLine($"Result of calculating your expression by DYNAMIC ARRAY stack: {result}");

            var linkedListStack = new LinkedListStack();
            stackCalculator = new StackCalculator(linkedListStack);

            result = stackCalculator.EvaluateExpression(expression);
            Console.WriteLine($"Result of calculating your expression by LINKED LIST stack: {result}");
        }
        catch (Exception ex) when (ex is ArgumentException ||
                                   ex is ArgumentNullException ||
                                   ex is DivideByZeroException ||
                                   ex is InvalidOperationException)
        {
            Console.WriteLine(ex.Message);
        }

        Console.ReadKey();
    }
}