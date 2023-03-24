namespace LZW;

using System;

class Program
{
    static void Main()
    {
        //reading bytes - compressing - writing compressed bytes
        var pathToFile = "WarAndPeace.txt";
        var input = File.ReadAllBytes(pathToFile);
        File.WriteAllBytes(pathToFile + ".zipped", LZWEncoder.Encode(input));
    }
}