namespace Game;

public class Game
{
    public (int, int) position { get; private set; }
    public Game((int, int) startingPosition)
    {
        position = startingPosition;
    }
    
    public static (int, int) GenerateMap(string path)
    {
        using StreamReader map = new StreamReader(path);
        (int, int) position = (-1, -1);
        int stringCounter = 0;
        while (true)
        {
            string? line = map.ReadLine();
            if (line == null)
            {
                break;
            }

            if (line.Contains('@'))
            {
                if (position.Item2 != -1)
                {
                    throw new Exception(); // Заменить на что-то более конкретное
                }
                position.Item2 = stringCounter;
                position.Item1 = line.IndexOf("@", StringComparison.Ordinal);
            }

            ++stringCounter;
            Console.WriteLine(line);
        }
        Console.SetCursorPosition(position.Item1, position.Item2);
        return position;
    }

    public void OnLeft(object? sender, EventArgs args)
    {
        // Console.WriteLine("Going left");
        Console.Write(" ");
        Console.SetCursorPosition(position.Item1 - 2, position.Item2);
        Console.Write("@");
        position = (Console.CursorLeft, Console.CursorTop);
        Console.SetCursorPosition(position.Item1 - 1, position.Item2);
    }

    public void OnRight(object? sender, EventArgs args)
    {
        Console.Write(" ");
        Console.SetCursorPosition(position.Item1, position.Item2);
        Console.Write("@");
        position = (Console.CursorLeft, Console.CursorTop);
        Console.SetCursorPosition(position.Item1 - 1, position.Item2);
    }

    public void OnUp(object? sender, EventArgs args)
    {
        Console.Write(" ");
        Console.SetCursorPosition(position.Item1 - 1, position.Item2 - 1);
        Console.Write("@");
        position = (Console.CursorLeft, Console.CursorTop);
        Console.SetCursorPosition(position.Item1 - 1, position.Item2);
    }

    public void OnDown(object? sender, EventArgs args)
    {
        Console.Write(" ");
        Console.SetCursorPosition(position.Item1 - 1, position.Item2 + 1);
        Console.Write("@");
        position = (Console.CursorLeft, Console.CursorTop);
        Console.SetCursorPosition(position.Item1 - 1, position.Item2);
    }
}