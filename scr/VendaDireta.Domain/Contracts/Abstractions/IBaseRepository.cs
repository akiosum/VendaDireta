using VendaDireta.Domain.Abstraction;

namespace VendaDireta.Domain.Contracts.Abstractions;

public interface IBaseRepository<TEntity> : IRepository
    where TEntity : BaseEntity
{
    Task<TEntity> Inserir(TEntity entity, CancellationToken cancellationToken);
    Task<TEntity> Atualizar(TEntity entity, CancellationToken cancellationToken);
    Task<TEntity?> ObterPorId(Guid id, CancellationToken cancellationToken);
}