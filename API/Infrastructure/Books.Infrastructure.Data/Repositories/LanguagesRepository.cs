using Books.Domain.Core.DbEntities;
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
    public class LanguagesRepository : ILanguagesRepository
    {
        private readonly DataContext _context;
        public LanguagesRepository(DataContext context)
        {
            this._context = context;
        }

        public Task Create(Languages entity, CancellationToken cancellationToken = default) => Task.CompletedTask;

        public Task Delete(Languages entity, CancellationToken cancellationToken = default) => Task.CompletedTask;

        public async Task<List<Languages>> Find(Func<Languages, bool> predicate, CancellationToken cancellationToken = default) =>
            await _context.Languages.Where(predicate).ToAsyncEnumerable().ToListAsync(cancellationToken).ConfigureAwait(false);

        public Task<List<Languages>> Find(Func<Languages, bool> predicate, string language, CancellationToken cancellationToken = default) =>
            this.Find(predicate, cancellationToken);

        public async Task<List<Languages>> GetAll(CancellationToken cancellationToken) => 
            await _context.Languages.ToListAsync(cancellationToken).ConfigureAwait(false);

        public Task<List<Languages>> GetAll(string language, CancellationToken cancellationToken = default) => this.GetAll(cancellationToken);

        public async Task<List<string>> LanguageCodes(CancellationToken cancellationToken)
        {
            var languages = await _context.Languages.ToListAsync(cancellationToken).ConfigureAwait(false);
            return languages.Select(language => language.Language).ToList();
        }

        public Task Update(Languages entity, CancellationToken cancellationToken = default) => Task.CompletedTask;
    }
}
