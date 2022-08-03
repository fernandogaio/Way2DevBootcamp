using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Way2DevBootcamp.Domain.Entities;

namespace Way2DevBootcamp.Data.Mappings;
public class VendaMap : IEntityTypeConfiguration<Venda> {
    public void Configure(EntityTypeBuilder<Venda> builder) {
        builder.ToTable(nameof(Venda));

        builder.Property(p => p.UsuarioId)
            .HasMaxLength(36);

        builder.Property(p => p.DataVenda)
            .IsRequired();

        builder.Property(p => p.StatusPedido)
            .IsRequired();

        builder.Property(p => p.ValorTotal)
            .HasColumnType("decimal")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.HasMany(p => p.Itens)
            .WithOne(p => p.Venda)
            .HasForeignKey(p => p.VendaId);
    }
}