using VendaDireta.Domain.Abstraction;
using VendaDireta.Domain.Contracts.Abstractions;
using VendaDireta.Infrastructure.Data;

namespace VendaDireta.Infrastructure.Abstractions;

public abstract class BaseReporitory<TEntity>(VendaDiretaContext context)
    : IBaseRepository<TEntity>
    where TEntity : BaseEntity
{
    #region Methods

    public async Task<TEntity> Inserir(TEntity entity, CancellationToken cancellationToken)
    {
        context
            .Set<TEntity>()
            .Add(entity);
        await context.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async Task<TEntity> Atualizar(TEntity entity, CancellationToken cancellationToken)
    {
        context
            .Set<TEntity>()
            .Update(entity);
        await context.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async Task<TEntity?> ObterPorId(Guid id, CancellationToken cancellationToken)
    {
        TEntity? entity = await context
            .Set<TEntity>()
            .FindAsync(id, cancellationToken);

        return entity;
    }

    #endregion Methods
}