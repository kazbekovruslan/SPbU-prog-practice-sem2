namespace LZW;

class ByteBuffer
{
    public List<byte> CompressedBytes { get; private set; } = new();

    public byte BufferedByte { get; private set; } = 0;

    public int CurrentByteSize = 9;

    public int CurrentLengthOfBufferedByte = 0;

    private const int ByteSize = 8;

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

    public void PutBufferedByteInCompressedBytes()
    {
        CompressedBytes.Add(BufferedByte);
        CurrentLengthOfBufferedByte = 0;
        BufferedByte = 0;
    }

    //just for array
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