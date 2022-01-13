using Microsoft.EntityFrameworkCore;
using Way2DevBootcamp.Data.Mappings;
using Way2DevBootcamp.Domain.Entities;

namespace Way2DevBootcamp.Data.Context {
    public class DataContext : DbContext {
        public DataContext() { }

        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
        }
    }
}
