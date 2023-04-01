namespace ParseTree;

public class Multiplication : Operator
{
    public override double Calculate()
    {
        return LeftChild!.Calculate() * RightChild!.Calculate();
    }

    public override void Print()
    {
        Console.Write("( * ");
        base.Print();
    }
}