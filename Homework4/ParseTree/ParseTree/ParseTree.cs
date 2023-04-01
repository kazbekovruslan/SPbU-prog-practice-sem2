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
        var splittedExpression = expression.Replace("(", " ").Replace(")", " ").Split(" ");

        var index = -1;

        ITree BuildSubTrees()
        {
            if (++index >= splittedExpression.Length)
            {
                throw new ArgumentException("Incorrect expression!");
            }

            // а не только цифры?
            if (char.IsDigit(splittedExpression[index][0]))
            {
                return new Operand(int.Parse(splittedExpression[index]));
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
        // if (index != splittedExpression.Length - 1)
        // {
        //     throw new ArgumentException("Incorrect expression!");
        // }
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