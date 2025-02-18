namespace WorkOS.API.Exceptions;

public class TaskItemException : Exception
{
    public TaskItemException(string? message) : base(message)
    {
    }
}