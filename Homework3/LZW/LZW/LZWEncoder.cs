namespace LZW;

/// <summary>
/// Class that represents LZW-encoder.
/// </summary>
public static partial class LZWEncoder
{
    /// <summary>
    /// Maximum available amount of codes.
    /// </summary>
    public const int maximumAmountOfCodes = 65536;

    /// <summary>
    /// Encodes input array of bytes with LZW-algorithm.
    /// </summary>
    /// <param name="input">Input array of bytes.</param>
    /// <returns>Array of LZW-decoded bytes.</returns>
    public static byte[] Encode(byte[]? input)
    {
        if (input == null)
        {
            throw new ArgumentNullException("Input bytes stream can't be null!");
        }

        if (input.Length == 0)
        {
            throw new ArgumentException("Input bytes stream can't be empty!");
        }

        var trie = new Trie();
        trie.InitTrie();
        var buffer = new CompressByteBuffer();

        var stream = new List<byte>();

        var currentmaximumAmountOfCodes = 512;
        for (var i = 0; i < input.Length; ++i)
        {
            var elementToAdd = new List<byte>();

            elementToAdd.AddRange(stream);
            elementToAdd.Add(input[i]);

            if (trie.Contains(elementToAdd))
            {
                stream = elementToAdd;
            }
            else
            {
                buffer.Add(trie.GetValueOfElement(stream));
                trie.Add(elementToAdd);

                if (trie.Size == maximumAmountOfCodes)
                {
                    currentmaximumAmountOfCodes = 512;
                    buffer.CurrentByteSize = 9;
                    trie = new();
                    trie.InitTrie();
                }

                if (trie.Size == currentmaximumAmountOfCodes)
                {
                    currentmaximumAmountOfCodes *= 2;
                    ++buffer.CurrentByteSize;
                }

                stream.Clear();
                stream.Add(input[i]);
            }
        }

        buffer.Add(trie.GetValueOfElement(stream));

        if (buffer.CurrentLengthOfBufferedByte != 0)
        {
            buffer.PutBufferedByteInCompressedBytes();
        }

        return buffer.CompressedBytes.ToArray();
    }
}