namespace SparseVectorTests;

using SparseVector;

public class Tests
{
    [Test]
    public void AddMethodShouldReturnRightAnswer()
    {
        var first = new List<(int, int)>() { (0, 1), (3, 2) };
        var second = new List<(int, int)>() { (0, 3), (2, 3), (3, 0) };

        List<(int, int)> actual = SparseVector.Add(first, second);
        var expected = new List<(int, int)>() { (0, 4), (2, 3), (3, 2) };
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void SubtractMethodShouldReturnRightAnswer()
    {
        var first = new List<(int, int)>() { (0, 1), (3, 2) };
        var second = new List<(int, int)>() { (0, 3), (2, 3), (3, 0) };

        List<(int, int)> actual = SparseVector.Subtract(first, second);
        var expected = new List<(int, int)>() { (0, -2), (2, -3), (3, 2) };
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void ScalarMultiplicateMethodShouldReturnRightAnswer()
    {
        var first = new List<(int, int)>() { (0, 1), (3, 2) };
        var second = new List<(int, int)>() { (0, 3), (2, 3), (3, 0) };

        int actual = SparseVector.ScalarMultiplicate(first, second);
        var expected = 3;
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void AddMethodForDifferentDimensionsVectorsShouldThrowException()
    {
        var first = new List<(int, int)>() { (0, 1), (2, 2) };
        var second = new List<(int, int)>() { (0, 3), (2, 3), (3, 0) };
        Assert.Throws<ArgumentException>(() => SparseVector.Add(first, second));
    }

    [Test]
    public void SubtractMethodForDifferentDimensionsVectorsShouldThrowException()
    {
        var first = new List<(int, int)>() { (0, 1), (2, 2) };
        var second = new List<(int, int)>() { (0, 3), (2, 3), (3, 0) };
        Assert.Throws<ArgumentException>(() => SparseVector.Subtract(first, second));
    }

    [Test]
    public void ScalarMultiplicateMethodForDifferentDimensionsVectorsShouldThrowException()
    {
        var first = new List<(int, int)>() { (0, 1), (2, 2) };
        var second = new List<(int, int)>() { (0, 3), (2, 3), (3, 0) };
        Assert.Throws<ArgumentException>(() => SparseVector.ScalarMultiplicate(first, second));
    }

    [Test]
    public void IsZeroMethodShouldReturnRightAnswer()
    {
        var vector = new List<(int, int)>() { (0, 0) };
        Assert.That(SparseVector.IsZero(vector));
    }
}