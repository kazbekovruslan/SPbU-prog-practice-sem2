namespace Game;

class Program
{
    static void Main()
    {
        var eventLoop = new EventLoop();
        var game = new Game("Map.txt");

        eventLoop.LeftHandler += game.OnLeft;
        eventLoop.RightHandler += game.OnRight;
        eventLoop.UpHandler += game.OnUp;
        eventLoop.DownHandler += game.OnDown;

        eventLoop.Run();
    }
}