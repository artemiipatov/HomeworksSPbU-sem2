namespace Game;

public class EventLoop
{
    public event EventHandler<EventArgs> LeftHandler = (sender, args) => { };
    public event EventHandler<EventArgs> RightHandler = (sender, args) => { };
    public event EventHandler<EventArgs> DownHandler = (sender, args) => { };
    public event EventHandler<EventArgs> UpHandler = (sender, args) => { };

    /// <summary>
    /// Starts the event loop
    /// </summary>
    public void Run()
    {
        while (true)
        {
            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                {
                    LeftHandler(this, EventArgs.Empty);
                    break;
                }
                case ConsoleKey.RightArrow:
                {
                    RightHandler(this, EventArgs.Empty);
                    break;
                }
                case ConsoleKey.UpArrow:
                {
                    UpHandler(this, EventArgs.Empty);
                    break;
                }
                case ConsoleKey.DownArrow:
                {
                    DownHandler(this, EventArgs.Empty);
                    break;
                }
                default:
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}