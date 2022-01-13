using Microsoft.EntityFrameworkCore;
using Way2DevBootcamp.Data.Context;
using Way2DevBootcamp.Domain.Entities;
using Way2DevBootcamp.Domain.Interfaces;

namespace Way2DevBootcamp.Data.Repositories {
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Entity {
        public readonly DbSet<TEntity> _dbSet;
        public readonly DataContext _dataContext;

        public RepositoryBase(DataContext dataContext) {
            _dbSet = dataContext.Set<TEntity>();
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<TEntity>> GetAll() 
            => await _dbSet.AsQueryable().AsNoTracking().ToListAsync();

        public async Task<TEntity> GetById(int id)
            => await _dbSet.FindAsync(id);

        public async Task Add(TEntity entity) {
            await _dbSet.AddAsync(entity);
        }

        public void Update(TEntity entity) {
            _dbSet.Update(entity);
        }

        public void Delete(TEntity entity) {
            _dbSet.Remove(entity);
        }
    }
}
