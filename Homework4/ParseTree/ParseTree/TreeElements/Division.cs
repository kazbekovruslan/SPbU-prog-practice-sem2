namespace ParseTree;

public class Division : Operator
{
    public override double Calculate()
    {
        if (Math.Abs(RightChild!.Calculate()) < 0.0001)
        {
            throw new DivideByZeroException("You can't divide by zero!");
        }
        return LeftChild!.Calculate() / RightChild!.Calculate();
    }

    public override void Print()
    {
        Console.WriteLine("( * ");
        base.Print();
    }
}