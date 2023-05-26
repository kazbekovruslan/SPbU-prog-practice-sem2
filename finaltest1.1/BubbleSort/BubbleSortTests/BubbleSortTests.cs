namespace BubbleSortTests;

using BubbleSort;

public class Tests
{
    [Test]
    public void SortNotSortedIntListWithShouldReturnSortedList()
    {
        var comparer = Comparer<int>.Default;
        var actual = new List<int>() { 5, 4, 3, 2, 1 };
        BubbleSorter<int>.Sort(actual, comparer);

        var expected = new List<int>() { 1, 2, 3, 4, 5 };

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void SortNotSortedStringListShouldReturnSortedList()
    {
        var comparer = Comparer<string>.Default;
        var actual = new List<string>() { "d", "ab", "a", "c", "de" };
        BubbleSorter<string>.Sort(actual, comparer);

        var expected = new List<string>() { "a", "ab", "c", "d", "de" };

        Assert.That(actual, Is.EqualTo(expected));
    }
}