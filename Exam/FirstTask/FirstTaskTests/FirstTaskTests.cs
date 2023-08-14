namespace firsttask;

public class Tests
{
    [TestCase(new int[] { 1, 2, 3, 4, 1 }, 1)]
    [TestCase(new int[] { 4, 8, -2, 3, 11, 11, 11 }, 11)]
    public void FindMostFrequentElementWithRightArrayShouldReturnRightAnswer(int[] array, int answer)
    {
        Assert.That(MostFrequent.FindMostFrequentElementInArray(array).Equals(result), Is.True);
    }

    [Test]
    public void FindMostFrequentElementShouldWithEmptyArrayShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() => MostFrequent.FindMostFrequentElementInArray(new int[] { }));
    }

    [Test]
    public void FindMostFrequentElementShouldWithNullArrayShouldThrowException()
    {
        Assert.Throws<ArgumentNullException>(() => MostFrequent.FindMostFrequentElementInArray(null));
    }
}