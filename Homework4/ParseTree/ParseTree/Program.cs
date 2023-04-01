namespace ParseTree;

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("This is infix-form expression calculator.");
        Console.Write("Enter your expression: ");
        var expression = Console.ReadLine();

        try
        {
            var parseTree = new ParseTree(expression);
            Console.Write("Right infix-form expression: ");
            parseTree.Print();
            Console.WriteLine(".");
            Console.WriteLine($"Result of calculating of the expression: {parseTree.Calculate()}.");
        }
        catch (Exception ex) when (ex is ArgumentException ||
                                   ex is ArgumentNullException ||
                                   ex is DivideByZeroException)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("Press any button to exit.");
        Console.ReadKey();
    }
}