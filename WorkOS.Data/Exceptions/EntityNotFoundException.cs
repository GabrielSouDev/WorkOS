namespace WorkOS.Data.Exceptions;

public class EntityNotFoundException : EntityException
{
    public EntityNotFoundException(string? message = "Entity is not Found!") : base(message) { }
}