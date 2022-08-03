using Microsoft.EntityFrameworkCore;
using Way2DevBootcamp.Data.Context;
using Way2DevBootcamp.Domain.Entities;
using Way2DevBootcamp.Domain.Interfaces;

namespace Way2DevBootcamp.Data.Repositories;
public class VendaRepository : RepositoryBase<Venda>, IVendaRepository {
    public VendaRepository(DataContext dataContext) : base(dataContext) {
    }

    public override async Task<IEnumerable<Venda>> GetAll()
        => await _dbSet.Include(p => p.Itens)
                           .ThenInclude(i => i.Produto)
                       .ToListAsync();

    public override async Task<Venda> GetById(int id)
        => await _dbSet.Include(p => p.Itens)
                           .ThenInclude(i => i.Produto)
                       .SingleOrDefaultAsync(p => p.Id == id);
}