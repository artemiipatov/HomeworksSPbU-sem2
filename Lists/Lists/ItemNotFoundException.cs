using System.Runtime.Serialization;

namespace Lists;

/// <summary>
/// Exception that is thrown when searched value is not in the unique list
/// </summary>
[Serializable]
public class ItemNotFoundException : Exception
{
    public ItemNotFoundException()
    {
    }

    public ItemNotFoundException(string message) : base(message)
    {
    }

    public ItemNotFoundException(string message, Exception inner) : base(message, inner)
    {
    }

    protected ItemNotFoundException(
        SerializationInfo info,
        StreamingContext context) : base(info, context)
    {
    }
}