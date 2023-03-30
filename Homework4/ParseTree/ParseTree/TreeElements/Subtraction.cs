namespace ParseTree;

public class Subtraction : Operator
{
    public override double Calculate()
    {
        return LeftChild!.Calculate() - RightChild!.Calculate();
    }

    public override void Print()
    {
        Console.WriteLine("( - ");
        base.Print();
    }
}