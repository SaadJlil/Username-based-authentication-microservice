namespace Domain.Interfaces.Exceptions;

public class AlreadyExistsException: Exception
{
    public AlreadyExistsException()
    {
    }

    public AlreadyExistsException(string message)
        : base(message)
    {
    }

    public AlreadyExistsException(string message, object obj)
        : base($"{message}. {obj} already exists.")
    {
    }

    public AlreadyExistsException(object obj)
        : base($"object {obj} already exists.")
    {
    }

}