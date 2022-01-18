using Books.Domain.Core.Account;
using Books.Domain.Interfaces.SQL;
using Books.Infrastructure.Data.DBContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Books.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Create(ApplicationUser entity, CancellationToken cancellationToken = default)
        {
            await _context.ApplicationUsers.AddAsync(entity, cancellationToken).ConfigureAwait(false);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(ApplicationUser entity, CancellationToken cancellationToken = default)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait (false);
        }

        public async Task<List<ApplicationUser>> Find(Func<ApplicationUser, bool> predicate, CancellationToken cancellationToken = default)
        {
            return await _context.ApplicationUsers
                .AsNoTracking()
                .Where(predicate)
                .ToAsyncEnumerable()
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<List<ApplicationUser>> Find(Func<ApplicationUser, bool> predicate, 
            string language, 
            CancellationToken cancellationToken = default)
        {
            return await Find(predicate, cancellationToken).ConfigureAwait(false);
        }

        public async Task<ApplicationUser> Get(Expression<Func<ApplicationUser, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await _context.ApplicationUsers
                .AsNoTracking()
                .SingleOrDefaultAsync(expression, cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<List<ApplicationUser>> GetAll(CancellationToken cancellationToken = default)
        {
            return await _context.ApplicationUsers
                .AsNoTracking()
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<List<ApplicationUser>> GetAll(string language, CancellationToken cancellationToken = default)
        {
            return await GetAll(cancellationToken).ConfigureAwait(false);
        }

        public async Task Update(ApplicationUser entity, CancellationToken cancellationToken = default)
        {
            _context.ApplicationUsers.Update(entity);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
