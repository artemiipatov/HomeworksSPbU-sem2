using System.Runtime.Serialization;

namespace Exceptions;

/// <summary>
/// Throws if vectors have different lengths
/// </summary>
[Serializable]
public class DifferentLengthsException : Exception
{
    public DifferentLengthsException()
    {
    }

    public DifferentLengthsException(string message) : base(message)
    {
    }

    public DifferentLengthsException(string message, Exception inner) : base(message, inner)
    {
    }

    protected DifferentLengthsException(
        SerializationInfo info,
        StreamingContext context) : base(info, context)
    {
    }
}