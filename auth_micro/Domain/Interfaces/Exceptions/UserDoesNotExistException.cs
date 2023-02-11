namespace Domain.Interfaces.Exceptions;

public class UserDoesNotExistException: Exception
{
    public UserDoesNotExistException()
    {
    }

    public UserDoesNotExistException(string message)
        : base(message)
    {
    }

    public UserDoesNotExistException(string message, object obj)
        : base($"{message}. {obj} does not exist.")
    {
    }

    public UserDoesNotExistException(object obj)
        : base($"object {obj} does not exist")
    {
    }

}