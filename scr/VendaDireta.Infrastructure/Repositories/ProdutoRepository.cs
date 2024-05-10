using Microsoft.EntityFrameworkCore;
using VendaDireta.Domain.Contracts.Repositories;
using VendaDireta.Domain.Entities;
using VendaDireta.Infrastructure.Abstractions;
using VendaDireta.Infrastructure.Data;

namespace VendaDireta.Infrastructure.Repositories;

public class ProdutoRepository(VendaDiretaContext context) :
    BaseReporitory<Produto>(context),
    IProdutoRepository
{
    public async Task<Produto?> ObterPorIdComDependencias(Guid id, CancellationToken cancellationToken)
    {
        Produto? produto = await context.Produto
            .AsNoTracking()
            .Include(p => p.ProdutoPreco)
            .Include(p => p.Estoque)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        return produto;
    }

    public async Task<List<Produto>> ObterTodosProdutos(CancellationToken cancellationToken)
    {
        List<Produto> produtos = await context.Produto
            .AsNoTracking()
            .Include(p => p.ProdutoPreco)
            .Include(p => p.Estoque)
            .ToListAsync(cancellationToken);

        return produtos;
    }
}