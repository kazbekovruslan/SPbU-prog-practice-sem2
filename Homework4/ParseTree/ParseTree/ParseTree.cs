namespace ParseTree;

public class ParseTree
{
    public ParseTree(string? expression)
    {
        if (expression == null)
        {
            throw new ArgumentNullException("Expression can't be null!");
        }

        if (expression == String.Empty)
        {
            throw new ArgumentException("Expression can't be empty!");
        }

        try
        {
            BuildTree(expression);
        }
        catch (ArgumentException)
        {
            throw;
        }
    }

    private ITree? root;

    private void BuildTree(string expression)
    {
        if (!IsBracketBalanced(expression))
        {
            throw new ArgumentException("Incorrect expression!");
        }

        var splittedExpression = expression.Split(new char[] { '(', ')', ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var index = -1;

        ITree BuildSubTrees()
        {
            // lack of parts
            if (++index >= splittedExpression.Length)
            {
                throw new ArgumentException("Incorrect expression!");
            }

            var parsedNumber = 0;
            if (int.TryParse(splittedExpression[index], out parsedNumber))
            {
                return new Operand(parsedNumber);
            }

            Operator newSubTree = splittedExpression[index] switch
            {
                "+" => new Addition(),
                "-" => new Subtraction(),
                "*" => new Multiplication(),
                "/" => new Division(),
                _ => throw new ArgumentException("Incorrect expression!")
            };

            newSubTree.LeftChild = BuildSubTrees();
            newSubTree.RightChild = BuildSubTrees();

            return newSubTree;
        }

        root = BuildSubTrees();

        // too many parts
        if (index != splittedExpression.Length - 1)
        {
            throw new ArgumentException("Incorrect expression!");
        }
    }

    private bool IsBracketBalanced(string expression)
    {
        var bracketCounter = 0;
        foreach (var symbol in expression)
        {
            if (symbol == '(')
            {
                ++bracketCounter;
            }

            if (symbol == ')')
            {
                --bracketCounter;
            }

            if (bracketCounter < 0)
            {
                return false;
            }
        }

        return bracketCounter == 0;
    }

    public double Calculate()
    {
        return root!.Calculate();
    }

    public void Print()
    {
        root!.Print();
    }
}