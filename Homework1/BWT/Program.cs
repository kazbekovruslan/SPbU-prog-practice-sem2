namespace BWT;

using System;
using System.Text;

class RotationsComparer : IComparer<int>
{
    private string str;

    public RotationsComparer(string str)
    {
        this.str = str;
    }

    public int Compare(int first, int second)
    {
        for (var i = 0; i < str.Length; ++i)
        {
            if (str[(first + i) % str.Length] > str[(second + i) % str.Length])
            {
                return 1;
            }
            else if (str[(first + i) % str.Length] < str[(second + i) % str.Length])
            {
                return -1;
            }
        }
        return 0;
    }
}

class Program
{
    const int AlphabetSize = 65536;

    //encodes the original string and returns BWT-encoded string
    //and position of last original string's symbol 

    static (string, int) Encoder(string encodingString)
    {
        var rotations = new int[encodingString.Length];

        for (var i = 0; i < rotations.Length; ++i)
        {
            rotations[i] = i;
        }

        Array.Sort(rotations, new RotationsComparer(encodingString));

        var result = new StringBuilder();
        int positionOfStringEnd = 0;

        for (var i = 0; i < encodingString.Length; ++i)
        {
            result.Append(encodingString[(rotations[i] + encodingString.Length - 1) % encodingString.Length]);

            if (rotations[i] == 0)
            {
                positionOfStringEnd = i;
            }
        }

        return (result.ToString(), positionOfStringEnd);
    }

    //decodes the BWT-encoded string with position of last original string's symbol
    //and returns decoded original string
    static string Decoder(string decodingString, int positionOfStringEnd)
    {
        var decodingStringSymbolFrequences = new int[AlphabetSize];
        for (var i = 0; i < decodingString.Length; ++i)
        {
            ++decodingStringSymbolFrequences[decodingString[i]];
        }

        int temporarySum = 0;
        for (var i = 0; i < AlphabetSize; ++i)
        {
            temporarySum += decodingStringSymbolFrequences[i];
            decodingStringSymbolFrequences[i] = temporarySum - decodingStringSymbolFrequences[i];
        }

        var nextSymbols = new int[decodingString.Length];
        for (var i = 0; i < decodingString.Length; ++i)
        {
            nextSymbols[decodingStringSymbolFrequences[decodingString[i]]] = i;
            ++decodingStringSymbolFrequences[decodingString[i]];
        }

        int nextSymbol = nextSymbols[positionOfStringEnd];
        var resultString = new StringBuilder();
        for (var i = 0; i < decodingString.Length; ++i)
        {
            resultString.Append(decodingString[nextSymbol]);
            nextSymbol = nextSymbols[nextSymbol];
        }

        return resultString.ToString();
    }

    static void Main(string[] args)
    {
        Console.WriteLine("This is BWT-Encoder-Decoder.");
        Console.Write("Enter 1 to encode, 2 to decode: ");

        int typeOfOperation = 0;

        while (!int.TryParse(Console.ReadLine(), out typeOfOperation) || typeOfOperation < 1 || typeOfOperation > 2)
        {
            Console.WriteLine("Incorrect input! You can enter only 1 or 2. Try again!");
            Console.WriteLine("Enter 1 to encode, 2 to decode: ");
        }

        switch (typeOfOperation)
        {
            case 1:
                {
                    Console.Write("Enter the string you want to encode: ");
                    string? encodingString = Console.ReadLine();

                    while (string.IsNullOrEmpty(encodingString))
                    {
                        Console.WriteLine("Incorrect input! Try again.");
                        Console.Write("Enter the string you want to encode: ");
                        encodingString = Console.ReadLine();
                    }

                    int positionOfStringEnd = 0;
                    string encodedString = "";

                    (encodedString, positionOfStringEnd) = Encoder(encodingString);

                    Console.WriteLine($"\nYour ENCODED string: {encodedString}");
                    Console.WriteLine($"Position of the end of the string: {positionOfStringEnd}");
                    Console.WriteLine("\nPress any key to exit.");
                    Console.ReadKey();
                    break;
                }
            case 2:
                {
                    Console.Write("Enter the string you want to decode: ");
                    string? decodingString = Console.ReadLine();

                    while (string.IsNullOrEmpty(decodingString))
                    {
                        Console.WriteLine("Incorrect input! Try again.");
                        Console.Write("Enter the string you want to encode: ");

                        decodingString = Console.ReadLine();
                    }

                    Console.Write("Enter the position of the end of the original string: ");
                    int positionOfStringEnd = -1;

                    while (!int.TryParse(Console.ReadLine(), out positionOfStringEnd) ||
                    (positionOfStringEnd < 0 || positionOfStringEnd >= decodingString.Length))
                    {
                        Console.WriteLine("Incorrect input! It must be a number in [0, length of string). Try again!");
                        Console.WriteLine("Enter the position of the end of the original string: ");
                    }

                    string decodedString = Decoder(decodingString, positionOfStringEnd);

                    Console.WriteLine($"\nYour DECODED string: {decodedString}");
                    Console.WriteLine("\nPress any key to exit.");
                    Console.ReadKey();
                    break;
                }
        }
    }
}