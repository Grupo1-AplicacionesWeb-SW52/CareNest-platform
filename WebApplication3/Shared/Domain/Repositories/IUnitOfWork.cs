namespace WebApplication3.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}