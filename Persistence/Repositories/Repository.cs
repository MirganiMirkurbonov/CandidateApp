using Persistence.Context;
using Persistence.Context.Base;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class Repository<T> : IRepository<T>
    where T : BaseEntity
{
    private readonly EntityContext _entityContext;
    private readonly DbSet<T> _dbSet;

    public Repository(EntityContext entityContext)
    {
        _entityContext = entityContext;
        _dbSet = _entityContext.Set<T>();
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _entityContext.SaveChangesAsync();
    }

    public void Update(T entity)
    {
        _entityContext.Update(entity);
        _entityContext.SaveChanges();
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
        _entityContext.SaveChanges();
    }
}
