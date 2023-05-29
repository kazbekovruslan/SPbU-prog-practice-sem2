namespace ParseTreeTests;

using ParseTree;

public class ParseTreeTests
{
    [Test]
    public void CalculatingWithRightExpressionShouldOutputRightAnswer()
    {
        var almostZero = 0.001F;
        var parseTree = new ParseTree("(* (+ 1 1) 2)");
        Assert.That(Math.Abs(parseTree.Calculate()) - 4 < almostZero);
    }

    [Test]
    public void CalculatingWithNullExpressionShouldThrowException()
    {
        Assert.Throws<ArgumentNullException>(() => new ParseTree(null));
    }

    [Test]
    public void CalculatingWithEmptyExpressionShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() => new ParseTree(String.Empty));
    }

    [Test]
    public void CalculatingWithDivisionByZeroExpressionShouldThrowException()
    {
        var parseTree = new ParseTree("/ 1 + -1 1");
        Assert.Throws<DivideByZeroException>(() => parseTree.Calculate());
    }

    private static IEnumerable<TestCaseData> Expressions()
    {
        yield return new TestCaseData("+ + 1 1 2 2");
        yield return new TestCaseData("+ + * 1 1");
        yield return new TestCaseData("+ + 1 1 b");
        yield return new TestCaseData("(+ 1 (+ 2 2 )))");
        yield return new TestCaseData("(+ 1 + (+ 2 2)");
    }

    [TestCaseSource(nameof(Expressions))]
    public void CalculatingWithIncorrectExpressionShouldThrowException(string? expression)
    {
        Assert.Throws<ArgumentException>(() => new ParseTree(expression));
    }
}