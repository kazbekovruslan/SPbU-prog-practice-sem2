namespace Routers;

using System;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Incorrect amount of arguments!");
            Console.WriteLine("Enter 'dotnet run [path to input file] [path to output file].");
            return;
        }

        if (!File.Exists(args[0]))
        {
            Console.WriteLine("File not found!");
        }

        var input = File.ReadAllText(args[0]);

        try
        {
            File.WriteAllText(args[1], TopologyBuilder.FindMaximumSpeedTopology(input));
        }
        catch (Exception ex) when (ex is ArgumentException ||
                                   ex is ArgumentNullException)
        {
            Console.Error.WriteLine(ex.Message);
        }

        Console.WriteLine("\nDone! Press any key to exit.");
        Console.ReadKey();
    }
}