using Way2DevBootcamp.Domain.Entities;

namespace Way2DevBootcamp.Domain.Interfaces {
    public interface IProdutoRepository : IRepositoryBase<Produto> {
        Task<bool> ExisteProduto(Produto produto);
    }
}
