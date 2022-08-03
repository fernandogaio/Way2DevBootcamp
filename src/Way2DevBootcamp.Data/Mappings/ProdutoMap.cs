using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Way2DevBootcamp.Domain.Entities;

namespace Way2DevBootcamp.Data.Mappings;
public class ProdutoMap : IEntityTypeConfiguration<Produto> {
    public void Configure(EntityTypeBuilder<Produto> builder) {
        builder.ToTable(nameof(Produto));

        builder.Property(p => p.Codigo)
            .HasMaxLength(6)
            .IsRequired();

        builder.Property(p => p.Nome)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.Descricao)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(p => p.Preco)
            .HasColumnType("decimal")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(p => p.DataCadastro)
            .HasColumnType("datetime")
            .IsRequired();

        builder.HasOne(p => p.Categoria)
            .WithMany(p => p.Produtos)
            .HasForeignKey(p => p.CategoriaId);
    }
}