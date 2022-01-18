using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Books.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task Create(T entity, CancellationToken cancellationToken = default);
        Task Update(T entity, CancellationToken cancellationToken = default);
        Task<List<T>> GetAll(CancellationToken cancellationToken = default);
        Task<List<T>> GetAll(string language, CancellationToken cancellationToken = default);
        Task Delete(T entity, CancellationToken cancellationToken = default);
        Task<List<T>> Find(Func<T, bool> predicate, CancellationToken cancellationToken = default);
        Task<List<T>> Find(Func<T, bool> predicate, string language, CancellationToken cancellationToken = default);
    }
}
