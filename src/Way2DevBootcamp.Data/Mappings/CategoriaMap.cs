using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Way2DevBootcamp.Domain.Entities;

namespace Way2DevBootcamp.Data.Mappings;
public class CategoriaMap : IEntityTypeConfiguration<Categoria> {
    public void Configure(EntityTypeBuilder<Categoria> builder) {
        builder.ToTable(nameof(Categoria));

        builder.Property(p => p.Id)
            .ValueGeneratedNever();

        builder.Property(c => c.Nome)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasMany(c => c.Produtos)
            .WithOne(c => c.Categoria)
            .HasForeignKey(c => c.CategoriaId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasData(new Categoria(1, "Acessórios de Tecnologia"),
                        new Categoria(2, "Ar e Ventilação"),
                        new Categoria(3, "Artesanato"),
                        new Categoria(4, "Artigos para Festa"),
                        new Categoria(5, "Áudio"),
                        new Categoria(6, "Automotivo"),
                        new Categoria(7, "Bebês"),
                        new Categoria(8, "Beleza & Perfumaria"),
                        new Categoria(9, "Brinquedos"),
                        new Categoria(10, "Cama, Mesa e Banho"),
                        new Categoria(11, "Câmeras e Drones"),
                        new Categoria(12, "Casa e Construção"),
                        new Categoria(13, "Casa Inteligente"),
                        new Categoria(14, "Celular e Smartphone"),
                        new Categoria(15, "Colchões"),
                        new Categoria(16, "Comércio e Indústria"),
                        new Categoria(17, "Cursos"),
                        new Categoria(18, "Decoração"),
                        new Categoria(19, "Eletrodomésticos"),
                        new Categoria(20, "Eletroportáteis"),
                        new Categoria(21, "Esporte e Lazer"),
                        new Categoria(22, "Ferramentas"),
                        new Categoria(23, "Filmes e Séries"),
                        new Categoria(24, "Games"),
                        new Categoria(25, "Informática"),
                        new Categoria(26, "Instrumentos Musicais"),
                        new Categoria(27, "Livros"),
                        new Categoria(28, "Mercado"),
                        new Categoria(29, "Moda"),
                        new Categoria(30, "Móveis"),
                        new Categoria(31, "Música e Shows"),
                        new Categoria(32, "Natal"),
                        new Categoria(33, "Papelaria"),
                        new Categoria(34, "Pet Shop"),
                        new Categoria(35, "Relógios"),
                        new Categoria(36, "Saúde e Cuidados Pessoais"),
                        new Categoria(37, "Serviços"),
                        new Categoria(38, "Suplementos Alimentares"),
                        new Categoria(39, "Tablets, iPads e E - Readers"),
                        new Categoria(40, "Telefonia Fixa"),
                        new Categoria(41, "TV e Vídeo"),
                        new Categoria(42, "Utilidades Domésticas"));
    }
}