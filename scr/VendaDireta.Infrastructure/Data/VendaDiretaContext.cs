using Microsoft.EntityFrameworkCore;
using VendaDireta.Domain.Contracts.Repositories;
using VendaDireta.Domain.Entities;

namespace VendaDireta.Infrastructure.Data;

public class VendaDiretaContext(DbContextOptions<VendaDiretaContext> options) : DbContext(options), IUnitOfWork
{
    #region DbSets

    public DbSet<Produto> Produto { get; set; }
    public DbSet<ProdutoPreco> ProdutoPreco { get; set; }
    public DbSet<Estoque> Estoque { get; set; }
    public DbSet<Venda> Venda { get; set; }
    public DbSet<VendaItem> VendaItem { get; set; }
    public DbSet<VendaPagamento> VendaPagamento { get; set; }

    #endregion DbSets

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(VendaDiretaContext).Assembly);
    }
}