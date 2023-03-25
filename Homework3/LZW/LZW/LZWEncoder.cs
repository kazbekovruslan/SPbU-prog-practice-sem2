namespace LZW;

public static class LZWEncoder
{
    public const int maximumAmountOfCodesNumber = 65536;

    public static byte[] Encode(byte[] input)
    {
        if (input.Length == 0)
        {
            throw new ArgumentException("Input bytes stream can't be empty!");
        }

        var trie = new Trie();
        trie.InitTrie();
        var buffer = new ByteBuffer();

        var stream = new List<byte>();

        var currentMaximumAmountOfCodesNumber = 512;
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

                //uvelichenie i perestroyka
                if (trie.Size == maximumAmountOfCodesNumber)
                {
                    currentMaximumAmountOfCodesNumber = 512;
                    buffer.CurrentByteSize = 9;
                    trie = new();
                    trie.InitTrie();
                }

                if (trie.Size == currentMaximumAmountOfCodesNumber)
                {
                    currentMaximumAmountOfCodesNumber *= 2;
                    ++buffer.CurrentByteSize;
                }
                //konec

                stream.Clear();
                stream.Add(input[i]);
            }
        }

        buffer.Add(trie.GetValueOfElement(stream));

        //хуйня про последний байтик

        if (buffer.CurrentLengthOfBufferedByte != 0)
        {
            buffer.PutBufferedByteInCompressedBytes();
        }

        return buffer.CompressedBytes.ToArray();
    }
}