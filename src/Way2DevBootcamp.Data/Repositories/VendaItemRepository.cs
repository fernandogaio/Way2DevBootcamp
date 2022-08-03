using Microsoft.EntityFrameworkCore;
using Way2DevBootcamp.Data.Context;
using Way2DevBootcamp.Domain.Entities;
using Way2DevBootcamp.Domain.Interfaces;

namespace Way2DevBootcamp.Data.Repositories;
public class VendaItemRepository : RepositoryBase<VendaItem>, IVendaItemRepository {
    public VendaItemRepository(DataContext dataContext) : base(dataContext) { }

    public override async Task<IEnumerable<VendaItem>> GetAll()
        => await _dbSet.Include(p => p.Venda)
                       .Include(p => p.Produto)
                       .ToListAsync();

    public override async Task<VendaItem> GetById(int id)
        => await _dbSet.Include(p => p.Venda)
                       .Include(p => p.Produto)
                       .SingleOrDefaultAsync(p => p.Id == id);
}