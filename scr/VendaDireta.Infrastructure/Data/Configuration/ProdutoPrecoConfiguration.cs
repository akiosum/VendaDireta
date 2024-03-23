using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendaDireta.Domain.Entities;

namespace VendaDireta.Infrastructure.Data.Configuration;

public class ProdutoPrecoConfiguration : IEntityTypeConfiguration<ProdutoPreco>
{
    public void Configure(EntityTypeBuilder<ProdutoPreco> builder)
    {
        builder.ToTable(nameof(ProdutoPreco));

        builder.Property(pp => pp.Preco)
            .HasPrecision(18, 3);

        builder.HasOne(pp => pp.Produto)
            .WithMany(p => p.ProdutoPreco)
            .HasForeignKey(pp => pp.IdProduto);
    }
}