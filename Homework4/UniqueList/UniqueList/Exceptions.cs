namespace UniqueList;

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