using VendaDireta.Domain.Contracts.Abstractions;
using VendaDireta.Domain.Entities;

namespace VendaDireta.Domain.Contracts.Repositories;

public interface IEstoqueRepository : IBaseRepository<Estoque>
{
    void AtualizarSemSave(Estoque estoque);
    Task AtualizarLote(List<Estoque> estoques, CancellationToken cancellationToken);
    Task<List<Estoque>> ObterTodosPorProduto(Guid idProduto, CancellationToken cancellationToken);
}