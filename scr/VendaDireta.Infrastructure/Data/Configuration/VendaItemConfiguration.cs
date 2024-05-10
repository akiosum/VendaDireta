using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendaDireta.Domain.Entities;

namespace VendaDireta.Infrastructure.Data.Configuration;

public class VendaItemConfiguration : IEntityTypeConfiguration<VendaItem>
{
    public void Configure(EntityTypeBuilder<VendaItem> builder)
    {
        builder.ToTable(nameof(VendaItem));
        
        builder.Property(vi => vi.Quantidade)
            .HasPrecision(18, 3);
        
        builder.Property(vi => vi.ValorUnitario)
            .HasPrecision(18, 3);
        
        builder.Property(vi => vi.ValorBruto)
            .HasPrecision(18, 3);
        
        builder.HasOne(vi => vi.Produto)
            .WithMany(p => p.VendaItem)
            .HasForeignKey(pp => pp.IdProduto);
        
        builder.HasOne(vi => vi.Venda)
            .WithMany(p => p.VendaItem)
            .HasForeignKey(pp => pp.IdVenda);
    }
}