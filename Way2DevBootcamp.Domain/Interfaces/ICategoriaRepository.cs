using Way2DevBootcamp.Domain.Entities;

namespace Way2DevBootcamp.Domain.Interfaces {
    public interface ICategoriaRepository {
        Task<IEnumerable<Categoria>> GetAll();
        Task<Categoria> GetById(int id);
    }
}
