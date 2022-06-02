namespace ConsoleWrapper;

public class ConsoleWrapperStub : IConsoleWrapper
{
    public void WriteLine(string data)
    {
    }

    public void Write(string data)
    {
    }

    public int GetCursorTop() => 0;

    public int GetCursorLeft() => 0;

    public void SetCursorPosition(int left, int top)
    {
    }
}