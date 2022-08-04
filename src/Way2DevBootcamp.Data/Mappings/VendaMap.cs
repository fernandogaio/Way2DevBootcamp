using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Way2DevBootcamp.Domain.Entities;

namespace Way2DevBootcamp.Data.Mappings;
public class VendaMap : IEntityTypeConfiguration<Venda> {
    public void Configure(EntityTypeBuilder<Venda> builder) {
        builder.ToTable(nameof(Venda));

        builder.Property(v => v.UsuarioId)
            .HasMaxLength(36);

        builder.Property(v => v.DataVenda)
            .IsRequired();

        builder.Property(v => v.StatusPedido)
            .IsRequired();

        builder.Property(v => v.ValorTotal)
            .HasColumnType("decimal")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.HasMany(v => v.Itens)
            .WithOne(v => v.Venda)
            .HasForeignKey(v => v.VendaId);
    }
}