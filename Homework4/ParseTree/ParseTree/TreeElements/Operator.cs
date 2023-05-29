namespace ParseTree;

/// <summary>
/// Class that represents operator-subtree.
/// </summary>
public abstract class Operator : ITree
{
    /// <summary>
    /// Left child of operator subtree.
    /// </summary>
    public ITree? LeftChild;

    /// <summary>
    /// Right child of operator subtree.
    /// </summary>
    public ITree? RightChild;

    /// <summary>
    /// Abstract method that calculates value of this subtree.
    /// </summary>
    public abstract double Calculate();

    /// <summary>
    /// Virtual method that prints LeftChild and RightChild of operator-subtree.
    /// </summary>
    public virtual void Print()
    {
        LeftChild?.Print();
        RightChild?.Print();
        Console.Write(") ");
    }
}