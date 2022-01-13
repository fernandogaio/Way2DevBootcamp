using Way2DevBootcamp.Data.Context;
using Way2DevBootcamp.Data.Repositories;
using Way2DevBootcamp.Domain.Entities;
using Way2DevBootcamp.Domain.Interfaces;

namespace Way2DevBootcamp.Data.Transaction {
    public class UnitOfWork : IUnitOfWork {
        private readonly DataContext _dataContext;
        private readonly IRepositoryBase<Categoria> _repositoryBaseCategoria;

        public IProdutoRepository Produtos { get; private set; }
        public ICategoriaRepository Categorias { get; private set; }

        public UnitOfWork(DataContext dataContext, IRepositoryBase<Categoria> repositoryBaseCategoria) {
            _dataContext = dataContext;
            _repositoryBaseCategoria = repositoryBaseCategoria;

            Produtos = new ProdutoRepository(_dataContext);
            Categorias = new CategoriaRepository(_repositoryBaseCategoria);
        }

        public async Task<bool> Commit() {
            var success = (await _dataContext.SaveChangesAsync()) > 0;

            return success;
        }

        public void Dispose() =>
            _dataContext.Dispose();

        public async Task Rollback() {
            await Task.CompletedTask;
        }
    }
}
