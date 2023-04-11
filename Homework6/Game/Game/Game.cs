namespace Game;

public class Game
{
    private char[,]? Map;

    private Person person;

    public Game(string pathToMap)
    {
        var (startPositionX, startPositionY) = LoadMap(pathToMap);

        PrintMap();

        this.person = new Person(startPositionX, startPositionY);
    }

    private (int, int) LoadMap(string pathToMap)
    {
        var input = File.ReadAllLines(pathToMap);

        if (input == null)
        {
            throw new ArgumentException("Map can't be null!");
        }

        var linesAmount = input.Length;
        var columnsAmount = input[0].Length;

        var loadedMap = new char[linesAmount, columnsAmount];
        var coordinatesOfPerson = (0, 0);
        for (var i = 0; i < linesAmount; ++i)
        {
            if (string.IsNullOrEmpty(input[i]))
            {
                throw new ArgumentException("Map can't be null or empty!");
            }

            for (var j = 0; j < columnsAmount; ++j)
            {
                if (input[i][j] == '@')
                {
                    coordinatesOfPerson = (j, i);
                    loadedMap[i, j] = ' ';
                }
                else
                {
                    loadedMap[i, j] = input[i][j];
                }
            }
        }

        Map = loadedMap;
        return coordinatesOfPerson;
    }

    private void PrintMap()
    {
        if (Map == null)
        {
            throw new ArgumentException("Map can't be null!");
        }

        var linesAmount = Map.GetLength(0);
        var columnsAmount = Map.GetLength(1);

        for (var i = 0; i < linesAmount; ++i)
        {
            for (var j = 0; j < columnsAmount; ++j)
            {
                Console.Write(Map[i, j]);
            }
            Console.WriteLine();
        }
    }

    public class Person
    {
        public int PositionX;
        public int PositionY;

        public Person(int positionX, int positionY)
        {
            this.PositionX = positionX;
            this.PositionY = positionY;
            UpdateCursor(positionX, positionY);
        }
    }

    private enum Direction
    {
        Left,
        Right,
        Up,
        Down
    }

    public void OnLeft(object? sender, EventArgs args)
    {
        Move(Direction.Left);
    }

    public void OnRight(object? sender, EventArgs args)
    {
        Move(Direction.Right);
    }

    public void OnUp(object? sender, EventArgs args)
    {
        Move(Direction.Up);
    }

    public void OnDown(object? sender, EventArgs args)
    {
        Move(Direction.Down);
    }

    private (int, int) ChooseDirection(Direction direction)
    {
        var result = direction switch
        {
            Direction.Left => (person.PositionX - 1, person.PositionY),
            Direction.Right => (person.PositionX + 1, person.PositionY),
            Direction.Up => (person.PositionX, person.PositionY - 1),
            Direction.Down => (person.PositionX, person.PositionY + 1),
            _ => throw new ArgumentException("Wrong direction!")
        };
        return result;
    }

    private void Move(Direction direction)
    {
        var (newPositionX, newPositionY) = ChooseDirection(direction);
        if (Map![newPositionY, newPositionX] == ' '
        && newPositionX >= 0 && newPositionX < Map.GetLength(1)
        && newPositionY >= 0 && newPositionY < Map.GetLength(0))
        {
            UpdateCursor(newPositionX, newPositionY);
            person.PositionX = newPositionX;
            person.PositionY = newPositionY;
        }
        else
        {
            UpdateCursor(person.PositionX, person.PositionY);
        }
    }

    private static void UpdateCursor(int newPositionX, int newPositionY)
    {
        Console.Write(" ");
        Console.SetCursorPosition(newPositionX, newPositionY);
        Console.Write("@");
        Console.SetCursorPosition(newPositionX, newPositionY);
    }
}