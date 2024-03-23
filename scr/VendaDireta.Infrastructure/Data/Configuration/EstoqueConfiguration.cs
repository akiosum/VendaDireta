using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendaDireta.Domain.Entities;

namespace VendaDireta.Infrastructure.Data.Configuration;

public class EstoqueConfiguration : IEntityTypeConfiguration<Estoque>
{
    public void Configure(EntityTypeBuilder<Estoque> builder)
    {
        builder.ToTable(nameof(Estoque));

        builder.Property(e => e.Quantidade)
            .IsRequired()
            .HasPrecision(18, 3);

        builder.HasOne(e => e.Produto)
            .WithMany(p => p.Estoque)
            .HasForeignKey(e => e.IdProduto);
    }
}