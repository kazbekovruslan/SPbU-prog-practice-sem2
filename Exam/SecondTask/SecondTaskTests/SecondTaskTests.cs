namespace secondtask;

public class Tests
{
    [TestCase("()", true)]
    [TestCase(")", false)]
    [TestCase("())", false)]
    [TestCase("([{}])", true)]
    [TestCase("()[]{}", true)]
    public void AllExpressionsShouldReturnRightAnswer(string expression, bool answer)
    {
        Assert.That(BracketBalance.IsBalanced(expression).Equals(answer), Is.True);
    }
}