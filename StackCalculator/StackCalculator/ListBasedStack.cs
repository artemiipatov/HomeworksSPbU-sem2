namespace StackCalculator;

/// <summary>
/// Stack implementation using list.
/// </summary>
public class ListBasedStack : IStack
{
    private class StackElement
    {
        public double Value { get; }
        public StackElement? Next { get; }

        public StackElement(double value, StackElement? next)
        {
            Value = value;
            Next = next;
        }
    }

    private StackElement? _head = null;
    public bool IsEmpty => _head == null;

    public void Push(double value)
    {
        _head = new StackElement(value, _head);
    }

    public double? Pop()
    {
        var value = _head?.Value ?? null;
        _head = _head?.Next;
        return value;
    }
}