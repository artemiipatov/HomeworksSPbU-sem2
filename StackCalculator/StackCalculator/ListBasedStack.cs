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
    public bool IsEmpty { get; private set; } = true;

    public void Push(double value)
    {
        _head = new StackElement(value, _head);
        IsEmpty = false;
    }

    public double? Pop()
    {
        var value = _head?.Value ?? null;
        _head = _head?.Next;
        if (_head == null)
        {
            IsEmpty = true;
        }
        return value;
    }
}