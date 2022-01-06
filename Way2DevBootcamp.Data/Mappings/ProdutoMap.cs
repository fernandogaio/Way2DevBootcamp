using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Way2DevBootcamp.Domain.Entities;

namespace Way2DevBootcamp.Data.Mappings {
    public class ProdutoMap : IEntityTypeConfiguration<Produto> {
        public void Configure(EntityTypeBuilder<Produto> builder) {
            builder.ToTable("Produto");

            builder.Property(p => p.Codigo)
                .HasColumnType("varchar(6)")
                .IsRequired();

            builder.Property(p => p.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasColumnType("varchar(500)")
                .IsRequired();

            builder.Property(p => p.Preco)
                .HasColumnType("numeric(18,2)")
                .IsRequired();

            builder.Property(p => p.DataCadastro)
                .HasColumnType("datetime")
                .IsRequired();

            builder.HasOne(p => p.Categoria)
                .WithMany(p => p.Produtos)
                .HasForeignKey(p => p.CategoriaId);
        }
    }
}
