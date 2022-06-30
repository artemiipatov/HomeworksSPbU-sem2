namespace Lists;

/// <summary>
/// Implementation of common list
/// </summary>
public class CommonList
{
    private class ListElement
    {
        /// <summary>
        /// Integer value of the list element
        /// </summary>
        public int Value { get; internal set; }

        /// <summary>
        /// Next element in the list
        /// </summary>
        public ListElement? Next { get; internal set; }

        public ListElement(int value)
        {
            Value = value;
        }
    }
    
    /// <summary>
    /// Number of elements in the list
    /// </summary>
    public int Length { get; private set; }

    /// <summary>
    /// First element of the list
    /// </summary>
    private ListElement? Head { get; set; }

    /// <summary>
    /// Last element of the list
    /// </summary>
    private ListElement? Tail { get; set; }

    /// <summary>
    /// Adds the element to the list
    /// </summary>
    public virtual void Add(int value)
    {
        var newElement = new ListElement(value);

        if (Tail == null)
        {
            Head = newElement;
            Tail = newElement;
        }
        else
        {
            Tail.Next = newElement;
            Tail = Tail.Next;
        }

        ++Length;
    }

    /// <summary>
    /// Removes the element from the list
    /// </summary>
    public void Remove(int position)
    {
        var currentElement = Head;
        if (currentElement == null)
        {
            throw new ItemNotFoundException("Removing item from empty list");
        }

        if (position == 0)
        {
            Head = Head!.Next;
            --Length;
            return;
        }

        int currentPosition = 0;
        while (currentPosition != position - 1)
        {
            if (currentElement.Next == null)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }

            currentElement = currentElement.Next;
            ++currentPosition;
        }

        if (currentElement.Next == null)
        {
            throw new IndexOutOfRangeException("Index is out of range");
        }

        currentElement.Next = currentElement.Next.Next;
        --Length;
    }

    /// <summary>
    /// Changes the value of the list element with give index
    /// </summary>
    virtual public void ChangeValue(int position, int newValue)
    {
        var currentElement = Head;
        if (currentElement == null)
        {
            throw new ItemNotFoundException("Changing item in empty list");
        }

        int currentPosition = 0;
        while (currentPosition != position)
        {
            currentElement = currentElement.Next ?? throw new IndexOutOfRangeException("Index is out of range");
            ++currentPosition;
        }

        currentElement.Value = newValue;
    }
    
    /// <summary>
    /// Returns the value of the list element with given index
    /// </summary>
    public int Get(int position)
    {
        var currentElement = Head;
        if (currentElement == null)
        {
            throw new ItemNotFoundException("Changing item in empty list");
        }

        int currentPosition = 0;
        while (currentPosition != position)
        {
            currentElement = currentElement.Next ?? throw new IndexOutOfRangeException("Index is out of range");
            ++currentPosition;
        }

        return currentElement.Value;
    }

    /// <summary>
    /// Checks whether the value is in the list
    /// </summary>
    public int Find(int value)
    {
        var currentElement = Head;
        int counter = 0;
        while (currentElement != null)
        {
            if (currentElement.Value == value)
            {
                return counter;
            }
            currentElement = currentElement.Next;
            counter++;
        }

        return -1;
    }
}