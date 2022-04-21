namespace Lists;

using Exceptions;

public class UniqueList : CommonList
{
    /// <summary>
    /// Adds given value to the list. Throws an exception if the item with such value is already in the list
    /// </summary>
    /// <param name="value"></param>
    /// <exception cref="AddingExistingItemException"></exception>
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