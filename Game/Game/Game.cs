namespace Game;

using IConsoleWrapper = ConsoleWrapper.IConsoleWrapper;

public class Game
{
    public (int, int) Position { get; private set; }
    public bool[][] Walls { get; } = new bool[100][];
    private readonly IConsoleWrapper console;
    
    public Game(IConsoleWrapper console)
    {
        this.console = console;

        Position = (-1, -1);
        for (int i = 0; i < 100; i++)
        {
            Walls[i] = new bool[100];
        }
    }

    /// <summary>
    /// Prints map from the given file to the console
    /// </summary>
    /// <param name="path"></param>
    /// <exception cref="Exception"></exception>
    public void GenerateMap(string path)
    {
        using StreamReader map = new StreamReader(path);
        int stringCounter = console.GetCursorTop();
        while (true)
        {
            string? line = map.ReadLine();
            if (line == null)
            {
                break;
            }

            for (int i = console.GetCursorLeft(); i < line.Length; i++)
            {
                Walls[stringCounter][i] = line[i] == '|' || line[i] == '+' || line[i] == '-';
                if (line[i] == '@')
                {
                    if (Position.Item2 != -1)
                    {
                        throw new Exception("Wrong input: there are more than one characters on the map");
                    }
                    Position = (i, stringCounter);
                }
            }

            ++stringCounter;
            console.WriteLine(line);
        }
        console.SetCursorPosition(Position.Item1, Position.Item2);
    }

    /// <summary>
    /// Actions on left arrow key
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public void OnLeft(object? sender, EventArgs args)
    {
        if (Walls[Position.Item2][Position.Item1 - 1])
        {
            return;
        }
        console.Write(" ");
        Position = (Position.Item1 - 1, Position.Item2);
        console.SetCursorPosition(Position.Item1, Position.Item2);
        WriteAtSign();
    }

    /// <summary>
    /// Actions on right arrow key
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public void OnRight(object? sender, EventArgs args)
    {
        if (Walls[Position.Item2][Position.Item1 + 1])
        {
            return;
        }
        console.Write(" ");
        Position = (Position.Item1 + 1, Position.Item2);
        WriteAtSign();
    }

    /// <summary>
    /// Actions on up arrow key
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public void OnUp(object? sender, EventArgs args)
    {
        if (Walls[Position.Item2 - 1][Position.Item1])
        {
            return;
        }
        console.Write(" ");
        Position = (Position.Item1, Position.Item2 - 1);
        console.SetCursorPosition(Position.Item1, Position.Item2);
        WriteAtSign();
    }

    /// <summary>
    /// Actions on down arrow key
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public void OnDown(object? sender, EventArgs args)
    {
        if (Walls[Position.Item2 + 1][Position.Item1])
        {
            return;
        }
        console.Write(" ");
        Position = (Position.Item1, Position.Item2 + 1);
        console.SetCursorPosition(Position.Item1, Position.Item2);
        WriteAtSign();
    }

    private void WriteAtSign()
    {
        console.Write("@");
        console.SetCursorPosition(Position.Item1, Position.Item2);
    }
}