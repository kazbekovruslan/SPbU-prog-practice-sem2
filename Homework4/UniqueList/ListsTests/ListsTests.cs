namespace ListsTests;

using Lists;

public class ListsTests
{
    private static IEnumerable<TestCaseData> Lists()
    {
        yield return new TestCaseData(new List());
        yield return new TestCaseData(new UniqueList());
    }

    [TestCaseSource(nameof(Lists))]
    public void AddToListShouldMakeItNotEmpty(List list)
    {
        list.Add(10);
        Assert.That(!list.IsEmpty());
    }

    [TestCaseSource(nameof(Lists))]
    public void AddToListAndRemoveFromListShouldMakeItEmpty(List list)
    {
        list.Add(10);
        list.Remove(10);
        Assert.That(list.IsEmpty());
    }

    [TestCaseSource(nameof(Lists))]
    public void RemoveFromEmptyListShouldThrowException(List list)
    {
        Assert.Throws<ArgumentNullException>(() => list.Remove(3));
    }

    [TestCaseSource(nameof(Lists))]
    public void RemoveNotExistingElementShouldThrowException(List list)
    {
        list.Add(10);
        Assert.Throws<ElementDoesntExistException>(() => list.Remove(3));
    }

    [TestCaseSource(nameof(Lists))]
    public void ReplaceElementByIndexFromEmptyListShouldThrowException(List list)
    {
        Assert.Throws<ArgumentNullException>(() => list.ReplaceElementByIndex(0, 0));
    }

    [TestCaseSource(nameof(Lists))]
    public void ReplaceElementByIndexOnIndexOutOfRangeShouldThrowException(List list)
    {
        list.Add(10);
        Assert.Throws<IndexOutOfRangeException>(() => list.ReplaceElementByIndex(3, 1));
    }

    [Test]
    public void AddAlreadyExistingElementToUniqueListShouldThrowException()
    {
        var uniqueList = new UniqueList();
        uniqueList.Add(10);
        Assert.Throws<ElementAlreadyExistsException>(() => uniqueList.Add(10));
    }
}