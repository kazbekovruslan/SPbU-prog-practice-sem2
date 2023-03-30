namespace ParseTree;

public abstract class Operator : ITree
{
    public ITree? LeftChild;

    public ITree? RightChild;

    public abstract double Calculate();

    public virtual void Print()
    {
        LeftChild?.Print();
        RightChild?.Print();
        Console.Write(") ");
    }
}