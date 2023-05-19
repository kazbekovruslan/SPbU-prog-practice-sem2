namespace Archiever;

/// <summary>
/// Class representing archiver. (it is archiever everywhere, but correctly archiver :) )
/// </summary>
public class Archiever
{
    private const int maxAvailableValueInByte = 255;

    /// <summary>
    /// Method for compressing input byte array.
    /// </summary>
    /// <param name="inputByteArray">Byte array for compressing.</param>
    /// <returns>Compressed byte array.</returns>
    public (byte[], float compressRatio) Compress(byte[]? inputByteArray)
    {
        if (inputByteArray == null)
        {
            throw new ArgumentNullException("Byte array can't be null!");
        }

        if (inputByteArray.Length == 0)
        {
            throw new ArgumentException("Byte array can't be empty!");
        }

        var output = new List<byte>();
        byte lastByte = inputByteArray[0];
        int duplicateByteCounter = 0;

        for (int i = 0; i < inputByteArray.Length; ++i)
        {
            if (inputByteArray[i] != lastByte)
            {
                while (duplicateByteCounter > maxAvailableValueInByte)
                {
                    output.Add((byte)maxAvailableValueInByte);
                    output.Add(lastByte);
                }

                output.Add((byte)duplicateByteCounter);
                output.Add(lastByte);

                lastByte = inputByteArray[i];
                duplicateByteCounter = 1;
            }
            else
            {
                ++duplicateByteCounter;
            }
        }

        // remaining
        while (duplicateByteCounter > maxAvailableValueInByte)
        {
            output.Add((byte)maxAvailableValueInByte);
            output.Add(lastByte);
            duplicateByteCounter -= maxAvailableValueInByte;
        }
        if (duplicateByteCounter != 0)
        {
            output.Add((byte)duplicateByteCounter);
            output.Add(lastByte);
        }

        var outputArrayOfBytes = output.ToArray();
        var compressRatio = (float)inputByteArray.Length / (float)outputArrayOfBytes.Length;

        return (outputArrayOfBytes, compressRatio);
    }


    /// <summary>
    /// Method for decompressing input byte array.
    /// </summary>
    /// <param name="inputByteArray">Byte array for decompressing.</param>
    /// <returns>Decompressed byte array.</returns>
    public byte[] Decompress(byte[]? inputByteArray)
    {
        if (inputByteArray == null)
        {
            throw new ArgumentNullException("Byte array can't be null!");
        }

        if (inputByteArray.Length == 0)
        {
            throw new ArgumentException("Byte array can't be empty!");
        }

        if (inputByteArray.Length % 2 != 0)
        {
            throw new ArgumentException("Incorrect input byte array!");
        }

        byte currentByte = 0;
        var amountOfCurrentByte = 0;
        byte previousByte = 0;
        var amountOfPreviousByte = 0;

        List<byte> output = new();

        for (int i = 0; i < inputByteArray.Length; i = i + 2)
        {
            amountOfCurrentByte = inputByteArray[i];
            currentByte = inputByteArray[i + 1];

            if (amountOfCurrentByte != 255)
            {
                for (int j = 0; j < amountOfCurrentByte + amountOfPreviousByte; ++j)
                {
                    output.Add(currentByte);
                }
            }
            else
            {
                previousByte = currentByte;
                amountOfPreviousByte += amountOfCurrentByte;
            }
        }

        return output.ToArray();
    }
}