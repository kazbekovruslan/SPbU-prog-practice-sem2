namespace LZW;

using System;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Incorrect amount of arguments. Enter 'dotnet run [file name] [--c/--u]'.");
        }
        else
        {
            if (!File.Exists(args[0]))
            {
                Console.WriteLine("File not found!");
            }
            else
            {
                switch (args[1])
                {
                    case "--c":
                        var pathToFile = args[0];
                        if (!File.Exists(pathToFile))
                        {
                            Console.WriteLine("File doesn't exist!");
                            return;
                        }
                        var input = File.ReadAllBytes(pathToFile);
                        var output = LZWEncoder.Encode(input);
                        File.WriteAllBytes(pathToFile + ".zipped", output);
                        Console.WriteLine("Compressing done!");
                        Console.WriteLine($"Compression ratio: {(double)input.Length / output.Length}");
                        break;
                    case "--u":
                        var pathToZippedFile = args[0];
                        if (!File.Exists(pathToZippedFile))
                        {
                            Console.WriteLine("File doesn't exist!");
                            return;
                        }
                        input = File.ReadAllBytes(pathToZippedFile);
                        File.WriteAllBytes(pathToZippedFile.Substring(0, pathToZippedFile.Length - 7), LZWDecoder.Decode(input));
                        Console.WriteLine("Decompressing done!");
                        break;
                    default:
                        Console.WriteLine("Incorrect function! There are only --c and --u!");
                        break;
                }
            }
        }

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}