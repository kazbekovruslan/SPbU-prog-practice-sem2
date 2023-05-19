namespace ParseTree;

/// <summary>
/// Class for division operator.
/// </summary>
public class Division : Operator
{
    /// <summary>
    /// Calculates the value of this subtree - division left child by right child.
    /// </summary>
    public override double Calculate()
    {
        var almostZero = 0.001;
        if (Math.Abs(RightChild!.Calculate()) < almostZero)
        {
            throw new DivideByZeroException("You can't divide by zero!");
        }
        return LeftChild!.Calculate() / RightChild!.Calculate();
    }

    /// <summary>
    /// Prints "( / [LeftChild] [RightChild]".
    /// </summary>
    public override void Print()
    {
        Console.Write("( / ");
        base.Print();
    }
}