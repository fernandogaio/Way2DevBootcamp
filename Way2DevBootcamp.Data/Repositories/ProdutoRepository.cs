using Microsoft.EntityFrameworkCore;
using Way2DevBootcamp.Data.Context;
using Way2DevBootcamp.Domain.Entities;
using Way2DevBootcamp.Domain.Interfaces;

namespace Way2DevBootcamp.Data.Repositories {
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository {
        public ProdutoRepository(DataContext dataContext) : base(dataContext) {
        }

        public async Task<IEnumerable<Produto>> GetAll()
            => await _dbSet.Include(p => p.Categoria)
                           .ToListAsync();

        public async Task<Produto> GetById(int id)
            => await _dbSet.Include(p => p.Categoria)
                           .SingleOrDefaultAsync(p => p.Id == id);

        public async Task<bool> ExisteProduto(Produto produto)
            => await _dbSet.AnyAsync(p => p.Id != produto.Id && 
                                         (p.Codigo.ToLower().Equals(produto.Codigo.ToLower()) || p.Nome.ToLower().Equals(produto.Nome.ToLower())));
    }
}