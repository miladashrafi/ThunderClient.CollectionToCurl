namespace ThunderClient.CollectionToCurl;

public class CustomException:Exception
{
    public CustomExceptionType Type { get; }

    public CustomException(CustomExceptionType type, string message): base(message)
    {
        Type = type;
    }
}

public enum CustomExceptionType
{
    Warning,
    Exception
}