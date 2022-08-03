using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Way2DevBootcamp.Domain.Entities;

namespace Way2DevBootcamp.Data.Mappings;
public class VendaItemMap : IEntityTypeConfiguration<VendaItem> {
    public void Configure(EntityTypeBuilder<VendaItem> builder) {
        builder.ToTable(nameof(VendaItem));

        builder.Property(p => p.Preco)
            .HasColumnType("decimal")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(p => p.Quantidade)
            .IsRequired();

        builder.HasOne(p => p.Venda)
            .WithMany(p => p.Itens)
            .HasForeignKey(p => p.VendaId);

        builder.HasOne(p => p.Produto)
            .WithMany()
            .HasForeignKey(p => p.ProdutoId);
    }
}