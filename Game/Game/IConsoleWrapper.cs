namespace ConsoleWrapper;

public interface IConsoleWrapper
{
    void WriteLine(string data);

    void Write(string data);

    int GetCursorTop();

    int GetCursorLeft();

    void SetCursorPosition(int left, int top);
}