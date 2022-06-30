using System.Runtime.Serialization;

namespace Lists;

/// <summary>
/// Exception that is thrown when the value is already in the unique list
/// </summary>
[Serializable]
public class AddingExistingItemException : Exception
{
    public AddingExistingItemException()
    {
    }

    public AddingExistingItemException(string message) : base(message)
    {
    }

    public AddingExistingItemException(string message, System.Exception inner) : base(message, inner)
    {
    }

    protected AddingExistingItemException(
        SerializationInfo info,
        StreamingContext context) : base(info, context)
    {
    }
}