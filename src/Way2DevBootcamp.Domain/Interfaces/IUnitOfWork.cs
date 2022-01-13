namespace Way2DevBootcamp.Domain.Interfaces {
    public interface IUnitOfWork {
        IProdutoRepository Produtos { get; }
        ICategoriaRepository Categorias { get; }

        Task<bool> Commit();
        void Dispose();
        Task Rollback();
    }
}
