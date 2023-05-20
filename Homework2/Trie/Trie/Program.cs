namespace Trie;

using System;

class Program
{
    static void PrintCommands()
    {
        Console.WriteLine("""

            How can you interact: 
            0 - exit
            1 - add element
            2 - check if trie contains element
            3 - remove element
            4 - print how many elements start with prefix
            5 - print size of trie
            6 - print commands

        """);
    }

    static void Main()
    {
        Console.WriteLine("This is program that represents data structure 'Trie'.");

        PrintCommands();

        bool IsWorking = true;
        string? command = "";

        var trie = new Trie();

        while (IsWorking)
        {
            Console.Write("Enter the command: ");
            command = Console.ReadLine();

            switch (command)
            {
                case "0":
                    IsWorking = false;
                    break;
                case "1":
                    Console.Write("Enter the element you want to add: ");
                    string? element = Console.ReadLine();

                    try
                    {
                        Console.WriteLine(trie.Add(element)
                        ? "Element added successfully!"
                        : "The trie already contains this element!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    break;
                case "2":
                    Console.Write("Enter the element you want to check for being in trie: ");
                    element = Console.ReadLine();

                    try
                    {
                        Console.WriteLine(trie.Contains(element)
                        ? $"Element '{element}' is in trie!"
                        : $"The trie doesn't contain '{element}'!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    break;
                case "3":
                    Console.Write("Enter the element you want to remove: ");
                    element = Console.ReadLine();

                    try
                    {
                        Console.WriteLine(trie.Remove(element)
                        ? $"Element '{element}' removed successfully!"
                        : $"The trie doesn't contain '{element}'!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    break;
                case "4":
                    Console.Write("Enter the prefix: ");
                    element = Console.ReadLine();

                    int ElementWithThisPrefix = 0;

                    try
                    {
                        ElementWithThisPrefix = trie.HowManyStartWithPrefix(element);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    Console.WriteLine(ElementWithThisPrefix == 1
                        ? $"There is {ElementWithThisPrefix} element that start with prefix '{element}'."
                        : $"There are {ElementWithThisPrefix} elements that start with prefix '{element}'.");

                    break;
                case "5":
                    Console.WriteLine($"Size of trie: {trie.Size}.");
                    break;
                case "6":
                    PrintCommands();
                    break;
                default:
                    Console.WriteLine("Wrong command. Try again!");
                    break;
            }
        }

        Console.ReadKey();
    }
}