// ReSharper disable once CheckNamespace
namespace Registration.Components;

using System;


[Serializable]
public class LongTransientException :
    Exception
{
    public LongTransientException()
    {
    }

    public LongTransientException(string message)
        : base(message)
    {
    }
}