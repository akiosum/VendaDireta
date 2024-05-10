using VendaDireta.Domain.Contracts.Abstractions;

namespace VendaDireta.Domain.Contracts.Repositories;

public interface IUnitOfWork : IRepository
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}