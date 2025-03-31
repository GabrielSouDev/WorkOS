namespace WorkOS.Data.Exceptions;

public class EntityException : Exception
{
    public EntityException(string? message) : base(message)
    {
    }
}