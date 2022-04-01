namespace StackCalculator;

/// <summary>
/// Stack implementation using list.
/// </summary>
public class ListBasedStack : IStack
{
    private class StackElement
    {
        public double Value;
        public StackElement? Next { get; set; }

        public StackElement(double value, StackElement? next)
        {
            this.Value = value;
            this.Next = next;
        }
    }

    private StackElement? _head = null;

    /// <summary>
    /// Pushes value to stack.
    /// </summary>
    /// <param name="value"></param>
    public void Push(double value) => _head = new StackElement(value, _head);

    /// <summary>
    /// Returns value of the stack head and removes it.
    /// </summary>
    /// <returns></returns>
    public double? Pop()
    {
        var value = _head?.Value ?? null;
        _head = _head?.Next;
        return value;
    }

    /// <summary>
    /// Returns true if stack is empty, returns false if stack is not empty.
    /// </summary>
    /// <returns></returns>
    public bool IsEmpty() => _head == null;
}