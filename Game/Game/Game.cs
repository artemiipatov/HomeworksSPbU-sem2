namespace Game;

public class Game
{
    public (int, int) Position { get; private set; }
    public bool[][] Walls { get; } = new bool[100][];
    
    public Game()
    {
        Position = (-1, -1);
        for (int i = 0; i < 100; i++)
        {
            Walls[i] = new bool[100];
        }
    }

    public void GenerateMap(string path)
    {
        using StreamReader map = new StreamReader(path);
        int stringCounter = Console.CursorTop;
        while (true)
        {
            string? line = map.ReadLine();
            if (line == null)
            {
                break;
            }

            for (int i = Console.CursorLeft; i < line.Length; i++)
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
            Console.WriteLine(line);
        }
        Console.SetCursorPosition(Position.Item1, Position.Item2);
    }

    public void OnLeft(object? sender, EventArgs args)
    {
        if (Walls[Position.Item2][Position.Item1 - 1])
        {
            return;
        }
        Console.Write(" ");
        Position = (Position.Item1 - 1, Position.Item2);
        Console.SetCursorPosition(Position.Item1, Position.Item2);
        WriteAtSign();
    }

    public void OnRight(object? sender, EventArgs args)
    {
        if (Walls[Position.Item2][Position.Item1 + 1])
        {
            return;
        }
        Console.Write(" ");
        Position = (Position.Item1 + 1, Position.Item2);
        WriteAtSign();
    }

    public void OnUp(object? sender, EventArgs args)
    {
        if (Walls[Position.Item2 - 1][Position.Item1])
        {
            return;
        }
        Console.Write(" ");
        Position = (Position.Item1, Position.Item2 - 1);
        Console.SetCursorPosition(Position.Item1, Position.Item2);
        WriteAtSign();
    }

    public void OnDown(object? sender, EventArgs args)
    {
        if (Walls[Position.Item2 + 1][Position.Item1])
        {
            return;
        }
        Console.Write(" ");
        Position = (Position.Item1, Position.Item2 + 1);
        Console.SetCursorPosition(Position.Item1, Position.Item2);
        WriteAtSign();
    }

    private void WriteAtSign()
    {
        Console.Write("@");
        Console.SetCursorPosition(Position.Item1, Position.Item2);
    }
}