namespace CarNest.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}