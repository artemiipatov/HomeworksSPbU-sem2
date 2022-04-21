namespace Lists;

using Exceptions;

public class CommonList : ICommonList
{
    public int Length { get; set; }

    public ListElement? Head;

    public ListElement? Tail;

    public void Add(int value)
    {
        ListElement newElement = new ListElement(value);

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

    public void Remove(int position)
    {
        ListElement? currentElement = Head;
        if (currentElement == null)
        {
            throw new ItemNotFoundException("Removing item from empty list");
        }

        if (position == 0)
        {
            Head = Head.Next;
            --Length;
            return;
        }

        int currentPosition = 0;
        while (currentPosition != position - 1)
        {
            if (currentElement.Next == null)
            {
                throw new ItemNotFoundException("Index is out of range");
            }

            currentElement = currentElement.Next;
            ++currentPosition;
        }

        if (currentElement.Next == null)
        {
            throw new ItemNotFoundException("Index is out of range");
        }

        currentElement.Next = currentElement.Next.Next;
        --Length;
    }

    public void ChangeValue(int position, int newValue)
    {
        ListElement? currentElement = Head;
        if (currentElement == null)
        {
            throw new ItemNotFoundException("Changing item in empty list");
        }

        int currentPosition = 0;
        while (currentPosition != position)
        {
            currentElement = currentElement.Next ?? throw new ItemNotFoundException("Index is out of range");
            ++currentPosition;
        }

        currentElement.Value = newValue;
    }
    
    public int Get(int position)
    {
        ListElement? currentElement = Head;
        if (currentElement == null)
        {
            throw new ItemNotFoundException("Changing item in empty list");
        }

        int currentPosition = 0;
        while (currentPosition != position)
        {
            currentElement = currentElement.Next ?? throw new ItemNotFoundException("Index is out of range");
            ++currentPosition;
        }

        return currentElement.Value;
    }
}