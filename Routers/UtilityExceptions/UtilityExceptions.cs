﻿using System.Runtime.Serialization;
namespace UtilityExceptions;

[Serializable]
public class WrongInputException : Exception
{
    public WrongInputException()
    {
    }

    public WrongInputException(string message) : base(message)
    {
    }

    public WrongInputException(string message, Exception inner) : base(message, inner)
    {
    }

    protected WrongInputException(
        SerializationInfo info,
        StreamingContext context) : base(info, context)
    {
    }
}