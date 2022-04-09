namespace Lists;

public class ListElement
{
    /// <summary>
    /// Integer value of the list element
    /// </summary>
    public int Value { get; set; }

    /// <summary>
    /// Next element in the list
    /// </summary>
    public ListElement? Next { get; set; }

    public ListElement(int value)
    {
        Value = value;
    }
}