using Books.Domain.Core.DbEntities.Books;
using Books.Domain.Interfaces.SQL;
using Books.Infrastructure.Data.DBContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Books.Infrastructure.Data.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly DataContext _context;

        public BooksRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Create(Book entity, CancellationToken cancellationToken = default)
        {
            await _context.AddAsync(entity, cancellationToken).ConfigureAwait(false);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Book entity, CancellationToken cancellationToken = default)
        {
            _context.Remove(entity);
            await this._context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<List<Book>> Find(Func<Book, bool> predicate, CancellationToken cancellationToken = default)
        {
            return await _context
                .Books
                .AsNoTracking()
                .Where(predicate)
                .ToAsyncEnumerable()
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<List<Book>> GetAll(CancellationToken cancellationToken = default) =>
            await _context.Books.AsNoTracking().ToListAsync(cancellationToken).ConfigureAwait(false);

        public async Task Update(Book entity, CancellationToken cancellationToken = default)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<List<Book>> GetPage(int pageNumber, int pageLength, CancellationToken cancellationToken = default)
        {
            return await this._context.Books
                .AsNoTracking()
                .Skip(pageLength * (pageNumber - 1))
                .Take(pageLength)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<List<Book>> GetAll(string language, CancellationToken cancellationToken = default) =>
            await _context.Books.ToListAsync(cancellationToken).ConfigureAwait(false);

        public async Task<List<Book>> Find(Func<Book, bool> predicate, string language, CancellationToken cancellationToken = default)
        {
            return await _context
                .Books
                .AsNoTracking()
                .Where(predicate)
                .ToAsyncEnumerable()
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<List<Book>> GetPage(int pageNumber, int pageLength, string language, CancellationToken cancellationToken = default)
        {
            return await this._context.Books
                .AsNoTracking()
                .Skip(pageLength * (pageNumber - 1))
                .Take(pageLength)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
