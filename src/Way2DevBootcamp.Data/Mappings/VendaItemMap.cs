using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Way2DevBootcamp.Domain.Entities;

namespace Way2DevBootcamp.Data.Mappings;
public class VendaItemMap : IEntityTypeConfiguration<VendaItem> {
    public void Configure(EntityTypeBuilder<VendaItem> builder) {
        builder.ToTable(nameof(VendaItem));

        builder.Property(i => i.Preco)
            .HasColumnType("decimal")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(i => i.Quantidade)
            .IsRequired();

        builder.HasOne(i => i.Venda)
            .WithMany(i => i.Itens)
            .HasForeignKey(i => i.VendaId);

        builder.HasOne(i => i.Produto)
            .WithMany(p => p.VendaItens)
            .HasForeignKey(i => i.ProdutoId);
    }
}