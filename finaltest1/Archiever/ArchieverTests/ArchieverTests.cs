namespace ArchieverTests;

using Archiever;

public class Tests
{
    private Archiever archiever = new();

    [Test]
    public void CompressOfSmallByteArrayShouldReturnRightAnswer()
    {
        byte[] input = { 0, 0, 1, 1 };
        byte[] expected = { 2, 0, 2, 1 };
        Assert.That(archiever.Compress(input).Item1, Is.EqualTo(expected));
    }

    [Test]
    public void CompressOfBigByteArrayShouldReturnRightAnswer()
    {
        var input = new byte[256];

        for (int i = 0; i < 256; ++i)
        {
            input[i] = 0;
        }

        byte[] expected = { 255, 0, 1, 0 };

        Assert.That(archiever.Compress(input).Item1, Is.EqualTo(expected));
    }

    [Test]
    public void DecompressOfSmallByteArrayShouldReturnRightAnswer()
    {
        byte[] input = { 2, 0, 2, 1 };
        byte[] expected = { 0, 0, 1, 1 };
        Assert.That(archiever.Decompress(input), Is.EqualTo(expected));
    }

    [Test]
    public void DecompressOfBigByteArrayShouldReturnRightAnswer()
    {
        byte[] input = { 255, 0, 1, 0 };

        var expected = new byte[256];

        for (int i = 0; i < 256; ++i)
        {
            expected[i] = 0;
        }

        Assert.That(archiever.Decompress(input), Is.EqualTo(expected));
    }

    [Test]
    public void CompressOfNullByteArrayShouldThrowException()
    {
        Assert.Throws<ArgumentNullException>(() => archiever.Compress(null));
    }

    [Test]
    public void CompressOfEmptyByteArrayShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() => archiever.Compress(new byte[0]));
    }

    [Test]
    public void DecompressOfNullByteArrayShouldThrowException()
    {
        Assert.Throws<ArgumentNullException>(() => archiever.Decompress(null));
    }

    [Test]
    public void DecompressOfEmptyByteArrayShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() => archiever.Decompress(new byte[0]));
    }

    [Test]
    public void DecompressOfByteArrayWithOddAmountOfElementsShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() => archiever.Decompress(new byte[1]));
    }

    [Test]
    public void CompressAndDecompressOfByteArrayShouldReturnOriginalByteArray()
    {
        byte[] input = { 0, 0, 1, 1 };
        var outputOfCompressor = archiever.Compress(input).Item1;
        var outputOfDecompressor = archiever.Decompress(outputOfCompressor);
        var expected = input;
        Assert.That(outputOfDecompressor, Is.EqualTo(expected));
    }

}