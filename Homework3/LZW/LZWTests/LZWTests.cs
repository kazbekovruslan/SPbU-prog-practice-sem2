namespace LZWTests;

using LZW;

public class LZWTests
{
    private static IEnumerable<TestCaseData> TestFiles()
    {
        yield return new TestCaseData("../../../testFiles/more.mp4");
        yield return new TestCaseData("../../../testFiles/v.mp4");
        yield return new TestCaseData("../../../testFiles/WarAndPeace.txt");
        yield return new TestCaseData("../../../testFiles/minesweeper.exe");
    }

    [Test]
    public void EncoderWithEmptyInputArrayOfBytesShouldThrowException()
    {
        var input = new byte[0];
        Assert.Throws<ArgumentException>(() => LZWEncoder.Encode(input));
    }

    [Test]
    public void EncoderWithNullInputArrayOfBytesShouldThrowException()
    {
        byte[]? input = null;
        Assert.Throws<ArgumentNullException>(() => LZWEncoder.Encode(input));
    }

    [Test]
    public void DecoderWithEmptyInputArrayOfBytesShouldThrowException()
    {
        var input = new byte[0];
        Assert.Throws<ArgumentException>(() => LZWDecoder.Decode(input));
    }

    [Test]
    public void DecoderWithNullInputArrayOfBytesShouldThrowException()
    {
        byte[]? input = null;
        Assert.Throws<ArgumentNullException>(() => LZWDecoder.Decode(input));
    }

    [TestCaseSource(nameof(TestFiles))]
    public void EncoderAndDecoderWithRightInputShouldOutputOriginalFile(string pathToFile)
    {
        var input = File.ReadAllBytes(pathToFile);
        var encoderOutput = LZWEncoder.Encode(input);
        var decoderOutput = LZWDecoder.Decode(encoderOutput);

        Assert.That(input, Is.EqualTo(decoderOutput));
    }
}