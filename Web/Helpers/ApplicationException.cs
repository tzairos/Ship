using System.Runtime.Serialization;

[Serializable]
internal class ApplicationException : Exception
{

    public ErrorType ErrorType { get; set; }
    public ApplicationException()
    {
    }

    public ApplicationException(string? message,ErrorType errorType=ErrorType.ApplicationError) : base(message)
    {
        ErrorType=errorType;
    }

    public ApplicationException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected ApplicationException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}