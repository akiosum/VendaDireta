using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendaDireta.Domain.Entities;

namespace VendaDireta.Infrastructure.Data.Configuration;

public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable(nameof(Produto));

        builder.Property(p => p.Descricao)
            .IsRequired()
            .HasMaxLength(250);
        
        builder.Property(p => p.DescricaoReduzida)
            .HasMaxLength(150);
    }
}