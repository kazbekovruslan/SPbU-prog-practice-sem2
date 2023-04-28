namespace MatrixMemory;

class MatrixMemoryGame
{
    private int AmountOfMarkedSquares = (new Random()).Next(2, 7);

    private List<int> markedSquares = new List<int>();

    public List<int> MarkedSquares
    {
        get => markedSquares;

        private set
        {
            markedSquares = value;
        }
    }

    public void MakeStart()
    {
        for (var i = 0; i < AmountOfMarkedSquares; ++i)
        {
            MarkedSquares.Add((new Random()).Next(1, 9));
        }
    }

}