using VendaDireta.Domain.Contracts.Abstractions;
using VendaDireta.Domain.Entities;

namespace VendaDireta.Domain.Contracts.Repositories;

public interface IProdutoRepository : IBaseRepository<Produto>
{
    Task<Produto?> ObterPorIdComDependencias(Guid id, CancellationToken cancellationToken);
    Task<List<Produto>> ObterTodosProdutos(CancellationToken cancellationToken);
}