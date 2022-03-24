namespace MyList;

public class MyList
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
            throw new Exception("Empty List"); // заменить на свое исключение.
        }

        int currentPosition = 0;
        while (currentPosition != position - 1)
        {
            if (currentElement.Next == null)
            {
                throw new Exception("Index is out of range"); // заменить на свое исключение.
            }
            currentElement = currentElement.Next;
            ++currentPosition;
        }

        currentElement.Next = currentElement.Next!.Next;
    }

    public void ChangeValue(int position, int newValue)
    {
        ListElement? currentElement = Head;
        if (currentElement == null)
        {
            throw new Exception("Empty List"); // заменить на свое исключение.
        }

        int currentPosition = 0;
        while (currentPosition != position)
        {
            currentElement = currentElement.Next ?? throw new Exception("Index is out of range"); // заменить на свое исключение.
            ++currentPosition;
        }

        currentElement.Value = newValue;
    }
}