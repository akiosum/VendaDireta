using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendaDireta.Domain.Entities;

namespace VendaDireta.Infrastructure.Data.Configuration;

public class VendaPagamentoConfiguration : IEntityTypeConfiguration<VendaPagamento>
{
    public void Configure(EntityTypeBuilder<VendaPagamento> builder)
    {
        builder.ToTable(nameof(VendaPagamento));
        
        builder.Property(vp => vp.ValorPago)
            .HasPrecision(18, 3);
        
        builder.Property(vp => vp.ValorTroco)
            .HasPrecision(18, 3);
        
        builder.HasOne(vp => vp.Venda)
            .WithMany(p => p.VendaPagamento)
            .HasForeignKey(vp => vp.IdVenda);
    }
}