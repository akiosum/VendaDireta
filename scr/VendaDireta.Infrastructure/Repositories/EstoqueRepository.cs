using Microsoft.EntityFrameworkCore;
using VendaDireta.Domain.Contracts.Repositories;
using VendaDireta.Domain.Entities;
using VendaDireta.Infrastructure.Abstractions;
using VendaDireta.Infrastructure.Data;

namespace VendaDireta.Infrastructure.Repositories;

public class EstoqueRepository(VendaDiretaContext context) : BaseReporitory<Estoque>(context), IEstoqueRepository
{
    public void AtualizarSemSave(Estoque estoque)
    {
        context.Estoque.Update(estoque);
    }

    public async Task AtualizarLote(List<Estoque> estoques, CancellationToken cancellationToken)
    {
        context.Estoque.UpdateRange(estoques);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Estoque>> ObterTodosPorProduto(Guid idProduto, CancellationToken cancellationToken)
    {
        List<Estoque> estoques = await context.Estoque
            .AsNoTracking()
            .Where(e => e.IdProduto == idProduto)
            .ToListAsync(cancellationToken);

        return estoques;
    }
}