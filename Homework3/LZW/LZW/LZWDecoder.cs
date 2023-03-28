namespace LZW;

/// <summary>
/// Class that represents LZW-Decoder.
/// </summary>
public class LZWDecoder
{
    /// <summary>
    /// Decodes input array of LZW-encoded bytes.
    /// </summary>
    /// <param name="input">Input array of LZW-encoded bytes.</param>
    /// <returns>Array of LZW-decoded bytes.</returns>
    public static byte[] Decode(byte[]? input)
    {
        if (input == null)
        {
            throw new ArgumentNullException("Input bytes stream can't be null!");
        }

        if (input.Length == 0)
        {
            throw new ArgumentException("Input bytes stream can't be empty!");
        }

        var output = new List<byte>();
        var dictionary = CreateAndInitDictionary();
        var codes = GetCodes(input);
        var dictionaryPointer = 256;
        var dictionarySize = 256;
        var sequence = new List<byte>();

        for (var i = 0; i < codes.Count; ++i)
        {
            if (dictionarySize == LZWEncoder.maximumAmountOfCodes)
            {
                dictionarySize = 256;
                dictionaryPointer = 256;
                dictionary = CreateAndInitDictionary();
            }

            if (dictionary.ContainsKey(codes[i]))
            {
                if (dictionarySize != 256)
                {
                    while (dictionary.ContainsKey(dictionaryPointer))
                    {
                        ++dictionaryPointer;
                    }

                    sequence = new List<byte>(dictionary[codes[i - 1]]) { dictionary[codes[i]][0] };

                    dictionary.Add(dictionaryPointer++, sequence);
                }

                output.AddRange(dictionary[codes[i]]);
            }
            else
            {
                sequence = new List<byte>(dictionary[codes[i - 1]]) { dictionary[codes[i - 1]][0] };

                dictionary.Add(codes[i], sequence);
                output.AddRange(sequence);
            }
            ++dictionarySize;
        }

        return output.ToArray();
    }

    private static List<int> GetCodes(byte[] input)
    {
        var buffer = new DecompressByteBuffer();

        var dictionarySize = 256;
        var currentMaximumAmountOfCodesNumber = 512;

        for (var i = 0; i < input.Length - 1; ++i)
        {
            if (dictionarySize == LZWEncoder.maximumAmountOfCodes)
            {
                dictionarySize = 256;
                currentMaximumAmountOfCodesNumber = 512;
                buffer.CurrentByteSize = 9;
            }

            if (dictionarySize == currentMaximumAmountOfCodesNumber)
            {
                currentMaximumAmountOfCodesNumber *= 2;
                ++buffer.CurrentByteSize;
            }

            if (buffer.Add(input[i]))
            {
                ++dictionarySize;
            }
        }

        //last byte
        if (buffer.CurrentLengthOfBuffer + DecompressByteBuffer.ByteSize == buffer.CurrentByteSize)
        {
            buffer.Add(input[^1]);
        }
        else
        {
            buffer.AddLastByte(input[^1]);
        }

        return buffer.Data;
    }

    private static Dictionary<int, List<byte>> CreateAndInitDictionary()
    {
        var dictionary = new Dictionary<int, List<byte>>();
        for (var i = 0; i < 256; ++i)
        {
            dictionary[i] = new List<byte> { (byte)i };
        }

        return dictionary;
    }
}