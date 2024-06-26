﻿using System.Linq.Expressions;

namespace Persistence.Repositories;

public interface IRepository<T>
{ 
        Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
        Task AddAsync(T entity, CancellationToken cancellationToken);
        void Update(T entity);
        void Delete(T entity);
        Task<T?> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
}