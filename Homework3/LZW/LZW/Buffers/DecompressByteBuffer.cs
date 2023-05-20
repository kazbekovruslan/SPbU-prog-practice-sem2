namespace LZW;

public static partial class LZWDecoder
{
    private class DecompressByteBuffer
    {
        /// <summary>
        /// Result output list of decompressed bytes. 
        /// </summary>
        public List<int> Data { get; private set; } = new();

        /// <summary>
        /// Single byte using for accumulation bits for byte.
        /// </summary>
        // 9 bit => int
        public int Buffer { get; private set; } = 0;

        /// <summary>
        /// Current size of one new "byte".
        /// </summary>
        public int CurrentByteSize { get; set; } = 9;

        /// <summary>
        /// Size of one new "byte" at the start.
        /// </summary>
        public readonly int StartByteSize = 9;

        /// <summary>
        /// Current length of byte using for accumulation bits for byte.
        /// </summary>
        public int CurrentLengthOfBuffer { get; set; } = 0;

        /// <summary>
        /// Size of 8-bit byte.
        /// </summary>
        public const int ByteSize = 8;

        /// <summary>
        /// Puts 8-bit bytes in CurrentByteSize-bit bytes and Data list
        /// </summary>
        /// <param name="byteFromInput">Single byte from input array of bytes.</param>
        /// <returns>
        /// true - if one new "byte" was filled and added to Data list,
        /// false - if one new "byte" wasn't filled and added to Data list.
        /// </returns>
        public bool Add(byte byteFromInput)
        {
            var bits = ConvertFromByteToBits(byteFromInput);
            bool wasAdded = false;

            foreach (var bit in bits)
            {
                Buffer = ((Buffer << 1) + bit);
                ++CurrentLengthOfBuffer;
                if (CurrentLengthOfBuffer == CurrentByteSize)
                {
                    PutByteToData();
                    wasAdded = true;
                }
            }

            return wasAdded;
        }

        /// <summary>
        /// Puts last byte to Data list.
        /// </summary>
        /// <param name="element">Last byte of array of input bytes.</param>
        public void AddLastByte(byte element)
        {
            var bits = ConvertFromIncompleteByteToBits(element);

            foreach (var bit in bits)
            {
                Buffer = ((Buffer << 1) + bit);
                ++CurrentLengthOfBuffer;
                if (CurrentLengthOfBuffer == CurrentByteSize)
                {
                    PutByteToData();
                }
            }
        }

        private byte[] ConvertFromIncompleteByteToBits(byte element)
        {
            var bits = new byte[CurrentByteSize - CurrentLengthOfBuffer];

            var digitCounter = 0;
            for (var i = CurrentByteSize - CurrentLengthOfBuffer - 1; element > 0; --i)
            {
                bits[i] = (byte)(element % 2);
                element /= 2;
                ++digitCounter;
            }

            return bits;
        }

        private void PutByteToData()
        {
            Data.Add(Buffer);
            CurrentLengthOfBuffer = 0;
            Buffer = 0;
        }

        private byte[] ConvertFromByteToBits(byte element)
        {
            var bits = new byte[ByteSize];

            for (var i = ByteSize - 1; i >= 0; --i)
            {
                bits[i] = (byte)(element % 2);
                element /= 2;
            }

            return bits;
        }
    }
}