using System.Linq.Expressions;
using Persistence.Context;
using Persistence.Context.Base;
using Microsoft.EntityFrameworkCore;
using Persistence.Context.Tables;

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

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbSet.FindAsync(id, cancellationToken);
    }

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbSet.ToListAsync(cancellationToken);
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
        await _entityContext.SaveChangesAsync(cancellationToken);
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

    public async Task<T?> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
    {
        return await _dbSet.FirstOrDefaultAsync(predicate, cancellationToken);
    }
}
