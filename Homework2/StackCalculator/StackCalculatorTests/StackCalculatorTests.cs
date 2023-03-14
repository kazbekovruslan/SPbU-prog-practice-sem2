namespace StackCalculatorTests;

using StackCalculator;

public class StackCalculatorTests
{
    private static IEnumerable<TestCaseData> StackCalculator()
    {
        yield return new TestCaseData(new StackCalculator(new DynamicArrayStack()));
        yield return new TestCaseData(new StackCalculator(new LinkedListStack()));
    }

    [TestCaseSource(nameof(StackCalculator))]
    public void CalculatorWithCorrectExpressionShouldReturnCorrectResult(StackCalculator stackCalculator)
    {
        var expression = "15 3 + 2 * 3 /";
        var expected = 12F;
        var delta = 0.00001;

        var actual = stackCalculator.EvaluateExpression(expression);

        Assert.That(Math.Abs(actual - expected) < delta);
    }

    [TestCaseSource(nameof(StackCalculator))]
    public void CalculatorWithExpressionWithDivisionByZeroShouldThrowException(StackCalculator stackCalculator)
    {
        var expression = "5 5 + 0 /";

        Assert.Throws<DivideByZeroException>(() => stackCalculator.EvaluateExpression(expression));
    }

    [TestCaseSource(nameof(StackCalculator))]
    public void CalculatorWithMissingNumbersShouldThrowException(StackCalculator stackCalculator)
    {
        var expression = "5 + +";

        Assert.Throws<ArgumentException>(() => stackCalculator.EvaluateExpression(expression));
    }

    [TestCaseSource(nameof(StackCalculator))]
    public void CalculatorWithTooManyNumbersShouldThrowException(StackCalculator stackCalculator)
    {
        var expression = "5 5 + 5";

        Assert.Throws<ArgumentException>(() => stackCalculator.EvaluateExpression(expression));
    }

    [TestCaseSource(nameof(StackCalculator))]
    public void CalculatorWithExpressionWithForbiddenSymbolsShouldThrowException(StackCalculator stackCalculator)
    {
        var expression = "1 2 + 3 - a";

        Assert.Throws<ArgumentException>(() => stackCalculator.EvaluateExpression(expression));
    }

    [TestCaseSource(nameof(StackCalculator))]
    public void CalculatorWithEmptyExpressionShouldThrowException(StackCalculator stackCalculator)
    {
        var expression = string.Empty;

        Assert.Throws<ArgumentException>(() => stackCalculator.EvaluateExpression(expression));
    }

    [TestCaseSource(nameof(StackCalculator))]
    public void CalculatorWithNullExpressionShouldThrowException(StackCalculator stackCalculator)
    {
        string? expression = null;

        Assert.Throws<ArgumentNullException>(() => stackCalculator.EvaluateExpression(expression));
    }
}