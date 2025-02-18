namespace WorkOS.API.Exceptions;

public class TaskItemNotFoundException : TaskItemException
{
    public TaskItemNotFoundException(string? message = "Task Item is not Found!") : base(message) { }
}