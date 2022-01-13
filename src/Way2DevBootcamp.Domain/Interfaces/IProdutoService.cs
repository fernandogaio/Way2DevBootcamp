using Way2DevBootcamp.Domain.Entities;

namespace Way2DevBootcamp.Domain.Interfaces {
    public interface IProdutoService {
        Task<IEnumerable<Produto>> GetAll();
        Task<Produto> GetById(int id);
        Task Create(Produto produto);
        Task Edit(Produto produto);
        Task Delete(Produto produto);
    }
}
