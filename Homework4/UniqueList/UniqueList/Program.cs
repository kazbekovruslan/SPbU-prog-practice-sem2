namespace Lists;

using System;

class Program
{
    static void PrintCommands()
    {
        Console.WriteLine("""
            How can you interact: 
            0 - exit
            1 - add element to the top
            2 - remove element
            3 - change element by index
            4 - print list
            5 - print commands
        """);
    }

    static void Main()
    {
        var inAction = true;

        var list = new UniqueList();

        Console.WriteLine("Hello, this is UniqueList data structure.");
        PrintCommands();

        while (inAction)
        {
            Console.Write("Enter the command: ");
            var command = Console.ReadLine();
            switch (command)
            {
                case "1":
                    Console.Write("Enter the element you want to add to the list: ");
                    var elementToAdd = 0;
                    if (!int.TryParse(Console.ReadLine(), out elementToAdd))
                    {
                        Console.WriteLine("You can add only integer numbers! Try again!");
                    }

                    try
                    {
                        list.Add(elementToAdd);
                        Console.WriteLine("Added successfully!");
                    }
                    catch (ElementAlreadyExistsException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    break;
                case "2":
                    Console.Write("Enter the element you want to remove from the list: ");
                    var elementToRemove = 0;
                    if (!int.TryParse(Console.ReadLine(), out elementToRemove))
                    {
                        Console.WriteLine("There are only integer elements in the list! Try again!");
                    }

                    try
                    {
                        list.Remove(elementToRemove);
                        Console.WriteLine("Removed successfully!");
                    }
                    catch (Exception ex) when (ex is ArgumentNullException ||
                                               ex is ElementDoesntExistException)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case "3":
                    Console.Write("Enter the element you want to insert to the list: ");
                    var elementToChange = 0;
                    if (!int.TryParse(Console.ReadLine(), out elementToChange))
                    {
                        Console.WriteLine("There are only integer elements in the list! Try again!");
                    }

                    Console.Write("Enter the index of the element you want to replace: ");
                    var indexForChange = 0;
                    if (!int.TryParse(Console.ReadLine(), out indexForChange))
                    {
                        Console.WriteLine("Index must be integer number! Try again!");
                    }

                    try
                    {
                        list.ReplaceElementByIndex(elementToChange, indexForChange);
                        Console.WriteLine("Changed successfully!");
                    }
                    catch (Exception ex) when (ex is ArgumentNullException ||
                                               ex is IndexOutOfRangeException ||
                                               ex is ElementAlreadyExistsException)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case "4":
                    try
                    {
                        list.Print();
                    }
                    catch (ArgumentNullException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case "5":
                    PrintCommands();
                    break;
                case "0":
                    inAction = false;
                    break;
                default:
                    Console.WriteLine("Incorrect command! Try again!");
                    break;
            }
        }
    }
}