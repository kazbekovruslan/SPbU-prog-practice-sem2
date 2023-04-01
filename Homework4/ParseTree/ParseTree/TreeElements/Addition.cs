namespace ParseTree;

public class Addition : Operator
{
    public override double Calculate()
    {
        return LeftChild!.Calculate() + RightChild!.Calculate();
    }

    public override void Print()
    {
        Console.Write("( + ");
        base.Print();
    }
}