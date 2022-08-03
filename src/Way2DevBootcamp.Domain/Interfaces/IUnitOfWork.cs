namespace Way2DevBootcamp.Domain.Interfaces;
public interface IUnitOfWork {
    IProdutoRepository Produtos { get; }
    ICategoriaRepository Categorias { get; }
    IVendaRepository Vendas { get; }
    IVendaItemRepository VendaItens { get; }

    Task<bool> Commit();
    Task BeginTransaction();
    Task EndTransaction();
    void Dispose();
    Task Rollback();
}