using Way2DevBootcamp.Domain.Entities;
using Way2DevBootcamp.Domain.Interfaces;

namespace Way2DevBootcamp.Data.Repositories;
public class CategoriaRepository : ICategoriaRepository {
    private readonly IRepositoryBase<Categoria> _repositoryBase;

    public CategoriaRepository(IRepositoryBase<Categoria> repositoryBase) {
        _repositoryBase = repositoryBase;
    }

    public async Task<IEnumerable<Categoria>> GetAll()
        => await _repositoryBase.GetAll();

    public async Task<Categoria> GetById(int id)
        => await _repositoryBase.GetById(id);

    public async Task<bool> Exists(int id)
        => await _repositoryBase.Exists(id);
}