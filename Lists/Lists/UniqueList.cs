using Exceptions;

namespace Lists;

public class UniqueList : CommonList
{
    public new void Add(int value)
    {
        ListElement newElement = new ListElement(value);
        ListElement? currentElement = Head;
        if (currentElement == null)
        {
            Head = newElement;
            ++Length;
            return;
        }
        while (currentElement.Next != null)
        {
            if (currentElement.Value == value)
            {
                throw new AddingExistingItemException("Item already exists");
            }
            currentElement = currentElement.Next;
        }

        if (currentElement.Value == value)
        {
            throw new AddingExistingItemException("Item already exists");
        }
        currentElement.Next = newElement;
        ++Length;
    }

}