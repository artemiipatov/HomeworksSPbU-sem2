namespace StackCalculator;

public interface IStack
{
    /// <summary>
    /// True if stack is empty, false if it is not empty
    /// </summary>
    public bool IsEmpty { get; }

    /// <summary>
    /// Pushes value to stack.
    /// </summary>
    /// <param name="value"></param>
    void Push(double value);

    /// <summary>
    /// Returns value of the stack head and removes it.
    /// </summary>
    /// <returns></returns>
    double? Pop();
}