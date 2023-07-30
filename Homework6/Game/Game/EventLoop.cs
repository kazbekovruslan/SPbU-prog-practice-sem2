namespace Game;

public class EventLoop
{
    public event EventHandler<EventArgs> LeftHandler = (sender, args) => { };
    public event EventHandler<EventArgs> RightHandler = (sender, args) => { };
    public event EventHandler<EventArgs> UpHandler = (sender, args) => { };
    public event EventHandler<EventArgs> DownHandler = (sender, args) => { };

    public void Run()
    {
        var IsRunning = true;
        while (IsRunning)
        {
            var key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.Escape:
                    IsRunning = false;
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    LeftHandler(this, EventArgs.Empty);
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    RightHandler(this, EventArgs.Empty);
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    UpHandler(this, EventArgs.Empty);
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    DownHandler(this, EventArgs.Empty);
                    break;
            }
        }
    }
}