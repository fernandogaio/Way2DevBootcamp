using Way2DevBootcamp.Domain.Entities;

namespace Way2DevBootcamp.Domain.Interfaces {
    public interface IRepositoryBase<TEntity> where TEntity : Entity {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}