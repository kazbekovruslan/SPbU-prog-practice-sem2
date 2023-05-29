namespace ParseTree;

/// <summary>
/// Interface for separate element of tree - subtree.
/// </summary>
public interface ITree
{
    /// <summary>
    /// Calculates the value of this subtree.
    /// </summary>
    public double Calculate();

    /// <summary>
    /// Prints this subtree.
    /// </summary>
    public void Print();
}