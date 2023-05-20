namespace LZW;

public static partial class LZWEncoder
{
    private class CompressByteBuffer
    {
        /// <summary>
        /// Result output list of compressed bytes. 
        /// </summary>
        public List<byte> CompressedBytes { get; private set; } = new();

        /// <summary>
        /// Single byte using for accumulation bits for byte.
        /// </summary>
        public byte BufferedByte { get; private set; } = 0;

        /// <summary>
        /// Current size of one new "byte".
        /// </summary>
        public int CurrentByteSize { get; set; } = 9;

        /// <summary>
        /// Current length of byte using for accumulation bits for byte.
        /// </summary>
        public int CurrentLengthOfBufferedByte { get; set; } = 0;

        private const int ByteSize = 8;

        /// <summary>
        /// Puts code from trie to separate 8-bit bytes.
        /// </summary>
        /// <param name="code">Code for symbol from trie.</param>
        public void Add(int code)
        {
            var bits = ConvertFromIntToBits(code);

            foreach (var bit in bits)
            {
                BufferedByte = (byte)((BufferedByte << 1) + bit);
                ++CurrentLengthOfBufferedByte;
                if (CurrentLengthOfBufferedByte == ByteSize)
                {
                    PutBufferedByteInCompressedBytes();
                }
            }
        }

        /// <summary>
        /// Puts buffered byte in list of compressed bytes.
        /// </summary>
        public void PutBufferedByteInCompressedBytes()
        {
            CompressedBytes.Add(BufferedByte);
            CurrentLengthOfBufferedByte = 0;
            BufferedByte = 0;
        }

        private byte[] ConvertFromIntToBits(int code)
        {
            var bitsOfCode = new byte[CurrentByteSize];
            for (var i = CurrentByteSize - 1; i >= 0; --i)
            {
                bitsOfCode[i] = (byte)(code % 2);
                code /= 2;
            }

            return bitsOfCode;
        }
    }
}