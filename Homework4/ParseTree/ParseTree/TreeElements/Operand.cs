namespace ParseTree;

public class Operand : ITree
{
    public int Value;

    public Operand(int value)
    {
        this.Value = value;
    }

    public double Calculate()
    {
        return Value;
    }

    public void Print()
    {
        Console.Write($"{Value} ");
    }
}