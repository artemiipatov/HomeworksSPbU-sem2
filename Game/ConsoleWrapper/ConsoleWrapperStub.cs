namespace ConsoleWrapper;

public class ConsoleWrapperStub : IConsoleWrapper
{
    public void WriteLine(string data)
    {
        return;
    }

    public void Write(string data)
    {
        return;
    }

    public int GetCursorTop()
    {
        return 0;
    }

    public int GetCursorLeft()
    {
        return 0;
    }

    public void SetCursorPosition(int left, int top)
    {
        return;
    }
}