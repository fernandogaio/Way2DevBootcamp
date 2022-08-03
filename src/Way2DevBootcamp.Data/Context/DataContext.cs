using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Way2DevBootcamp.Domain.Entities;

namespace Way2DevBootcamp.Data.Context;
public class DataContext : DbContext {
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Venda> Vendas { get; set; }
    public DbSet<VendaItem> VendaItens { get; set; }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder) {
        configurationBuilder
            .Properties<string>()
            .AreUnicode(false)
            .HaveMaxLength(500);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder
            .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}