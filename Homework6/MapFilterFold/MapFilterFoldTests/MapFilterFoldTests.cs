namespace MapFilterFoldTests;

using static MapFilterFold.MapFilterFold;

public class Tests
{
    [Test]
    public void MapWithRightArgsShouldReturnRightList()
    {
        Assert.That(Map(new List<string>() { "a", "b", "c" }, x => x + x), Is.EqualTo(new List<string>() { "aa", "bb", "cc" }));
        Assert.That(Map(new List<int>() { 1, 2, 3 }, x => x * 2), Is.EqualTo(new List<int>() { 2, 4, 6 }));
    }

    [Test]
    public void FilterWithRightArgsShouldReturnRightList()
    {
        Assert.That(Filter(new List<string>() { "a", "bb", "c" }, x => x.Length == 1), Is.EqualTo(new List<string>() { "a", "c" }));
        Assert.That(Filter(new List<int>() { 1, 2, 3 }, x => x % 2 != 0), Is.EqualTo(new List<int>() { 1, 3 }));
    }

    [Test]
    public void FoldWithRightArgsShouldReturnRightList()
    {
        Assert.That(Fold(new List<string>() { "a", "b", "c" }, "a", (acc, elem) => acc + elem), Is.EqualTo("aabc"));
        Assert.That(Fold(new List<int>() { 1, 2, 3 }, 1, (acc, elem) => acc * elem), Is.EqualTo(6));
    }
}