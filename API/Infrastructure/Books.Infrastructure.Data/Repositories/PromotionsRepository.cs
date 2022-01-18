using Books.Domain.Core.DbEntities.PromotionsModels;
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
    public class PromotionsRepository : IPromotionsRepository
    {
        private readonly DataContext _context;
        public PromotionsRepository(DataContext context)
        {
            this._context = context;
        }
        public async Task Create(Promotions entity, CancellationToken cancellationToken = default)
        {
            _context.Promotions.Add(entity);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Promotions entity, CancellationToken cancellationToken = default)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait (false);
        }

        public async Task<List<Promotions>> Find(Func<Promotions, bool> predicate, CancellationToken cancellationToken = default)
        {
            return await _context
                .Promotions
                .Include(x => x.PromotionsTranslates)
                .ThenInclude(x => x.Languages)
                .AsQueryable()
                .Where(predicate)
                .ToAsyncEnumerable()
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<List<Promotions>> Find(Func<Promotions, bool> predicate, string language, CancellationToken cancellationToken = default)
        {
            return await _context
                .Promotions
                .Include(x => x.PromotionsTranslates.Where(x => string.Equals(x.Languages.Language, language)))
                .ThenInclude(x => x.Languages)
                .AsQueryable()
                .Where(predicate)
                .ToAsyncEnumerable()
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<List<Promotions>> GetAll(CancellationToken cancellationToken = default)
        {
            return await _context
                .Promotions
                .Include(x => x.PromotionsTranslates)
                .ThenInclude(x => x.Languages)
                .Include(x => x.PromotionsTranslates)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<List<Promotions>> GetAll(string language, CancellationToken cancellationToken = default)
        {
            return await _context
                .Promotions
                .Include(x => x.PromotionsTranslates.Where(x => string.Equals(x.Languages.Language, language)))
                .ThenInclude(x => x.Languages)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task Update(Promotions entity, CancellationToken cancellationToken = default)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
