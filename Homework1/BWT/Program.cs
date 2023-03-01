namespace BWT;

using System;
using System.Text;

class Program
{
    const int AlphabetSize = 65536;

    static (string, int) Encoder(string encodingString)
    {
        StringBuilder resultString = new StringBuilder();
        int positionOfStringEnd = 0;

        var shiftsArray = new string[encodingString.Length];
        shiftsArray[0] = encodingString;
        for (int i = 1; i < encodingString.Length; ++i)
        {
            shiftsArray[i] = shiftsArray[i - 1].Substring(1) + shiftsArray[i - 1][0];
        }

        Array.Sort(shiftsArray);

        for (int i = 0; i < encodingString.Length; ++i)
        {
            resultString.Append(shiftsArray[i][^1]);

            if (shiftsArray[i] == encodingString)
            {
                positionOfStringEnd = i;
            }
        }

        return (resultString.ToString(), positionOfStringEnd);
    }

    static string Decoder(string decodingString, int positionOfStringEnd)
    {
        StringBuilder resultString = new StringBuilder();

        var decodingStringSymbolFrequences = new int[AlphabetSize];
        for (int i = 0; i < decodingString.Length; ++i)
        {
            ++decodingStringSymbolFrequences[decodingString[i]];
        }

        int temporarySum = 0;
        for (int i = 0; i < AlphabetSize; ++i)
        {
            temporarySum += decodingStringSymbolFrequences[i];
            decodingStringSymbolFrequences[i] = temporarySum - decodingStringSymbolFrequences[i];
        }

        var nextSymbols = new int[decodingString.Length];
        for (int i = 0; i < decodingString.Length; ++i)
        {
            nextSymbols[decodingStringSymbolFrequences[decodingString[i]]] = i;
            ++decodingStringSymbolFrequences[decodingString[i]];
        }

        int j = nextSymbols[positionOfStringEnd];
        for (int i = 0; i < decodingString.Length; ++i)
        {
            resultString.Append(decodingString[j]);
            j = nextSymbols[j];
        }

        return resultString.ToString();
    }

    static void Main(string[] args)
    {
        Console.WriteLine("This is BWT-OldEncoder-OldDecoder.");
        Console.Write("Enter 1 to encode, 2 to decode: ");

        int typeOfOperation = 0;

        while (!int.TryParse(Console.ReadLine(), out typeOfOperation) || (typeOfOperation < 1 || typeOfOperation > 2))
        {
            Console.WriteLine("Incorrect input! You can enter only 1 or 2. Try again!");
            Console.WriteLine("Enter 1 to encode, 2 to decode: ");
        }

        switch (typeOfOperation)
        {
            case (1):
                {
                    Console.Write("Enter the string you want to encode: ");
                    string? encodingString = Console.ReadLine();

                    while (encodingString == null || encodingString == "")
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
            case (2):
                {
                    Console.Write("Enter the string you want to decode: ");
                    string? decodingString = Console.ReadLine(); ;

                    while (decodingString == null || decodingString == "")
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