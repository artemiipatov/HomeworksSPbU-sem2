namespace ConsoleWrapper;

public class ConsoleWrapper : IConsoleWrapper
{
    public void WriteLine(string data)
    {
        Console.WriteLine(data);
    }

    public void Write(string data)
    {
        Console.Write(data);
    }

    public int GetCursorTop()
    {
        return Console.CursorTop;
    }

    public int GetCursorLeft()
    {
        return Console.CursorLeft;
    }

    public void SetCursorPosition(int left, int top)
    {
        Console.SetCursorPosition(left, top);
    }
}
