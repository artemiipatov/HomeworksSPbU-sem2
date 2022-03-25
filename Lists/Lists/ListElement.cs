namespace Lists;

public class ListElement
{
    public int Value { get; set; }

    public ListElement? Next { get; set; }

    public ListElement(int value)
    {
        Value = value;
    }
}