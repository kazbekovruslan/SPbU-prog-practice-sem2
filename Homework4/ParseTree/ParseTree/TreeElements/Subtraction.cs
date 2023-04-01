namespace ParseTree;

/// <summary>
/// Class for subtraction operator.
/// </summary>
public class Subtraction : Operator
{
    /// <summary>
    /// Calculates the value of this subtree - difference of left and right children.
    /// </summary>
    public override double Calculate()
    {
        return LeftChild!.Calculate() - RightChild!.Calculate();
    }

    /// <summary>
    /// Prints "( - [LeftChild] [RightChild]".
    /// </summary>
    public override void Print()
    {
        Console.Write("( - ");
        base.Print();
    }
}