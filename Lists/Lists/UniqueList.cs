namespace Lists;

/// <summary>
/// Implementation of unique list -- the list with unique values
/// </summary>
public class UniqueList : CommonList
{
    /// <summary>
    /// Adds given value to the list. Throws an exception if the item with such value is already in the list
    /// </summary>
    public override void Add(int value)
    {
        if (Find(value) != -1)
        {
            throw new AddingExistingItemException("Item already exists");
        }
        base.Add(value);
    }

    public override void ChangeValue(int position, int newValue)
    {
        int pos = Find(newValue);
        if (pos == position)
        {
            return;
        }
        else if (pos == -1)
        {
            base.ChangeValue(position, newValue);
        }
        else
        {
            throw new AddingExistingItemException();
        }
    }
}