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

    private StackElement? head = null;

    /// <summary>
    /// Pushes value to stack.
    /// </summary>
    /// <param name="value"></param>
    public void Push(double value) => head = new StackElement(value, head);

    /// <summary>
    /// Returns value of the stack head and removes it.
    /// </summary>
    /// <returns></returns>
    public double? Pop()
    {
        var value = head?.Value ?? null;
        head = head?.Next;
        return value;
    }

    /// <summary>
    /// Returns true if stack is empty, returns false if stack is not empty.
    /// </summary>
    /// <returns></returns>
    public bool IsEmpty() => head == null;
}