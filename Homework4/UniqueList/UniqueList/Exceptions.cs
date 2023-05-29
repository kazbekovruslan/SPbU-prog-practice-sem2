namespace Lists;

/// <summary>
/// Exception that is thrown when you want to interact with element that doesn't exist.
/// </summary>
[System.Serializable]
public class ElementDoesntExistException : System.Exception
{
    public ElementDoesntExistException() { }
    public ElementDoesntExistException(string message) : base(message) { }
    public ElementDoesntExistException(string message, System.Exception inner) : base(message, inner) { }
    protected ElementDoesntExistException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}

/// <summary>
/// Exception that is thrown when you want to interact with element that already exist.
/// </summary>
[System.Serializable]
public class ElementAlreadyExistsException : System.Exception
{
    public ElementAlreadyExistsException() { }
    public ElementAlreadyExistsException(string message) : base(message) { }
    public ElementAlreadyExistsException(string message, System.Exception inner) : base(message, inner) { }
    protected ElementAlreadyExistsException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}