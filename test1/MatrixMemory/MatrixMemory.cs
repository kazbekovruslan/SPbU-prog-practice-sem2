namespace MatrixMemory;

class MatrixMemoryGame
{
    private int AmountOfMarkedSquares = (new Random()).Next(2, 7);

    public List<int> MarkedSquares = new List<int>();

    public void MakeStart()
    {
        for (var i = 0; i < AmountOfMarkedSquares; ++i)
        {
            MarkedSquares.Add((new Random()).Next(1, 9));
        }
    }

}