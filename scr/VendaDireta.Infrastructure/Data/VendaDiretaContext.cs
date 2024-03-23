using Microsoft.EntityFrameworkCore;
using VendaDireta.Domain.Entities;

namespace VendaDireta.Infrastructure.Data;

public class VendaDiretaContext(DbContextOptions<VendaDiretaContext> options) : DbContext(options)
{
    #region DbSets

    public DbSet<Produto> Produto { get; set; }
    public DbSet<ProdutoPreco> ProdutoPreco { get; set; }
    public DbSet<Estoque> Estoque { get; set; }

    #endregion DbSets

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(VendaDiretaContext).Assembly);
    }
}