namespace CustomExceptions;

[System.Serializable]
public class InvalidResourceException : System.Exception
{
    public InvalidResourceException() { }
    public InvalidResourceException(string message) : base(message) { }
    public InvalidResourceException(string message, System.Exception inner) : base(message, inner) { }
    protected InvalidResourceException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}